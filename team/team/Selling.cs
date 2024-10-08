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
    public partial class Selling : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from selling", cd.conder);
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
            dataGridView1.Columns[6].Width = 170;
            dataGridView1.Columns[7].Width = 200;
            dataGridView1.Columns[8].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດການຂາຍ";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[2].HeaderText = "ລະຫັດລູກຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຂະໜາດ";
            dataGridView1.Columns[6].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[7].HeaderText = "ລາຄາ";
            dataGridView1.Columns[8].HeaderText = "ລາຄາລວມ";
        }

        SqlDataAdapter dastaff = new SqlDataAdapter();
        DataSet dsstaff = new DataSet();
        connectjah cdstaff = new connectjah();
        SqlCommand cmdstaff = new SqlCommand();
        DataTable dtstaff = new DataTable();
        public void staffder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select Emid from employee", cd.conder);
            dp.Fill(dtstaff);
            txtstaff.DataSource = dtstaff;
            txtstaff.DisplayMember = "Emid";
            txtstaff.ValueMember = "Emid";

        }
        SqlDataAdapter dacus = new SqlDataAdapter();
        DataSet dscus = new DataSet();
        connectjah cdcus = new connectjah();
        SqlCommand cmdcus = new SqlCommand();
        DataTable dtcus = new DataTable();
        public void cusder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select Cusid from customer", cd.conder);
            dp.Fill(dtcus);
            txtcustomer.DataSource = dtcus;
            txtcustomer.DisplayMember = "Cusid";
            txtcustomer.ValueMember = "Cusid";

        }
        public Selling()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Selling_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();

            cdstaff.connectja();
            staffder();

            cdcus.connectja();
            cusder();
        }

        private void txtquan_TextChanged(object sender, EventArgs e)
        {
            int a, b, c;
            int.TryParse(txtquan.Text, out a);
            int.TryParse(txtprice.Text, out b);
            c = a * b;

            txttotalprice.Text = c.ToString();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            int a, b, c;
            int.TryParse(txtquan.Text, out a);
            int.TryParse(txtprice.Text, out b);
            c = a * b;

            txttotalprice.Text = c.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtproid.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=DESKTOP-3B6JIUK; initial Catalog = team; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select Productname from product where Productid=@Productid", tor);
                cc.Parameters.AddWithValue("@Productid", txtproid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtproduct.Text = rdr.GetValue(0).ToString();


                }
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into selling values(@Sellid,@Emid,@Cusid,@Productid,@Productname,@Size,@Quantity,@Price,@Totalprice)", cd.conder);
            cmd.Parameters.AddWithValue("@Sellid", txtsellid.Text);
            cmd.Parameters.AddWithValue("@Emid", txtstaff.Text);
            cmd.Parameters.AddWithValue("@Cusid", txtcustomer.Text);
            cmd.Parameters.AddWithValue("@Productid", txtproid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update selling set Sellid=@Sellid,Emid=@Emid,Cusid=@Cusid,Productid=@Productid,Productname=@Productname,Size=@Size,Quantity=@Quantity,Price=@Price,Totalprice=@Totalprice where Sellid=@Sellid", cd.conder);
            cmd.Parameters.AddWithValue("@Sellid", txtsellid.Text);
            cmd.Parameters.AddWithValue("@Emid", txtstaff.Text);
            cmd.Parameters.AddWithValue("@Cusid", txtcustomer.Text);
            cmd.Parameters.AddWithValue("@Productid", txtproid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsellid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtstaff.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtcustomer.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtproid.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtproduct.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsize.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtquan.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttotalprice.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete selling where Sellid=@Sellid", cd.conder);
            cmd.Parameters.AddWithValue("@Sellid", txtsellid.Text);
            cmd.Parameters.AddWithValue("@Emid", txtstaff.Text);
            cmd.Parameters.AddWithValue("@Cusid", txtcustomer.Text);
            cmd.Parameters.AddWithValue("@Productid", txtproid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtproduct.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not delete"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new khormoon().Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new reportform().Show();
        }

        private void txtcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txttotalprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsellid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
