﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectRJSith
{
    public partial class orderdetail : Form
    {
        public orderdetail()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            home displayMainForm = new home();
            displayMainForm.Show();
            this.Close();
        }
    }
}