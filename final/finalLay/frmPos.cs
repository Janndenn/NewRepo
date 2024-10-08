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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final
{
    public partial class frmPos : Form
    {
        DbConnect db = new DbConnect();
        SqlCommand cmd = null;
        SqlCommand cmds= null;
        SqlDataReader dr = null;
        SqlDataReader drs = null;
        frmPos obj = (frmPos)Application.OpenForms["frmPos"];

        private PictureBox pic;
        private Label price;
        private Label description;
        DateTime now = DateTime.UtcNow.Date;

        
        int _qty;
        double _tot = 0;
        double _sum = 0 ;
        double _discount_per = 0;
        double _discount = 0;
        string condition = "";
        string promotion_id;
        double _promotion_price = 0;
        string promotion_name;

        string cus_id = "1";

        public frmPos()
        {
            InitializeComponent();
        }

        private void frmPos_Load(object sender, EventArgs e)
        {
            txtCode.Text = DateTime.UtcNow.Year.ToString()+DateTime.UtcNow.Month.ToString()+DateTime.UtcNow.ToString("dd")+ DateTime.UtcNow.ToString("mm");
            txtDate.Text = DateTime.UtcNow.ToString("dd/MM/yyyy");
            getCus();
            getdata();
            getDataCate();
            pic.Cursor = Cursors.Hand;
        }

        public void getCus()
        {
            if (txtTel.Text != "")
            {
                string sqls = "select * from customer where cus_type = 'Member' and phone = '" + txtTel.Text + "'";
                cmd = new SqlCommand(sqls, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    DataRow rows = dt.Rows[0];
                    lbName.Text = rows["cus_name"].ToString();
                    lbTel.Text = rows["phone"].ToString();
                }
            }
            else
            {
                string sqls = "select * from customer where cus_id = 1";
                cmd = new SqlCommand(sqls, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    DataRow rows = dt.Rows[0];
                    lbName.Text = rows["cus_name"].ToString();
                    lbTel.Text = rows["phone"].ToString();
                }
            }
            
        }

        private void getdata()
        {
            int i;
            float m = 0;
            string sql;
            if (cboCate.SelectedValue != null)
            {
                sql = "select a.img, a.product_id, a.pro_name, b.cate_name, a.qty, a.price, a.detail from product as a join category as b on a.cate_id = b.cate_id where a.cate_id = " + cboCate.SelectedValue;
            }
            else
            {
                sql = "select a.img, a.product_id, a.pro_name, b.cate_name, a.qty, a.price, a.detail from product as a join category as b on a.cate_id = b.cate_id where qty > 0";
            }
            
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] buf = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, buf, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();
                pic.Width = 200;
                pic.Height = 200;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle= BorderStyle.Fixed3D;
                pic.Tag = dr["product_id"].ToString();

                price= new Label();
                m = Int32.Parse(dr["price"].ToString());
                price.Text = m.ToString("#,000");
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.Dock= DockStyle.Bottom;
                price.Tag = dr["product_id"].ToString();

                description = new Label();
                description.Text = dr["pro_name"].ToString();
                description.BackColor = Color.FromArgb(46, 134, 222);
                description.TextAlign = ContentAlignment.MiddleCenter;
                description.Dock = DockStyle.Top;
                description.Tag = dr["product_id"].ToString();

                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(ms);
                pic.BackgroundImage = b;

                pic.Controls.Add(description);
                pic.Controls.Add(price);

                flowLayoutPanel1.Controls.Add(pic);

                pic.Click += new EventHandler(onClick);
               
            }
            dr.Close();

            //for (i=1; i <= 15; i++)
            //{
            //    button = new Button();
            //    button.Width = 274;
            //    button.Height = 50;
            //    button.Text = "Table " + i;
            //    button.BackgroundImageLayout = ImageLayout.Stretch;

            //    flowLayoutPanel3.Controls.Add(button);
            //}
        }

        public void getDataCate()
        {
            //cboCate.SelectedIndexChanged -= cboCate_SelectedIndexChanged;

            cmd = new SqlCommand("select * from category", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cboCate.DataSource = dt;
            cboCate.DisplayMember = "cate_name";
            cboCate.ValueMember = "cate_id";
        }

        public void onClick(object sender, EventArgs e)
        {
            string pro_id;
            int pr;
            float m = 0;
            int qty = 0;
            string tag = ((PictureBox)sender).Tag.ToString();
            //MessageBox.Show(((PictureBox)sender).Tag.ToString());
            string sql = "select img, product_id, pro_name, cate_id, qty, price, detail from product where product_id = '" + tag +"'";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                _tot += double.Parse(dr["price"].ToString());
                m = Int32.Parse(dr["price"].ToString());
                pro_id = dr["product_id"].ToString();
                pr = Int32.Parse(dr["price"].ToString());
                dr.Close();

                cmd = new SqlCommand("select * from sale_detail where sale_ful_id = '" + txtCode.Text +"' and product_id = '" + pro_id + "'", db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                //drs.Close();    
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    qty = Int32.Parse(row["qty"].ToString()) +1;
                    string sqls = "update sale_detail set " +
                        "qty =" + qty + ", total = "+ pr*qty + " where sale_ful_id = '" + txtCode.Text + "' and product_id = '" + pro_id + "'";
                    cmd = new SqlCommand(sqls, db.Connect());
                    cmd.ExecuteNonQuery();
                    resetData();
                }
                else
                {
                    string sqls = "insert into sale_detail values('" +
                    txtCode.Text + "','" +
                    pro_id + "', " +
                    pr + ", " +
                    1 + ", " +
                    pr + ")";
                    cmd = new SqlCommand(sqls, db.Connect());
                    cmd.ExecuteNonQuery();
                    resetData();
                }
            }

            if (_tot >= 30000)
            {
                double r = (_tot * 5) / 100;
                _discount_per = 7;
                _discount = r;
                txtDiscount.Text = r.ToString("#,000");
            }
            else if(_tot >= 40000)
            {
                double r = (_tot * 7) / 100;
                _discount_per = 7;
                _discount = r;
                txtDiscount.Text = r.ToString("#,000");
            }
            else
            {
                _discount_per = 0;
                _discount = 0;
                txtDiscount.Text = "0";
            }
            
            _qty = dataGridView1.Rows.Count;
            label10.Text = _tot.ToString("#,000.00");
            label2.Text = (_tot - _discount).ToString("#,000.00");
        }
        
        private void resetData()
        {
            dataGridView1.Rows.Clear();
            int i;
            float m;
            cmd = new SqlCommand("select a.*, b.pro_name from sale_detail as a join product as b on a.product_id = b.product_id where a.sale_ful_id = '" + txtCode.Text +"'", db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dts = new DataTable();
            dts.Load(dr);

            if (dts.Rows.Count > 0)
            {
                for(i = 0; i < dts.Rows.Count; i++)
                {
                    DataRow row = dts.Rows[i];
                    m = Int32.Parse(row["total"].ToString());
                    dataGridView1.Rows.Add(dataGridView1.Rows.Count, row["product_id"].ToString(), row["pro_name"].ToString(), row["qty"].ToString(), m.ToString("#,000"));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _sum = _tot - _discount;
            try
            {

                int i;
                cmd = new SqlCommand("select a.*, b.pro_name from sale_detail as a join product as b on a.product_id = b.product_id where a.sale_ful_id = '" + txtCode.Text + "'", db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dts = new DataTable();
                dts.Load(dr);

                if (dts.Rows.Count > 0)
                {
                    for (i = 0; i < dts.Rows.Count; i++)
                    {
                        DataRow row = dts.Rows[i];
                        string sqls = "select img, product_id, pro_name, cate_id, qty, price, detail from product where product_id = '" + row["product_id"].ToString() + "'";
                        cmd = new SqlCommand(sqls, db.Connect());
                        dr = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        if (dt.Rows.Count > 0)
                        {
                            DataRow rows = dt.Rows[0];
                            int count = Int32.Parse(rows["qty"].ToString()) - Int32.Parse(row["qty"].ToString());

                            string sqlss = "update product set qty=" +
                               count + " where product_id='" +
                               row["product_id"].ToString() + "'";
                            cmd = new SqlCommand(sqlss, db.Connect());
                            cmd.ExecuteNonQuery();
                        }
                     }
                }

                string sql = "insert into sale values('" +
                 DateTime.UtcNow.ToString("yyyy-MM-dd") + "','" +
                txtCode.Text + "'," +
                _tot + ", " +
                _discount_per + ", " +
                _discount + ", " +
                _sum + ",1,1," +
                cus_id + ", " +
                1 + ")";
                cmd = new SqlCommand(sql, db.Connect());
                cmd.ExecuteNonQuery();

                flowLayoutPanel1.Enabled = false;
                dataGridView1.Enabled = false;
                btnAdd.Enabled = false;

                MessageBox.Show("ບັນທຶກສຳເລັດ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ເກິດຂໍ້ຜິດພາດກະລຸນາລອງໃໝ່");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                DialogResult result = MessageBox.Show("ທ່ານຕ້ອງການລົບລາຍການນີ້ ຫຼື ບໍ?", "ຢືນຢັນການລົບຂໍ້ມູນ", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    string c = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    string q = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    string p = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    float sum = Int32.Parse(c.Replace(",", "")) / Int32.Parse(q);
                    float count = Int32.Parse(q) - 1;
                    float total = Int32.Parse(c.Replace(",", "")) - sum;
                    int i;
                    _tot = _tot - sum;
                    label2.Text= _tot.ToString("#,##0.00");

                    cmd = new SqlCommand("select * from sale_detail where sale_ful_id = '" + txtCode.Text + "' and product_id = '" + p + "'", db.Connect());
                    dr = cmd.ExecuteReader();
                    DataTable dts = new DataTable();
                    dts.Load(dr);

                    if (dts.Rows.Count > 0)
                    {
                        for (i = 0; i < dts.Rows.Count; i++)
                        {
                            DataRow row = dts.Rows[i];
                            if (Int32.Parse(row["qty"].ToString()) > 1)
                            {
                                string sql = "update sale_detail set qty = "+ count +", total = "+ total +" where sale_ful_id = '" + txtCode.Text + "' and product_id = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                                cmd = new SqlCommand(sql, db.Connect());
                                cmd.ExecuteNonQuery();
                                resetData();
                            }
                            else
                            {
                                string sql = "delete from sale_detail where sale_ful_id = '" + txtCode.Text + "' and product_id = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                                cmd = new SqlCommand(sql, db.Connect());
                                cmd.ExecuteNonQuery();
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                resetData();
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("ເກີດຂໍ້ຜິດພາດ ກະລຸນາລອງໃໝ່");
            }
}

        private void txtCodePromotion_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmReportBill frm = new frmReportBill(txtCode.Text);
            frm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Enabled = true;
            dataGridView1.Enabled = true;
            btnAdd.Enabled = true;

            txtCode.Text = DateTime.UtcNow.Year.ToString() + DateTime.UtcNow.Month.ToString() + DateTime.UtcNow.ToString("dd") + DateTime.UtcNow.ToString("mm");

            promotion_id = null; promotion_name = null; _promotion_price = 0;txtDiscount.Text = null;_discount = 0;_discount_per = 0;cus_id = "1";
            dataGridView1.Rows.Clear();
            label2.Text = "0.00"; label10.Text = "0.00";
            _tot = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (flowLayoutPanel1 != null)
            {
                List<Control> listControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();

                foreach (Control control in listControls)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }
            }

            int i;
            float m = 0;
            string sql;

            sql = "select a.img, a.product_id, a.pro_name, b.cate_name, a.qty, a.price, a.detail from product as a join category as b on a.cate_id = b.cate_id where a.qty > 0";
           

            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] buf = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, buf, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();
                pic.Width = 200;
                pic.Height = 200;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.Fixed3D;
                pic.Tag = dr["product_id"].ToString();

                price = new Label();
                m = Int32.Parse(dr["price"].ToString());
                price.Text = m.ToString("#,000");
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.Dock = DockStyle.Bottom;
                price.Tag = dr["product_id"].ToString();

                description = new Label();
                description.Text = dr["pro_name"].ToString();
                description.BackColor = Color.FromArgb(46, 134, 222);
                description.TextAlign = ContentAlignment.MiddleCenter;
                description.Dock = DockStyle.Top;
                description.Tag = dr["product_id"].ToString();

                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(ms);
                pic.BackgroundImage = b;

                pic.Controls.Add(description);
                pic.Controls.Add(price);

                flowLayoutPanel1.Controls.Add(pic);

                pic.Click += new EventHandler(onClick);

            }
            dr.Close();
        }

        private void cboCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1 != null)
            {
                List<Control> listControls = flowLayoutPanel1.Controls.Cast<Control>().ToList();

                foreach (Control control in listControls)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                }
            }

            int i;
            float m = 0;
            string sql;

            sql = "select a.img, a.product_id, a.pro_name, b.cate_name, a.qty, a.price, a.detail from product as a join category as b on a.cate_id = b.cate_id where a.qty > 0 and a.cate_id = " + cboCate.SelectedValue;
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] buf = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, buf, 0, System.Convert.ToInt32(len));
                pic = new PictureBox();
                pic.Width = 200;
                pic.Height = 200;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BorderStyle = BorderStyle.Fixed3D;
                pic.Tag = dr["product_id"].ToString();

                price = new Label();
                m = Int32.Parse(dr["price"].ToString());
                price.Text = m.ToString("#,000");
                price.BackColor = Color.FromArgb(255, 121, 121);
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.Dock = DockStyle.Bottom;
                price.Tag = dr["product_id"].ToString();

                description = new Label();
                description.Text = dr["pro_name"].ToString();
                description.BackColor = Color.FromArgb(46, 134, 222);
                description.TextAlign = ContentAlignment.MiddleCenter;
                description.Dock = DockStyle.Top;
                description.Tag = dr["product_id"].ToString();

                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Bitmap b = new System.Drawing.Bitmap(ms);
                pic.BackgroundImage = b;

                pic.Controls.Add(description);
                pic.Controls.Add(price);

                flowLayoutPanel1.Controls.Add(pic);

                pic.Click += new EventHandler(onClick);

            }
            dr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getCus();
        }
    }
}
