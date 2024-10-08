using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace thesis
{
    public partial class employee : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Clonnecting cd = new Clonnecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
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
            dataGridView1.Columns[12].Width = 100;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ:";
            dataGridView1.Columns[5].HeaderText = "ບ້ານ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ແຂວງ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[9].HeaderText = "email";
            dataGridView1.Columns[10].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView1.Columns[11].HeaderText = "ລະຫັດຜ່ານ";
            dataGridView1.Columns[12].HeaderText = "ຮູບພາບ";
        }
        public employee()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void employee_Load(object sender, EventArgs e)
        {
            cd.connectjah();
            show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("insert into employee values(@em_id,@gender,@em_name,@em_surname,@birthday,@village,@district,@province,@phone,@email,@dateofhired, @passwordd,@picture)", cd.conder);
            cmd.Parameters.AddWithValue("@em_id", txtid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@em_name", txtname.Text);
            cmd.Parameters.AddWithValue("@em_surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@phone", txttel.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@dateofhired",txtdate.Text);
            cmd.Parameters.AddWithValue("@passwordd", txtpassword.Text);
            cmd.Parameters.AddWithValue("@picture", arr);
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
            txtbirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[12].Value);
            pictureBox1.Image = Image.FromStream(ms);
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

        private void button3_Click(object sender, EventArgs e)
        {

            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("delete employee where em_id=@em_id", cd.conder);
            cmd.Parameters.AddWithValue("@em_id", txtid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@em_name", txtname.Text);
            cmd.Parameters.AddWithValue("@em_surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@phone", txttel.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@dateofhired", txtdate.Text);
            cmd.Parameters.AddWithValue("@passwordd", txtpassword.Text);
            cmd.Parameters.AddWithValue("@picture", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not delete"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text !="" && txtsurname.Text !="" && txtbirthday.Text !="" && txtvillage.Text !="" && txtdistrict.Text !="" && txtprovince.Text != "" && txttel.Text !="" && txtemail.Text !="" && txtdate.Text !="" && txtpassword.Text != "")
            {
                cmd = new SqlCommand("update employee set em_id=@em_id,gender=@gender,em_name=@em_name,em_surname=@em_surname,birthday=@birthday,village=@village,district=@district,province=@province,phone=@phone,email=@email,dateofhired=@dateofhired,passwordd=@passwordd,picture=@picture", cd.conder);
                cmd.Parameters.AddWithValue("@em_id", txtid.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@em_name", txtname.Text);
                cmd.Parameters.AddWithValue("@em_surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                cmd.Parameters.AddWithValue("@village", txtvillage.Text);
                cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
                cmd.Parameters.AddWithValue("@province", txtprovince.Text);
                cmd.Parameters.AddWithValue("@phone", txttel.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@dateofhired", txtdate.Text);
                cmd.Parameters.AddWithValue("@passwordd", txtpassword.Text);
                cmd.Parameters.AddWithValue("@picture", arr);
                cmd.ExecuteNonQuery();
                show();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
