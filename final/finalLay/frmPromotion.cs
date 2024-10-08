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
    public partial class frmPromotion : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id;
        public frmPromotion()
        {
            InitializeComponent();
        }

        private void frmPromotion_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select supplier_id, supplier_name, phone, detail from supplier";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 500;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດຜູ້ສະໜອງ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ຜູ້ສະໜອງ";
            dataGridView1.Columns[2].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[3].HeaderText = "ລາຍລະອຽດ";
        }
        private void cleardata()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtCondition.Clear();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into supplier values(N'" +
                txtName.Text + "'," + " '" +
                txtPrice.Text + "', " + "N'" +
                txtCondition.Text + "')";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                MessageBox.Show("ເພິ່ມສຳເລັດ !!!");
            }
            catch {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtCondition.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update supplier set " +
                 "supplier_name =N'" + txtName.Text + "', " +
                 "detail =N'" + txtCondition.Text + "', " +
                 "phone =N'" + txtPrice.Text + "' " +
                 " where supplier_id = '" + id + "'";
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from supplier where supplier_id = '" + id + "'";
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
