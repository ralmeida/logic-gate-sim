using System;
using System.Collections.Generic;
using System.Windows.Forms;

using FPGA;

namespace FPGA_Simulator
{
    public partial class FPGACellSetupForm : Form
    {
        protected FPGAConfigurationForm ConfigForm;
        protected FPGACell cell;
        int row = -1;
        int col = -1;

        public FPGACellSetupForm(FPGAConfigurationForm configForm, int inRow, int inCol)
        {
            ConfigForm = configForm;
            row = inRow;
            col = inCol;

            InitializeComponent();

            cell = configForm.ConfigData[row][col];
            if (cell != null && (int)cell.circut > 0 && (int)cell.circut < 8)
            {
                cbCircut.SelectedIndex = (int)cell.circut - 1;
                numInputCount.Value = cell.inputNum;
                //numOutputCount.Value = cell.outputNum;

                foreach(FPGACell_OutputAddress output in cell.Outputs)
                {
                    dgCellOutputs.Rows.Add(new object[] { output.To.Row, output.To.Column });
                }

                foreach(int boardInputPort in cell.BoardInputs)
                {
                    dgBoardInputs.Rows.Add(new object[] { boardInputPort });
                }

                foreach (int boardOutputPort in cell.BoardOutputs)
                {
                    dgBoardOutputs.Rows.Add(new object[] { boardOutputPort });
                }
            }
        }

        private void btnCellSave_Click(object sender, EventArgs e)
        {
            FPGACell cell = ConfigForm.ConfigData[row][col];

            cell.circut = (FPGAGateType)cbCircut.SelectedIndex + 1;
            string cellLabel = " - ", cellLabelDefault = " - ";

            if (cell.circut != FPGAGateType.NONE || (int)cell.circut < 8)
            {
                cell.inputNum = (int)numInputCount.Value;
                cell.outputNum = 0;
                cellLabel = cbCircut.Text;

                //Get the outputs and set them up in the object
                cell.Outputs = new List<FPGACell_OutputAddress>();
                int outPortOn = 1;
                foreach (DataGridViewRow row in dgCellOutputs.Rows)
                {
                    var outToRowVal = row.Cells[0].Value;
                    var outToColVal = row.Cells[1].Value;

                    int outToRow = -1,
                        outToCol = -1;

                    if (outToRowVal != null && outToColVal != null)
                    {
                        if (int.TryParse(outToRowVal.ToString(), out outToRow) &&
                            int.TryParse(outToColVal.ToString(), out outToCol))
                        {
                            cell.Outputs.Add(new FPGACell_OutputAddress(new FPGA_ADDRESS(outToRow, outToCol), outPortOn++));
                            cell.outputNum++;
                        }
                    }
                }

                #region Board Inputs

                cell.BoardInputs = new List<int>();
                foreach (DataGridViewRow boardInputRow in dgBoardInputs.Rows)
                {
                    var inCellValue = boardInputRow.Cells[0].Value;
                    if (inCellValue != null)
                    {
                        int boardInputPort = 0;
                        if (int.TryParse(inCellValue.ToString(), out boardInputPort))
                            cell.BoardInputs.Add(boardInputPort);
                    }
                }

                #endregion

                #region Board Outputs

                cell.BoardOutputs = new List<int>();
                foreach (DataGridViewRow boardOutputRow in dgBoardOutputs.Rows)
                {
                    var outCellValue = boardOutputRow.Cells[0].Value;
                    if (outCellValue != null)
                    {
                        int boardOutputPort = 0;
                        if (int.TryParse(outCellValue.ToString(), out boardOutputPort))
                            cell.BoardOutputs.Add(boardOutputPort);
                    }
                }

                #endregion
            }

            bool doClose = true;
            if(cell.Outputs.Count != cell.outputNum)
            {
                MessageBox.Show("You your Output Number must match your Output Maps", "Check your Outputs", MessageBoxButtons.OK);
                cell = new FPGACell();
                cellLabel = cellLabelDefault;
                doClose = false;
            }

            ConfigForm.SetCell(row, col, cellLabel);

            if(doClose)
            {
                this.Close();
            }
        }
        
        private void dgCellOutputs_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //if (e.RowCount < (int)numOutputCount.Value)
                //dgCellOutputs.AllowUserToAddRows = true;
        }

        private void dgCellOutputs_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //if (e.Row.Index+1 == (int)numOutputCount.Value)
                //dgCellOutputs.AllowUserToAddRows = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult rslt = MessageBox.Show("Are you sure you want to remove this Cell?", "Remove FPGA Cell?", MessageBoxButtons.OKCancel);
            if(rslt == DialogResult.OK)
            {
                ConfigForm.ConfigData[row][col] = new FPGACell();
                ConfigForm.SetCell(row, col, " - ");
                Close();
            }
        }
    }
}
