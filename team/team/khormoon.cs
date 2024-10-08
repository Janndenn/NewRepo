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
    public partial class khormoon : Form
    {
        public khormoon()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            customer dt = new customer() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            staff dt = new staff() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle= FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            product dt = new product() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            stock dt = new stock() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            khstock dt = new khstock() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            supplier dt = new supplier() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            orderingItem dt = new orderingItem() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            new Selling().Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            customer dt = new customer() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            staff dt = new staff() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            supplier dt = new supplier() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            stock dt = new stock() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            orderingItem dt = new orderingItem() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            product dt = new product() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new khormoon().Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
