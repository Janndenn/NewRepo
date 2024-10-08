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
    public partial class frmProblem : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        float _total; float _qty; float _result;
        string id;

        public frmProblem()
        {
            InitializeComponent();
        }

        public void clear()
        {
            txtCode.Clear();
            txtProId.Clear();
            txtProCode.Clear();
            txtProName.Clear();
            txtQty.Clear();
            //txtPrice.Clear();
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
            txtCode.Text = dgvSearch.CurrentRow.Cells[0].Value.ToString();
            txtProId.Text = dgvSearch.CurrentRow.Cells[1].Value.ToString();
            txtProCode.Text = dgvSearch.CurrentRow.Cells[2].Value.ToString();
            txtProName.Text = dgvSearch.CurrentRow.Cells[3].Value.ToString();
            txtUnit.Text = dgvSearch.CurrentRow.Cells[5].Value.ToString();
            txtQty.Text = dgvSearch.CurrentRow.Cells[4].Value.ToString();
            //txtPrice.Text = dgvSearch.CurrentRow.Cells[6].Value.ToString();
            //_qty += Int32.Parse(dgvSearch.CurrentRow.Cells[4].Value.ToString());
            //_total += Int32.Parse(dgvSearch.CurrentRow.Cells[6].Value.ToString());
        }

        private void frmProblem_Load(object sender, EventArgs e)
        {
            getData();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        public void getData()
        {
            DataTable dt = new DataTable();
            string sql = "select a.problem_id, a.valuedt, a.code, a.product_id, b.code, b.pro_name, a.qty, d.unit_name from problem as a join product as b on a.product_id = b.product_id join unit as d on b.unit_id = d.unit_id where a.code = '" + txtCode.Text + "'";
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
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;

            dataGridView1.Columns[0].HeaderText = "ໄອດີປ່ຽນສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ວັນທີ";
            dataGridView1.Columns[2].HeaderText = "ລະຫັດບິນຂາຍ";
            dataGridView1.Columns[3].HeaderText = "ໄອດີສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[6].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[7].HeaderText = "ຊື່ຫົວໜ່ວຍ";
        }

        public void getDataSale()
        {
            DataTable dt = new DataTable();
            string sql = "select a.sale_ful_id, a.product_id, b.code, b.pro_name, a.qty, d.unit_name, a.price from sale_detail as a join product as b on a.product_id = b.product_id join unit as d on b.unit_id = d.unit_id where a.sale_ful_id = '" + txtSearch.Text + "'";
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
            dgvSearch.Columns[5].Width = 100;

            dgvSearch.Columns[0].HeaderText = "ລະຫັດບິນຂາຍ";
            dgvSearch.Columns[1].HeaderText = "ໄອດີສິນຄ້າ";
            dgvSearch.Columns[2].HeaderText = "ລະຫັດສິນຄ້າ";
            dgvSearch.Columns[3].HeaderText = "ຊື່ສິນຄ້າ";
            dgvSearch.Columns[4].HeaderText = "ຈຳນວນ";
            dgvSearch.Columns[5].HeaderText = "ຊື່ຫົວໜ່ວຍ";
            dgvSearch.Columns[6].HeaderText = "ເງິນລວມຊື້ສິນຄ້າ";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            getDataSale();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text != "")
            {
                //int s = int.Parse(txtPrice.Text) / int.Parse(txtQty.Text);
                //MessageBox.Show(_total.ToString());
                //_result = s * float.Parse(txtQty.Text);
                //txtPrice.Text = _result.ToString("#,###.00");
            }
            else
            {
                //txtPrice.Text = "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != "")
                {
                    string sql = "insert into problem values('" +
                    dateTimePicker1.Text + "','" + txtCode.Text + "'," + txtProId.Text + ", " + txtQty.Text + ")";
                    SqlCommand cmd = new SqlCommand(sql, db.Connect());
                    cmd.ExecuteNonQuery();

                    string sqls = "select product_id, pro_name, cate_id, qty, price, detail from product where product_id = '" + txtProId.Text + "'";
                    cmd = new SqlCommand(sqls, db.Connect());
                    dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    if (dt.Rows.Count > 0)
                    {
                        DataRow rows = dt.Rows[0];
                        int count = Int32.Parse(rows["qty"].ToString()) - Int32.Parse(txtQty.Text);

                        string sqlss = "update product set qty=" +
                           count + " where product_id='" +
                           txtProId.Text + "'";
                        cmd = new SqlCommand(sqlss, db.Connect());
                        cmd.ExecuteNonQuery();
                    }
                    //string sqls = "update product set qty= " + txtQty.Text + " where product_id='" + txtProId.Text + "'";
                    //SqlCommand cmds = new SqlCommand(sqls, db.Connect());
                    //cmds.ExecuteNonQuery();

                    getData();
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
            string sql = "delete from problem where problem_id = " + id + "";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                getData();
                clear();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cindex = dataGridView1.CurrentRow.Index;
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCode.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtProId.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtProName.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtProCode.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtQty.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtUnit.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            getData();
        }
    }
}
