using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Common.UI.DataGrid
{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }
}
