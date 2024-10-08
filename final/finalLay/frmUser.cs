using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.AxHost;

namespace final
{
    
    public partial class frmUser : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id = null;
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFdl = new OpenFileDialog();
            opFdl.Filter = "(Image Type *.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";
            if (opFdl.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opFdl.FileName);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select emp_id, username, emp_name, phone, email, address, detail, img from employee";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 400;
            dataGridView1.Columns[6].Width = 400;
            dataGridView1.Columns[7].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ເຂົ້າໃຊ້ລະບົບ";
            dataGridView1.Columns[2].HeaderText = "ຊື່ເຕັມພະນັກງານ";
            dataGridView1.Columns[3].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[4].HeaderText = "ອີເມວ";
            dataGridView1.Columns[5].HeaderText = "ທີ່ຢູ່";
            dataGridView1.Columns[6].HeaderText = "ລາຍລະອຽດ";
            dataGridView1.Columns[7].HeaderText = "ຮູບພາບ";
        }

        private void cleardata()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFirstname.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCard.Clear();
            pictureBox1.Image= null;
            txtUsername.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into employee values(N'" +
                txtFirstname.Text + "', '" +
                txtTel.Text + "', '" +
                txtEmail.Text + "',N'" +
                txtAddress.Text + "', N'" +
                txtCard.Text + "', @img, '"+
                txtUsername.Text + "', '" +
                txtPassword.Text + "')";
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] btimg = ms.GetBuffer();
                cmd = new SqlCommand(sql, db.Connect());
                cmd.Parameters.AddWithValue("@img", btimg);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ເພີ່ມສຳເລັດ");
            }catch(Exception ex)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtFirstname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCard.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if(dataGridView1.CurrentRow.Cells[7].Value.ToString() != "")
            {
                var img = (byte[])dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                if (txtPassword.Text != "")
                {
                    sql = "update employee set " +
                     "password ='" + txtPassword.Text + "', " +
                     "username ='" + txtUsername.Text + "', " +
                     "emp_name =N'" + txtFirstname.Text + "', " +
                     "phone ='" + txtTel.Text + "', " +
                     "email ='" + txtEmail.Text + "', " +
                     "address =N'" + txtAddress.Text + "', " +
                     "detail =N'" + txtCard.Text + "', " +
                     "img = @img where emp_id = '" + id + "'";
                }
                else
                {
                    sql = "update employee set " +
                     "username ='" + txtUsername.Text + "', " +
                     "emp_name =N'" + txtFirstname.Text + "', " +
                     "phone ='" + txtTel.Text + "', " +
                     "email ='" + txtEmail.Text + "', " +
                     "address =N'" + txtAddress.Text + "', " +
                     "detail =N'" + txtCard.Text + "', " +
                     "img = @img where emp_id = '" + id + "'";
                }
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] btimg = ms.GetBuffer();
                cmd = new SqlCommand(sql, db.Connect());
                cmd.Parameters.AddWithValue("@img", btimg);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from employee where emp_id = '" + id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }
    }
}
