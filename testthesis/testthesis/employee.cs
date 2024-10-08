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
using System.Xml.Linq;

namespace testthesis
{
    public partial class employee : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
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
            dataGridView1.Columns[13].Width = 150;
     

            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ";
            dataGridView1.Columns[5].HeaderText = "ອາຍຸ";
            dataGridView1.Columns[6].HeaderText = "ບ້ານ";
            dataGridView1.Columns[7].HeaderText = "ເມືອງ";
            dataGridView1.Columns[8].HeaderText = "ແຂວງ";
            dataGridView1.Columns[9].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[10].HeaderText = "email";
            dataGridView1.Columns[11].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView1.Columns[12].HeaderText = "ລະຫັດຜ່ານ";
            dataGridView1.Columns[13].HeaderText = "ຮູບພາບ";
        }
        public employee()
        {
            InitializeComponent();
        }

        private void employee_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("insert into employee values(@emid,@gender,@emname,@emsurname,@birthday,@age,@village,@district,@province,@tel,@email,@datehire,@pass,@pic)", cd.conder);
                cmd.Parameters.AddWithValue("@emid", txtid.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@emname", txtname.Text);
                cmd.Parameters.AddWithValue("@emsurname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                cmd.Parameters.AddWithValue("@age",txtage.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@district", txtdt.Text);
                cmd.Parameters.AddWithValue("@province", txtpv.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@datehire", txtdate.Text);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                cmd.Parameters.AddWithValue("@pic", arr);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imder = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtid.Text))
            {
                string query = "DELETE FROM employee WHERE emid=@emid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@emid", txtid.Text);

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
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtpass.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[13].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
            frm.Show();
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

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            brand frm = new brand();
            frm.Show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.Show();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            exchange frm = new exchange();
            frm.Show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            salerecord frm = new salerecord();
            frm.Show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport frm = new productreport();
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
            ordersummery frm = new ordersummery();
            frm.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord frm = new importrecord();
            frm.Show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord frm = new problemrecord();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                // Ensure the SQL command includes a WHERE clause
                string query = "UPDATE employee SET gender=@gender, emname=@emname, emsurname=@emsurname, birthday=@birthday, village=@village, district=@district, province=@province, tel=@tel, email=@email, datehire=@datehire, pass=@pass, pic=@pic WHERE emid=@emid";

                using (SqlCommand cmd = new SqlCommand(query, cd.conder))
                {
                    cmd.Parameters.AddWithValue("@emid", txtid.Text);
                    cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                    cmd.Parameters.AddWithValue("@emname", txtname.Text);
                    cmd.Parameters.AddWithValue("@emsurname", txtsurname.Text);
                    cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                    cmd.Parameters.AddWithValue("@village", txtvl.Text);
                    cmd.Parameters.AddWithValue("@district", txtdt.Text);
                    cmd.Parameters.AddWithValue("@province", txtpv.Text);
                    cmd.Parameters.AddWithValue("@tel", txttel.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@datehire", txtdate.Text);
                    cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                    cmd.Parameters.AddWithValue("@pic", arr);

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

    }
}
