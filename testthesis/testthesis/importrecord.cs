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
    public partial class importrecord : Form
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
            adt = new SqlDataAdapter("select * from import", cd.conder);
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
            dataGridView2.Columns[13].Width = 180;
            dataGridView2.Columns[14].Width = 150;

            dataGridView2.Columns[0].HeaderText = "ImportID";
            dataGridView2.Columns[1].HeaderText = "Import Date";
            dataGridView2.Columns[2].HeaderText = "EmployeeID";
            dataGridView2.Columns[3].HeaderText = "OrderID";
            dataGridView2.Columns[4].HeaderText = "OrderDate";
            dataGridView2.Columns[5].HeaderText = "ProductID";
            dataGridView2.Columns[6].HeaderText = "ProductName";
            dataGridView2.Columns[7].HeaderText = "Description";
            dataGridView2.Columns[8].HeaderText = "Supplier";
            dataGridView2.Columns[9].HeaderText = "ProductType";
            dataGridView2.Columns[10].HeaderText = "Brand";
            dataGridView2.Columns[11].HeaderText = "Qty.";
            dataGridView2.Columns[12].HeaderText = "Unit";
            dataGridView2.Columns[13].HeaderText = "OrderPrice";
            dataGridView2.Columns[14].HeaderText = "Totalprice";
        }
        public importrecord()
        {
            InitializeComponent();
        }

        private void importrecord_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adt = new SqlDataAdapter("select * from import where imdate between '" + txtdate.Value.ToString() + "' and '" + txttodate.Value.ToString() + "'", cd.conder);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
