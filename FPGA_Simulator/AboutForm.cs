﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPGA_Simulator
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            
        }

        private void btnAboutOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
