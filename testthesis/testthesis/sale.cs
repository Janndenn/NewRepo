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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace testthesis
{
    public partial class sale : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = new SqlConnection();
        public void show()
        {
            adt = new SqlDataAdapter("select proid,proname,ddesc,supname,typename,brandname,jamnoun,unit,saleprice,totalprice from product", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            //dataGridView1.Columns[10].Width = 180;
            /*dataGridView1.Columns[11].Width = 180;
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
            // dataGridView1.Columns[8].HeaderText = "ລາຄານຳເຂົ້າ";
            dataGridView1.Columns[8].HeaderText = "ລາຄາຂາຍ";
            dataGridView1.Columns[9].HeaderText = "ລາຄາລວມ";
        }
        public sale()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sale_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();

            Fillcombo();
            Fillcombocurrency();

        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtproid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtproname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtp.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtsol.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }
        private void Fillcombo()
        {
            SqlConnection conn = new SqlConnection("Data Source=JANNDENN\\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
            SqlCommand cmd = new SqlCommand("select namepm from paymenttype", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbluy.DataSource = dt;
            cmbluy.DisplayMember = "namepm";

        }
        private void Fillcombocurrency()
        {
            SqlConnection conn = new SqlConnection("Data Source=JANNDENN\\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
            SqlCommand cmd = new SqlCommand("select currency from exchange", conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbcrc.DataSource = dt;
            cmbcrc.DisplayMember = "currency";



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcrc.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select exchange from exchange where currency=@currency", tor);
                cc.Parameters.AddWithValue("@currency", cmbcrc.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    cmbcrc.Text = rdr.GetValue(0).ToString();


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(txtproid.Text) || string.IsNullOrEmpty(txtproname.Text) || string.IsNullOrEmpty(txtp.Text) || string.IsNullOrEmpty(txtqty.Text) || string.IsNullOrEmpty(txttotal.Text))
            { return; }
            ListViewItem item = new ListViewItem(txtproid.Text);
            item.SubItems.Add(txtproname.Text);
            item.SubItems.Add(txtp.Text);
            item.SubItems.Add(txtqty.Text);
            item.SubItems.Add(txttotal.Text);
            ListView1.Items.Add(item);
            txtid.Clear();
            txtid.Focus();

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtdate.Text != "" && txtem.Text != "")
            {
                cmd = new SqlCommand("insert into sale values(@saleid,@saledate,@emid,@cusid,@cusname,@proid,@proname,@unitprice,@discount,@amount,@saleqty,@totalprice,@grandtotal,@paymenttype,@currency)", cd.conder);
                cmd.Parameters.AddWithValue("@saleid", txtid.Text);
                cmd.Parameters.AddWithValue("@saledate", txtdate.Text);
                cmd.Parameters.AddWithValue("@emid", txtem.Text);
                cmd.Parameters.AddWithValue("@cusid", txtcus.Text);
                cmd.Parameters.AddWithValue("@cusname", txtcusname.Text);
                cmd.Parameters.AddWithValue("@proid", txtproid.Text);
                cmd.Parameters.AddWithValue("@proname", txtproname.Text);
                cmd.Parameters.AddWithValue("@unitprice", txtp.Text);
                cmd.Parameters.AddWithValue("@discount", txtdis.Text);
                cmd.Parameters.AddWithValue("@amount", txtamount.Text);
                cmd.Parameters.AddWithValue("@saleqty", txtqty.Text);
                cmd.Parameters.AddWithValue("@totalprice", txttotal.Text);
                cmd.Parameters.AddWithValue("@grandtotal", txtfinal.Text);
                cmd.Parameters.AddWithValue("@paymenttype", cmbluy.Text);
                cmd.Parameters.AddWithValue("@currency", cmbcrc.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
        }


        private void txtcus_TextChanged(object sender, EventArgs e)
        {
            if (txtcus.Text != "")
            {
                SqlConnection co = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                co.Open();
                SqlCommand cc = new SqlCommand("select cusname from customer where cusid=@cusid", co);
                cc.Parameters.AddWithValue("@cusid", txtcus.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtcusname.Text = rdr.GetValue(0).ToString();


                }
            }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            int v1 = 0;
            int v2 = 0;
            int v3 = 0;
            int.TryParse(txtamount.Text, out v1);
            int.TryParse(txtqty.Text, out v2);
            int.TryParse(txttotal.Text, out v3);
            int I = (v1 * v2);
            txttotal.Text = I.ToString();
        }
        public double subtot()
        {
            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }


        private void txtpromo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int val1 = 0;
            int val2 = 0;
            int val3 = 0;
            int.TryParse(txtp.Text, out val1);
            int.TryParse(txtdis.Text, out val2);
            int.TryParse(txtamount.Text, out val3);
            int I = (val1 * val2) / 100;
            int l = (val1 - I);
            txtamount.Text = l.ToString();
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListView1.Items.Count > 0)
                ListView1.Items.Remove(ListView1.SelectedItems[0]);
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            salerecord frm = new salerecord();
            frm.Show();

        }

        private void cmbluy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsol_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 12);
            float yPos = 100;
            float leftMargin = e.MarginBounds.Left;
            float rightMargin = e.MarginBounds.Right;
            float lineHeight = font.GetHeight(e.Graphics);

            // Draw header
            e.Graphics.DrawString("Sales Report", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
            yPos += lineHeight + 20;

            // Draw column headers
            foreach (ColumnHeader column in ListView1.Columns)
            {
                e.Graphics.DrawString(column.Text, font, Brushes.Black, leftMargin, yPos);
                leftMargin += column.Width;
            }

            yPos += lineHeight;
            leftMargin = e.MarginBounds.Left;

            // Draw items
            foreach (ListViewItem item in ListView1.Items)
            {
                float xPos = leftMargin;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    e.Graphics.DrawString(subItem.Text, font, Brushes.Black, xPos, yPos);
                    xPos += ListView1.Columns[item.SubItems.IndexOf(subItem)].Width;
                }

                yPos += lineHeight;
            }
        }
        private double GetSumOfColumnValues()
        {
            double sum = 0;

            foreach (ListViewItem item in ListView1.Items)
            {
                if (double.TryParse(item.SubItems[4].Text, out double value))
                {
                    sum += value;
                }
            }

            return sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double sum = GetSumOfColumnValues();
            txtfinal.Text = sum.ToString();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user frm = new user();
            frm.show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            product frm = new product();
                frm.show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            employee frm = new employee();
            frm.show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            supplier frm = new supplier();
            frm.show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            producttype frm = new producttype();
            frm.show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            brand brand = new brand();
            brand.show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            paymenttype frm = new paymenttype();
            frm.show();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            exchange exchange = new exchange(); 
            exchange.show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord frm = new employeerecord();
            frm.show();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport frm = new productreport();
            frm.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Customoerrecord frm = new Customoerrecord();
            frm.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            supplierRecord frm = new supplierRecord();
            frm.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery record = new ordersummery();
            record.show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord frm = new importrecord();
            frm.show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord frm = new problemrecord();
            frm.Show();
        }
    }
}
