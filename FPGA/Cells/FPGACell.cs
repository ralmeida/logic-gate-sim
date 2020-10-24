using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

/*
    * -------------------------------
    * -  Cell Byte Mapping Layout   -
    * -------------------------------
    * 
    * -------------------------------
    * | 1 - Config
    * -------------------------------
    * -- 0000 [Gate Type]
    * -- 00   [Internal Input Count]
    * --   00 [Internal Output Count]
    * -------------------------------
    * | 2/3 - Output Address 1
    * -------------------------------
    * -- 00000000 [Row]
    * -- 00000000 [Column]
    * -------------------------------
    * | 4/5 - Output Address 2
    * -------------------------------
    * -- 00000000 [Row]
    * -- 00000000 [Column]
    * -------------------------------
    * | 6/7 - Output Address 3
    * -------------------------------
    * -- 00000000 [Row]
    * -- 00000000 [Column]
    * -------------------------------
    * | 8/9 - Output Address 4
    * -------------------------------
    * -- 00000000 [Row]
    * -- 00000000 [Column]
    * -------------------------------
    * | 10/11 - Board Inputs used (16bit) toggles
    * -------------------------------
    * -- 00000000 [0-7]
    * -- 00000000 [8-15]
    * -------------------------------
    * | 12/13 - Board Outputs used (16bit) toggles
    * -------------------------------
    * -- 00000000 [0-7]
    * -- 00000000 [8-15]
    * -------------------------------
    * 
*/
namespace FPGA
{
    /// <summary>
    /// FPGA Board Cell which reperesents a circut in a FPGA Cell
    /// </summary>
    public class FPGACell : List<BitArray>
    {
        /// <summary>
        /// FPGA Board the Cell is on
        /// </summary>
        public FPGABoard Board = null;

        /// <summary>
        /// Address on the FPGA Board
        /// </summary>
        public FPGA_ADDRESS Address { get; protected set; }

        /// <summary>
        /// Circut Type
        /// </summary>
        public FPGAGateType circut { get; set; } = FPGAGateType.NONE;

        /// <summary>
        /// Value of the cell, this may need to change if a cell can have more than one output value, i.e. 'output0'=true and 'output1'=false
        /// </summary>
        public bool Value { get; protected set; }

        /// <summary>
        /// Total Number of Internal Inputs
        /// </summary>
        public int inputNum { get; set; } = 0;
        /// <summary>
        /// Total Number of Internal Outputs
        /// </summary>
        public int outputNum { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public List<FPGACell_Input> Inputs { get; set; } = new List<FPGACell_Input>();
        /// <summary>
        /// 
        /// </summary>
        public List<FPGACell_OutputAddress> Outputs { get; set; } = new List<FPGACell_OutputAddress>();

        public List<int> OutputCounts { get; private set; } = new List<int>();

        /// <summary>
        /// Tracking of the input bit(s) which the cell is listening to
        /// </summary>
        public List<int> BoardInputs { get; set; } = new List<int>();
        /// <summary>
        /// Track of the output bit(s) which the cell successfully registed to (or set for setup)
        /// </summary>
        public List<int> BoardOutputs { get; set; } = new List<int>();

        /// <summary>
        /// Toggle weather the inital signal was sent or not, if not then send the output no matter what
        /// </summary>
        public bool InitalSignal = false;

        /// <summary>
        /// The Ready State of the Cell
        /// </summary>
        public bool Ready { get; protected set; } = true;

        /// <summary>
        /// Empty Data Constructor
        /// </summary>
        public FPGACell() { }
        /// <summary>
        /// Full Use Constructor
        /// </summary>
        /// <param name="board">the FPGA the cell is on</param>
        /// <param name="address">the Address on the FPGA the cell is on</param>
        /// <param name="config">the cell BitArray data</param>
        public FPGACell(FPGABoard board, FPGA_ADDRESS address, List<BitArray> config)
        {
            Board = board;
            Address = address;

            //we are looking for 6 bytes
            if(config.Count == FPGAConfig.BytesPerCell)
            {
                BitArray addressData = config[0];
                if (addressData.Length == 8)
                {
                    #region Circut Guide

                    /*
                    * -----------------------------------------------
                    * First 4 Bits will give us our circut type
                    * -----------------------------------------------
                    *   00 - 0000 - EMPTY
                    *   01 - 0001 - AND
                    *   02 - 0010 - NAND
                    *   03 - 0011 - OR
                    *   04 - 0100 - NOR
                    *   05 - 0101 - XOR
                    *   06 - 0110 - XNOR
                    *   07 - 0111 - NOT
                    *   08 - TBD
                    *   09 - TBD
                    *   10 - TBD
                    *   11 - TBD
                    *   12 - TBD
                    *   13 - TBD
                    *   14 - TBD
                    *   15 - TBD
                    * -----------------------------------------------
                    */

                    #endregion

                    #region Get Config 4bits

                    bool A = addressData[0];
                    bool B = addressData[1];
                    bool C = addressData[2];
                    bool D = addressData[3];
                    int gateTypeInt = NumberHelper.GetIntFromBitArray(new BitArray(new bool[] { D, C, B, A }));

                    #endregion

                    //TODO: add in more circut types, for now we only want 0-7
                    if (gateTypeInt > 0 && gateTypeInt <= 7)
                    {
                        circut = (FPGAGateType)gateTypeInt;

                        #region Get Input / Output 4bits

                        //next we need to get our input and output numbers
                        bool E = addressData[4];
                        bool F = addressData[5];
                        inputNum = NumberHelper.GetIntFromBitArray(new BitArray(new bool[] { F, E }));
                        if (inputNum < 2 && circut != FPGAGateType.NOT) inputNum = 2;

                        bool G = addressData[6];
                        bool H = addressData[7];
                        outputNum = NumberHelper.GetIntFromBitArray(new BitArray(new bool[] { H, G }));

                        #endregion

                        #region Board Input Subscriptions

                        BitArray boardInputMapA = config[1];
                        int ia = 0;
                        for(; ia<boardInputMapA.Count; ia++)
                        {
                            if (boardInputMapA[ia])
                                BoardInputs.Add(ia);
                        }
                        BitArray boardInputMapB = config[2];
                        for (int ib = 0; ib < boardInputMapB.Count; ib++)
                        {
                            if (boardInputMapB[ib])
                                BoardInputs.Add(ib+ia);
                        }

                        //Tell the board to register the requested input ports to this cell
                        RegisterBoardInputs();

                        #endregion

                        #region Board Output Subscriptions

                        BitArray boardOutputMapA = config[3];
                        int oa = 0;
                        for (; oa < boardOutputMapA.Count; oa++)
                        {
                            if (boardOutputMapA[oa])
                                BoardOutputs.Add(oa);
                        }
                        BitArray boardOutputMapB = config[4];
                        for (int ob = 0; ob < boardOutputMapB.Count; ob++)
                        {
                            if (boardOutputMapB[ob])
                                BoardOutputs.Add(ob + oa);
                        }

                        //Try to register each output
                        RegisterBoardOutputs();

                        #endregion

                        if(BoardOutputs.Count == 0 && outputNum == 0) outputNum = 1;

                        #region Internal Output Addresses
                        
                        //max 4 internal outputs
                        for (int i = 4; i < outputNum + 4; i++)
                        {
                            int outputAddressX = -10;
                            int outputAddressY = -10;

                            if (Board.SquareSize <= 16) // FPGAConfig.BytesPerCell == 9)
                            {
                                BitArray outputAryRow = config[i + 1];

                                bool[] Ybools = new bool[] { false, false, false, false };
                                bool[] Xbools = new bool[] { false, false, false, false };

                                /*
                                    Determine what dna to pull based on
                                        the square size of the board
                                        so if the board is only a 4x4 then
                                        we will only pull the first 2 bits
                                */
                                //Board size 2X2 or more
                                if (Board.SquareSize >= 2)
                                {
                                    Ybools[0] = outputAryRow[0];
                                    Xbools[0] = outputAryRow[4];
                                }
                                //Board size 4X4 or more
                                if(Board.SquareSize >= 4)
                                {
                                    Ybools[1] = outputAryRow[1];
                                    Xbools[1] = outputAryRow[5];
                                }
                                //Board size 8X8 or more
                                if(Board.SquareSize >= 8)
                                {
                                    Ybools[2] = outputAryRow[2];
                                    Xbools[2] = outputAryRow[6];
                                }
                                //Board size 16X16 or more
                                if(Board.SquareSize >= 16)
                                {
                                    Ybools[3] = outputAryRow[3];
                                    Xbools[3] = outputAryRow[7];
                                }

                                BitArray outY = new BitArray(Ybools);
                                BitArray outX = new BitArray(Xbools);

                                outputAddressX = NumberHelper.GetIntFromBitArray(outX);
                                outputAddressY = NumberHelper.GetIntFromBitArray(outY);
                            }
                            else if(Board.SquareSize <= 256)
                            {
                                //for each output address we use 2 bytes so we need i and
                                BitArray outputAryRow = config[(i - 1) + i];
                                BitArray outputAryCol = config[(i - 1) + (i - 1) + 2];

                                outputAddressX = NumberHelper.GetIntFromBitArray(outputAryRow);
                                outputAddressY = NumberHelper.GetIntFromBitArray(outputAryCol);
                            }

                            FPGA_ADDRESS outToAddress = new FPGA_ADDRESS() { Row = outputAddressX, Column = outputAddressY };
                            FPGACell_OutputAddress outputAddress = new FPGACell_OutputAddress(outToAddress, i);

                            //add to the Outputs list so we know where to send our signal(s)
                            Outputs.Add(outputAddress);

                            //Init a counter for this output
                            OutputCounts.Add(0);
                        }

                        #endregion
                    }
                    else
                        circut = FPGAGateType.NONE;
                }
            }
        }

        /// <summary>
        /// Atempt to register with Board Inputs
        /// </summary>
        protected void RegisterBoardInputs()
        {
            foreach(int inputPort in BoardInputs)
            {
                Board.RegisterForInput(inputPort, Address);
            }
        }

        /// <summary>
        /// Atempt to register with Board Outputs
        /// </summary>
        protected void RegisterBoardOutputs()
        {
            List<int> notRegisterd = new List<int>();
            foreach (int outputPort in BoardOutputs)
            {
                //if we successfuly registered to the output we need to make sure we send it
                if (!Board.RegisterForOutput(outputPort, Address))
                    notRegisterd.Add(outputPort);
            }

            notRegisterd.ForEach((i) => BoardOutputs.Remove(i));
        }

        /// <summary>
        /// Recieve input from a Source
        /// </summary>
        /// <param name="from">Address of where the input came from</param>
        /// <param name="fromByte">Port the output is using</param>
        /// <param name="input">Value being sent</param>
        public void ProcessInput(FPGA_ADDRESS from, int outPort, bool input)
        {
            if (circut == FPGAGateType.NONE) return;
            if ((int)circut > 7) return;
            
            Ready = false;

            //check to see if we have this source already registerd to an input
            FPGACell_Input inputCell = Inputs.Find(i => i.From.CompareTo(from) == 0 && i.OutputPort == outPort);
            
            //if we don't have any tie and we have inputs.Count < inputNum create a new input ref
            if (inputCell == null)
            {
                if (Inputs.Count > 0)
                    Inputs.RemoveAll((aInput) => aInput.OutputPort == -2);
                
                inputCell = new FPGACell_Input(from, outPort);
                Inputs.Add(inputCell);
            }

            if (inputCell == null)
            {
                Ready = true;
                return;
            }

            //if(inputCell.)

            inputCell.Value = input;

            //Console.WriteLine("Gate {0} at {1} recieved input:[{2}] from {3}:{4}", circut, Address, input, from, outPort);
            //Console.Write(".");

            //File.AppendAllLines(@"C:\apps\io.txt", new string[] { string.Format("{0}: {1}-{2} | {3}-{4}:{5} | {6}", Board.ID, Address.Column, Address.Row, from.Column, from.Row, outPort, input) });

            //once we have set our input we need to update our logic
            UpdateLogic();
        }

        /// <summary>
        /// Update the circut
        /// </summary>
        protected void UpdateLogic()
        {
            bool[] inputValues = new bool[inputNum];
            
            //zero fill any missing inputs
            for(int i = 0; i<inputNum; i++)
            {
                if (Inputs.Count == i)
                    Inputs.Add(new FPGACell_Input());

                inputValues[i] = Inputs[i].Value;
            }

            #region Process Circut

            bool result = false;
            switch (circut)
            {
                case FPGAGateType.AND:
                        result = GATE.AND(inputValues);
                    break;

                case FPGAGateType.NAND:
                        result = GATE.NAND(inputValues);
                    break;

                case FPGAGateType.OR:
                        result = GATE.OR(inputValues);
                    break;

                case FPGAGateType.NOR:
                        result = GATE.NOR(inputValues);
                    break;

                case FPGAGateType.XOR:
                        result = GATE.XOR(inputValues);
                    break;

                case FPGAGateType.XNOR:
                        result = GATE.XNOR(inputValues);
                    break;

                case FPGAGateType.NOT:
                    result = GATE.NOT(Inputs[0].Value);
                    break;

                default:
                    break;
            }

            #endregion

            if (!InitalSignal || Value != result)
            {
                Value = result;
                InitalSignal = true;

                //send the result to each output
                int outputByte = 0;
                foreach (FPGACell_OutputAddress outputAddress in Outputs)
                {
                    if(!outputAddress.To.Equals(Address) && OutputCounts[outputByte] < FPGAConfig.InputCountLimit)
                        Board.SendInput(outputAddress.To, Address, outputByte++, Value);
                }

                foreach(int boardOutputPort in BoardOutputs)
                {
                    Board.RecieveOutput(boardOutputPort, Address, Value);
                }
            }

            Ready = true;
        }

        /// <summary>
        /// Get Bytes of cell Config
        /// </summary>
        public List<byte> Bytes
        {
            get
            {
                List<byte> fileBytes = new List<byte>();

                #region Config

                /*
                 * -------------------------------
                 * | 1 - Config
                 * -------------------------------
                 * -- 0000 [Gate Type]
                 * -- 00   [Input Count]
                 * --   00 [Output Count]
                */
                BitArray configAry = ByteHelper.Empty8BitArray;

                BitArray gateTypeByte = new BitArray(ByteHelper.Encoding.GetBytes(((int)circut).ToString()));
                BitArray inputNumByte = new BitArray(ByteHelper.Encoding.GetBytes(inputNum.ToString()));
                BitArray outputNumByte = new BitArray(ByteHelper.Encoding.GetBytes(outputNum.ToString()));
                
                configAry[7] = gateTypeByte[3];
                configAry[6] = gateTypeByte[2];
                configAry[5] = gateTypeByte[1];
                configAry[4] = gateTypeByte[0];
                configAry[3] = inputNumByte[1];
                configAry[2] = inputNumByte[0];
                configAry[1] = outputNumByte[1];
                configAry[0] = outputNumByte[0];

                fileBytes.Add(configAry.ToByte());

                #endregion

                #region External Input Map

                /*
                 * -------------------------------
                 * | 2/3 - Board Input Map
                 * -------------------------------
                 * -- 00000000 [0-7]
                 * -- 00000000 [8-15]
                */
                BitArray InputMapA = ByteHelper.Empty8BitArray;
                BitArray InputMapB = ByteHelper.Empty8BitArray;

                foreach(int inputPort in BoardInputs)
                {
                    if (inputPort < 8)
                        InputMapA[inputPort] = true;
                    else
                        InputMapB[inputPort-8] = true;
                }

                InputMapA.Reverse();
                InputMapB.Reverse();

                fileBytes.Add(InputMapA.ToByte());
                fileBytes.Add(InputMapB.ToByte());

                #endregion

                #region External Output Map

                /*
                 * -------------------------------
                 * | 4/5 - Board Output Map
                 * -------------------------------
                 * -- 00000000 [0-7]
                 * -- 00000000 [8-15]
                */
                BitArray OutputMapA = ByteHelper.Empty8BitArray;
                BitArray OutputMapB = ByteHelper.Empty8BitArray;

                foreach (int outputPort in BoardOutputs)
                {
                    if (outputPort < 8)
                        OutputMapA[outputPort] = true;
                    else
                        OutputMapB[outputPort - 8] = true;
                }

                OutputMapA.Reverse();
                OutputMapB.Reverse();
                
                fileBytes.Add(OutputMapA.ToByte());
                fileBytes.Add(OutputMapB.ToByte());

                #endregion

                #region Output Addresses

                /*
                 * -------------------------------
                 * | {n}/{n}+5 - Output Address {n}+1
                 * -------------------------------
                 * -- 00000000 [Row]
                 * -- 00000000 [Column]
                */
                for (int i = 0; i < Outputs.Count; i++)
                {
                    if (FPGAConfig.BytesPerCell == 9)
                    {
                        byte RowByte = (byte)Outputs[i].To.Row,
                             ColumnByte = (byte)Outputs[i].To.Column;

                        BitArray outputAddressRow = RowByte.ToBitArray();
                        BitArray outputAddressColumn = ColumnByte.ToBitArray();
                        BitArray outputAddressAry = new BitArray(new bool[] { outputAddressRow[4], outputAddressRow[5], outputAddressRow[6], outputAddressRow[7],
                                                                              outputAddressColumn[4], outputAddressColumn[5], outputAddressColumn[6], outputAddressColumn[7]});
                        fileBytes.Add(outputAddressAry.ToByte());
                    }
                    else
                    {
                        byte RowByte = (byte)Outputs[i].To.Row,
                             ColumnByte = (byte)Outputs[i].To.Column;

                        BitArray outputAddressRow = RowByte.ToBitArray();
                        fileBytes.Add(outputAddressRow.ToByte());

                        BitArray outputAddressColumn = ColumnByte.ToBitArray();
                        fileBytes.Add(outputAddressColumn.ToByte());
                    }
                }
                //zero fill the rest of the output bytes
                for (int i = Outputs.Count; i < FPGAConfig.MaxInternalOutputs; i++)
                {
                    BitArray outputAddressAry = ByteHelper.Empty8BitArray;
                    fileBytes.Add(outputAddressAry.ToByte());

                    if (FPGAConfig.BytesPerCell != 9)
                        fileBytes.Add(outputAddressAry.ToByte());
                }

                #endregion

                return fileBytes;
            }
        }

        /// <summary>
        /// Easy read value for a Cell
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(@" Address [ Row: {0}, Column: {1} ] Circut: [ {2} ] Inputs:  [ {3} ] Outputs: [ {4} ]", 
                                                    Address.Row, Address.Column, circut, inputNum, outputNum);
        }
    }
}
