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

namespace finalthesis
{
    public partial class sale : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select proid,proname,jamnoun,price,totalprice,finalprice from sales", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
        
            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[3].HeaderText = "ລາຄາ";
            dataGridView1.Columns[4].HeaderText = "ລາຄາລວມ";
            dataGridView1.Columns[5].HeaderText = "ລາຄາທັງໝົດ";
            
        }
        public sale()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void sale_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
