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
    public partial class producttype : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from producttype", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
          


            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ປະເພດ";
           
        }
        public producttype()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand(" insert into producttype values (@typeid,@typename)", cd.conder);
                cmd.Parameters.AddWithValue("@typeid", txtid.Text);
                cmd.Parameters.AddWithValue("@typename", txtname.Text);
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
                cmd = new SqlCommand("delete producttype where typeid=@typeid", cd.conder);
                cmd.Parameters.AddWithValue("@typeid", txtid.Text);
                cmd.Parameters.AddWithValue("@typename", txtname.Text);
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

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            new product().Show();
            this.Close();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            new employee().Show();
        }
    }
}
