using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace team
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new loginform().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new khormoon().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Selling().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          new register().Show();

        }
    }
}
