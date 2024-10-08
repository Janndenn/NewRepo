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
    public partial class frmCustomer : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select cus_id, cus_type, cus_name, phone, buy_total from customer where cus_id != 1";
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

            dataGridView1.Columns[0].HeaderText = "ລະຫັດລູກຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ປະເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່ລູກຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[4].HeaderText = "ຍອດຊື້";
        }

        public void cleardata()
        {
            txtName.Text = null;
            txtPhone.Text = null;
            txtName.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into customer values( 'Member' , N'" +
                txtName.Text + "', '" +
                txtPhone.Text + "', 0, 0)";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ເພິ່ມສຳເລັດ !!!");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update customer set " +
                 "cus_name =N'" + txtName.Text + "', " +
                 "cus_type ='Member', " +
                 "phone =N'" + txtPhone.Text + "', " +
                 "dis_percent = 0 where cus_id = '" + id + "'";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ແກ້ໄຂສຳເລັດ !!!");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from customer where cus_id = '" + id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
            }
        }
    }
}
