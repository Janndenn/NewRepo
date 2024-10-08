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

namespace testthesis
{
    public partial class supplierRecord : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from supplier", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດຜູ້ສະໜອງ";
            dataGridView1.Columns[1].HeaderText = "ຊື້";
            dataGridView1.Columns[2].HeaderText = "ບ້ານ";
            dataGridView1.Columns[3].HeaderText = "ເມືອງ";
            dataGridView1.Columns[4].HeaderText = "ແຂວງ";
            dataGridView1.Columns[5].HeaderText = "ປະເທດ";
            dataGridView1.Columns[6].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[7].HeaderText = "Email";

        }
        public supplierRecord()
        {
            InitializeComponent();
        }

        private void supplierRecord_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }
       

        private void txtSuppliers_TextChanged(object sender, EventArgs e)
        {
           
        }

    }
}
