using System;
using System.IO;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using FPGA;

namespace FPGA_DNAProcessor
{
    public partial class MainForm : Form
    {
        protected bool canUse = true;
        protected bool canRun = true;

        protected string SelectedTestFile = null;

        public MainForm()
        {
            InitializeComponent();

            folderOutput.SelectedPath = Properties.Settings.Default.DefaultOutputDir.Replace("[__NewGuid__]", Guid.NewGuid().ToString());

            cbGeneticSwapMethod.SelectedIndex = Properties.Settings.Default.DefaultGeneticSwap;
            cbMutationMethod.SelectedIndex = Properties.Settings.Default.DefaultGeneticMutation;
            numMutationN.Value = Properties.Settings.Default.DefaultGeneticMutationN;
            cbSelectTest.SelectedIndex = 0;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            canRun = false;
            canUse = false;

            #region Setup Test Request

            int inputCount = (int)numBoardIns.Value;
            int outputCount = (int)numBoardOuts.Value;
            int squareSize = (int)numSquareSize.Value;
            bool resume = cbResume.Checked;
            bool createSubDir = cbCreateSubDir.Checked;
            bool showFitnessGraph = cbShowFitnessGraph.Checked;

            int populationSize = (int)numInitalPopulationCount.Value;

            GenitcSwapMethod selectedSwapMethod = (GenitcSwapMethod)cbGeneticSwapMethod.SelectedIndex;
            GeneticMutationMethod selectedMutationMethod = (GeneticMutationMethod)cbMutationMethod.SelectedIndex;
            int mutationN = (int)numMutationN.Value;

            string TestInputsFile = openFileTest.FileName;

            bDNA_Test_Request req = new bDNA_Test_Request()
            {
                TestInputsFile = TestInputsFile,
                TestInputsFileData = SelectedTestFile,
                OutputDirectory = folderOutput.SelectedPath,
                CreateSubDirectory = createSubDir,
                PopulationSize = populationSize,
                SquareSize = squareSize,
                InputCount = inputCount,
                OutputCount = outputCount,
                Resume = resume,
                ShowFitnessGraph = showFitnessGraph,
                SwapMethod = selectedSwapMethod,
                MutationMethod = selectedMutationMethod,
                MutationN = mutationN,
                CullHerd = cbCullHerd.Checked
            };

            #endregion

            if (!string.IsNullOrEmpty(folderOutput.SelectedPath))
            {
                bDNA_Solver solverDialog = new bDNA_Solver(this, req);
                if (!solverDialog.IsDisposed)
                {
                    solverDialog.Show();
                    solverDialog.BringToFront();
                    WindowState = FormWindowState.Minimized;
                    //solverDialog.Show(this);
                }
            }
        }
        
        private void timerTick_Tick(object sender, EventArgs e)
        {
            labelTestCount.Visible = labelTestCountLB.Visible = !string.IsNullOrEmpty(openFileTest.FileName) || SelectedTestFile != null;
            btnRun.Enabled = labelTestCount.Visible && canRun;
            fileToolStripMenuItem.Enabled = canUse;

            lbDNAOutputDir.Text = folderOutput.SelectedPath;
            Properties.Settings.Default.Save();
        }
        
        public void EnableRun()
        {
            canUse = true;
            canRun = true;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rslt = openFileTest.ShowDialog();

            if (!string.IsNullOrEmpty(openFileTest.FileName))
            {
                cbSelectTest.SelectedIndex = 0;
                labelTestFile.Text = Path.GetFileName(openFileTest.FileName);
                if (File.Exists(openFileTest.FileName))
                {
                    string[] testLines = File.ReadAllLines(openFileTest.FileName);
                    if(string.IsNullOrEmpty(testLines[testLines.Length-1]))                         
                        labelTestCount.Text = (testLines.Length-1).ToString();
                    else
                        labelTestCount.Text = testLines.Length.ToString();
                }
            }
        }
        
        private void btnLoadOutputDir_Click(object sender, EventArgs e)
        {
            DialogResult rslt = folderOutput.ShowDialog();
            if (!string.IsNullOrEmpty(folderOutput.SelectedPath))
            {
                Properties.Settings.Default.DefaultOutputDir = folderOutput.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            folderOutput.SelectedPath = string.Format("C:\\Apps\\{0}", Guid.NewGuid().ToString());
        }

        private void cbShowFitnessGraph_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultShowFitnessGraph = cbShowFitnessGraph.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbMutationMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox me = (ComboBox)sender;
            if (me != null && (me.SelectedIndex == 0 || me.SelectedIndex == 2))
                numMutationN.Visible = lbNumMutationN.Visible = true;
            else 
                numMutationN.Visible = lbNumMutationN.Visible = false;
            
            Properties.Settings.Default.DefaultGeneticMutation = me.SelectedIndex;
            Properties.Settings.Default.Save();
        }
        
        private void cbSelectTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox me = (ToolStripComboBox)sender;
            if (me != null && me.SelectedIndex != 0)
            {
                if (me.SelectedIndex == 1)
                {
                    SelectedTestFile = Properties.Resources._4BitAdderFullTest;
                    string[] lines = SelectedTestFile.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    labelTestFile.Text = me.Text;
                    labelTestCount.Text = lines.Length.ToString();
                    return;
                }
            }
            SelectedTestFile = null;
            labelTestFile.Text = "NONE";
            labelTestCount.Text = "0";
        }

        private void cbCullHerd_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultCullHerd = cbCullHerd.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbGeneticSwapMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox me = (ComboBox)sender;
            Properties.Settings.Default.DefaultGeneticSwap = me.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
