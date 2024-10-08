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
    public partial class product : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from product", cd.conder);
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


            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ປະເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ນະໜາດ";
            dataGridView1.Columns[4].HeaderText = "ລາຄາ";
            dataGridView1.Columns[5].HeaderText = "ຮູບພາບ";

        }
        public product()
        {
            InitializeComponent();
        }

        private void product_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imder = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("insert into product values(@ProductID,@Category,@Productname,@Size,@Price,@Pic)", cd.conder);
            cmd.Parameters.AddWithValue("@ProductID", txtid.Text);
            cmd.Parameters.AddWithValue("@Category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("update product set ProductID=@ProductID,Category=@Category,Productname=@Productname,Size=@Size,Price=@Price,Pic=@Pic where ProductID=@ProductID", cd.conder);
            cmd.Parameters.AddWithValue("@ProductID", txtid.Text);
            cmd.Parameters.AddWithValue("@Category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtcate.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsize.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[5].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("delete product where ProductID=@ProductID", cd.conder);
            cmd.Parameters.AddWithValue("@ProductID", txtid.Text);
            cmd.Parameters.AddWithValue("@Category", txtcate.Text);
            cmd.Parameters.AddWithValue("@Productname", txtname.Text);
            cmd.Parameters.AddWithValue("@Size", txtsize.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
            cmd.Parameters.AddWithValue("@Pic", arr);
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
