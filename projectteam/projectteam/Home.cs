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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new khormoon().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new orderdetail().Show();
            this.Hide();
        }
    }
}
