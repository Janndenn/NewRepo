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

namespace testthesis
{
    public partial class order : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        public void show()
        {
            adt = new SqlDataAdapter("select proid,proname,ddesc,supname,typename,brandname,jamnoun,unit,imprice,totalprice from product", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            /*dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 180;
            dataGridView1.Columns[12].Width = 150;
            dataGridView1.Columns[13].Width = 180;*/

            dataGridView1.Columns[0].HeaderText = "ລະຫັດສິນຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ຊື້ສິນຄ້າ";
            dataGridView1.Columns[2].HeaderText = "ຄຳອະທິບາຍ";
           // dataGridView1.Columns[3].HeaderText = "supid";
            dataGridView1.Columns[3].HeaderText = "ຜູ້ສະໜອງ";
           // dataGridView1.Columns[5].HeaderText = "typeid";
            dataGridView1.Columns[4].HeaderText = "ປະເພດສິນຄ້າ";
            //dataGridView1.Columns[7].HeaderText = "brandid";
            dataGridView1.Columns[5].HeaderText = "ຍີ່ຫໍ້ສິນຄ້າ";
            dataGridView1.Columns[6].HeaderText = "ຈຳນວນ";
            dataGridView1.Columns[7].HeaderText = "ຫົວໜ່ວຍສິນຄ້າ";
            dataGridView1.Columns[8].HeaderText = "ລາຄານຳເຂົ້າ";
           // dataGridView1.Columns[12].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[9].HeaderText = "ລາຄາລວມ";
        }
        public order()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void order_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtproid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtproname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtdes.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txttype.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbrand.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtsol.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtunit.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtorderprice.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtid.Text) || string.IsNullOrEmpty(txtdate.Text) || string.IsNullOrEmpty(txtem.Text) || string.IsNullOrEmpty(txtproid.Text) || string.IsNullOrEmpty(txtproname.Text) || string.IsNullOrEmpty(txtsup.Text) || string.IsNullOrEmpty(txttype.Text) || string.IsNullOrEmpty(txtbrand.Text) || string.IsNullOrEmpty(txtqty.Text) || string.IsNullOrEmpty(txtunit.Text) || string.IsNullOrEmpty((string)txtorderprice.Text) || string.IsNullOrEmpty((string)txttotal.Text) || string.IsNullOrEmpty(txtprice.Text))
            { return; }
            ListViewItem item = new ListViewItem(txtid.Text);
            item.SubItems.Add(txtdate.Text);
            item.SubItems.Add(txtem.Text);
            item.SubItems.Add(txtproid.Text);
            item.SubItems.Add(txtproname.Text);
            item.SubItems.Add(txtdes.Text);
            item.SubItems.Add(txtsup.Text);
            item.SubItems.Add(txttype.Text);
            item.SubItems.Add(txtbrand.Text);
            item.SubItems.Add(txtqty.Text);
            item.SubItems.Add(txtunit.Text);
            item.SubItems.Add(txtorderprice.Text);
            item.SubItems.Add(txttotal.Text);
            item.SubItems.Add(txtprice.Text);
            ListView1.Items.Add(item);
            txtid.Clear();
            txtid.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count > 0)
                ListView1.Items.Remove(ListView1.SelectedItems[0]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Lst_item in ListView1.Items)
            {
                cmd = new SqlCommand("insert into orderr values(@orderid,@dateorder,@emid,@proid,@proname,@ddesc, @supname, @typename,@brandname,@orderqty,@unit,@orderprice,@totalprice, @finalprice)", cd.conder);
                cmd.Parameters.AddWithValue("@orderid", Lst_item.SubItems[0].Text);
                cmd.Parameters.AddWithValue("@dateorder", Lst_item.SubItems[1].Text);
                cmd.Parameters.AddWithValue("@emid", Lst_item.SubItems[2].Text);
                cmd.Parameters.AddWithValue("@proid", Lst_item.SubItems[3].Text);
                cmd.Parameters.AddWithValue("@proname", Lst_item.SubItems[4].Text);
                cmd.Parameters.AddWithValue("@ddesc", Lst_item.SubItems[5].Text);
                cmd.Parameters.AddWithValue("@supname", Lst_item.SubItems[6].Text);
                cmd.Parameters.AddWithValue("@typename", Lst_item.SubItems[7].Text);
                cmd.Parameters.AddWithValue("@brandname", Lst_item.SubItems[8].Text);
                cmd.Parameters.AddWithValue("@orderqty", Lst_item.SubItems[9].Text);
                cmd.Parameters.AddWithValue("@unit", Lst_item.SubItems[10].Text);
                cmd.Parameters.AddWithValue("@orderprice", Lst_item.SubItems[11].Text);
                cmd.Parameters.AddWithValue("@totalprice", Lst_item.SubItems[12].Text);
                cmd.Parameters.AddWithValue("@finalprice", Lst_item.SubItems[13].Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    show();
                }
                else { MessageBox.Show("data inserted!!"); }

            }
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery frm = new ordersummery();
            frm.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int.TryParse(txtorderprice.Text, out v1);
            int.TryParse(txtqty.Text, out v2);
            int.TryParse(txttotal.Text, out v3);
            int I = (v1 * v2);
            txttotal.Text = I.ToString();
            txtprice.Text = I.ToString();

        }
    }
}
