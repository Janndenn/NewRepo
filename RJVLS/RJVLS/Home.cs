using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJVLS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            new Student().Show();
            this.Hide();
        }

        private void btnclass_Click(object sender, EventArgs e)
        {
            new Class().Show();
            this.Hide();
        }

        private void btnmajor_Click(object sender, EventArgs e)
        {
            new Major().Show();
            this.Hide();
        }

        private void btnyear_Click(object sender, EventArgs e)
        {
            new Year().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
