using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testthesis
{
    public partial class productreport : Form
    {
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
            adt = new SqlDataAdapter("select * from product", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 0;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 0;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 0;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 180;
            dataGridView1.Columns[12].Width = 150;
            dataGridView1.Columns[13].Width = 180;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຄຳອະທິບາຍ";
            dataGridView1.Columns[3].HeaderText = "supid";
            dataGridView1.Columns[4].HeaderText = "ຜູ້ສະໜອງ";
            dataGridView1.Columns[5].HeaderText = "typeid";
            dataGridView1.Columns[6].HeaderText = "ປະເພດສິນຄ້າ";
            dataGridView1.Columns[7].HeaderText = "brandid";
            dataGridView1.Columns[8].HeaderText = "ຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView1.Columns[9].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[10].HeaderText = "ຫົວໜ່ວຍສິນຄ້າ";
            dataGridView1.Columns[11].HeaderText = "ລາຄານຳເຂົ້າ";
            dataGridView1.Columns[12].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[13].HeaderText = "ລາຄາລວມ";
        }
        public productreport()
        {
            InitializeComponent();
        }

        private void productreport_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productName = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(productName))
            {
                // SQL query to search for products by name
                string query = "SELECT * FROM product WHERE proname LIKE @proname";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    // Use parameterized query to prevent SQL injection
                    cmd.Parameters.AddWithValue("@proname", "%" + productName + "%");

                    try
                    {
                        // Use SqlDataAdapter to fill a DataTable with the results
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;

                        // Provide feedback if no results are found
                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No products found with the specified name.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a product name to search.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string productId = txtSearchById.Text.Trim();

            if (!string.IsNullOrEmpty(productId))
            {
                // SQL query to search for products by ID
                string query = "SELECT * FROM product WHERE proid = @proid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {

                    cmd.Parameters.AddWithValue("@proid", productId);

                    try
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);


                        dataGridView1.DataSource = dataTable;


                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No products found with the specified ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a product ID to search.");
            }
        }
        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Product");

                // Load data from DataGridView to DataTable
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dr[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(dr);
                }

                // Load the DataTable into the worksheet
                ws.Cells["A1"].LoadFromDataTable(dt, true);

                // Save the file
                FileInfo fi = new FileInfo(filePath);
                pck.SaveAs(fi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "ProductList.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(dataGridView1, sfd.FileName);
                    MessageBox.Show("Export successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
