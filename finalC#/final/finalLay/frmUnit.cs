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
    public partial class frmUnit : Form
    {
        DbConnect db = new DbConnect();
        string id = null;
        public frmUnit()
        {
            InitializeComponent();
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select unit_id, unit_name from unit";
            SqlCommand cmd = new SqlCommand(sql, db.Connect());
            db.dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(db.dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 400;
            dataGridView1.Columns[1].Width = 400;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດຫົວໜ່ວຍສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ຫົວໜ່ວຍສິນຄ້າ";
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
                string sql = "insert into unit values(N'" +
                txtName.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                id = null;
                MessageBox.Show("ເພີ່ມສຳເລັດ");
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
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update unit set " +
                 "unit_name =N'" + txtName.Text + "' where unit_id = " + id + "";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                id = null;
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from unit where unit_id = '" + id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                id = null;
            }
        }
    }
}
