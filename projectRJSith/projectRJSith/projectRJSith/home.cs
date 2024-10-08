using System;
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
    public partial class home : Form
    {
        public home()
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

        private void button3_Click(object sender, EventArgs e)
        {
            new orderdetail().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Hide();
        }
    }
}
