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
    public partial class staff : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from employee", cd.conder);
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
            dataGridView1.Columns[12].Width = 180;
            dataGridView1.Columns[13].Width = 180;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ:";
            dataGridView1.Columns[5].HeaderText = "ສະຖານະ";
            dataGridView1.Columns[6].HeaderText = "ແຂວງ";
            dataGridView1.Columns[7].HeaderText = "ເມືອງ";
            dataGridView1.Columns[8].HeaderText = "ບ້ານ";
            dataGridView1.Columns[9].HeaderText = "E-mail";
            dataGridView1.Columns[10].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[11].HeaderText = "ຕຳແໜ່ງ";
            dataGridView1.Columns[12].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView1.Columns[13].HeaderText = "ຮູບພາບ";

        }
        public staff()
        {
            InitializeComponent();
        }

        private void staff_Load(object sender, EventArgs e)
        {
            cd.connectja();
            sadaeng();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("insert into employee values(@Emid,@Gender,@Emname,@Emsurname,@DOB,@Emstatus,@Province,@District,@Village,@Email,@Tel,@Position,@Hiredate,@picture)", cd.conder);
            cmd.Parameters.AddWithValue("@Emid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Emname", txtname.Text);
            cmd.Parameters.AddWithValue("@Emsurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@Emstatus", txtstatus.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Position", txtposition.Text);
            cmd.Parameters.AddWithValue("@Hiredate", txtdate.Text);
            cmd.Parameters.AddWithValue("@picture", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imder = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtstatus.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtProvince.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtposition.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[13].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("update employee set Emid=@Emid,Gender=@Gender,Emname=@Emname,Emsurname=@Emsurname,DOB=@DOB,Emstatus=@Emstatus,Province=@Province,District=@District,Village=@Village,Email=@Email,Tel=@Tel,Position=@Position,Hiredate=@Hiredate,picture=@picture where Emid=@Emid", cd.conder);
            cmd.Parameters.AddWithValue("@Emid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Emname", txtname.Text);
            cmd.Parameters.AddWithValue("@Emsurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@Emstatus", txtstatus.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Position", txtposition.Text);
            cmd.Parameters.AddWithValue("@Hiredate", txtdate.Text);
            cmd.Parameters.AddWithValue("@picture", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("delete employee where Emid=@Emid", cd.conder);
            cmd.Parameters.AddWithValue("@Emid", txtid.Text);
            cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@Emname", txtname.Text);
            cmd.Parameters.AddWithValue("@Emsurname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@DOB", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@Emstatus", txtstatus.Text);
            cmd.Parameters.AddWithValue("@Province", txtProvince.Text);
            cmd.Parameters.AddWithValue("@District", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@Village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Tel", txttel.Text);
            cmd.Parameters.AddWithValue("@Position", txtposition.Text);
            cmd.Parameters.AddWithValue("@Hiredate", txtdate.Text);
            cmd.Parameters.AddWithValue("@picture", arr);
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
