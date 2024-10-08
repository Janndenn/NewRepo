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
    public partial class student : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=lab2; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from student", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public student()
        {
            InitializeComponent();
            showder();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void student_Load(object sender, EventArgs e)
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
            if (txtid.Text != "" && txtname.Text != "" && txtsurname.Text != "" && txtgender.Text !="" && txtdep.Text !="" && txtmajor.Text!="" && txtclassroom.Text !="")
            {
                cmd = new SqlCommand("insert into student values(@st_id, @st_name, @st_surname, @st_gen, @st_dep, @st_maj, @st_class)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@st_id", txtid.Text);
                cmd.Parameters.AddWithValue("@st_name", txtname.Text);
                cmd.Parameters.AddWithValue("@st_surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@st_gen", txtgender.Text);
                cmd.Parameters.AddWithValue("@st_dep", txtdep.Text);
                cmd.Parameters.AddWithValue("@st_maj", txtmajor.Text);
                cmd.Parameters.AddWithValue("@st_class", txtclassroom.Text);
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
            if (txtid.Text != "" && txtname.Text != "" && txtsurname.Text != "" && txtgender.Text != "" && txtdep.Text != "" && txtmajor.Text != "" && txtclassroom.Text != "")
            {
                cmd = new SqlCommand("update student set(@st_id, @st_name, @st_surname, @st_gen, @st_dep, @st_maj, @st_class)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@st_id", txtid.Text);
                cmd.Parameters.AddWithValue("@st_name", txtname.Text);
                cmd.Parameters.AddWithValue("@st_surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@st_gen", txtgender.Text);
                cmd.Parameters.AddWithValue("@st_dep", txtdep.Text);
                cmd.Parameters.AddWithValue("@st_maj", txtmajor.Text);
                cmd.Parameters.AddWithValue("@st_class", txtclassroom.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("save dai lev");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("Save bor dai ka lu na pon khor moon korn"); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adt = new SqlDataAdapter("select * from student where st_id like'" + txtsearch.Text + "%' ", con);
            dt = new DataTable();
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            new longder1().Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
