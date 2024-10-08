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
    public partial class orderingItem : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from orderingitem", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ບໍລິສັດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ປະເພດ";
            dataGridView1.Columns[4].HeaderText = "ນະໜາດ";
            dataGridView1.Columns[5].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[6].HeaderText = "ວັນເດືອນປີສັ່ງຊື້";
        }

        SqlDataAdapter dacom = new SqlDataAdapter();
        DataSet dscom = new DataSet();
        connectjah cdcom = new connectjah();
        SqlCommand cmdcom = new SqlCommand();
        DataTable dtcom = new DataTable();
        public void companyname()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select Companyname from supplier", cd.conder);
            dp.Fill(dtcom);
            txtname.DataSource = dtcom;
            txtname.DisplayMember = "Companyname";
            txtname.ValueMember = "Companyname";

        }
        public orderingItem()
        {
            InitializeComponent();
        }

        private void orderingItem_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();

            cdcom.connectja();
            companyname();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into orderingitem values(@Orderid,@Companyname,@Productname,@category,@Size,@Quantity,@Dateoforder)", cd.conder);
            cmd.Parameters.AddWithValue("@Orderid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuan.Text);
            cmd.Parameters.AddWithValue("@Dateoforder", txtdate.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtproduct.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtcate.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsize.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update orderingitem set Orderid=@Orderid,Companyname=@Companyname,Productname=@Productname,category=@category,Size=@Size,Quantity=@Quantity,Dateoforder=@Dateoforder where Orderid=@Orderid", cd.conder);
            cmd.Parameters.AddWithValue("@Orderid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuan.Text);
            cmd.Parameters.AddWithValue("@Dateoforder", txtdate.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete orderingitem where Orderid=@Orderid", cd.conder);
            cmd.Parameters.AddWithValue("@Orderid", txtid.Text);
            cmd.Parameters.AddWithValue("@Companyname", txtname.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtQuan.Text);
            cmd.Parameters.AddWithValue("@Dateoforder", txtdate.Text);
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

        private void txtname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
