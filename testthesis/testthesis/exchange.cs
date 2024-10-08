using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testthesis
{
    public partial class exchange : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from exchange", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 220;
            dataGridView1.Columns[2].Width = 220;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດອັດຕາແລກປ່ຽນ";
            dataGridView1.Columns[1].HeaderText = "ສະກຸນເງິນ";
            dataGridView1.Columns[2].HeaderText = "ອັດຕາແລກປ່ຽນ";

        }
        public exchange()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exchange_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtex.Text !="")
            {
                cmd = new SqlCommand(" insert into exchange values (@exid,@currency,@exchange)", cd.conder);
                cmd.Parameters.AddWithValue("@exid", txtid.Text);
                cmd.Parameters.AddWithValue("currency", txtname.Text);
                cmd.Parameters.AddWithValue("@exchange", txtex.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtex.Text != "")
            {
                cmd = new SqlCommand(" delete exchange where exid=@exid", cd.conder);
                cmd.Parameters.AddWithValue("@exid", txtid.Text);
                cmd.Parameters.AddWithValue("currency", txtname.Text);
                cmd.Parameters.AddWithValue("@exchange", txtex.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please click on the data"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtex.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            product frm = new product();
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer frm = new customer();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
                frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            brand frm = new brand();
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
              frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            salerecord frm = new salerecord();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport frm = new productreport();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Customoerrecord frm = new Customoerrecord();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            supplierRecord frm = new supplierRecord();
            frm.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery frm = new ordersummery();
            frm.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord frm = new importrecord();
            frm.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord frm = new problemrecord();
            frm.Show();
        }
    }
}
