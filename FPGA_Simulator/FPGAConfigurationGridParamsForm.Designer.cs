namespace FPGA_Simulator
{
    partial class FPGAConfigurationGridParamsForm
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
            this.txtArraySquare = new System.Windows.Forms.TextBox();
            this.btnCancelArraySize = new System.Windows.Forms.Button();
            this.btnOKArraySize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Square Size";
            // 
            // txtArraySquare
            // 
            this.txtArraySquare.Location = new System.Drawing.Point(13, 30);
            this.txtArraySquare.Name = "txtArraySquare";
            this.txtArraySquare.Size = new System.Drawing.Size(155, 20);
            this.txtArraySquare.TabIndex = 1;
            // 
            // btnCancelArraySize
            // 
            this.btnCancelArraySize.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelArraySize.Location = new System.Drawing.Point(12, 71);
            this.btnCancelArraySize.Name = "btnCancelArraySize";
            this.btnCancelArraySize.Size = new System.Drawing.Size(75, 23);
            this.btnCancelArraySize.TabIndex = 2;
            this.btnCancelArraySize.Text = "Cancel";
            this.btnCancelArraySize.UseVisualStyleBackColor = true;
            // 
            // btnOKArraySize
            // 
            this.btnOKArraySize.Location = new System.Drawing.Point(93, 71);
            this.btnOKArraySize.Name = "btnOKArraySize";
            this.btnOKArraySize.Size = new System.Drawing.Size(75, 23);
            this.btnOKArraySize.TabIndex = 3;
            this.btnOKArraySize.Text = "OK";
            this.btnOKArraySize.UseVisualStyleBackColor = true;
            this.btnOKArraySize.Click += new System.EventHandler(this.btnOKArraySize_Click);
            // 
            // FPGAConfigurationGridParamsForm
            // 
            this.AcceptButton = this.btnOKArraySize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelArraySize;
            this.ClientSize = new System.Drawing.Size(186, 105);
            this.Controls.Add(this.btnOKArraySize);
            this.Controls.Add(this.btnCancelArraySize);
            this.Controls.Add(this.txtArraySquare);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPGAConfigurationGridParamsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FPGA Array size";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArraySquare;
        private System.Windows.Forms.Button btnCancelArraySize;
        private System.Windows.Forms.Button btnOKArraySize;
    }
}