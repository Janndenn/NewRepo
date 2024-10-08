using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectteam
{
    public partial class orderdetail : Form
    {
        public orderdetail()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Home displayMainForm = new Home();
            displayMainForm.Show();
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new khormoon().Show();
            this.Hide();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }
    }
}
