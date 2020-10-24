namespace FPGA_DNAProcessor
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
            this.btnRun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabInitalTests = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numMutationN = new System.Windows.Forms.NumericUpDown();
            this.lbNumMutationN = new System.Windows.Forms.Label();
            this.cbMutationMethod = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGeneticSwapMethod = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCreateSubDir = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbResume = new System.Windows.Forms.CheckBox();
            this.lbDNAOutputDir = new System.Windows.Forms.Label();
            this.btnLoadDNADir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCullHerd = new System.Windows.Forms.CheckBox();
            this.labelTestCount = new System.Windows.Forms.Label();
            this.labelTestCountLB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTestFile = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSelectTest = new System.Windows.Forms.ToolStripComboBox();
            this.openFileTest = new System.Windows.Forms.OpenFileDialog();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.folderOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.cbShowFitnessGraph = new System.Windows.Forms.CheckBox();
            this.numInitalPopulationCount = new System.Windows.Forms.NumericUpDown();
            this.numSquareSize = new System.Windows.Forms.NumericUpDown();
            this.numBoardOuts = new System.Windows.Forms.NumericUpDown();
            this.numBoardIns = new System.Windows.Forms.NumericUpDown();
            this.tabInitalTests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationN)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitalPopulationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSquareSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOuts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIns)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRun.Location = new System.Drawing.Point(0, 50);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(810, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Board Inputs";
            // 
            // tabInitalTests
            // 
            this.tabInitalTests.Controls.Add(this.splitContainer1);
            this.tabInitalTests.Location = new System.Drawing.Point(4, 22);
            this.tabInitalTests.Name = "tabInitalTests";
            this.tabInitalTests.Padding = new System.Windows.Forms.Padding(3);
            this.tabInitalTests.Size = new System.Drawing.Size(816, 258);
            this.tabInitalTests.TabIndex = 1;
            this.tabInitalTests.Text = "Inital Tests";
            this.tabInitalTests.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbCullHerd);
            this.splitContainer1.Panel2.Controls.Add(this.btnRun);
            this.splitContainer1.Panel2.Controls.Add(this.labelTestCount);
            this.splitContainer1.Panel2.Controls.Add(this.labelTestCountLB);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.labelTestFile);
            this.splitContainer1.Size = new System.Drawing.Size(810, 252);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.numMutationN);
            this.groupBox3.Controls.Add(this.lbNumMutationN);
            this.groupBox3.Controls.Add(this.cbMutationMethod);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbGeneticSwapMethod);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(608, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 165);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Genetic Setup";
            // 
            // numMutationN
            // 
            this.numMutationN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMutationN.Location = new System.Drawing.Point(86, 124);
            this.numMutationN.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.numMutationN.Name = "numMutationN";
            this.numMutationN.Size = new System.Drawing.Size(90, 20);
            this.numMutationN.TabIndex = 21;
            this.numMutationN.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // lbNumMutationN
            // 
            this.lbNumMutationN.AutoSize = true;
            this.lbNumMutationN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumMutationN.Location = new System.Drawing.Point(15, 127);
            this.lbNumMutationN.Name = "lbNumMutationN";
            this.lbNumMutationN.Size = new System.Drawing.Size(65, 13);
            this.lbNumMutationN.TabIndex = 20;
            this.lbNumMutationN.Text = "Mutation {n}";
            // 
            // cbMutationMethod
            // 
            this.cbMutationMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMutationMethod.FormattingEnabled = true;
            this.cbMutationMethod.Items.AddRange(new object[] {
            "Out of {n} [Cell]",
            "R-Method",
            "Out fo {n} [Byte]"});
            this.cbMutationMethod.Location = new System.Drawing.Point(15, 95);
            this.cbMutationMethod.Name = "cbMutationMethod";
            this.cbMutationMethod.Size = new System.Drawing.Size(161, 23);
            this.cbMutationMethod.TabIndex = 19;
            this.cbMutationMethod.SelectedIndexChanged += new System.EventHandler(this.cbMutationMethod_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Genetic Mutation Method";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Genetic Swap Method";
            // 
            // cbGeneticSwapMethod
            // 
            this.cbGeneticSwapMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGeneticSwapMethod.FormattingEnabled = true;
            this.cbGeneticSwapMethod.Items.AddRange(new object[] {
            "Two Bit",
            "Four Bit",
            "Kenneth\'s Mix"});
            this.cbGeneticSwapMethod.Location = new System.Drawing.Point(15, 42);
            this.cbGeneticSwapMethod.Name = "cbGeneticSwapMethod";
            this.cbGeneticSwapMethod.Size = new System.Drawing.Size(161, 23);
            this.cbGeneticSwapMethod.TabIndex = 16;
            this.cbGeneticSwapMethod.SelectedIndexChanged += new System.EventHandler(this.cbGeneticSwapMethod_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.cbShowFitnessGraph);
            this.groupBox2.Controls.Add(this.btnNew);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbCreateSubDir);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbResume);
            this.groupBox2.Controls.Add(this.lbDNAOutputDir);
            this.groupBox2.Controls.Add(this.btnLoadDNADir);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.numInitalPopulationCount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(124, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 164);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Setup";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(134, 60);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(34, 19);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "This will create a directory within the Output Directory for this Test";
            this.label8.Visible = false;
            // 
            // cbCreateSubDir
            // 
            this.cbCreateSubDir.AutoSize = true;
            this.cbCreateSubDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCreateSubDir.Location = new System.Drawing.Point(11, 116);
            this.cbCreateSubDir.Name = "cbCreateSubDir";
            this.cbCreateSubDir.Size = new System.Drawing.Size(188, 17);
            this.cbCreateSubDir.TabIndex = 12;
            this.cbCreateSubDir.Text = "Create a SubDirectory for this Test";
            this.cbCreateSubDir.UseVisualStyleBackColor = true;
            this.cbCreateSubDir.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "OR";
            // 
            // cbResume
            // 
            this.cbResume.AutoSize = true;
            this.cbResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbResume.Location = new System.Drawing.Point(272, 31);
            this.cbResume.Name = "cbResume";
            this.cbResume.Size = new System.Drawing.Size(171, 17);
            this.cbResume.TabIndex = 10;
            this.cbResume.Text = "Resume From Output Directory";
            this.cbResume.UseVisualStyleBackColor = true;
            // 
            // lbDNAOutputDir
            // 
            this.lbDNAOutputDir.AutoSize = true;
            this.lbDNAOutputDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDNAOutputDir.Location = new System.Drawing.Point(15, 83);
            this.lbDNAOutputDir.Name = "lbDNAOutputDir";
            this.lbDNAOutputDir.Size = new System.Drawing.Size(42, 13);
            this.lbDNAOutputDir.TabIndex = 7;
            this.lbDNAOutputDir.Text = "NONE";
            // 
            // btnLoadDNADir
            // 
            this.btnLoadDNADir.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDNADir.Location = new System.Drawing.Point(94, 60);
            this.btnLoadDNADir.Name = "btnLoadDNADir";
            this.btnLoadDNADir.Size = new System.Drawing.Size(34, 19);
            this.btnLoadDNADir.TabIndex = 9;
            this.btnLoadDNADir.Text = "Load";
            this.btnLoadDNADir.UseVisualStyleBackColor = true;
            this.btnLoadDNADir.Click += new System.EventHandler(this.btnLoadOutputDir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Output Directory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Inital Population Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.numSquareSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numBoardOuts);
            this.groupBox1.Controls.Add(this.numBoardIns);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FGPA Setup";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Board Size Sq";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Board Outputs";
            // 
            // cbCullHerd
            // 
            this.cbCullHerd.AutoSize = true;
            this.cbCullHerd.Location = new System.Drawing.Point(623, 7);
            this.cbCullHerd.Name = "cbCullHerd";
            this.cbCullHerd.Size = new System.Drawing.Size(87, 17);
            this.cbCullHerd.TabIndex = 7;
            this.cbCullHerd.Text = "Cull the Herd";
            this.cbCullHerd.UseVisualStyleBackColor = true;
            this.cbCullHerd.CheckedChanged += new System.EventHandler(this.cbCullHerd_CheckedChanged);
            // 
            // labelTestCount
            // 
            this.labelTestCount.AutoSize = true;
            this.labelTestCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestCount.Location = new System.Drawing.Point(77, 28);
            this.labelTestCount.Name = "labelTestCount";
            this.labelTestCount.Size = new System.Drawing.Size(14, 13);
            this.labelTestCount.TabIndex = 6;
            this.labelTestCount.Text = "0";
            this.labelTestCount.Visible = false;
            // 
            // labelTestCountLB
            // 
            this.labelTestCountLB.AutoSize = true;
            this.labelTestCountLB.Location = new System.Drawing.Point(12, 28);
            this.labelTestCountLB.Name = "labelTestCountLB";
            this.labelTestCountLB.Size = new System.Drawing.Size(59, 13);
            this.labelTestCountLB.TabIndex = 5;
            this.labelTestCountLB.Text = "Test Count";
            this.labelTestCountLB.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Test Loaded";
            // 
            // labelTestFile
            // 
            this.labelTestFile.AutoSize = true;
            this.labelTestFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTestFile.Location = new System.Drawing.Point(75, 8);
            this.labelTestFile.Name = "labelTestFile";
            this.labelTestFile.Size = new System.Drawing.Size(42, 13);
            this.labelTestFile.TabIndex = 4;
            this.labelTestFile.Text = "NONE";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInitalTests);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 284);
            this.tabControl1.TabIndex = 2;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.cbSelectTest});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(824, 27);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.fileToolStripMenuItem.Text = "Load Test";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // cbSelectTest
            // 
            this.cbSelectTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectTest.Items.AddRange(new object[] {
            "-- or Select a Test",
            "4Bit Adder Full Test"});
            this.cbSelectTest.Name = "cbSelectTest";
            this.cbSelectTest.Size = new System.Drawing.Size(200, 23);
            this.cbSelectTest.SelectedIndexChanged += new System.EventHandler(this.cbSelectTest_SelectedIndexChanged);
            // 
            // openFileTest
            // 
            this.openFileTest.DefaultExt = "test";
            this.openFileTest.Filter = "bDNA Test File|*.test";
            this.openFileTest.InitialDirectory = "C:\\Apps";
            this.openFileTest.Title = "Open bDNA Test File";
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // cbShowFitnessGraph
            // 
            this.cbShowFitnessGraph.AutoSize = true;
            this.cbShowFitnessGraph.Checked = global::FPGA_DNAProcessor.Properties.Settings.Default.DefaultShowFitnessGraph;
            this.cbShowFitnessGraph.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::FPGA_DNAProcessor.Properties.Settings.Default, "DefaultShowFitnessGraph", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbShowFitnessGraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShowFitnessGraph.Location = new System.Drawing.Point(324, 116);
            this.cbShowFitnessGraph.Name = "cbShowFitnessGraph";
            this.cbShowFitnessGraph.Size = new System.Drawing.Size(146, 17);
            this.cbShowFitnessGraph.TabIndex = 15;
            this.cbShowFitnessGraph.Text = "Auto Show Fitness Graph";
            this.cbShowFitnessGraph.UseVisualStyleBackColor = true;
            this.cbShowFitnessGraph.CheckedChanged += new System.EventHandler(this.cbShowFitnessGraph_CheckedChanged);
            // 
            // numInitalPopulationCount
            // 
            this.numInitalPopulationCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_DNAProcessor.Properties.Settings.Default, "DefaultInitalPopulation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numInitalPopulationCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInitalPopulationCount.Location = new System.Drawing.Point(130, 30);
            this.numInitalPopulationCount.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numInitalPopulationCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInitalPopulationCount.Name = "numInitalPopulationCount";
            this.numInitalPopulationCount.Size = new System.Drawing.Size(82, 20);
            this.numInitalPopulationCount.TabIndex = 5;
            this.numInitalPopulationCount.Value = global::FPGA_DNAProcessor.Properties.Settings.Default.DefaultInitalPopulation;
            // 
            // numSquareSize
            // 
            this.numSquareSize.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_DNAProcessor.Properties.Settings.Default, "DefaultFPGASquareSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numSquareSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numSquareSize.Location = new System.Drawing.Point(19, 117);
            this.numSquareSize.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numSquareSize.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSquareSize.Name = "numSquareSize";
            this.numSquareSize.Size = new System.Drawing.Size(50, 20);
            this.numSquareSize.TabIndex = 6;
            this.numSquareSize.Value = global::FPGA_DNAProcessor.Properties.Settings.Default.DefaultFPGASquareSize;
            // 
            // numBoardOuts
            // 
            this.numBoardOuts.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_DNAProcessor.Properties.Settings.Default, "DefaultFPGAOutCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numBoardOuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBoardOuts.Location = new System.Drawing.Point(19, 78);
            this.numBoardOuts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardOuts.Name = "numBoardOuts";
            this.numBoardOuts.Size = new System.Drawing.Size(50, 20);
            this.numBoardOuts.TabIndex = 4;
            this.numBoardOuts.Value = global::FPGA_DNAProcessor.Properties.Settings.Default.DefaultFPGAOutCount;
            // 
            // numBoardIns
            // 
            this.numBoardIns.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::FPGA_DNAProcessor.Properties.Settings.Default, "DefaultFPGAInCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numBoardIns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBoardIns.Location = new System.Drawing.Point(19, 39);
            this.numBoardIns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBoardIns.Name = "numBoardIns";
            this.numBoardIns.Size = new System.Drawing.Size(50, 20);
            this.numBoardIns.TabIndex = 3;
            this.numBoardIns.Value = global::FPGA_DNAProcessor.Properties.Settings.Default.DefaultFPGAInCount;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 311);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(840, 350);
            this.MinimumSize = new System.Drawing.Size(840, 350);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bDNA Processor";
            this.tabInitalTests.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMutationN)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInitalPopulationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSquareSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardOuts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardIns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabInitalTests;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBoardOuts;
        private System.Windows.Forms.NumericUpDown numBoardIns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTestFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numInitalPopulationCount;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileTest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSquareSize;
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Label labelTestCountLB;
        private System.Windows.Forms.Label labelTestCount;
        private System.Windows.Forms.FolderBrowserDialog folderOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbDNAOutputDir;
        private System.Windows.Forms.Button btnLoadDNADir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbResume;
        private System.Windows.Forms.CheckBox cbCreateSubDir;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckBox cbShowFitnessGraph;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbGeneticSwapMethod;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numMutationN;
        private System.Windows.Forms.Label lbNumMutationN;
        private System.Windows.Forms.ComboBox cbMutationMethod;
        private System.Windows.Forms.ToolStripComboBox cbSelectTest;
        private System.Windows.Forms.CheckBox cbCullHerd;
    }
}

