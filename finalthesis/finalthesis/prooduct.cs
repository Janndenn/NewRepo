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

namespace finalthesis
{
    public partial class prooduct : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from product", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 150;
            dataGridView1.Columns[12].Width = 100;
            dataGridView1.Columns[13].Width = 100;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຄຳອະທິບາຍ";
            dataGridView1.Columns[3].HeaderText = "ປະເພດສິນຄ້າ";
            dataGridView1.Columns[4].HeaderText = "ຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView1.Columns[5].HeaderText = "ຫົວໜ່ວຍສິນຄ້າ";
            dataGridView1.Columns[6].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[7].HeaderText = "ລາຄານຳເຂົ້າ";
            dataGridView1.Columns[8].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[9].HeaderText = "ຜູ້ສະໜອງ";
            dataGridView1.Columns[10].HeaderText = "Promotion";
            dataGridView1.Columns[11].HeaderText = "ຈຳນວນpromotion";
            dataGridView1.Columns[12].HeaderText = "ລາຄາລວມ";
            dataGridView1.Columns[13].HeaderText = "ວັນpromotion";

        }
        public prooduct()
        {
            InitializeComponent();
        }
        public void cal()
        {
            if(!string.IsNullOrEmpty(txtqty.Text) && !string.IsNullOrEmpty(txtsale.Text))
            {
                txtprice.Text = (Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtsale.Text)).ToString();
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prooduct_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtdes.Text != "" && txttype.Text !="" && txtbrand.Text !="" && txtunit.Text !="" && txtqty.Text !="" && txtimp.Text !="" && txtsale.Text !="" && txtsup.Text !="" && txtpromo.Text !="" && txtnum.Text !="" && txtprice.Text !="" && txtdate.Text !="")
            {
                cmd = new SqlCommand("insert into product values(@proid,@proname,@ddesc,@typeid,@brandid,@unit,@jamnoun,@imprice,@saleprice,@supid,@promo,@numpro,@totalprice,@datepro)", cd.conder);
                cmd.Parameters.AddWithValue("@proid", txtid.Text);
                cmd.Parameters.AddWithValue("@proname", txtname.Text);
                cmd.Parameters.AddWithValue("@ddesc", txtdes.Text);
                cmd.Parameters.AddWithValue("@typeid", txttype.Text);
                cmd.Parameters.AddWithValue("@brandid", txtbrand.Text);
                cmd.Parameters.AddWithValue("@unit", txtunit.Text);
                cmd.Parameters.AddWithValue("@jamnoun", txtqty.Text);
                cmd.Parameters.AddWithValue("@imprice", txtimp.Text);
                cmd.Parameters.AddWithValue("@saleprice", txtsale.Text);
                cmd.Parameters.AddWithValue("@supid", txtsup.Text);
                cmd.Parameters.AddWithValue("@promo", txtpromo.Text);
                cmd.Parameters.AddWithValue("@numpro", txtnum.Text);
                cmd.Parameters.AddWithValue("@totalprice", txtprice.Text);
                cmd.Parameters.AddWithValue("@datepro", txtdate.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtsale_TextChanged(object sender, EventArgs e)
        {
            cal();
        }

        private void txtpromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            double qty, price, dis, amount, final;
            qty = double.Parse(txtqty.Text);
            price = double.Parse(txtsale.Text);
            amount = double.Parse(txtprice.Text);
            dis = double.Parse(txtpromo.Text);
            final = dis * amount / 100;
            txtprice.Text = (amount - final).ToString();
        }

        private void txtimp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
