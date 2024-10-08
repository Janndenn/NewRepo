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
    public partial class product : Form
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

        public product()
        {
            InitializeComponent();

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txttype_TextChanged(object sender, EventArgs e)
        {

        }

        private void product_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into product values(@proid,@proname,@ddesc,@supid, @supname,@typeid,@typename,@brandid,@brandname,@jamnoun,@unit,@imprice,@saleprice,@totalprice)", cd.conder);
            cmd.Parameters.AddWithValue("@proid", txtid.Text);
            cmd.Parameters.AddWithValue("@proname", txtname.Text);
            cmd.Parameters.AddWithValue("@ddesc", txtdes.Text);
            cmd.Parameters.AddWithValue("@supid", txtsupid.Text);
            cmd.Parameters.AddWithValue("@supname", txtname.Text);
            cmd.Parameters.AddWithValue("@typeid", txttypeid.Text);
            cmd.Parameters.AddWithValue("@typename", txttype.Text);
            cmd.Parameters.AddWithValue("@brandid", txtbrandid.Text);
            cmd.Parameters.AddWithValue("@brandname", txtbrand.Text);
            cmd.Parameters.AddWithValue("@jamnoun", txtqty.Text);
            cmd.Parameters.AddWithValue("@unit", txtunit.Text);
            cmd.Parameters.AddWithValue("@imprice", txtimp.Text);
            cmd.Parameters.AddWithValue("@saleprice", txtsale.Text);
            cmd.Parameters.AddWithValue("@totalprice", txtprice.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void txtsupid_TextChanged(object sender, EventArgs e)
        {
            if (txtsupid.Text != "")
            {
                SqlConnection co = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                co.Open();
                SqlCommand cc = new SqlCommand("select supname from supplier where supid=@supid", co);
                cc.Parameters.AddWithValue("@supid", txtsupid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtsup.Text = rdr.GetValue(0).ToString();


                }
            }
        }

        private void txttypeid_TextChanged(object sender, EventArgs e)
        {
            if (txttypeid.Text != "")
            {
                SqlConnection co = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                co.Open();
                SqlCommand cc = new SqlCommand("select typename from producttype where typeid=@typeid", co);
                cc.Parameters.AddWithValue("@typeid", txttypeid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txttype.Text = rdr.GetValue(0).ToString();


                }
            }
        }

        private void txtbrandid_TextChanged(object sender, EventArgs e)
        {
            if (txtbrandid.Text != "")
            {
                SqlConnection co = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                co.Open();
                SqlCommand cc = new SqlCommand("select brandname from brand where brandid=@brandid", co);
                cc.Parameters.AddWithValue("@brandid", txtbrandid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtbrand.Text = rdr.GetValue(0).ToString();


                }
            }
        }
        public void cal()
        {
            if (!string.IsNullOrEmpty(txtqty.Text) && !string.IsNullOrEmpty(txtsale.Text))
            {
                txtprice.Text = (Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtsale.Text)).ToString();
            }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtsale_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport frm = new productreport();
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
                frm.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            customer frm = new customer();
                frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
            frm.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            brand frm = new brand();
            frm.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
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

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery record = new ordersummery();
            record.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord record = new importrecord();
            record.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord record = new problemrecord();
            record.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsupid.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsup.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txttypeid.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txttype.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtbrandid.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtqty.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtunit.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtimp.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtsale.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtdes.Text != "")
            {
                // Ensure the SQL command includes a WHERE clause and matches parameter names
                string query = "UPDATE product SET proname=@proname, ddesc=@ddesc, supid=@supid, supname=@supname, typeid=@typeid, typename=@typename, brandid=@brandid, brandname=@brandname, jamnoun=@jamnoun, unit=@unit, imprice=@imprice, saleprice=@saleprice, totalprice=@totalprice WHERE proid=@proid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@proid", txtid.Text); // Primary Key for WHERE clause
                    cmd.Parameters.AddWithValue("@proname", txtname.Text);
                    cmd.Parameters.AddWithValue("@ddesc", txtdes.Text);
                    cmd.Parameters.AddWithValue("@supid", txtsupid.Text);
                    cmd.Parameters.AddWithValue("@supname", txtsup.Text); // Fixed mismatch here
                    cmd.Parameters.AddWithValue("@typeid", txttypeid.Text);
                    cmd.Parameters.AddWithValue("@typename", txttype.Text);
                    cmd.Parameters.AddWithValue("@brandid", txtbrandid.Text);
                    cmd.Parameters.AddWithValue("@brandname", txtbrand.Text);
                    cmd.Parameters.AddWithValue("@jamnoun", txtqty.Text);
                    cmd.Parameters.AddWithValue("@unit", txtunit.Text);
                    cmd.Parameters.AddWithValue("@imprice", txtimp.Text);
                    cmd.Parameters.AddWithValue("@saleprice", txtsale.Text);
                    cmd.Parameters.AddWithValue("@totalprice", txtprice.Text);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Update successful");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID");
                        }

                        dataGridView1.Refresh();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                string query = "DELETE FROM product WHERE proid=@proid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@proid", txtid.Text);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully");
                        }
                        else
                        {
                            MessageBox.Show("No record found with the specified ID");
                        }

                        // Refresh the data grid and any other UI elements as needed
                        dataGridView1.Refresh();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter an ID to delete");
            }
        }
    }

}

