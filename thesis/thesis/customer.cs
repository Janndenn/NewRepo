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
using System.Dynamic;
using System.IO;
using System.Drawing.Imaging;
using System.Xml.Linq;

namespace thesis
{
    public partial class customer : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Clonnecting cd = new Clonnecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from customer", cd.conder);
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
            dataGridView1.Columns[8].Width = 150;
            dataGridView1.Columns[9].Width = 150;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດລູກຄ້າ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື້";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເກີດ";
            dataGridView1.Columns[5].HeaderText = "ບ້ານ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ແຂວງ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[9].HeaderText = "ລະຫັດຜ່ານ";

        }
        public customer()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            cd.connectjah();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into customer values(@cus_id,@gender,@cus_name,@cus_surname,@birthday,@village,@district,@province,@phone,@cus_pass)", cd.conder);
            cmd.Parameters.AddWithValue("@cus_id", txtid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@cus_name", txtname.Text);
            cmd.Parameters.AddWithValue("@cus_surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtdate.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@cus_pass", txtpass.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtphone.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtpass.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update customer set cus_id=@cus_id,gender=@gender,cus_name=@cus_name,cus_surname=@cus_surname,birthday=@birthday,village=@village,district=@district,province=@province,phone=@phone,cus_pass=@cus_pass", cd.conder);
            cmd.Parameters.AddWithValue("@cus_id", txtid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@cus_name", txtname.Text);
            cmd.Parameters.AddWithValue("@cus_surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtdate.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@cus_pass", txtpass.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not save"); }
        }
    }
}
