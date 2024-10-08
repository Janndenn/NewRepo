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
using System.Xml.Linq;

namespace testthesis
{
    public partial class brand : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from brand", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;



            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ຍີ່ຫໍ້";

        }
        public brand()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void brand_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand(" insert into brand values (@brandid,@brandname)", cd.conder);
                cmd.Parameters.AddWithValue("@brandid", txtid.Text);
                cmd.Parameters.AddWithValue("@brandname", txtname.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("delete brand where brandid=@brandid", cd.conder);
                cmd.Parameters.AddWithValue("@brandid", txtid.Text);
                cmd.Parameters.AddWithValue("@brandname", txtname.Text);
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
        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
           new employee().Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer frm = new customer();
            frm.show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
            frm.show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            product frm = new product();
            frm.show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            exchange frm = new exchange();
            frm.show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
            frm.show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new salerecord().Show();
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
            productreport frm= new productreport();
            frm.Show();
        }
    }
}
