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

namespace thesis
{
    public partial class supplier : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Clonnecting cd = new Clonnecting();
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
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດຜູ້ສະໜອງ";
            dataGridView1.Columns[1].HeaderText = "ຊື່";
            dataGridView1.Columns[2].HeaderText = "ບ້ານ";
            dataGridView1.Columns[3].HeaderText = "ເມືອງ";
            dataGridView1.Columns[4].HeaderText = "ແຂວງ";
            dataGridView1.Columns[5].HeaderText = "ປະເທດ";
            dataGridView1.Columns[6].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[7].HeaderText = "email";
          
        }
        public supplier()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            cd.connectjah();
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into supplier values(@sup_id,@sup_name,@village,@district,@province,@country,@phone,@email)", cd.conder);
            cmd.Parameters.AddWithValue("@sup_id", txtid.Text);
            cmd.Parameters.AddWithValue("@sup_name", txtname.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            cmd.Parameters.AddWithValue("@phone", txttel.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not save"); }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update supplier set sup_id=@sup_id,sup_name=@sup_name,village=@village,district=@district,province=@province,country=@country,phone=@phone,email=@email", cd.conder);
            cmd.Parameters.AddWithValue("@sup_id", txtid.Text);
            cmd.Parameters.AddWithValue("@sup_name", txtname.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            cmd.Parameters.AddWithValue("@phone", txttel.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not update"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtcountry.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete supplier where sup_id=@sup_id", cd.conder);
            cmd.Parameters.AddWithValue("@sup_id", txtid.Text);
            cmd.Parameters.AddWithValue("@sup_name", txtname.Text);
            cmd.Parameters.AddWithValue("@village", txtvillage.Text);
            cmd.Parameters.AddWithValue("@district", txtdistrict.Text);
            cmd.Parameters.AddWithValue("@province", txtprovince.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            cmd.Parameters.AddWithValue("@phone", txttel.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                show();
            }
            else { MessageBox.Show("can not delete"); }
        }
    }
}
