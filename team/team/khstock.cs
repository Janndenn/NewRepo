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
    public partial class khstock : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from importitem", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 170;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 170;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດການສັ່ງຊື້";
            dataGridView1.Columns[2].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[4].HeaderText = "ລາຄາ";
            dataGridView1.Columns[5].HeaderText = "ລາຄາລວມ";
            dataGridView1.Columns[6].HeaderText = "ວັນເດືອນປີການຮັບສິນຄ້າ";
        }
        public khstock()
        {
            InitializeComponent();
        }

        private void khstock_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (txtorderid.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=DESKTOP-3B6JIUK; initial Catalog = team; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select Productname, Quantity from orderingitem where Orderid=@Orderid", tor);
                cc.Parameters.AddWithValue("@Orderid", txtorderid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtname.Text = rdr.GetValue(0).ToString();
                    txtquan.Text = rdr.GetValue(1).ToString();
                  
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into importitem values(@Importid,@Orderid,@Productname,@Quantity,@Price,@Totalprice,@Dateofimport)", cd.conder);
            cmd.Parameters.AddWithValue("@Importid", txtid.Text);
            cmd.Parameters.AddWithValue("@Orderid", txtorderid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            cmd.Parameters.AddWithValue("@Dateofimport", txtdate.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtorderid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtquan.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txttotalprice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update importitem set Importid=@Importid,Orderid=@Orderid,Productname=@Productname,Quantity=@Quantity,Price=@Price,Totalprice=@Totalprice,Dateofimport=@Dateofimport where Importid=@Importid", cd.conder);
            cmd.Parameters.AddWithValue("@Importid", txtid.Text);
            cmd.Parameters.AddWithValue("@Orderid", txtorderid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            cmd.Parameters.AddWithValue("@Dateofimport", txtdate.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete importitem where Importid=@Importid", cd.conder);
            cmd.Parameters.AddWithValue("@Importid", txtid.Text);
            cmd.Parameters.AddWithValue("@Orderid", txtorderid.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquan.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Totalprice", txttotalprice.Text);
            cmd.Parameters.AddWithValue("@Dateofimport", txtdate.Text);
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
