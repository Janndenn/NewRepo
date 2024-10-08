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

namespace final
{
    public partial class frmOrder : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id;

        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            getdata();
            getdataProduct();
            getDataSupplier();
            reset();
        }

        public void reset()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            txtCode.Text = db.User_id + DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.ToString("dd") + DateTime.UtcNow.ToString("mm");
            dateTimePicker1.Enabled= true;
            cbSupplier.Enabled = true;
        }

        public void delOrder()
        {
            string sqls = "delete from buy where code = '" + txtCode.Text + "'";
            SqlCommand cmds = new SqlCommand(sqls, db.Connect());
            cmds.ExecuteNonQuery();

            string sql = "delete from buy_detail where buy_code = '" + txtCode.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, db.Connect());
            cmd.ExecuteNonQuery();
        }

        public void disable()
        {
            dateTimePicker1.Enabled = false;
            cbSupplier.Enabled = false;
        }

        public void clear()
        {
            txtProId.Clear();
            txtProCode.Clear();
            txtProName.Clear();
            txtQty.Clear();
        }

        private void getdata()
        {
            DataTable dt = new DataTable();
            string sql = "select a.buy_detail_id, a.buy_code, a.product_id, b.code, b.pro_name, a.qty from buy_detail as a join product as b on a.product_id = b.product_id where a.buy_code = '"+ txtCode.Text +"'";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;

            dataGridView1.Columns[0].HeaderText = "ໄອດີສິນຄ້າສັ່ງຊື້";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດບິນສັ່ງຊື້";
            dataGridView1.Columns[2].HeaderText = "ໄອດີສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຈຳນວນ";
        }

        private void getdataProduct()
        {
            DataTable dt = new DataTable();
            if (txtSearch.Text != null)
            {
                string sql = "select a.product_id, a.code, a.pro_name, b.cate_name, c.brand_name, d.unit_name from product as a join category as b on a.cate_id = b.cate_id join brand as c on a.brand_id = c.brand_id join unit as d on a.unit_id = d.unit_id where a.pro_name like N'%" + txtSearch.Text + "%'";
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
            }
            else
            {
                string sql = "select a.product_id, a.code, a.pro_name, b.cate_name, c.brand_name, d.unit_name from product as a join category as b on a.cate_id = b.cate_id join brand as c on a.brand_id = c.brand_id join unit as d on a.unit_id = d.unit_id";
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
            }
            dt.Load(dr);
            dgvSearch.DataSource = dt;

            dgvSearch.Columns[0].Width = 100;
            dgvSearch.Columns[1].Width = 100;
            dgvSearch.Columns[2].Width = 100;
            dgvSearch.Columns[3].Width = 100;
            dgvSearch.Columns[4].Width = 100;
            dgvSearch.Columns[5].Width = 100;

            dgvSearch.Columns[0].HeaderText = "ໄອດີສິນຄ້າ";
            dgvSearch.Columns[1].HeaderText = "ລະຫັດສິນຄ້າ";
            dgvSearch.Columns[2].HeaderText = "ຊື່ສິນຄ້າ";
            dgvSearch.Columns[3].HeaderText = "ຊື່ປະເພດ";
            dgvSearch.Columns[4].HeaderText = "ຊື່ຍີ່ຫໍ້";
            dgvSearch.Columns[5].HeaderText = "ຊື່ຫົວໜ່ວຍ";
        }

        public void getDataSupplier()
        {
            cmd = new SqlCommand("select * from supplier", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cbSupplier.DataSource = dt;
            cbSupplier.DisplayMember = "supplier_name";
            cbSupplier.ValueMember = "supplier_id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getdataProduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void dgvSearch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dgvSearch.CurrentRow.Index;
            txtProId.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            txtProCode.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            txtProName.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString();
            txtUnit.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != "")
                {
                    

                    string sql = "insert into buy_detail values(" +
                    txtCode.Text + "," + txtProId.Text + "," + txtQty.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, db.Connect());
                    cmd.ExecuteNonQuery();
                    getdata();
                    disable();
                    clear();
                    MessageBox.Show("ເພີ່ມສຳເລັດ");
                }
                else
                {
                    MessageBox.Show("ກະລຸນາປ້ອນຈຳນວນສິນຄ້າກ່ອນ");
                }
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Are you sure for clear ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delOrder();
                reset();
                clear();
                getdata();

                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                txtQty.Enabled = true;
                dataGridView1.Enabled = true;
                dgvSearch.Enabled = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dataGridView1.CurrentRow.Index;
            txtProId.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtProCode.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtProName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtQty.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update buy_detail set " +
                 "qty =" + txtQty.Text + " where product_id = " + txtProId.Text + " and buy_code = '"+ txtCode.Text +"'";
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                clear();
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
                string sql = "delete from buy_detail where product_id = " + txtProId.Text + " and buy_code = '" + txtCode.Text + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getdata();
                clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
                string sqls = "insert into buy values('" + dateTimePicker1.Text + "','" + txtCode.Text + "',1," + cbSupplier.SelectedValue + ",'p')";
                SqlCommand cmds = new SqlCommand(sqls, db.Connect());
                cmds.ExecuteNonQuery();

                frmReportBillBuy frm = new frmReportBillBuy(txtCode.Text);
                frm.Show();

                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                txtQty.Enabled = false;
                dataGridView1.Enabled = false;
                dgvSearch.Enabled = false;

                
            //}
            //catch
            //{
            //    MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            //}
        }
    }
}
