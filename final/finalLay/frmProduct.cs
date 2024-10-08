using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace final
{
    public partial class frmProduct : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string id = null;
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog opFdl = new OpenFileDialog();
            opFdl.Filter = "(Image Type *.png;*.jpg;*.gif)|*.png;*.jpg;*.gif";
            if (opFdl.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opFdl.FileName);
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            refresh();
        }

        public void refresh()
        {
            getdata();
            getDataCate();
            getDataBrand();
            getDataUnit();
        }

        private void getdata()
        {
            string sql = "select a.img, a.product_id, a.pro_name, b.cate_id, b.cate_name, c.brand_id, c.brand_name, d.unit_id, d.unit_name, a.qty, a.price, a.detail from product as a join category as b on a.cate_id = b.cate_id join brand as c on a.brand_id = c.brand_id join unit as d on a.unit_id = d.unit_id";
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
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;
            dataGridView1.Columns[8].Width = 200;
            dataGridView1.Columns[9].Width = 200;
            dataGridView1.Columns[10].Width = 200;
            dataGridView1.Columns[11].Width = 600;

            dataGridView1.Columns[0].HeaderText = "ຮູບພາບ";
            dataGridView1.Columns[1].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຊື່ສິນຄ້າ";
            dataGridView1.Columns[3].HeaderText = "ລະຫັດປະເພດ";
            dataGridView1.Columns[4].HeaderText = "ຊື່ປະເພດ";
            dataGridView1.Columns[5].HeaderText = "ລະຫັດຍີ່ຫໍ້";
            dataGridView1.Columns[6].HeaderText = "ຊື່ຍີ່ຫໍ້";
            dataGridView1.Columns[7].HeaderText = "ລະຫັດຫົວໜ່ວຍ";
            dataGridView1.Columns[8].HeaderText = "ຊື່ຫົວໜ່ວຍ";
            dataGridView1.Columns[9].HeaderText = "ຈຳນວນສິນຄ້າ";
            dataGridView1.Columns[10].HeaderText = "ລາຄາສິນຄ້າ";
            dataGridView1.Columns[11].HeaderText = "ລາຍລະອຽດ";
        }

        public void getDataCate()
        {
            cmd = new SqlCommand("select * from category", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboCate.DataSource = dt;
            cboCate.DisplayMember = "cate_name";
            cboCate.ValueMember = "cate_id";
        }

        public void getDataBrand()
        {
            cmd = new SqlCommand("select * from brand", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cbBrand.DataSource = dt;
            cbBrand.DisplayMember = "brand_name";
            cbBrand.ValueMember = "brand_id";
        }

        public void getDataUnit()
        {
            cmd = new SqlCommand("select * from unit", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cbUnit.DataSource = dt;
            cbUnit.DisplayMember = "unit_name";
            cbUnit.ValueMember = "unit_id";
        }

        private void cleardata()
        {
            txtCode.Clear();
            txtName.Clear();
            cboCate.DataSource = null;
            txtPrice.Clear();
            cbBrand.DataSource = null;
            cbUnit.DataSource = null;
            txtDescription.Clear();
            pictureBox1.Image = null;
            txtCode.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into product values('" +
                txtCode.Text + "'," +
                cboCate.SelectedValue + "," +
                cbBrand.SelectedValue + "," +
                cbUnit.SelectedValue + ",N'" +
                txtName.Text + "',0," +
                txtPrice.Text + ",@pro_img,N'" +
                txtDescription.Text + "')";
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] btimg = ms.GetBuffer();
                cmd = new SqlCommand(sql, db.Connect());
                cmd.Parameters.AddWithValue("@pro_img", btimg);
                cmd.ExecuteNonQuery();
                cleardata();
                refresh();
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
            int cindex = dataGridView1.CurrentRow.Index;
            id = dataGridView1.Rows[cindex].Cells[1].Value.ToString();
            txtName.Text = dataGridView1.Rows[cindex].Cells[2].Value.ToString();
            cboCate.SelectedValue = dataGridView1.Rows[cindex].Cells[3].Value.ToString();
            cbBrand.SelectedValue = dataGridView1.Rows[cindex].Cells[5].Value.ToString();
            cbUnit.SelectedValue = dataGridView1.Rows[cindex].Cells[7].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[cindex].Cells[10].Value.ToString();
            txtDescription.Text = dataGridView1.Rows[cindex].Cells[11].Value.ToString();
            if (dataGridView1.Rows[cindex].Cells[0].Value.ToString() != "")
            {
                var img = (byte[])dataGridView1.Rows[cindex].Cells[0].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update product set pro_name=N'" +
               txtName.Text + 
               "',brand_id='" +
               cbBrand.SelectedValue + 
               "',price='" +
               txtPrice.Text + 
               "',cate_id=" +
               cboCate.SelectedValue + 
               ",detail=N'" +
               txtDescription.Text + 
               "',img=@pro_img,unit_id=" +
               cbUnit.SelectedValue + " where product_id='" +
               id + "'";
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] btimg = ms.GetBuffer();
                cmd = new SqlCommand(sql, db.Connect());
                cmd.Parameters.AddWithValue("@pro_img", btimg);
                cmd.ExecuteNonQuery();
                getdata();
                cleardata();
                getDataCate();
                MessageBox.Show("ແກ້ໄຂສຳເລັດ");
            }
            catch(Exception ex)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from product where product_id = '" + id + "'";
            if (MessageBox.Show(" Are you sure?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();
                cleardata();
                refresh();
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
