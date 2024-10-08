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
    public partial class supplier : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from supplier", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດຜູ້ສະໜອງ";
            dataGridView1.Columns[1].HeaderText = "ຊື້";
            dataGridView1.Columns[2].HeaderText = "ບ້ານ";
            dataGridView1.Columns[3].HeaderText = "ເມືອງ";
            dataGridView1.Columns[4].HeaderText = "ແຂວງ";
            dataGridView1.Columns[5].HeaderText = "ປະເທດ";
            dataGridView1.Columns[6].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[7].HeaderText = "Email";

        }
        public supplier()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtvillage.Text != "")
            {
                cmd = new SqlCommand("insert into supplier values(@supid,@supname,@village,@district,@province,@country,@tel,@email)", cd.conder);
                cmd.Parameters.AddWithValue("@supid", txtid.Text);
                cmd.Parameters.AddWithValue("@supname", txtname.Text);
                cmd.Parameters.AddWithValue("@village", txtvillage.Text);
                cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@province", txtprovince.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@tel", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
              
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtvillage.Text != "")
            {
                cmd = new SqlCommand("update supplier set supid=@supid,supname=@supname,village=@village,district=@district,province=@province,country=@country,tel=@tel,email=@email", cd.conder);
                cmd.Parameters.AddWithValue("@supid", txtid.Text);
                cmd.Parameters.AddWithValue("@supname", txtname.Text);
                cmd.Parameters.AddWithValue("@village", txtvillage.Text);
                cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@province", txtprovince.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@tel", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("update");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please update the data"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcountry.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtphone.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (txtid.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("delete supplier where supid=@supid", cd.conder);
                cmd.Parameters.AddWithValue("@supid", txtid.Text);
                cmd.Parameters.AddWithValue("@supname", txtname.Text);
                cmd.Parameters.AddWithValue("@village", txtvillage.Text);
                cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@province", txtprovince.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@tel", txtphone.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please click on the data"); }
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
           new employee().Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            customer customer = new customer();
            customer.show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            producttype producttype = new producttype();
            producttype.show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            brand brand = new brand();
            brand.show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            paymenttype paymenttype = new paymenttype();
            paymenttype.show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            exchange exchange = new exchange();
            exchange.show();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            employeerecord employeerecord = new employeerecord();
            employeerecord.show();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            new salerecord().Show();        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            productreport productreport = new productreport();
            productreport.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            Customoerrecord customoerrecord = new Customoerrecord();
            customoerrecord.Show();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            supplierRecord frm = new supplierRecord();
            frm.Show();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            ordersummery frm = new ordersummery();
            frm.Show();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            importrecord importrecord = new importrecord();
            importrecord.show();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            problemrecord problemrecord = new problemrecord();
            problemrecord.Show();

        }
    }
}
