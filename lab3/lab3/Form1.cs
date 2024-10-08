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

namespace lab3
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectder cn = new connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        string imder = null;
        public void sadaeng()
        {
            adt = new SqlDataAdapter("Select * from product", cn.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 282;
            dataGridView1.Columns[1].Width = 200;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Connectder();
            sadaeng();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            int a, b, c;
            int.TryParse(txtamount.Text, out a);
            int.TryParse(txtprice.Text, out b);
            c = a * b;

            txttotal.Text = c.ToString();
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            int a, b, c;
            int.TryParse(txtamount.Text, out a);
            int.TryParse(txtprice.Text, out b);
            c = a * b;

            txttotal.Text = c.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
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
            cmd = new SqlCommand("insert into product values (@p_id, @p_name,@p_type,@p_size,@p_amount,@p_price,@p_total,@p_expire,@p_photo)",cn.conder);
            cmd.Parameters.AddWithValue("@p_id",txtid.Text);
            cmd.Parameters.AddWithValue("@p_name", txtname.Text);
            cmd.Parameters.AddWithValue("@p_type", comtype.Text);
            cmd.Parameters.AddWithValue("@p_size", txtsize.Text);
            cmd.Parameters.AddWithValue("@p_amount", txtamount.Text);
            cmd.Parameters.AddWithValue("@p_price", txtprice.Text);
            cmd.Parameters.AddWithValue("@p_total", txttotal.Text);
            cmd.Parameters.AddWithValue("@p_expire", txtdate.Text);
            cmd.Parameters.AddWithValue("@p_photo", arr);

            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
                MessageBox.Show("save dai lei");

            }
            else { MessageBox.Show("save bor dai"); } 


        }
    }
}
