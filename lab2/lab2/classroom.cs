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
    public partial class classroom : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=lab2; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();

        private void showder()
        {
            con.Open();
            adt = new SqlDataAdapter("Select * from classroomder", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 325;
            dataGridView1.Columns[1].Width = 300;

            dataGridView1.Columns[0].HeaderText = "Classroom ID";
            dataGridView1.Columns[1].HeaderText = "Classroom";
            con.Close();
        }
        public classroom()
        {
            InitializeComponent();
            showder();
        }

        private void classroom_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 displayMainForm = new Form1();
            displayMainForm.Show();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtclass.Text != "")
            {
                cmd = new SqlCommand("insert into classroomder values(@c_id, @c_room)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@c_id", txtid.Text);
                cmd.Parameters.AddWithValue("@c_room", txtclass.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("save dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("Save bor dai ka lu na pon khor moon korn"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtclass.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtclass.Text != "")
            {
                cmd = new SqlCommand("update classroomder set @c_room=@c_room where c_id=c_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@c_id", txtid.Text);
                cmd.Parameters.AddWithValue("@c_room", txtclass.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("update dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("update bor dai ka lu na pon khor moon korn"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtclass.Text != "")
            {
                cmd = new SqlCommand("delete classroomder where c_id=c_id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@c_id", txtid.Text);
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
            adt = new SqlDataAdapter("select * from classroomder where c_room like'" + txtsearch.Text + "%' ", con);
            dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new longder().Show();
         
        }
    }
}
