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

namespace project_for_exam
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source =DESKTOP-3B6JIUK;initial Catalog=infor; Integrated Security=True");
        SqlDataAdapter adt;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataReader dr;
        string id;
        bool Mode = true;
        string sql;

        private void show()
        {
            con.Open();
            adt = new SqlDataAdapter("select * from information", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Name";
            dataGridView1.Columns[2].HeaderText = "Surname";
            dataGridView1.Columns[3].HeaderText = "Village";
            dataGridView1.Columns[4].HeaderText = "District";
            dataGridView1.Columns[5].HeaderText = "Province";
            con.Close();
        }
        public Form1()
        {
            InitializeComponent();
            show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string ID = txtID.Text;
           string name = txtName.Text;
           string Surname = txtSurname.Text;
           string Village = txtvillage.Text;
           string District = txtdistrict.Text;
           string province = txtprovince.Text;
           if(Mode == true)
            {
                sql = "insert into information(inf_ID, inf_Name, inf_Surname, inf_village, inf_Disrict, inf_province) values(@inf_ID, @inf_Name, @inf_Surname, @inf_village, @inf_Disrict, @inf_province)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@inf_ID", ID);
                cmd.Parameters.AddWithValue("@inf_Name", name);
                cmd.Parameters.AddWithValue("@inf_Surname", Surname);
                cmd.Parameters.AddWithValue("@inf_village", Village);
                cmd.Parameters.AddWithValue("@inf_Disrict", District);
                cmd.Parameters.AddWithValue("@inf_province", province);
                MessageBox.Show("Save dai leo");
                cmd.ExecuteNonQuery();

                txtID.Clear();
                txtName.Clear();
                txtSurname.Clear();
                txtvillage.Clear();
                txtdistrict.Clear();
                txtprovince.Clear();
                txtName.Focus();
            }
            else { MessageBox.Show("Save bo dai der"); }
           con.Close();
            dataGridView1.Refresh();
        }











        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtvillage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdistrict_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbel6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string name = txtName.Text;
            string Surname = txtSurname.Text;
            string Village = txtvillage.Text;
            string District = txtdistrict.Text;
            string province = txtprovince.Text;
            if (Mode == true)
            {
                sql = "Update information set (inf_ID, inf_Name, inf_Surname, inf_village, inf_Disrict, inf_province) where(@inf_ID, @inf_Name, @inf_Surname, @inf_village, @inf_Disrict, @inf_province)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@inf_ID", ID);
                cmd.Parameters.AddWithValue("@inf_Name", name);
                cmd.Parameters.AddWithValue("@inf_Surname", Surname);
                cmd.Parameters.AddWithValue("@inf_village", Village);
                cmd.Parameters.AddWithValue("@inf_Disrict", District);
                cmd.Parameters.AddWithValue("@inf_province", province);
                MessageBox.Show("update dai leo");
                cmd.ExecuteNonQuery();

                txtID.Clear();
                txtName.Clear();
                txtSurname.Clear();
                txtvillage.Clear();
                txtdistrict.Clear();
                txtprovince.Clear();
                txtName.Focus();
            }
            else { MessageBox.Show("update bo dai der"); }
            con.Close();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtvillage.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdistrict.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtprovince.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
