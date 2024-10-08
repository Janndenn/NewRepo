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
    public partial class rpemployee : Form
    {

        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from employee", cd.conder);
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
            dataGridView1.Columns[11].Width = 150;
            dataGridView1.Columns[12].Width = 100;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ:";
            dataGridView1.Columns[5].HeaderText = "ບ້ານ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ແຂວງ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[9].HeaderText = "email";
            dataGridView1.Columns[10].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView1.Columns[11].HeaderText = "ລະຫັດຜ່ານ";
            dataGridView1.Columns[12].HeaderText = "ຮູບພາບ";
        }
        public rpemployee()
        {
            InitializeComponent();
            
        }

        private void rpemployee_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
