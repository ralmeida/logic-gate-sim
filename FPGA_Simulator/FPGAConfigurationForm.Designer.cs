namespace FPGA_Simulator
{
    partial class FPGAConfigurationForm
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
            this.dgFPGAConfig = new System.Windows.Forms.DataGridView();
            this.menuFPGAConfig = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileConfig = new System.Windows.Forms.SaveFileDialog();
            this.statusBarFGPAConfig = new System.Windows.Forms.StatusStrip();
            this.toolStripFPGAConfigStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openConfigToEdit = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgFPGAConfig)).BeginInit();
            this.menuFPGAConfig.SuspendLayout();
            this.statusBarFGPAConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgFPGAConfig
            // 
            this.dgFPGAConfig.AllowUserToAddRows = false;
            this.dgFPGAConfig.AllowUserToDeleteRows = false;
            this.dgFPGAConfig.AllowUserToResizeColumns = false;
            this.dgFPGAConfig.AllowUserToResizeRows = false;
            this.dgFPGAConfig.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFPGAConfig.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgFPGAConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFPGAConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgFPGAConfig.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgFPGAConfig.Location = new System.Drawing.Point(0, 24);
            this.dgFPGAConfig.MultiSelect = false;
            this.dgFPGAConfig.Name = "dgFPGAConfig";
            this.dgFPGAConfig.ReadOnly = true;
            this.dgFPGAConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgFPGAConfig.ShowEditingIcon = false;
            this.dgFPGAConfig.Size = new System.Drawing.Size(531, 408);
            this.dgFPGAConfig.TabIndex = 0;
            this.dgFPGAConfig.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgFPGAConfig_CellDoubleClick);
            // 
            // menuFPGAConfig
            // 
            this.menuFPGAConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.randomToolStripMenuItem});
            this.menuFPGAConfig.Location = new System.Drawing.Point(0, 0);
            this.menuFPGAConfig.Name = "menuFPGAConfig";
            this.menuFPGAConfig.Size = new System.Drawing.Size(531, 24);
            this.menuFPGAConfig.TabIndex = 1;
            this.menuFPGAConfig.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // saveFileConfig
            // 
            this.saveFileConfig.CreatePrompt = true;
            this.saveFileConfig.DefaultExt = "bdna";
            this.saveFileConfig.Filter = "Config Files|*.bDNA";
            this.saveFileConfig.InitialDirectory = "C:\\";
            this.saveFileConfig.Title = "Save FPGA Configuration";
            // 
            // statusBarFGPAConfig
            // 
            this.statusBarFGPAConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFPGAConfigStatus});
            this.statusBarFGPAConfig.Location = new System.Drawing.Point(0, 410);
            this.statusBarFGPAConfig.Name = "statusBarFGPAConfig";
            this.statusBarFGPAConfig.Size = new System.Drawing.Size(531, 22);
            this.statusBarFGPAConfig.TabIndex = 2;
            this.statusBarFGPAConfig.Text = "statusStrip1";
            // 
            // toolStripFPGAConfigStatus
            // 
            this.toolStripFPGAConfigStatus.Name = "toolStripFPGAConfigStatus";
            this.toolStripFPGAConfigStatus.Size = new System.Drawing.Size(246, 17);
            this.toolStripFPGAConfigStatus.Text = "Create or Open bDNA Configuration to begin";
            // 
            // openConfigToEdit
            // 
            this.openConfigToEdit.DefaultExt = "bdna";
            this.openConfigToEdit.Filter = "Config Files|*.bDNA";
            this.openConfigToEdit.Title = "Open FPGA bDNA Configuration to Edit";
            // 
            // FPGAConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 432);
            this.Controls.Add(this.statusBarFGPAConfig);
            this.Controls.Add(this.dgFPGAConfig);
            this.Controls.Add(this.menuFPGAConfig);
            this.MainMenuStrip = this.menuFPGAConfig;
            this.Name = "FPGAConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FPGA Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.dgFPGAConfig)).EndInit();
            this.menuFPGAConfig.ResumeLayout(false);
            this.menuFPGAConfig.PerformLayout();
            this.statusBarFGPAConfig.ResumeLayout(false);
            this.statusBarFGPAConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgFPGAConfig;
        private System.Windows.Forms.MenuStrip menuFPGAConfig;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileConfig;
        private System.Windows.Forms.StatusStrip statusBarFGPAConfig;
        private System.Windows.Forms.ToolStripStatusLabel toolStripFPGAConfigStatus;
        private System.Windows.Forms.OpenFileDialog openConfigToEdit;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
    }
}