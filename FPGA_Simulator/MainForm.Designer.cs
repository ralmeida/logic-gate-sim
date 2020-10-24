namespace FPGA_Simulator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPause = new System.Windows.Forms.Button();
            this.timerTicks = new System.Windows.Forms.Timer(this.components);
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fPGAConfigurationManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusFPGAState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusActiveCells = new System.Windows.Forms.ToolStripStatusLabel();
            this.openConfigToRun = new System.Windows.Forms.OpenFileDialog();
            this.groupOutputs = new System.Windows.Forms.GroupBox();
            this.flowLayoutOutputs = new System.Windows.Forms.FlowLayoutPanel();
            this.groupInputs = new System.Windows.Forms.GroupBox();
            this.flowPanelInputs = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.numInputCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReConfigure = new System.Windows.Forms.Button();
            this.numOutputCount = new System.Windows.Forms.NumericUpDown();
            this.openTestToRun = new System.Windows.Forms.OpenFileDialog();
            this.bwRunTests = new System.ComponentModel.BackgroundWorker();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnPrevTest = new System.Windows.Forms.Button();
            this.btnNextTest = new System.Windows.Forms.Button();
            this.menuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupOutputs.SuspendLayout();
            this.groupInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInputCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(610, 35);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(49, 23);
            this.btnPause.TabIndex = 6;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // timerTicks
            // 
            this.timerTicks.Tick += new System.EventHandler(this.timerTicks_Tick);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.fPGAConfigurationManagerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(674, 24);
            this.menuMain.TabIndex = 8;
            this.menuMain.Text = "Main Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInputsToolStripMenuItem,
            this.testInputsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(204, 20);
            this.fileToolStripMenuItem.Text = "Load and Run bDNA Configuration";
            // 
            // userInputsToolStripMenuItem
            // 
            this.userInputsToolStripMenuItem.Name = "userInputsToolStripMenuItem";
            this.userInputsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.userInputsToolStripMenuItem.Text = "User Inputs";
            this.userInputsToolStripMenuItem.Click += new System.EventHandler(this.userInputsToolStripMenuItem_Click);
            // 
            // testInputsToolStripMenuItem
            // 
            this.testInputsToolStripMenuItem.Name = "testInputsToolStripMenuItem";
            this.testInputsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.testInputsToolStripMenuItem.Text = "Test Inputs";
            this.testInputsToolStripMenuItem.Click += new System.EventHandler(this.testInputsToolStripMenuItem_Click);
            // 
            // fPGAConfigurationManagerToolStripMenuItem
            // 
            this.fPGAConfigurationManagerToolStripMenuItem.Name = "fPGAConfigurationManagerToolStripMenuItem";
            this.fPGAConfigurationManagerToolStripMenuItem.Size = new System.Drawing.Size(178, 20);
            this.fPGAConfigurationManagerToolStripMenuItem.Text = "bDNA Configuration Manager";
            this.fPGAConfigurationManagerToolStripMenuItem.Click += new System.EventHandler(this.fPGAConfigurationManagerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusFPGAState,
            this.toolStripStatusActiveCells});
            this.statusStrip1.Location = new System.Drawing.Point(0, 400);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusFPGAState
            // 
            this.toolStripStatusFPGAState.Name = "toolStripStatusFPGAState";
            this.toolStripStatusFPGAState.Size = new System.Drawing.Size(201, 17);
            this.toolStripStatusFPGAState.Text = "Load a bDNA Configuration to begin";
            // 
            // toolStripStatusActiveCells
            // 
            this.toolStripStatusActiveCells.Name = "toolStripStatusActiveCells";
            this.toolStripStatusActiveCells.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusActiveCells.Text = "Active Cells: 0";
            this.toolStripStatusActiveCells.Visible = false;
            // 
            // openConfigToRun
            // 
            this.openConfigToRun.DefaultExt = "bdna";
            this.openConfigToRun.Filter = "Config Files|*.bdna";
            this.openConfigToRun.Title = "Open FPGA bDNA File";
            // 
            // groupOutputs
            // 
            this.groupOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupOutputs.Controls.Add(this.flowLayoutOutputs);
            this.groupOutputs.Enabled = false;
            this.groupOutputs.Location = new System.Drawing.Point(12, 233);
            this.groupOutputs.Name = "groupOutputs";
            this.groupOutputs.Size = new System.Drawing.Size(650, 164);
            this.groupOutputs.TabIndex = 11;
            this.groupOutputs.TabStop = false;
            this.groupOutputs.Text = "Outputs";
            // 
            // flowLayoutOutputs
            // 
            this.flowLayoutOutputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutOutputs.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutOutputs.Name = "flowLayoutOutputs";
            this.flowLayoutOutputs.Size = new System.Drawing.Size(644, 145);
            this.flowLayoutOutputs.TabIndex = 6;
            // 
            // groupInputs
            // 
            this.groupInputs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupInputs.Controls.Add(this.flowPanelInputs);
            this.groupInputs.Enabled = false;
            this.groupInputs.Location = new System.Drawing.Point(12, 70);
            this.groupInputs.Name = "groupInputs";
            this.groupInputs.Size = new System.Drawing.Size(650, 157);
            this.groupInputs.TabIndex = 12;
            this.groupInputs.TabStop = false;
            this.groupInputs.Text = "Inputs";
            // 
            // flowPanelInputs
            // 
            this.flowPanelInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelInputs.Location = new System.Drawing.Point(3, 16);
            this.flowPanelInputs.Name = "flowPanelInputs";
            this.flowPanelInputs.Size = new System.Drawing.Size(644, 138);
            this.flowPanelInputs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Input Count";
            // 
            // numInputCount
            // 
            this.numInputCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_Simulator.Properties.Settings.Default, "DefaultInputCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numInputCount.Location = new System.Drawing.Point(88, 38);
            this.numInputCount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numInputCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInputCount.Name = "numInputCount";
            this.numInputCount.Size = new System.Drawing.Size(43, 20);
            this.numInputCount.TabIndex = 14;
            this.numInputCount.Value = global::FPGA_Simulator.Properties.Settings.Default.DefaultInputCount;
            this.numInputCount.ValueChanged += new System.EventHandler(this.numInputCount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Output Count";
            // 
            // btnReConfigure
            // 
            this.btnReConfigure.Location = new System.Drawing.Point(274, 35);
            this.btnReConfigure.Name = "btnReConfigure";
            this.btnReConfigure.Size = new System.Drawing.Size(138, 23);
            this.btnReConfigure.TabIndex = 17;
            this.btnReConfigure.Text = "Re-Configure FPGA";
            this.btnReConfigure.UseVisualStyleBackColor = true;
            this.btnReConfigure.Click += new System.EventHandler(this.btnReConfigure_Click);
            // 
            // numOutputCount
            // 
            this.numOutputCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_Simulator.Properties.Settings.Default, "DefaultOutputCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numOutputCount.Location = new System.Drawing.Point(214, 38);
            this.numOutputCount.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numOutputCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOutputCount.Name = "numOutputCount";
            this.numOutputCount.Size = new System.Drawing.Size(40, 20);
            this.numOutputCount.TabIndex = 16;
            this.numOutputCount.Value = global::FPGA_Simulator.Properties.Settings.Default.DefaultOutputCount;
            this.numOutputCount.ValueChanged += new System.EventHandler(this.numOutputCount_ValueChanged);
            // 
            // openTestToRun
            // 
            this.openTestToRun.DefaultExt = "test";
            this.openTestToRun.Filter = "bDNA Test File|*.test";
            this.openTestToRun.Title = "Open bDNA Test File";
            // 
            // bwRunTests
            // 
            this.bwRunTests.WorkerReportsProgress = true;
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(442, 35);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(69, 23);
            this.btnTest.TabIndex = 18;
            this.btnTest.Text = "Begin Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnPrevTest
            // 
            this.btnPrevTest.Enabled = false;
            this.btnPrevTest.Location = new System.Drawing.Point(517, 35);
            this.btnPrevTest.Name = "btnPrevTest";
            this.btnPrevTest.Size = new System.Drawing.Size(37, 23);
            this.btnPrevTest.TabIndex = 19;
            this.btnPrevTest.Text = "<<";
            this.btnPrevTest.UseVisualStyleBackColor = true;
            this.btnPrevTest.Click += new System.EventHandler(this.btnPrevTest_Click);
            // 
            // btnNextTest
            // 
            this.btnNextTest.Enabled = false;
            this.btnNextTest.Location = new System.Drawing.Point(560, 35);
            this.btnNextTest.Name = "btnNextTest";
            this.btnNextTest.Size = new System.Drawing.Size(37, 23);
            this.btnNextTest.TabIndex = 20;
            this.btnNextTest.Text = ">>";
            this.btnNextTest.UseVisualStyleBackColor = true;
            this.btnNextTest.Click += new System.EventHandler(this.btnNextTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 422);
            this.Controls.Add(this.btnNextTest);
            this.Controls.Add(this.btnPrevTest);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnReConfigure);
            this.Controls.Add(this.numOutputCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numInputCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupInputs);
            this.Controls.Add(this.groupOutputs);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "FPGA Simulator";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupOutputs.ResumeLayout(false);
            this.groupInputs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInputCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Timer timerTicks;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFPGAState;
        private System.Windows.Forms.OpenFileDialog openConfigToRun;
        private System.Windows.Forms.GroupBox groupOutputs;
        private System.Windows.Forms.GroupBox groupInputs;
        private System.Windows.Forms.FlowLayoutPanel flowPanelInputs;
        private System.Windows.Forms.ToolStripMenuItem fPGAConfigurationManagerToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutOutputs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numInputCount;
        private System.Windows.Forms.NumericUpDown numOutputCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReConfigure;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusActiveCells;
        private System.Windows.Forms.ToolStripMenuItem userInputsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testInputsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openTestToRun;
        private System.ComponentModel.BackgroundWorker bwRunTests;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnPrevTest;
        private System.Windows.Forms.Button btnNextTest;
    }
}

