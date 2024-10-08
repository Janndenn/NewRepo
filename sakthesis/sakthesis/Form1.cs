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

namespace sakthesis
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK\\SQLEXPRESS; initial Catalog=team; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select product, jamnoun, price from sale ", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
           /* dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "cusid";*/
            dataGridView1.Columns[0].HeaderText = "product";
            dataGridView1.Columns[1].HeaderText = "Jamnoun";
            dataGridView1.Columns[2].HeaderText = "price";
            con.Close();
        }

        public Form1()
        {
            InitializeComponent();
            showder();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtcus.Text != "" && txtname.Text != "" && txtjam.Text != "" && txtp.Text != "")
            {
                cmd = new SqlCommand("insert into sale values(@saleid,@cusid,@product,@jamnoun,@price)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@saleid", txtid.Text);
                cmd.Parameters.AddWithValue("@cusid", txtcus.Text);
                cmd.Parameters.AddWithValue("@product", txtname.Text);
                cmd.Parameters.AddWithValue("@jamnoun", txtjam.Text);
                cmd.Parameters.AddWithValue("@price", txtp.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
