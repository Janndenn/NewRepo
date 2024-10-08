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
namespace cpr2023
{
    public partial class Staff : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from staff", cd.conder);
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
            dataGridView1.Columns[14].Width = 180;



            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ:";
            dataGridView1.Columns[5].HeaderText = "ບ້ານ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ແຂວງ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[9].HeaderText = "E-mail";
            dataGridView1.Columns[10].HeaderText = "facebook";
            dataGridView1.Columns[11].HeaderText = "ພະແນກ";
            dataGridView1.Columns[12].HeaderText = "ຕຳແໜ່ງ";
            dataGridView1.Columns[13].HeaderText = "ວຸດທິການສຶກສາ";
            dataGridView1.Columns[14].HeaderText = "ຮູບພາບ";

        }
        SqlDataAdapter dadepart = new SqlDataAdapter();
        DataSet dsdepart = new DataSet();
        Connectder cddepart = new Connectder();
        SqlCommand cmddepart = new SqlCommand();
        DataTable dtdepart = new DataTable();
        public void departder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select dep_name from department",cd.conder);
            dp.Fill(dtdepart);
            txtdepartment.DataSource = dtdepart;
            txtdepartment.DisplayMember = "dep_name";
            txtdepartment.ValueMember = "dep_name";

        }
        SqlDataAdapter posider = new SqlDataAdapter();
        DataSet dsps = new DataSet();
        Connectder cdps = new Connectder();
        SqlCommand cmdps = new SqlCommand();
        DataTable dtps = new DataTable();
        public void positionder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select po_name from position", cd.conder);
            dp.Fill(dtps);
            txtposition.DataSource = dtps;
            txtposition.DisplayMember = "po_name";
            txtposition.ValueMember = "po_name";

        }
        SqlDataAdapter quader = new SqlDataAdapter();
        DataSet dsqua = new DataSet();
        Connectder cdqua = new Connectder();
        SqlCommand cmdqua = new SqlCommand();
        DataTable dtqua = new DataTable();
        public void qualificationder()
        {
            SqlDataAdapter dp = new SqlDataAdapter("select q_name from qualification", cd.conder);
            dp.Fill(dtqua);
            txtqualification.DataSource = dtqua;
            txtqualification.DisplayMember = "q_name";
            txtqualification.ValueMember = "q_name";

        }
        public Staff()
        {
            InitializeComponent();
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {
             cd.connectder();
            sadaeng();

            cddepart.connectder();
            departder();

            cdps.connectder();
            positionder();

            cdqua.connectder();
            qualificationder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog()== DialogResult.OK)
                {
                    imder = ofd.FileName;
                    pictureBox2.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Image img = pictureBox2.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("insert into staff values(@st_id,@gender,@st_name,@surname,@birthday,@village,@district,@province,@tel,@mail,@facebook,@department,@position,@qualification,@pic)",cd.conder);
            cmd.Parameters.AddWithValue("@st_id",txtstid.Text);
            cmd.Parameters.AddWithValue("@gender",txtgender.Text);
            cmd.Parameters.AddWithValue("@st_name", txtname.Text);
            cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@tel", txttel.Text);
            cmd.Parameters.AddWithValue("@mail", txtemail.Text);
            cmd.Parameters.AddWithValue("@facebook", txtfacebook.Text);
            cmd.Parameters.AddWithValue("@department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("@position", txtposition.Text);
            cmd.Parameters.AddWithValue("@qualification", txtqualification.Text);
            cmd.Parameters.AddWithValue("@pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not save"); }
        }

        private void txtdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Image img = pictureBox2.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            cmd = new SqlCommand("update staff set st_id=@st_id,gender=@gender,st_name=@st_name,surname=@surname,birthday=@birthday,village=@village,district=@district,province=@province,tel=@tel,mail=@mail,facebook=@facebook,department=@department,position=@position,qualification=@qualification,pic=@pic where st_id=@st_id", cd.conder);
            cmd.Parameters.AddWithValue("@st_id", txtstid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@st_name", txtname.Text);
            cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@tel", txttel.Text);
            cmd.Parameters.AddWithValue("@mail", txtemail.Text);
            cmd.Parameters.AddWithValue("@facebook", txtfacebook.Text);
            cmd.Parameters.AddWithValue("@department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("@position", txtposition.Text);
            cmd.Parameters.AddWithValue("@qualification", txtqualification.Text);
            cmd.Parameters.AddWithValue("@pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtstid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbirthday.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtfacebook.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtdepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtposition.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            txtqualification.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[14].Value);
            pictureBox2.Image = Image.FromStream(ms);


        }

        private void button9_Click(object sender, EventArgs e)
        {
            Image img = pictureBox2.Image;
            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            cmd = new SqlCommand("delete staff where st_id=@st_id", cd.conder);
            cmd.Parameters.AddWithValue("@st_id", txtstid.Text);
            cmd.Parameters.AddWithValue("@gender", txtgender.Text);
            cmd.Parameters.AddWithValue("@st_name", txtname.Text);
            cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
            cmd.Parameters.AddWithValue("@birthday", txtbirthday.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@tel", txttel.Text);
            cmd.Parameters.AddWithValue("@mail", txtemail.Text);
            cmd.Parameters.AddWithValue("@facebook", txtfacebook.Text);
            cmd.Parameters.AddWithValue("@department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("@position", txtposition.Text);
            cmd.Parameters.AddWithValue("@qualification", txtqualification.Text);
            cmd.Parameters.AddWithValue("@pic", arr);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("can not delete"); }
        }
        Bitmap bitmap;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
