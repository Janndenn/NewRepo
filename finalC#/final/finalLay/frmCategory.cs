using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace final
{
    public partial class frmCategory : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        string cate_id;
        DbConnect db = new DbConnect();
        public frmCategory()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string sql = "select cate_id, cate_name from category";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 400;
            dataGridView1.Columns[1].Width = 400;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດປະເພດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ປະເພດສິນຄ້າ";
        }

        int index;
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            cate_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into category values(N'" +
                txtName.Text + "')";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                cate_id = null;
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
                string sql = "update category set " +
                 "cate_name =N'" + txtName.Text + "' where cate_id = " + cate_id + "";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                cate_id = null;
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from category where cate_id = '" + cate_id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                txtName.Clear();
                cate_id = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            frmMainMenu frm = new frmMainMenu();
            frm.Show();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
