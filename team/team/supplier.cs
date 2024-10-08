using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
namespace team
{
    public partial class supplier : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from supplier", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 200;
          

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ບໍລິສັດ";
            dataGridView1.Columns[2].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[3].HeaderText = "Email";
            dataGridView1.Columns[4].HeaderText = "Address";

        }
        public supplier()
        {
            InitializeComponent();
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into supplier values(@Supplierid,@Companyname,@Tel,@Email,@SupAddress)", cd.conder);
            cmd.Parameters.AddWithValue("@Supplierid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@SupAddress", txtaddress.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update supplier set Supplierid=@Supplierid,Companyname=@Companyname,Tel=@Tel,Email=@Email,SupAddress=@SupAddress where Supplierid=@Supplierid", cd.conder);
            cmd.Parameters.AddWithValue("@Supplierid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@SupAddress", txtaddress.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete supplier where Supplierid=@Supplierid", cd.conder);
            cmd.Parameters.AddWithValue("@Supplierid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@SupAddress", txtaddress.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not delete"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
