namespace FPGA_Simulator
{
    partial class FPGACellSetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCircut = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numInputCount = new System.Windows.Forms.NumericUpDown();
            this.dgCellOutputs = new System.Windows.Forms.DataGridView();
            this.SetupCellAddressX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SetupCellAddressY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCellSave = new System.Windows.Forms.Button();
            this.btnSaveCellCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgBoardInputs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dgBoardOutputs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numInputCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCellOutputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoardInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoardOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a Circut";
            // 
            // cbCircut
            // 
            this.cbCircut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCircut.FormattingEnabled = true;
            this.cbCircut.Items.AddRange(new object[] {
            "AND",
            "NAND",
            "OR",
            "NOR",
            "XOR",
            "XNOR",
            "NOT"});
            this.cbCircut.Location = new System.Drawing.Point(12, 25);
            this.cbCircut.Name = "cbCircut";
            this.cbCircut.Size = new System.Drawing.Size(326, 21);
            this.cbCircut.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Internal Input Count";
            // 
            // numInputCount
            // 
            this.numInputCount.Location = new System.Drawing.Point(12, 81);
            this.numInputCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numInputCount.Name = "numInputCount";
            this.numInputCount.Size = new System.Drawing.Size(149, 20);
            this.numInputCount.TabIndex = 3;
            this.numInputCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // dgCellOutputs
            // 
            this.dgCellOutputs.AllowUserToResizeRows = false;
            this.dgCellOutputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCellOutputs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgCellOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCellOutputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SetupCellAddressX,
            this.SetupCellAddressY});
            this.dgCellOutputs.Location = new System.Drawing.Point(12, 306);
            this.dgCellOutputs.Name = "dgCellOutputs";
            this.dgCellOutputs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgCellOutputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCellOutputs.Size = new System.Drawing.Size(326, 133);
            this.dgCellOutputs.TabIndex = 6;
            this.dgCellOutputs.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgCellOutputs_RowsRemoved);
            this.dgCellOutputs.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgCellOutputs_UserAddedRow);
            // 
            // SetupCellAddressX
            // 
            this.SetupCellAddressX.HeaderText = "To Row";
            this.SetupCellAddressX.MaxInputLength = 3;
            this.SetupCellAddressX.Name = "SetupCellAddressX";
            // 
            // SetupCellAddressY
            // 
            this.SetupCellAddressY.HeaderText = "To Column";
            this.SetupCellAddressY.MaxInputLength = 3;
            this.SetupCellAddressY.Name = "SetupCellAddressY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Internal Outputs";
            // 
            // btnCellSave
            // 
            this.btnCellSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCellSave.Location = new System.Drawing.Point(263, 613);
            this.btnCellSave.Name = "btnCellSave";
            this.btnCellSave.Size = new System.Drawing.Size(75, 23);
            this.btnCellSave.TabIndex = 8;
            this.btnCellSave.Text = "Save";
            this.btnCellSave.UseVisualStyleBackColor = true;
            this.btnCellSave.Click += new System.EventHandler(this.btnCellSave_Click);
            // 
            // btnSaveCellCancel
            // 
            this.btnSaveCellCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCellCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSaveCellCancel.Location = new System.Drawing.Point(12, 613);
            this.btnSaveCellCancel.Name = "btnSaveCellCancel";
            this.btnSaveCellCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCellCancel.TabIndex = 9;
            this.btnSaveCellCancel.Text = "Cancel";
            this.btnSaveCellCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "External Inputs";
            // 
            // dgBoardInputs
            // 
            this.dgBoardInputs.AllowUserToResizeRows = false;
            this.dgBoardInputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBoardInputs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBoardInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBoardInputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgBoardInputs.Location = new System.Drawing.Point(12, 139);
            this.dgBoardInputs.Name = "dgBoardInputs";
            this.dgBoardInputs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgBoardInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBoardInputs.Size = new System.Drawing.Size(326, 137);
            this.dgBoardInputs.TabIndex = 10;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Input Index";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "External Outputs";
            // 
            // dgBoardOutputs
            // 
            this.dgBoardOutputs.AllowUserToResizeRows = false;
            this.dgBoardOutputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgBoardOutputs.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgBoardOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBoardOutputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dgBoardOutputs.Location = new System.Drawing.Point(12, 467);
            this.dgBoardOutputs.Name = "dgBoardOutputs";
            this.dgBoardOutputs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgBoardOutputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBoardOutputs.Size = new System.Drawing.Size(326, 137);
            this.dgBoardOutputs.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Output Index";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(128, 613);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FPGACellSetupForm
            // 
            this.AcceptButton = this.btnCellSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSaveCellCancel;
            this.ClientSize = new System.Drawing.Size(350, 648);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgBoardOutputs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgBoardInputs);
            this.Controls.Add(this.btnSaveCellCancel);
            this.Controls.Add(this.btnCellSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgCellOutputs);
            this.Controls.Add(this.numInputCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCircut);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPGACellSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FPGA Cell Setup";
            ((System.ComponentModel.ISupportInitialize)(this.numInputCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCellOutputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoardInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoardOutputs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCircut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numInputCount;
        private System.Windows.Forms.DataGridView dgCellOutputs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCellSave;
        private System.Windows.Forms.Button btnSaveCellCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgBoardInputs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetupCellAddressX;
        private System.Windows.Forms.DataGridViewTextBoxColumn SetupCellAddressY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgBoardOutputs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnRemove;
    }
}