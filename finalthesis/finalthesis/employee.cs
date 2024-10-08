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
using System.Xml.Linq;

namespace finalthesis
{
    public partial class employee : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void employee_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("insert into employee values(@emid,@gender,@emname,@emsurname,@birthday,@village,@district,@province,@tel,@email,@datehire,@pass,@pic)", cd.conder);
                cmd.Parameters.AddWithValue("@emid", txtid.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@emname", txtname.Text);
                cmd.Parameters.AddWithValue("@emsurname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@district", txtdt.Text);
                cmd.Parameters.AddWithValue("@province", txtpv.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@datehire", txtdate.Text);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                cmd.Parameters.AddWithValue("@pic", arr);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            if (txtid.Text != "" && txtgender.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("update employee set emid=@emid,gender=@gender,emname=@emname,emsurname=@emsurname,birthday=@birthday,village=@village,district=@district,province=@province,tel=@tel,email=@email,datehire=@datehire,pass=@pass,pic=@pic", cd.conder);
                cmd.Parameters.AddWithValue("@emid", txtid.Text);
                cmd.Parameters.AddWithValue("@gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@emname", txtname.Text);
                cmd.Parameters.AddWithValue("@emsurname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@district", txtdt.Text);
                cmd.Parameters.AddWithValue("@province", txtpv.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@datehire", txtdate.Text);
                cmd.Parameters.AddWithValue("@pass", txtpass.Text);
                cmd.Parameters.AddWithValue("@pic", arr);
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
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtvl.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdt.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtpv.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtdate.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtpass.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[12].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }
    }
}
