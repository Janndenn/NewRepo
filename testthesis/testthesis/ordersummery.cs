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
using OfficeOpenXml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;


namespace testthesis
{
    public partial class ordersummery : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        public void show()
        {
            adt = new SqlDataAdapter("select * from orderr", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].Width = 20;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 100;
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Width = 100;
            dataGridView2.Columns[8].Width = 180;
            dataGridView2.Columns[9].Width = 150;
            dataGridView2.Columns[10].Width = 180;
            dataGridView2.Columns[11].Width = 180;
            dataGridView2.Columns[12].Width = 150;

            dataGridView2.Columns[1].HeaderText = "dateorder";
            dataGridView2.Columns[2].HeaderText = "Date Order";
            dataGridView2.Columns[3].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView2.Columns[4].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView2.Columns[5].HeaderText = "ຄຳອະທິບາຍ";
            dataGridView2.Columns[6].HeaderText = "ຜູ້ສະໜອງ";
            dataGridView2.Columns[7].HeaderText = "ປະເພດສິນຄ້າ";
            dataGridView2.Columns[8].HeaderText = "ຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView2.Columns[9].HeaderText = "ຈຳນວນ";
            dataGridView2.Columns[10].HeaderText = "ຫົວໜ່ວຍສິນຄ້າ";
            dataGridView2.Columns[11].HeaderText = "ລາຄານຳເຂົ້າ";
            dataGridView2.Columns[12].HeaderText = "ລາຄາລວມ";
            dataGridView2.Columns[13].HeaderText = "ລາຄາລວມທັງໝົດ";
        }
        public ordersummery()
        {
            InitializeComponent();

        }

        private void button5_Click(object sender, EventArgs e)
        {
          SqlDataAdapter adt = new SqlDataAdapter("select * from orderr where dateoder between '"+txtdate.Value.ToString()+"' and '"+txttodate.Value.ToString()+"'",cd.conder);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ordersummery_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }
    }
}
