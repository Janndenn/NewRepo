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
    public partial class customer : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
       ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from customer", cd.conder);
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


            dataGridView1.Columns[0].HeaderText = "ລະຫັດລ/ຄ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ:";
            dataGridView1.Columns[5].HeaderText = "ອາຍຸ";
            dataGridView1.Columns[6].HeaderText = "ບ້ານ";
            dataGridView1.Columns[7].HeaderText = "ເມືອງ";
            dataGridView1.Columns[8].HeaderText = "ແຂວງ";
            dataGridView1.Columns[9].HeaderText = "ເບີໂທ";

        }
        public customer()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("insert into customer values(@cusid,@gender,@cusname,@cussurname,@birthday,@age, @village,@district,@province,@tel)", cd.conder);
                cmd.Parameters.AddWithValue("@cusid", txtid.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@cusname", txtname.Text);
                cmd.Parameters.AddWithValue("@cussurname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@district", txtdt.Text);
                cmd.Parameters.AddWithValue("@province", txtpv.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                string query = "DELETE FROM customer WHERE cusid=@cusid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@cusid", txtid.Text);

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

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
            frm.show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            product frm = new product();
            frm.show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            brand frm = new brand();
            frm.show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            payment frm = new payment();
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            exchange frm = new exchange();  
            frm.show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
            frm.show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            salerecord frm = new salerecord();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport frm = new productreport();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            customer frm = new customer();
            frm.show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            supplierRecord frm = new supplierRecord();
            frm.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery frm = new ordersummery();
            frm.show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord frm = new importrecord();
            frm.show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord frm = new problemrecord();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                // Ensure the SQL command includes a WHERE clause
                string query = "UPDATE customer SET gender=@gender, cusname=@cusname, cussurname=@cussurname, birthday=@birthday,age=@age, vilage=@vilage, district=@district, province=@province, tel=@tel WHERE cusid=@cusid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@cusid", txtid.Text);
                    cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                    cmd.Parameters.AddWithValue("@cusname", txtname.Text);
                    cmd.Parameters.AddWithValue("@cussurname", txtsurname.Text);
                    cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                    cmd.Parameters.AddWithValue("@age", txtage.Text);
                    cmd.Parameters.AddWithValue("@vilage", txtvl.Text);
                    cmd.Parameters.AddWithValue("@district", txtdt.Text);
                    cmd.Parameters.AddWithValue("@province", txtpv.Text);
                    cmd.Parameters.AddWithValue("@tel", txttel.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                    dataGridView1.Refresh();
                    show();
                }
            }
            else
            {
                MessageBox.Show("Please fill in all required fields");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtvl.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtdt.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtpv.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }
    }
}
