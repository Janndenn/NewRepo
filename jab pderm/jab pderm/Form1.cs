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

namespace jab_pderm
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=lect1; Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from test", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand comm;
            
            comm = new SqlCommand("insert into Test values(" + textBox1.Text + ",'" + textBox2.Text + "')", con);
            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved...");
            }
            catch (Exception)
            {
                MessageBox.Show("Not Saved");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
