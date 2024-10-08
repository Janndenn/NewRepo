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

        private void button1_Click(object sender, EventArgs e)
        {
            customer dt = new customer() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            staff dt = new staff() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle= FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            position dt = new position() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            product dt = new product() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            khstock dt = new khstock() { TopLevel = false, TopMost = true };    
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            importitems dt = new importitems() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            stock dt = new stock() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Home displayMainForm = new Home();
            displayMainForm.Show();
            this.Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            customer dt = new customer() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            staff dt = new staff() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            position dt = new position() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            product dt = new product() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            khstock dt = new khstock() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            new bill().Show();
            this.Close();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            new orderdetail().Show();
            this.Close();
        }
    }
}
