using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace FPGA
{
    /// <summary>
    /// FPGA is a mock FPGA Board
    /// </summary>
    public class FPGABoard : List<List<FPGACell>>
    {
        public string ID { get; set; }

        /// <summary>
        /// Value for ref on the size of the Grid
        /// </summary>
        public int SquareSize { get { return rows; } }
        /// <summary>
        /// Total Rows
        /// </summary>
        private int rows = 0;
        /// <summary>
        /// Total Columns
        /// </summary>
        private int columns = 0;

        /// <summary>
        /// 
        /// </summary>
        //protected FPGADataArray data = null;
        /// <summary>
        /// 
        /// </summary>
        //public FPGADataArray Data {  get { return data; } set { data = value; } }
        
        /// <summary>
        /// Total number of available Inputs for the 'board'
        /// </summary>
        public int InputCount { get; private set; }
        /// <summary>
        /// Total number of available Outputs for the 'board'
        /// </summary>
        public int OutputCount { get; private set; }

        /// <summary>
        /// Internal toggle for the Board Ready
        /// </summary>
        public bool Loaded { get; protected set; } = false;
        /// <summary>
        /// FPGA Ready State, will not be ready until it's loaded, and all Cells are done processing
        /// </summary>
        public bool Ready
        {
            get
            {
                bool cellsReady = true;      
                foreach(List<FPGACell> row in Cells)
                {
                    foreach (FPGACell cell in row)
                    {
                        if (!cellsReady) break;
                        cellsReady = cell.Ready;
                    }
                    if (!cellsReady) break;
                }
                return cellsReady; //&& taskCount > 0;
                //return taskCount == 0;
                //return InUseCells.Count == 0;
            }
        }
        
        /// <summary>
        /// Board Input Map, where do the Board Inputs goto
        /// </summary>
        public Dictionary<int, List<FPGA_ADDRESS>> InputMap { get; protected set; } = new Dictionary<int, List<FPGA_ADDRESS>>();
        /// <summary>
        /// Board Output map, where are the Output Maps
        /// </summary>
        public Dictionary<int, FPGABoard_Output> Outputs { get; protected set; } = new Dictionary<int, FPGABoard_Output>();

        /// <summary>
        /// Raw bit data used to build the array config
        /// </summary>
        protected List<List<List<BitArray>>> Data { get; set; }
        /// <summary>
        /// Object data used to represent the bit config
        /// </summary>
        public  List<List<FPGACell>> Cells { get; set; }

        /// <summary>
        /// Tacking Var to hold the input requests
        /// </summary>
        protected Dictionary<FPGA_ADDRESS, int> InputRequestCount { get; set; } = new Dictionary<FPGA_ADDRESS, int>();

        /// <summary>
        /// Basic empty Constructor for Data and not useage
        /// </summary>
        public FPGABoard() { }
        /// <summary>
        /// internal Generic Constructor for raw and file configs to use
        /// </summary>
        /// <param name="inputNum">Number of Inputs for the FPGA Board</param>
        /// <param name="outNum">Number of Outputs for the FPGA Board</param>
        protected FPGABoard(int inputNum = 4, int outNum = 4)
        {
            //Set the Input Count for the Board
            InputCount = inputNum;
            //Set the Output Count for the Board
            OutputCount = outNum;
        }
        /// <summary>
        /// New FPGA Board from Config file
        /// </summary>
        /// <param name="fileName">bDNA Configuration file</param>
        /// <param name="inputs">Number of Inputs for the FPGA Board</param>
        /// <param name="outputs">Number of Outputs for the FPGA Board</param>
        public FPGABoard(string fileName, int inputNum = 4, int outNum = 4) : this(inputNum, outNum)
        {            
            //Load the Config from File
            LoadConfig(fileName);

            //Call the Init method
            Init();

            Loaded = true;
        }
        /// <summary>
        /// New FPGA Board from raw Config
        /// </summary>
        /// <param name="config">raw Config data for FPGA</param>
        /// <param name="inputNum">Number of Inputs for the FPGA Board</param>
        /// <param name="outNum">Number of Outputs for the FPGA Board</param>
        public FPGABoard(List<List<List<BitArray>>> config, int inputNum = 4, int outNum = 4) : this(inputNum, outNum)
        {
            //Load the Config from raw Data
            LoadConfig(config);

            //Call the Init method
            Init();

            Loaded = true;
        }

        /// <summary>
        /// Setup Cells and Outputs for the Board
        /// </summary>
        protected void Init()
        {
            //setup our cells/rows/columns
            Cells = new List<List<FPGACell>>();
            for (int i = 0; i < rows; i++)
            {
                int rowIndx = Cells.Count;
                List<FPGACell> row = new List<FPGACell>();
                for (int j = 0; j < columns; j++)
                {
                    row.Add(new FPGACell(this, new FPGA_ADDRESS() { Row = rowIndx, Column = j }, Data[rowIndx][j]));
                }
                Cells.Add(row);
            }

            for(int i=0; i<OutputCount; i++)
            {
                if(!Outputs.ContainsKey(i))
                    Outputs.Add(i, new FPGABoard_Output(new FPGA_ADDRESS(-3, -3), false));
            }

        }

        /// <summary>
        /// Load FPGA Config from File
        /// </summary>
        /// <param name="fileName"></param>
        protected void LoadConfig(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("FPGA bDNA file could not be found", fileName);

            //Load the bytes for the config
            byte[] configBytesFromFile = File.ReadAllBytes(fileName);

            //total bytes divided by the {n} we use will give us total cells
            double cellCount = configBytesFromFile.Length / FPGAConfig.BytesPerCell;
            //columns and rows will always match as we always force a square
            columns = rows = int.Parse(Math.Sqrt(cellCount).ToString());

            //Set our data to the BitArray table from the file bytes
            Data = configBytesFromFile.ToBitArrayTable(FPGAConfig.BytesPerCell, columns);
        }
        /// <summary>
        /// Load FPGA Config from raw Data
        /// </summary>
        /// <param name="config">Raw Data Config</param>
        protected void LoadConfig(List<List<List<BitArray>>> config)
        {
            if (config == null)
                throw new ArgumentNullException("config", "Config is required to construct a FPGABoard");

            if (config.Count <= 0)
                throw new ArgumentOutOfRangeException("config", "Config must have at least one Row");

            if (config[0].Count <= 0)
                throw new ArgumentOutOfRangeException("config", "Config must have at least one Column");

            if (config[0][0].Count <= 0)
                throw new ArgumentOutOfRangeException("config", "Config must have at least one Cell");

            Data = config;

            double cellCount = Data[0].Count * Data.Count;

            //columns and rows will always match as we always force a square
            columns = rows = int.Parse(Math.Sqrt(cellCount).ToString());
        }

        /// <summary>
        /// Send External "board" inputs
        /// </summary>
        /// <param name="inputs">Array of external input values</param>
        public void SendInputs(bool[] inputs)
        {
            //When we send/re-send inputs we need to make sure we clear the tracker to each connection can make the max number (if needed)
            InputRequestCount = new Dictionary<FPGA_ADDRESS, int>();

            for (int i=0; i<inputs.Length; i++)
            {
                if(InputMap.ContainsKey(i))
                {
                    foreach(FPGA_ADDRESS toAddress in InputMap[i])
                    {
                        //Console.WriteLine("Sending Board Input:[{0}] to {1}", inputs[i], toAddress);
                        SendInput(toAddress, new FPGA_ADDRESS(-1, -1), i, inputs[i]);
                        //Thread.Sleep(10);
                    }
                }
            }

            //Console.Write(".");
            Thread.Sleep(5);

            while (!Ready)
            {
                //Console.Write("-");
                Thread.Sleep(5);
            }

            //Console.WriteLine("{0} Tests", inputs.Length);
        }
        /// <summary>
        /// Send Input to an address
        /// </summary>
        /// <param name="address">Where to send input to</param>
        /// <param name="from">Where is the input from</param>
        /// <param name="fromByte">where from the source is it</param>
        /// <param name="input">incoming value</param>
        public void SendInput(FPGA_ADDRESS address, FPGA_ADDRESS from, int outputPort, bool input)
        {
            //Get our Address Info
            FPGACell cell = GetAddress(address);
            
            //if we have a cell we start a new Thread to process the input
            if (cell != null && !address.Equals(from))
            {
                if (InputRequestCount.ContainsKey(address))
                    InputRequestCount[address]++;
                else
                    InputRequestCount.Add(address, 1);

                if (InputRequestCount[address] > FPGAConfig.InputCountLimit) return;
                else
                {
                    try
                    {
                        //if(from.Column != -1 && from.Row != -1)
                            //File.AppendAllLines(@"C:\apps\io.txt", new string[] { string.Format("{0}: {1}-{2} | {3}-{4}:{5}-({6}) | {7}", ID, address.Column, address.Row, from.Column, from.Row, outputPort, InputRequestCount[address], input) });

                        cell.ProcessInput(from, outputPort, input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("FPGA Board Process Input Error: {0}", ex.Message);
                    }
                }
            }
        }
        
        /// <summary>
        /// Recieve the Board Output from an Address, and set the output.Value 
        /// </summary>
        /// <param name="port">Output Port to use</param>
        /// <param name="from">FPGA_Address the input is from</param>
        /// <param name="input">Input value</param>
        public void RecieveOutput(int port, FPGA_ADDRESS from, bool input)
        {
            if (Outputs.ContainsKey(port) && Outputs[port].Address.CompareTo(from) == 0)
            {
                //Console.WriteLine("Sending [{0}] Board Output from {1}:{2}", input, from, port);
                Outputs[port].Value = input;
            }
        }

        /// <summary>
        /// Internal method to get a Cell
        /// </summary>
        /// <param name="address">Address of the Cell to find</param>
        /// <returns></returns>
        protected FPGACell GetAddress(FPGA_ADDRESS address)
        {
            //validate the address and get the Cell
            if (Cells.Count <= address.Row) return null;
            else if (Cells[address.Row].Count <= address.Column) return null;
            else return Cells[address.Row][address.Column];
        }

        /// <summary>
        /// Register Cell to Input, many Cells can recieve the Input form the board
        /// </summary>
        /// <param name="port">Input Source [0-15]</param>
        /// <param name="address">To Address for the input</param>
        public void RegisterForInput(int port, FPGA_ADDRESS address)
        {
            if (InputMap == null) InputMap = new Dictionary<int, List<FPGA_ADDRESS>>();
            if (!InputMap.ContainsKey(port)) InputMap.Add(port, new List<FPGA_ADDRESS>());

            List<FPGA_ADDRESS> alreadyThere = InputMap[port].FindAll(i => i.CompareTo(address) == 0);
            if (alreadyThere.Count == 0) InputMap[port].Add(address);
        }

        /// <summary>
        /// Register Cell to Output, only one output port can be consumed by anything
        /// </summary>
        /// <param name="port">Output Source [0-15]</param>
        /// <param name="address">From Address for the output</param>
        /// <returns>True - did Register | False - did NOT Register</returns>
        public bool RegisterForOutput(int port, FPGA_ADDRESS address)
        {
            bool didRegister = false;
            if (Outputs == null) Outputs = new Dictionary<int, FPGABoard_Output>();

            //if we have something in the port but it's default, remove it
            if (Outputs.ContainsKey(port) && Outputs[port].Address.Row == -3)
                Outputs.Remove(port);

            //if we have an unassiged port, assign it
            if (!Outputs.ContainsKey(port))
            {
                didRegister = true;
                Outputs.Add(port, new FPGABoard_Output(address, false));
            }
            //else it's already registered, we will only acept Outputs from registerd sources to the port
            return didRegister;
        }
        
        #region Helpers
        
        /// <summary>
        /// Get the byte[] data for the FPGA Configuration
        /// </summary>
        public byte[] Byes
        {
            get
            {
                List<byte> fileBytes = new List<byte>();
                foreach (List<FPGACell> ConfigRows in Cells)
                {
                    foreach (FPGACell ConfigCell in ConfigRows)
                    {
                        fileBytes.AddRange(ConfigCell.Bytes);
                    }
                }

                return fileBytes.ToArray();
            }
        }

        /// <summary>
        /// Simple 2 value Gate test
        /// </summary>
        public void GateTest()
        {
            //Test Gates
            Console.WriteLine(" |-------------------|");
            Console.WriteLine(" |--** GATE TEST **--|");
            Console.WriteLine(" |-------------------|");
            Console.WriteLine("");
            Console.WriteLine("  1) GATE_NOT - [{0}]", GATE.NOT(false) && !GATE.NOT(true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0]-> {0}", GATE.NOT(false));
            Console.WriteLine("     [1]-> {0}", GATE.NOT(true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  2) GATE_AND - [{0}]", !GATE.AND(false, false) && !GATE.AND(true, false) && !GATE.AND(false, true) && GATE.AND(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.AND(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.AND(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.AND(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.AND(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  3) GATE_NAND - [{0}]", GATE.NAND(false, false) && GATE.NAND(true, false) && GATE.NAND(false, true) && !GATE.NAND(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.NAND(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.NAND(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.NAND(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.NAND(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  4) GATE_OR - [{0}]", !GATE.OR(false, false) && GATE.OR(true, false) && GATE.OR(false, true) && GATE.OR(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.OR(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.OR(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.OR(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.OR(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  5) GATE_NOR - [{0}]", GATE.NOR(false, false) && !GATE.NOR(true, false) && !GATE.NOR(false, true) && !GATE.NOR(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.NOR(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.NOR(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.NOR(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.NOR(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  6) GATE_XOR - [{0}]", !GATE.XOR(false, false) && GATE.XOR(true, false) && GATE.XOR(false, true) && !GATE.XOR(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.XOR(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.XOR(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.XOR(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.XOR(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("  7) GATE_XNOR - [{0}]", GATE.XNOR(false, false) && !GATE.XNOR(true, false) && !GATE.XNOR(false, true) && GATE.XNOR(true, true) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0]-> {0}", GATE.XNOR(false, false));
            Console.WriteLine("     [1,0]-> {0}", GATE.XNOR(true, false));
            Console.WriteLine("     [0,1]-> {0}", GATE.XNOR(false, true));
            Console.WriteLine("     [1,1]-> {0}", GATE.XNOR(true, true));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");

            //Additional multi-input gate tests
            bool[] xorVals1 = new bool[] { false, false, false };
            bool[] xorVals2 = new bool[] { true, false, true };
            bool[] xorVals3 = new bool[] { true, true, true };
            Console.WriteLine("  8) GATE_XOR[] - [{0}]",
                !GATE.XOR(xorVals1) && GATE.XOR(xorVals2) && GATE.XOR(xorVals3) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0,0]-> {0}", GATE.XOR(xorVals1));
            Console.WriteLine("     [1,0,1]-> {0}", GATE.XOR(xorVals2));
            Console.WriteLine("     [1,1,1]-> {0}", GATE.XOR(xorVals3));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");

            Console.WriteLine("  9) GATE_XNOR[] - [{0}]",
                GATE.XNOR(xorVals1) && !GATE.XNOR(xorVals2) && !GATE.XNOR(xorVals3) ? "Success" : "Fail");
            Console.WriteLine("");
            Console.WriteLine("     [0,0,0]-> {0}", GATE.XNOR(xorVals1));
            Console.WriteLine("     [1,0,1]-> {0}", GATE.XNOR(xorVals2));
            Console.WriteLine("     [1,1,1]-> {0}", GATE.XNOR(xorVals3));
            Console.WriteLine(" -----------------------------------");
            Console.WriteLine("");
        }
        
        /// <summary>
        /// Simple visual output of the FPGA
        /// </summary>
        public void LogOut()
        {
            string output = string.Empty;

            int rowCount = 0;
            foreach (List<FPGACell> row in Cells)
            {
                int cellCount = 0;
                Console.WriteLine("Row: {0}", rowCount++);

                foreach (FPGACell cell in row)
                {
                    Console.WriteLine("Cell: {0}", cellCount++);
                    Console.WriteLine("{0}", cell);
                    Console.WriteLine("");
                }
            }
        }

        /// <summary>
        /// Generate a Random Config
        /// </summary>
        /// <param name="squareSize">Square Size to Generate</param>
        /// <returns>byte[] data for FileSave</returns>
        public static byte[] RandomConfig(int squareSize)
        {
            List<List<List<BitArray>>> randomConfigData = new List<List<List<BitArray>>>();
            for (int i = 0; i < squareSize; i++)
            {
                randomConfigData.Add(new List<List<BitArray>>());
                for (int j = 0; j < squareSize; j++)
                {
                    randomConfigData[i].Add(new List<BitArray>());

                    //1byte for Circut/InputCount/OutputCount
                    // 4x2byte for Output Mapings
                    // 2byte for Board Input Map
                    // 2byte for Board Output Map
                    for (int k = 0; k < FPGAConfig.BytesPerCell; k++)
                    {
                        randomConfigData[i][j].Add(ByteHelper.RandomBitArray);
                    }
                }
            }

            return randomConfigData.BitArrayTableToByteArray();
        }

        #endregion
    }
}