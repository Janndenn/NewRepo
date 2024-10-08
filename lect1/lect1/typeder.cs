using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using Microsoft.SqlServer;
using System.Security;

namespace lect1
{
    public partial class typeder : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectder cd = new connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void Sadaeng()
        {
            da = new SqlDataAdapter("select * from type", cd.conder);
            da.Fill(ds);
            ds.Tables[0].Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[0].HeaderText = "Type ID";
            dataGridView1.Columns[0].HeaderText = "Type of Product";

        }
        public typeder()
        {
            InitializeComponent();
        }

        private void typeder_Load(object sender, EventArgs e)
        {
            cd.Connectder();
            Sadaeng();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 displayMainForm = new Form1();
            displayMainForm.Show();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete type where t_id=@t_id", cd.conder);
            cmd.Parameters.AddWithValue("@t_id", txtid.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Sadaeng();
                MessageBox.Show("delete Dai lev");
            }
            else
            {
                MessageBox.Show("delete bor dai");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into type values(@t_id, @name)",cd.conder);
            cmd.Parameters.AddWithValue("@t_id",txtid.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);

            if(cmd.ExecuteNonQuery() == 1)
            {
                Sadaeng();
                MessageBox.Show("Save Dai lev");
            }
            else
            {
                MessageBox.Show("Save bor dai");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update type set name=@name where t_id=@t_id", cd.conder);
            cmd.Parameters.AddWithValue("@t_id", txtid.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);

            if (cmd.ExecuteNonQuery() == 1)
            {
                Sadaeng();
                MessageBox.Show("update Dai lev");
            }
            else
            {
                MessageBox.Show("update bor dai");
            }
        }
    }
}
