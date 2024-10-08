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
    public partial class department : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from department", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 395;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ພະແນກ";
        }
        public department()
        {
            InitializeComponent();
            
        }

        private void department_Load(object sender, EventArgs e)
        {
            cd.connectder();
            sadaeng();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into department values(@dep_name)", cd.conder);
            cmd.Parameters.AddWithValue("@dep_name",txtdepname.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT SAVE"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdepname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update department set dep_name=@dep_name where dep_id=@dep_id", cd.conder);
            cmd.Parameters.AddWithValue("@dep_id",ID.Text);
            cmd.Parameters.AddWithValue("@dep_name", txtdepname.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT UPDATE"); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete department where dep_id=@dep_id", cd.conder);
            cmd.Parameters.AddWithValue("@dep_id", ID.Text);
            cmd.Parameters.AddWithValue("@dep_name", txtdepname.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT DELETE"); }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
        Bitmap bitmap;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0,0,dataGridView1.Width, dataGridView1.Height));
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
