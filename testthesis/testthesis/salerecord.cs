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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace testthesis
{
    public partial class salerecord : Form
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
            adt = new SqlDataAdapter("select * from sale", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 200;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 300;
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Width = 150;
            dataGridView2.Columns[8].Width = 200;
            dataGridView2.Columns[9].Width = 150;
            dataGridView2.Columns[10].Width = 150;
            dataGridView2.Columns[11].Width = 300;
            dataGridView2.Columns[12].Width = 150;
            dataGridView2.Columns[13].Width = 150;
            dataGridView2.Columns[14].Width = 200;


            dataGridView2.Columns[0].HeaderText = "SaleID";
            dataGridView2.Columns[1].HeaderText = "Sale Date";
            dataGridView2.Columns[2].HeaderText = "EmployeeID";
            dataGridView2.Columns[3].HeaderText = "CustomerID";
            dataGridView2.Columns[4].HeaderText = "CustomerName";
            dataGridView2.Columns[5].HeaderText = "ProductID";
            dataGridView2.Columns[6].HeaderText = "ProductName";
            dataGridView2.Columns[7].HeaderText = "UnitPrice";
            dataGridView2.Columns[8].HeaderText = "Discount";
            dataGridView2.Columns[9].HeaderText = "Amount";
            dataGridView2.Columns[10].HeaderText = "saleQty";
            dataGridView2.Columns[11].HeaderText = "TotalPrice";
            dataGridView2.Columns[12].HeaderText = "GrandTotal";
            dataGridView2.Columns[13].HeaderText = "Paymenttype";
            dataGridView2.Columns[14].HeaderText = "Currency";
        }

        public salerecord()
        {
            InitializeComponent();
        }

        private void salerecord_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adt = new SqlDataAdapter("select * from sale where saledate between '" + txtdate.Value.ToString() + "' and '" + txttodate.Value.ToString() + "'", cd.conder);
            DataTable dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtdate.Text = DateTime.Today.ToString();
            txttodate.Text = DateTime.Today.ToString();
            cmbCustomerName.Text = "";
            dataGridView3.DataSource = null;
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row first", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                sale frmAnother = new sale();

                // Show the form
                frmAnother.Show();

                // Set values of controls directly
               /* frmAnother.txtid.Text = selectedRow.Cells[0].Value?.ToString();
                frmAnother.txtdate.Text = selectedRow.Cells[1].Value?.ToString();
                frmAnother.txtem.Text = selectedRow.Cells[2].Value?.ToString();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
