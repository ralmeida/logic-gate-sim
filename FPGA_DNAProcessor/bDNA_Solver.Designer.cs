namespace FPGA_DNAProcessor
{
    partial class bDNA_Solver
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTimeToSolve = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.bwSolver = new System.ComponentModel.BackgroundWorker();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusGeneration = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSwapMethod = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMutationMethod = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWriteLogToFile = new System.Windows.Forms.Button();
            this.saveLogFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnOpenGraph = new System.Windows.Forms.Button();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelCullHerd = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbTimeToSolve);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time to Solve the Problem";
            // 
            // lbTimeToSolve
            // 
            this.lbTimeToSolve.AutoSize = true;
            this.lbTimeToSolve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimeToSolve.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimeToSolve.Location = new System.Drawing.Point(3, 16);
            this.lbTimeToSolve.Name = "lbTimeToSolve";
            this.lbTimeToSolve.Padding = new System.Windows.Forms.Padding(10);
            this.lbTimeToSolve.Size = new System.Drawing.Size(694, 76);
            this.lbTimeToSolve.TabIndex = 0;
            this.lbTimeToSolve.Text = "001 Weeks 4 Days 06:34:22";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(631, -1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 5;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // bwSolver
            // 
            this.bwSolver.WorkerReportsProgress = true;
            this.bwSolver.WorkerSupportsCancellation = true;
            this.bwSolver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSolver_DoWork);
            this.bwSolver.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwProcess_ProgressChanged);
            this.bwSolver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwProcess_RunWorkerCompleted);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(13, 137);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(704, 499);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.TabStop = false;
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusGeneration,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelSwapMethod,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelMutationMethod,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelCullHerd});
            this.statusStripMain.Location = new System.Drawing.Point(0, 639);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(734, 22);
            this.statusStripMain.TabIndex = 11;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusGeneration
            // 
            this.toolStripStatusGeneration.Name = "toolStripStatusGeneration";
            this.toolStripStatusGeneration.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusGeneration.Text = "Generation 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(89, 17);
            this.toolStripStatusLabel1.Text = "| Swap Method:";
            // 
            // toolStripStatusLabelSwapMethod
            // 
            this.toolStripStatusLabelSwapMethod.Name = "toolStripStatusLabelSwapMethod";
            this.toolStripStatusLabelSwapMethod.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabelSwapMethod.Text = "__";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel3.Text = "| Mutation Method:";
            // 
            // toolStripStatusLabelMutationMethod
            // 
            this.toolStripStatusLabelMutationMethod.Name = "toolStripStatusLabelMutationMethod";
            this.toolStripStatusLabelMutationMethod.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabelMutationMethod.Text = "___";
            // 
            // btnWriteLogToFile
            // 
            this.btnWriteLogToFile.Location = new System.Drawing.Point(0, -1);
            this.btnWriteLogToFile.Name = "btnWriteLogToFile";
            this.btnWriteLogToFile.Size = new System.Drawing.Size(106, 23);
            this.btnWriteLogToFile.TabIndex = 12;
            this.btnWriteLogToFile.Text = "Write Log to File";
            this.btnWriteLogToFile.UseVisualStyleBackColor = true;
            this.btnWriteLogToFile.Click += new System.EventHandler(this.btnWriteLogToFile_Click);
            // 
            // saveLogFileDialog
            // 
            this.saveLogFileDialog.DefaultExt = "log";
            this.saveLogFileDialog.Filter = "bDNA Solver Log Files|*.log";
            this.saveLogFileDialog.Title = "Save bDNA Solver Log Output";
            // 
            // btnOpenGraph
            // 
            this.btnOpenGraph.Location = new System.Drawing.Point(113, -1);
            this.btnOpenGraph.Name = "btnOpenGraph";
            this.btnOpenGraph.Size = new System.Drawing.Size(124, 23);
            this.btnOpenGraph.TabIndex = 13;
            this.btnOpenGraph.Text = "Open Fitness Graph";
            this.btnOpenGraph.UseVisualStyleBackColor = true;
            this.btnOpenGraph.Click += new System.EventHandler(this.btnOpenGraph_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel2.Text = "| Cull the Herd:";
            // 
            // toolStripStatusLabelCullHerd
            // 
            this.toolStripStatusLabelCullHerd.Name = "toolStripStatusLabelCullHerd";
            this.toolStripStatusLabelCullHerd.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabelCullHerd.Text = "___";
            // 
            // bDNA_Solver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 661);
            this.Controls.Add(this.btnOpenGraph);
            this.Controls.Add(this.btnWriteLogToFile);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(750, 700);
            this.Name = "bDNA_Solver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "bDNA Solver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbTimeToSolve;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timerTick;
        private System.ComponentModel.BackgroundWorker bwSolver;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusGeneration;
        private System.Windows.Forms.Button btnWriteLogToFile;
        private System.Windows.Forms.SaveFileDialog saveLogFileDialog;
        private System.Windows.Forms.Button btnOpenGraph;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSwapMethod;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMutationMethod;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCullHerd;
    }
}