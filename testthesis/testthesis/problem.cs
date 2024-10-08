using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testthesis
{
    public partial class problem : Form
    {
        public problem()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void problem_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();  
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            product product = new product();
            product.show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            employee employee = new employee();
            employee.show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier supplier = new supplier();
            supplier.show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            producttype producttype = new producttype();
            producttype.show();
        }
    }
}
