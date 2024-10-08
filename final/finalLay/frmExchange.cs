using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class frmExchange : Form
    {
        DbConnect db = new DbConnect();
        string id = null;
        public frmExchange()
        {
            InitializeComponent();
        }

        private void frmExchange_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select ex_id, ex_name, ex_rate from exchange";
            SqlCommand cmd = new SqlCommand(sql, db.Connect());
            db.dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(db.dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 400;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 400;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດອັດຕາແລກປ່ຽນ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ສະກຸນເງິນ";
            dataGridView1.Columns[2].HeaderText = "ອັດຕາແລກປ່ຽນ";
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update exchange set " +
                 "ex_name =N'" + txtName.Text + "', ex_rate = " + txtRate.Text + " where ex_id = " + id + "";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                txtRate.Clear();
                id = null;
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }
    }
}
