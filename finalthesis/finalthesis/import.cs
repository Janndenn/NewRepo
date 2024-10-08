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

namespace finalthesis
{
    public partial class import : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from importt", cd.conder);
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
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 180;
            dataGridView1.Columns[12].Width = 180;
            dataGridView1.Columns[13].Width = 180;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດນ້ຳເຂົ້າ";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດພ/ງ";
            dataGridView1.Columns[2].HeaderText = "ລະຫັດສັ່ງຊື້";
            dataGridView1.Columns[3].HeaderText = "ຜູ້ສະໜອງ";
            dataGridView1.Columns[4].HeaderText = "ວັນນຳເຂົ້າ";
            dataGridView1.Columns[5].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[6].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[7].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[8].HeaderText = "ປະເພດ";
            dataGridView1.Columns[9].HeaderText = "ຍີ່ຫໍ້";
            dataGridView1.Columns[10].HeaderText = "ລາຄາ";
            dataGridView1.Columns[11].HeaderText = "ລາຄາລວມ";
            dataGridView1.Columns[12].HeaderText = "ລາຄາທັງໝົດ";
            dataGridView1.Columns[13].HeaderText = "ສະຖານະ";


        }
        public import()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void import_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }
    }
}
