using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FPGA;

namespace FPGA_Simulator
{
    public partial class FPGAConfigurationGridParamsForm : Form
    {
        FPGAConfigurationForm ConfigForm;

        public FPGAConfigurationGridParamsForm(FPGAConfigurationForm configForm)
        {
            ConfigForm = configForm;
            InitializeComponent();
        }

        private void btnOKArraySize_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArraySquare.Text))
            {
                int squareSize = 0;
                if (int.TryParse(txtArraySquare.Text, out squareSize))
                {
                    if (squareSize < FPGAConfig.MaxGridSquareSize+1)
                    {
                        if (squareSize > 0)
                        {
                            ConfigForm.SetSquareSize(squareSize);
                            Close();
                        }
                        else
                            MessageBox.Show("Number must be greater than 0");
                    }
                    else
                        MessageBox.Show("Number must be less than 16");
                }
                else
                    MessageBox.Show("Enter a valid number");
            }
            else
                MessageBox.Show("Enter a valid number");
        }
    }
}
