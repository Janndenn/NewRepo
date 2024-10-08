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

namespace lab2
{
    public partial class department : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=lab2; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from department", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public department()
        {
            InitializeComponent();
            showder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 displayMainForm = new Form1();
            displayMainForm.Show();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtlaoname.Text != "" && txtengname.Text !="")
            {
                cmd = new SqlCommand("insert into department values(@d_id, @l_name, @E_name)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@d_id", txtid.Text);
                cmd.Parameters.AddWithValue("@l_name", txtlaoname.Text);
                cmd.Parameters.AddWithValue("@E_name", txtengname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("save dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("Save bor dai ka lu na pon khor moon korn"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtlaoname.Text != "" && txtengname.Text != "")
            {
                cmd = new SqlCommand("update department set @E_name = @E_name @l_name=@l_name where d_id=d_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@d_id", txtid.Text);
                cmd.Parameters.AddWithValue("@l_name", txtlaoname.Text);
                cmd.Parameters.AddWithValue("@E_name", txtengname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("update dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("update bor dai ka lu na pon khor moon korn"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtlaoname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtengname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtlaoname.Text != "" && txtengname.Text != "")
            {
                cmd = new SqlCommand("delete department where d_id=d_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@d_id", txtid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("delete dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("delete bor dai ka lu na pon khor moon korn"); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adt = new SqlDataAdapter("select * from department where d_id like'" + txtsearch.Text + "%' ", con);
            dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            new longder1().Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
