using System;
using System.Collections;
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
    public partial class FPGAConfigurationForm : Form
    {
        protected int SquareSize = 0;
        public int Rows = 0;
        public int Columns = 0;

        FPGABoard FPGA_Board;
        public List<List<FPGACell>> ConfigData { get { if (FPGA_Board == null) FPGA_Board = new FPGABoard(); return FPGA_Board.Cells; } }

        public FPGAConfigurationForm()
        {
            FPGA_Board = new FPGABoard();
            InitializeComponent();
        }
        
        #region Grid Setup

        protected void SetupGrid()
        {
            Rows = Columns = SquareSize;

            dgFPGAConfig.Columns.Clear();

            FPGA_Board.Cells = new List<List<FPGACell>>();
            for (int x = 0; x < Columns; x++)
            {
                dgFPGAConfig.Columns.Add(x.ToString(), x.ToString());
            }

            dgFPGAConfig.Rows.Clear();
        }

        protected void SetupNewGrid()
        {
            SetupGrid();

            for (int i=0; i<Rows; i++)
            {
                FPGA_Board.Cells.Add(new List<FPGACell>());
                object[] colData = new object[Columns];
                for (int x=0; x<Columns; x++)
                {
                    FPGA_Board.Cells[i].Add(new FPGACell());
                    colData[x] = " - ";
                }
                dgFPGAConfig.Rows.Add(colData);
            }

            toolStripFPGAConfigStatus.Text = "New bDNA Created, Ready";
        }

        protected void SetupLoadGrid(List<List<FPGACell>> data)
        {
            SetupGrid();

            for (int i = 0; i < Rows; i++)
            {
                FPGA_Board.Cells.Add(new List<FPGACell>());
                object[] colData = new object[Columns];
                for (int x = 0; x < Columns; x++)
                {
                    FPGA_Board.Cells[i].Add(data[i][x]);
                    if (data[i][x].circut != FPGAGateType.NONE && (int)data[i][x].circut < 8)
                        colData[x] = data[i][x].circut.ToString();
                    else
                        colData[x] = " - ";
                }
                dgFPGAConfig.Rows.Add(colData);
            }
        }

        #endregion

        public void SetCell(int row, int col, string text)
        {
            dgFPGAConfig.Rows[row].Cells[col].Value = text;
        }

        public void SetSquareSize(int size)
        {
            SquareSize = size;
        }

        protected bool SaveFile(bool forceWindow = false, byte[] fileData = null)
        {
            bool fileSaved = false;
            DialogResult rslt = DialogResult.None;

            if (forceWindow || string.IsNullOrEmpty(saveFileConfig.FileName))
                rslt = saveFileConfig.ShowDialog();

            if (rslt != DialogResult.Cancel && rslt != DialogResult.Abort)
            {
                if (!string.IsNullOrEmpty(saveFileConfig.FileName))
                {
                    if(fileData == null) fileData = FPGA_Board.Byes;
                    if (FileHelper.ByteArrayToFile(saveFileConfig.FileName, fileData))
                    {
                        fileSaved = true;
                        toolStripFPGAConfigStatus.Text = string.Format("Saved: {0} bytes, Ready", fileData.Length);
                    }
                    else toolStripFPGAConfigStatus.Text = "Error Saving file, Ready";
                }
                else
                    MessageBox.Show("Enter a FileName");
            }

            return fileSaved;
        }

        protected void LoadConfigFile(string fileName)
        {
            FPGABoard editFPGA = new FPGABoard(fileName);
            SquareSize = editFPGA.SquareSize;
            SetupLoadGrid(editFPGA.Cells);
        }

        private void dgFPGAConfig_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FPGACellSetupForm cellSetupForm = new FPGACellSetupForm(this, e.RowIndex, e.ColumnIndex);
            DialogResult rslt = cellSetupForm.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rslt = openConfigToEdit.ShowDialog();

            if(rslt == DialogResult.OK)
            {
                if(!string.IsNullOrEmpty(openConfigToEdit.FileName))
                {
                    LoadConfigFile(openConfigToEdit.FileName);
                    saveFileConfig.FileName = openConfigToEdit.FileName;
                    toolStripFPGAConfigStatus.Text = "Configuration loaded, Ready";
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPGAConfigurationGridParamsForm configParamsForm = new FPGAConfigurationGridParamsForm(this);
            DialogResult rsltarams = configParamsForm.ShowDialog();

            if (SquareSize > 0)
            {
                saveFileConfig.FileName = string.Empty;
                SetupNewGrid();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FPGAConfigurationGridParamsForm configParamsForm = new FPGAConfigurationGridParamsForm(this);
            DialogResult rsltarams = configParamsForm.ShowDialog();

            if (SquareSize > 0)
            {
                if(SaveFile(true, FPGABoard.RandomConfig(SquareSize)))
                {
                    LoadConfigFile(saveFileConfig.FileName);
                }
            }
        }
    }
}
