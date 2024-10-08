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
    public partial class frmBrand : Form
    {
        DbConnect db = new DbConnect();
        string brand_id = null;
        public frmBrand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select brand_id, brand_name from brand";
            SqlCommand cmd = new SqlCommand(sql, db.Connect());
            db.dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(db.dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 400;
            dataGridView1.Columns[1].Width = 400;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ຍີ່ຫໍ້ສິນຄ້າ";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into brand values(N'" +
                txtName.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                brand_id = null;
                MessageBox.Show("ເພີ່ມສຳເລັດ");
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
                string sql = "update brand set " +
                 "brand_name =N'" + txtName.Text + "' where cate_id = " + brand_id + "";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                brand_id = null;
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
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
            brand_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from brand where brand_id = '" + brand_id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                brand_id = null;
            }
        }
    }
}
