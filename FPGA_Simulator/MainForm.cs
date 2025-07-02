using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FPGA;

namespace FPGA_Simulator
{
    public partial class MainForm : Form
    {
        protected string ConfigFileToRun = string.Empty;
        protected int ConfigInputCount { get { return int.Parse(Properties.Settings.Default.DefaultInputCount.ToString()); } }
        protected int ConfigOutputCount { get { return int.Parse(Properties.Settings.Default.DefaultOutputCount.ToString()); } }

        public FPGABoard FPGA_Controller;

        protected string FPGA_TestFile = null;
        string[] TestLines;

        public bool Ready { get { return FPGA_Controller != null; } }

        public List<CheckBox> FPGA_Inputs = new List<CheckBox>();
        public List<CheckBox> FPGA_Outputs = new List<CheckBox>();

        public MainForm()
        {
            InitializeComponent();
            timerTicks.Start();
        }
        
        void FPGASetup(bool userInputs=true)
        {
            //setup our Inputs based on the FPGA_Controller
            FPGA_Controller = new FPGABoard(ConfigFileToRun, ConfigInputCount, ConfigOutputCount);

            Console.Write("Loading FPGA...");
            while (!FPGA_Controller.Loaded) { Console.Write("."); }
            Console.WriteLine("done!");

            #region User Input Setup

            //Clear our Input Controls
            flowPanelInputs.Controls.Clear();
            //Clear our input values list
            FPGA_Inputs.Clear();
            
            //Setup our Input CheckBoxes for User Input
            for (int i = 0; i < FPGA_Controller.InputCount; i++)
            {
                CheckBox newInput = GetBoolInput(string.Format("Input{0}", i));
                FPGA_Inputs.Add(newInput);
                flowPanelInputs.Controls.Add(newInput);
                newInput.Enabled = userInputs;
            }

            #endregion

            #region FPGA Board Output Setup

            //Clear our Output Controls
            flowLayoutOutputs.Controls.Clear();
            //Clear our Output values list
            FPGA_Outputs.Clear();
            //Setup our Output CheckBoxes for User Output Read
            for (int i = 0; i < FPGA_Controller.OutputCount; i++)
            {
                CheckBox newInput = GetBoolInput(string.Format("Output{0}", i));
                newInput.Enabled = false;
                FPGA_Outputs.Add(newInput);
                flowLayoutOutputs.Controls.Add(newInput);
            }

            #endregion
            
            //Send the Inital Inputs
            SendFPGAInputs();
        }

        void SendFPGAInputs()
        {
            bool[] inputs = new bool[FPGA_Inputs.Count];
            for(int i=0; i<FPGA_Inputs.Count; i++) 
            {
                inputs[i] = FPGA_Inputs[i].Checked;
                //Console.WriteLine("Input: {0} Value: {1}", i, inputs[i]);
            }
            FPGA_Controller.SendInputs(inputs);
        }
        
        /// <summary>
        /// Get a CheckBox "Input" for FGPA Board
        /// </summary>
        /// <param name="name">String Name of the Input</param>
        /// <param name="val">Inital Value of the Input</param>
        /// <returns>new CheckBox object</returns>
        private CheckBox GetBoolInput(string name, bool val=false)
        {
            CheckBox newBox = new CheckBox()
            {
                Text = name,
                Checked = val
            };

            newBox.CheckedChanged += FPGAInput_CheckedChanged;

            return newBox;
        }
        
        protected void ProcessTestRun()
        {
            //FPGAPerson personData = GetPersonFromPopulation(testReq.PersonID);

            //Setup FPGA Board
            FPGABoard testBoard = FPGA_Controller;
            Thread.Sleep(50);

            int totalCount = TestLines.Length;
            int totalProcessed = 0;
            int percentComplete = (100 * totalProcessed) / totalCount;

            string inputLine = TestLines[testLine];
            //foreach (string inputLine in TestLines)
            //{
                DateTime timeoutTime = DateTime.Now;
                int intTimeout = 45;
                bool done = false;
                while ((timeoutTime - DateTime.Now).Seconds < intTimeout && !done)
                {
                    percentComplete = (100 * totalProcessed) / totalCount;

                    string[] inputOutputText = inputLine.Split(' ');
                    if (inputOutputText.Length > 1)
                    {
                        //Set the Input values 
                        string inputValue = inputOutputText[0];

                        //Converting Inputs to bool values
                        bool[] inputVals = new bool[inputValue.Length];
                        for (int i = 0; i < inputValue.Length; i++)
                        {
                            inputVals[i] = false;
                            if (inputValue[i] == '1') inputVals[i] = true;

                            FPGA_Inputs[i].Checked = inputVals[i];
                        }

                        Array.Reverse(inputVals);

                        //Send Inputs to the Board
                        testBoard.SendInputs(inputVals);
                        Thread.Sleep(300);

                        //Convert the output
                        string outOutStr = string.Empty;
                        for (int v = testBoard.OutputCount-1; v > -1; v--)
                        {
                            outOutStr += (testBoard.Outputs[v].Value ? "1" : "0");
                        }

                        //Capture the output
                        //personData.Results.Add(outOutStr);

                        Console.WriteLine("IN: {0} -> OUT: {1} -> EXPECTED: {2}", inputValue, outOutStr, inputOutputText[1]);
                    }

                    done = true;
                }
            //}
        }

        void ProcessTest()
        {
            btnTest.Enabled = false;
            btnNextTest.Enabled = false;
            btnPrevTest.Enabled = false;

            ProcessTestRun();

            btnTest.Enabled = true;
            btnNextTest.Enabled = true;
            btnPrevTest.Enabled = true;
        }

        private void UpdateInputOutCounts()
        {
            Properties.Settings.Default.DefaultInputCount = numInputCount.Value;
            Properties.Settings.Default.DefaultOutputCount = numOutputCount.Value;
            Properties.Settings.Default.Save();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Console.WriteLine(FPGA_Controller);
        }
        
        private void timerTicks_Tick(object sender, EventArgs e)
        {
            groupInputs.Enabled = Ready;
            groupOutputs.Enabled = Ready;
            btnReConfigure.Enabled = Ready;

            if (!Ready) return;

            for(int i=0; i<FPGA_Controller.OutputCount; i++)
            {
                FPGA_Outputs[i].Checked = FPGA_Controller.Outputs[i].Value;
            }

            toolStripStatusFPGAState.Text = !FPGA_Controller.Ready ? "Running..." : "Ready";
            //toolStripStatusActiveCells.Text = string.Format("Active Cells: {0}", FPGA_Controller.TaskCount);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            DialogResult rslt = aboutForm.ShowDialog();
        }
        
        private void FPGAInput_CheckedChanged(object sender, EventArgs e)
        {
            SendFPGAInputs();
        }

        private void fPGAConfigurationManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPGAConfigurationForm configForm = new FPGAConfigurationForm();
            //here we need to set or ref to a Board?
            DialogResult rslt = configForm.ShowDialog();
        }
        
        private void btnReConfigure_Click(object sender, EventArgs e)
        {
            UpdateInputOutCounts();
            FPGASetup();
        }

        private void numInputCount_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultInputCount = numInputCount.Value;
            Properties.Settings.Default.Save();
        }

        private void numOutputCount_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultOutputCount = numOutputCount.Value;
            Properties.Settings.Default.Save();
        }

        private void userInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFPGA();
        }

        private void testInputsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFPGA(false);
            DialogResult rslt = openTestToRun.ShowDialog();

            if (rslt == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openTestToRun.FileName))
                {
                    toolStripStatusFPGAState.Text += ", Loading Test file";
                    Console.WriteLine("Test {0} Loaded", openTestToRun.FileName);
                    toolStripStatusFPGAState.Text = "Test loaded, Ready";

                    btnTest.Enabled = true;
                    btnNextTest.Enabled = true;
                    btnPrevTest.Enabled = true;

                    //cbSelectTest.SelectedIndex = 0;
                    //TODO: add this back, by adding a label somewhere -> labelTestFile.Text = Path.GetFileName(openTestToRun.FileName);
                    if (File.Exists(openTestToRun.FileName))
                    {
                        TestLines = File.ReadAllLines(openTestToRun.FileName);
                        if (string.IsNullOrEmpty(TestLines[TestLines.Length - 1]))
                            toolStripStatusFPGAState.Text = (TestLines.Length - 1).ToString();
                        else
                            toolStripStatusFPGAState.Text = TestLines.Length.ToString();
                    }
                }
                else
                    MessageBox.Show("Select a Test file to begin");
            }
        }

        void LoadFPGA(bool userInputs = true)
        {
            DialogResult rslt = openConfigToRun.ShowDialog();

            if (rslt == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openConfigToRun.FileName))
                {
                    toolStripStatusFPGAState.Text = "Loading FPGA bDNA";
                    ConfigFileToRun = openConfigToRun.FileName;
                    FPGASetup(userInputs);
                    Console.WriteLine("Configuration {0} Loaded", openConfigToRun.FileName);
                    toolStripStatusFPGAState.Text = "Configuration loaded, Ready";
                }
                else
                    MessageBox.Show("Select a Configuration file to begin");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ProcessTest();
        }

        private void btnPrevTest_Click(object sender, EventArgs e)
        {
            ProcessTest();
            prevTestLine();
        }

        private void btnNextTest_Click(object sender, EventArgs e)
        {
            ProcessTest();
            nextTestLine();
        }

        int testLine = 0;

        void prevTestLine()
        {
            if (TestLines.LongLength <= 0) return;

            int newTestline = testLine - 1;
            if (newTestline < 0) testLine = TestLines.Length;
            else testLine = newTestline;
        }

        void nextTestLine()
        {
            if (TestLines.LongLength <= 0) return;

            int newTestline = testLine + 1;
            if (newTestline > TestLines.Length) testLine = 0;
            else testLine = newTestline;
        }
    }
}