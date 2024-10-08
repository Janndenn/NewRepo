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

namespace final
{
    public partial class frmRole : Form
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string strConn = "Data Source=DESKTOP-U2B1AN9\\BOYZ2019;Initial Catalog=pos_cafe;User ID=sa;Password=123456";
        int role_id;
        int data;
        int employee;
        int promotion;
        int report;

        int manage_data = 0;
        int manage_employee = 0;
        int manage_promotion = 0;
        int manage_report = 0;

        public frmRole()
        {
            InitializeComponent();
        }

        private void frmRole_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(strConn);
            conn.Open();

            getdata();
        }

        private void getdata()
        {
            string sql = "select role_id, username_id, manage_data, manage_employee, manage_promotion, manage_report from roles";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິດນຳໃຊ້";
            dataGridView1.Columns[1].HeaderText = "ຊື່ເຂົ້າໃຊ້ລະບົບ";
            dataGridView1.Columns[2].HeaderText = "ຟອມຂໍ້ມູນທົ່ວໄປ";
            dataGridView1.Columns[3].HeaderText = "ຟອມຂໍ້ມູນພະນັກງານ";
            dataGridView1.Columns[4].HeaderText = "ຟອມຂໍ້ມູນໂປຣໂມຊັ່ນ";
            dataGridView1.Columns[5].HeaderText = "ຟອມລາຍງານ";
        }

        private void cleardata()
        {
            txtCode.Clear();
            txtName.Clear();
            txtLname.Clear();
            cbData.Checked = false;
            cbUser.Checked = false;
            cbPromotion.Checked = false;
            cbReport.Checked = false;
            role_id = 0;

            txtCode.Focus();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmd = new SqlCommand("select * from users where username_id = '" + txtCode.Text + "'", conn);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtName.Text = row["username_id"].ToString();
                    txtLname.Text = row["user_name"].ToString() + " " + row["user_lastname"].ToString();
                    MessageBox.Show("ຄົ້ນຫາສຳເລັດ");
                }
                else
                {
                    MessageBox.Show("ບໍ່ມີຜູ້ໃຊ້ງານນີ້");
                    cleardata();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into roles values(" +
                manage_data + ", " +
                manage_employee + ", " +
                manage_promotion + ", " +
                manage_report + ", N'" +
                txtName.Text + "')";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ເພີ່ມສຳເລັດ");
            }
            catch {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            role_id = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            data = Int32.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            employee = Int32.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            promotion = Int32.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            report = Int32.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());

            if (data == 1)
            {
                cbData.Checked = true;
            }

            if (employee == 1)
            {
                cbUser.Checked = true;
            }

            if (promotion == 1)
            {
                cbPromotion.Checked = true;
            }

            if (report == 1)
            {
                cbReport.Checked = true;
            }
        }

        private void cbData_Click(object sender, EventArgs e)
        {
            if (cbData.Checked)
            {
                manage_data = 1;
            }
            else
            {
                manage_data = 0;
            }
        }

        private void cbUser_Click(object sender, EventArgs e)
        {
            if (cbUser.Checked)
            {
                manage_employee = 1;
            }
            else
            {
                manage_employee = 0;
            }
        }

        private void cbPromotion_Click(object sender, EventArgs e)
        {
            if (cbPromotion.Checked)
            {
                manage_promotion = 1;
            }
            else
            {
                manage_promotion = 0;
            }
        }

        private void cbReport_Click(object sender, EventArgs e)
        {
            if (cbReport.Checked)
            {
                manage_report = 1;
            }
            else
            {
                manage_report = 0;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update roles set " +
                 "username_id ='" + txtName.Text + "', " +
                 "manage_data =" + manage_data + ", " +
                 "manage_employee =" + manage_employee + ", " +
                 "manage_promotion =" + manage_promotion + ", " +
                 "manage_report =" + manage_report +
                 " where role_id= " + role_id + "";
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from roles where role_id = '" + role_id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
            }
        }
    }
}
