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
using System.Xml.Linq;

namespace final
{
    public partial class frmImport : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        float total = 0;
        string id;
        public frmImport()
        {
            InitializeComponent();
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            reset();
            data();
        }

        public void delOrder()
        {
            string sqls = "delete from import where code = '" + txtCode.Text + "'";
            SqlCommand cmds = new SqlCommand(sqls, db.Connect());
            cmds.ExecuteNonQuery();

            string sql = "delete from import_detail where import_code = '" + txtCode.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, db.Connect());
            cmd.ExecuteNonQuery();

            data();
            MessageBox.Show("ລ້າງສຳເລັດ");
        }

        public void disable()
        {
            dateTimePicker1.Enabled = false;
        }

        public void reset()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            txtCode.Text = db.User_id + DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.ToString("dd") + DateTime.UtcNow.ToString("mm");
            dateTimePicker1.Enabled = true;
            rbBuy.Checked= true;
        }

        public void clear()
        {
            txtProId.Clear();
            txtProCode.Clear();
            txtProName.Clear();
            txtQty.Clear();
            txtPrice.Clear();
        }

        public void data()
        {
            DataTable dt = new DataTable();
            string sql = "select a.import_detail_id, a.import_code, a.product_id, b.code, b.pro_name, d.unit_name, a.qty, a.total from import_detail as a join product as b on a.product_id = b.product_id join unit as d on b.unit_id = d.unit_id where a.import_code = '" + txtCode.Text + "'";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;

            dataGridView1.Columns[0].HeaderText = "ໄອດີສິນຄ້ານຳເຂົ້າ";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດບິນບິນນຳເຂົ້າ";
            dataGridView1.Columns[2].HeaderText = "ໄອດີສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຫົວໜ່ວຍ";
            dataGridView1.Columns[6].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[7].HeaderText = "ເງິນ";

        }

        private void getdata()
        {
            if (rbBuy.Checked == true)
            {
                DataTable dt = new DataTable();
                string sql = "select a.buy_code, a.product_id, b.code, b.pro_name, a.qty, d.unit_name, a.qty from buy_detail as a join  buy as c on a.buy_code = c.code join product as b on a.product_id = b.product_id join unit as d on b.unit_id = d.unit_id where a.buy_code = '" + txtSearch.Text + "'";
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dgvSearch.DataSource = dt;

                dgvSearch.Columns[0].Width = 200;
                dgvSearch.Columns[1].Width = 100;
                dgvSearch.Columns[2].Width = 200;
                dgvSearch.Columns[3].Width = 200;
                dgvSearch.Columns[4].Width = 100;
                dgvSearch.Columns[5].Width = 100;
                dgvSearch.Columns[6].Width = 100;

                dgvSearch.Columns[0].HeaderText = "ລະຫັດບິນສັ່ງຊື້";
                dgvSearch.Columns[1].HeaderText = "ໄອດີສິນຄ້າ";
                dgvSearch.Columns[2].HeaderText = "ລະຫັດສິນຄ້າ";
                dgvSearch.Columns[3].HeaderText = "ຊື່ສິນຄ້າ";
                dgvSearch.Columns[4].HeaderText = "ຈຳນວນ";
                dgvSearch.Columns[5].HeaderText = "ຊື່ຫົວໜ່ວຍ";
                dgvSearch.Columns[6].HeaderText = "ຈຳນວນ";
            }
            else
            {
                DataTable dt = new DataTable();
                if (txtSearch.Text != null)
                {
                    string sql = "select a.product_id, a.code, a.pro_name, b.cate_name, c.brand_name, d.unit_name from product as a join category as b on a.cate_id = b.cate_id join brand as c on a.brand_id = c.brand_id join unit as d on a.unit_id = d.unit_id where a.pro_name like N'%" + txtSearch.Text + "%' or a.code = '"+ txtSearch.Text + "'";
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void dgvSearch_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (rbBuy.Checked == true)
            {
                int cindex = dgvSearch.CurrentRow.Index;
                txtProId.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
                txtProCode.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString();
                txtProName.Text = dgvSearch.CurrentRow.Cells[3].Value.ToString();
                txtUnit.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString();
                txtQty.Text = dgvSearch.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                int cindex = dgvSearch.CurrentRow.Index;
                txtProId.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
                txtProCode.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
                txtProName.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString();
                txtUnit.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString();
                txtQty.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Are you sure for clear ?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                delOrder();
                reset();
                clear();
                getdata();

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
                txtQty.Enabled = true;
                dataGridView1.Enabled = true;
                dgvSearch.Enabled = true;
                txtPrice.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                try
                {
                    if (txtQty.Text != "" && txtPrice.Text != "")
                    {
                        string sql = "insert into import_detail values(" +
                        txtCode.Text + "," + txtProId.Text + "," + txtQty.Text + ", "+ txtPrice.Text + ")";
                        SqlCommand cmd = new SqlCommand(sql, db.Connect());
                        cmd.ExecuteNonQuery();

                        string sqls = "update product set qty= " + txtQty.Text + " where product_id='" + txtProId.Text + "'";
                        SqlCommand cmds = new SqlCommand(sqls, db.Connect());
                        cmds.ExecuteNonQuery();

                        total += (float.Parse(txtPrice.Text) * float.Parse(txtQty.Text));

                        data();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from import_detail where product_id = " + txtProId.Text + " and import_code = '" + txtCode.Text + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                data();
                clear();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dataGridView1.CurrentRow.Index;
            txtProId.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtProCode.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtProName.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtUnit.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtQty.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sqls = "insert into import values('" +
                dateTimePicker1.Text + "','" + txtCode.Text + "',1,1," + total + ",1)";
                SqlCommand cmds = new SqlCommand(sqls, db.Connect());
                cmds.ExecuteNonQuery();

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                txtQty.Enabled = false;
                dataGridView1.Enabled = false;
                dgvSearch.Enabled = false;
                txtPrice.Enabled = false;

                MessageBox.Show("ບັນທຶກສຳເລັດ");
            }
            catch
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່ !!!");
            }
}

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
