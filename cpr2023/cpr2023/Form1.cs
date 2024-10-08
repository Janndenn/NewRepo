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

namespace cpr2023
{
    public partial class Form1 : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds= new DataSet();
        Connectder cd= new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from staffder",cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 250;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນ ເດືອນ ປີເກີດ";
            dataGridView1.Columns[5].HeaderText = "ບ້ານ";
            dataGridView1.Columns[6].HeaderText = "ເມືອງ";
            dataGridView1.Columns[7].HeaderText = "ແຂວງ";
            dataGridView1.Columns[8].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[9].HeaderText = "Email";
            dataGridView1.Columns[10].HeaderText = "Facebook";
            dataGridView1.Columns[11].HeaderText = "ພະແນກ";
            dataGridView1.Columns[12].HeaderText = "ຕຳແໜ່ງ";
            dataGridView1.Columns[13].HeaderText = "ວຸດທິການສຶກສາ";
            dataGridView1.Columns[14].HeaderText = "ຮູບພາບ";
            

        }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cd.connectder();
            sadaeng();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            department dt = new department() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Position dt = new Position() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Qualification dt = new Qualification() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Staff dt = new Staff() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            salary dt = new salary() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            userder dt = new userder() { TopLevel = false, TopMost = true };
            dt.FormBorderStyle = FormBorderStyle.None;
            panel3.Controls.Add(dt);
            dt.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
