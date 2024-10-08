using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalthesis
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            rpemployee dt = new rpemployee() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel6.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            new producttype().Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            new brand().Show();

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            new supplier().Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            new employee().Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            new customer().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            rpsale dt = new rpsale() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel6.Controls.Add(dt);
            dt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new sale().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new order().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new import().Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
