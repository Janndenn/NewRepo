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
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
namespace team
{
    public partial class customer : Form
    {
        
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
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
            dataGridView1.Columns[8].Width = 180;
   
            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ";
            dataGridView1.Columns[5].HeaderText = "ແຂວງ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ບ້ານ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";


        }

        public customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void customer_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into customer values(@Cusid,@Gender,@Cusname,@Cussurname,@DOB,@Province,@District,@Village,@Tel)", cd.conder);
            cmd.Parameters.AddWithValue("@Cusid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Cusname", txtname.Text);
            cmd.Parameters.AddWithValue("@Cussurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update customer set Cusid=@Cusid,Gender=@Gender,Cusname=@Cusname,Cussurname=@Cussurname,DOB=@DOB,Province=@Province,District=@District,Village=@Village,Tel=@Tel where Cusid=@Cusid", cd.conder);
            cmd.Parameters.AddWithValue("@Cusid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Cusname", txtname.Text);
            cmd.Parameters.AddWithValue("@Cussurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdob.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtProvince.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete customer where Cusid=@Cusid", cd.conder);
            cmd.Parameters.AddWithValue("@Cusid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Cusname", txtname.Text);
            cmd.Parameters.AddWithValue("@Cussurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtdob.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not delete"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
