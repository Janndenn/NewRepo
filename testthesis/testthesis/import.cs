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
    public partial class import : Form
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
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 180;
            dataGridView1.Columns[12].Width = 150;
            dataGridView1.Columns[13].Width = 150;

            dataGridView1.Columns[0].HeaderText = "orderid";
            dataGridView1.Columns[1].HeaderText = "Date Order";
            dataGridView1.Columns[2].HeaderText = "ລະຫັດພ/ງ";
            dataGridView1.Columns[3].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຄຳອະທິບາຍ";
            dataGridView1.Columns[6].HeaderText = "ຜູ້ສະໜອງ";
            dataGridView1.Columns[7].HeaderText = "ປະເພດສິນຄ້າ";
            dataGridView1.Columns[8].HeaderText = "ຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView1.Columns[9].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[10].HeaderText = "ຫົວໜ່ວຍສິນຄ້າ";
            dataGridView1.Columns[11].HeaderText = "ລາຄານຳເຂົ້າ";
            dataGridView1.Columns[12].HeaderText = "ລາຄາລວມ";
            dataGridView1.Columns[13].HeaderText = "ລາຄາລວມທັງໝົດ";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtorderid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdateorder.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtproid.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtproname.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtdes.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtsup.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txttype.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtsol.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtunit.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtorderprice.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery frm = new ordersummery();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into import values(@imid,@imdate,@emid,@orderid,@dateoder,@proid,@proname,@ddesc,@supname,@typename,@brandname,@orderqty,@unit,@orderprice,@totalprice)", cd.conder);
            cmd.Parameters.AddWithValue("@imid", txtid.Text);
            cmd.Parameters.AddWithValue("@imdate", txtdate.Text);
            cmd.Parameters.AddWithValue("@emid", txtem.Text);
            cmd.Parameters.AddWithValue("@orderid", txtorderid.Text);
            cmd.Parameters.AddWithValue("@dateoder", txtdateorder.Text);
            cmd.Parameters.AddWithValue("@proid", txtproid.Text);
            cmd.Parameters.AddWithValue("@proname", txtproname.Text);
            cmd.Parameters.AddWithValue("@ddesc", txtdes.Text);
            cmd.Parameters.AddWithValue("@supname", txtsup.Text);
            cmd.Parameters.AddWithValue("@typename", txttype.Text);
            cmd.Parameters.AddWithValue("@brandname", txtbrand.Text);
            cmd.Parameters.AddWithValue("@orderqty", txtqty.Text);
            cmd.Parameters.AddWithValue("@unit", txtunit.Text);
            cmd.Parameters.AddWithValue("@orderprice", txtorderprice.Text);
            cmd.Parameters.AddWithValue("@totalprice", txttotal.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not save"); }

        }
        private void AddProductQuantity(int productId, int quantityToAdd)
        {

        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int.TryParse(txtorderprice.Text, out v1);
            int.TryParse(txtqty.Text, out v2);
            int.TryParse(txttotal.Text, out v3);
            int I = (v1 * v2);
            txttotal.Text = I.ToString();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord frm = new importrecord();
            frm.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            product frm = new product();
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer frm = new customer();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
            frm.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            brand frm = new brand();
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.Show();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            exchange frm = new exchange();
            frm.Show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            salerecord frm = new salerecord();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Customoerrecord frm = new Customoerrecord();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            supplierRecord frm = new supplierRecord();
            frm.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord frm = new problemrecord();
            frm.Show();
        }
        private string connectionString = "Data Source=JANNDENN\\SQLEXPRESS;Initial Catalog=testthesis;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(txtproid.Text); // Ensure txtProductId contains a valid integer
            int quantityToAdd = int.Parse(txtqty.Text);
            UpdateProductQuantity(productId, quantityToAdd);
        }
        private void UpdateProductQuantity(int productId, int quantityToAdd)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Retrieve current quantity
                    int currentQuantity = GetCurrentQuantity(con, productId);

                    // Calculate new quantity
                    int newQuantity = currentQuantity + quantityToAdd;

                    // Update the quantity in the database
                    string updateQuery = "UPDATE product SET jamnoun = @jamnoun WHERE proid = @proid";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("jamnoun", newQuantity);
                        cmd.Parameters.AddWithValue("@proid", productId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Quantity updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetCurrentQuantity(SqlConnection con, int productId)
        {
            string selectQuery = "SELECT jamnoun FROM product WHERE proid = @proid";
            using (SqlCommand cmd = new SqlCommand(selectQuery, con))
            {
                cmd.Parameters.AddWithValue("@proid", productId);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }


    }
}
