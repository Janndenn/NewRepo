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

namespace RJVLS
{
    public partial class Major : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=projectRJVLS; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from Major", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 260;
            dataGridView1.Columns[1].Width = 215;
            con.Close();
        }
            public Major()
        {
            InitializeComponent();
            showder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("insert into Major values(@majorID, @MajorName)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@majorID", txtID.Text);
                cmd.Parameters.AddWithValue("@MajorName", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved");
                showder();
                
            }
            else
            {
                MessageBox.Show("Please insert the data!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("update Major set majorName=@MajorName where majorID=@majorID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@majorID", txtID.Text);
                cmd.Parameters.AddWithValue("@MajorName", txtname.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully!");
                showder();
            }
            else { MessageBox.Show("Update Fail!!"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "") 
            {
                cmd = new SqlCommand("delete Major where majorID=@majorID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@majorID", txtID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted");
                showder();
            }
            else { MessageBox.Show("Can not delete"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home displayMainForm = new Home();
            displayMainForm.Show();

            this.Close();
        }
    }
}
