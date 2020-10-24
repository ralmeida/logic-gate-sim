using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using FPGA;

namespace FPGA_Simulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            //Console.WriteLine("args length: {0}", args.Length);
            
            if (args.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else if(args.Length == 5)
            {
                int argInputCount = 1;
                int argOutputCount = 2;
                int argConfigFile = 3;
                int argInputs = 4;

                //input count args[0]
                int inputCount = 0;
                int.TryParse(args[argInputCount], out inputCount);

                //output count args[1]
                int outputCount = 0;
                int.TryParse(args[argOutputCount], out outputCount);

                //Check that the file arg[2] is there
                string fileName = args[argConfigFile];

                Console.WriteLine("Checking for config file: {0}", fileName);
                if (!string.IsNullOrEmpty(fileName))
                {
                    string inputString = args[argInputs];
                    if (string.IsNullOrEmpty(inputString))
                        throw new ArgumentNullException("args[4]", "args[4] [Inputs] is required to run simulation");

                    if (File.Exists(fileName))
                    {
                        FPGABoard testBoard = new FPGABoard(fileName, inputCount, outputCount);
                        Console.Write("Loading FPGA bDNA from [{0}]...", fileName);
                        while (!testBoard.Ready) { Console.Write("."); }
                        Console.WriteLine("done!");

                        Console.Write("Converting {0} Inputs to bool values", inputString.Length);
                        bool[] inputVals = new bool[16];
                        for (int i = 0; i < inputString.Length; i++)
                        {
                            Console.Write(".");
                            inputVals[i] = false;
                            if (inputString[i] == '1') inputVals[i] = true;
                        }
                        Console.WriteLine("done!");

                        //Send Inputs to the Board
                        testBoard.SendInputs(inputVals);
                        Console.Write("Sending inputs: ");
                        for (int v = 0; v < inputVals.Length; v++)
                        {
                            if (v != 0) Console.Write(" | ");
                            Console.Write("[{0}]=> {1}", v, inputVals[v]);
                        }
                        Console.WriteLine(" done!");

                        Console.WriteLine("Waiting 3 seconds...");
                        Thread.Sleep(3000);

                        //int maxTimeWait = 15;
                        int timeWaited = 0;
                        Console.Write("Waiting On Board...");
                        while (!testBoard.Ready) //testBoard.TaskCount > 0 && timeWaited < maxTimeWait)
                        {
                            Console.Write(".");
                            Thread.Sleep(500);
                            timeWaited++;
                        }
                        Console.WriteLine("done!");

                        Console.WriteLine("[OUTPUT_START]");
                        for (int v = 0; v < testBoard.OutputCount; v++)
                        {
                            Console.Write("{0}", testBoard.Outputs[v].Value ? "1" : "0");
                        }
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Could not find file: {0}", fileName);
                    }
                }
            }
        }
    }
}
