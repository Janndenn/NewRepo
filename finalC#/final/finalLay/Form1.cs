using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace final
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string strConn = "Data Source=JANNDENN\\SQLEXPRESS;Initial Catalog=pos_dshop; integrated security = True";
        DbConnect db = new DbConnect();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name, pwd;
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    string query = "select * from employee where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        user_name = txtUsername.Text;
                        pwd = txtPassword.Text;
                        //MessageBox.Show(row["emp_id"].ToString());
                        db.userid = row["emp_id"].ToString();
                        //MessageBox.Show(db.userid);

                        frmMainMenu frm = new frmMainMenu();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("ຂໍ້ມູນຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ!");
                        txtUsername.Clear();
                        txtPassword.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານ!");
                }
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດກະລຸນາລອງໃໝ່!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string user_name, pwd;
                try
                {
                    if (txtUsername.Text != "" && txtPassword.Text != "")
                    {
                        string query = "select * from employee where username = '" + txtUsername.Text + "' and password = '" + txtPassword.Text + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            user_name = txtUsername.Text;
                            pwd = txtPassword.Text;
                            //MessageBox.Show(row["emp_id"].ToString());
                            db.userid = row["emp_id"].ToString();
                            //MessageBox.Show(db.userid);

                            frmMainMenu frm = new frmMainMenu();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("ຂໍ້ມູນຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ!");
                            txtUsername.Clear();
                            txtPassword.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ກະລຸນາປ້ອນຂໍ້ມູນຜູ້ໃຊ້ ແລະ ລະຫັດຜ່ານ!");
                    }
                }
                catch
                {
                    MessageBox.Show("ເກີດຂໍ້ຜິດພາດກະລຸນາລອງໃໝ່!");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
