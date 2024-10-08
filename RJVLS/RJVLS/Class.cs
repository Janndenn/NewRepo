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
    public partial class Class : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=projectRJVLS; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from class", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Class ID";
            dataGridView1.Columns[1].HeaderText = " Class Name";
            dataGridView1.Columns[2].HeaderText = "Major ID";
            con.Close();
        }
   
        
        public Class()
        {
            InitializeComponent();
            showder();
        }
    
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtmajorID.Text != "")
            {
                cmd = new SqlCommand("insert into class values(@classID, @classname, @majorID)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@classID", txtID.Text);
                cmd.Parameters.AddWithValue("@classname", txtname.Text);
                cmd.Parameters.AddWithValue("@majorID", txtmajorID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtmajorID.Text != "")
            {
                cmd = new SqlCommand("update class set majorID=@majorID, classname=@classname where classID=@classID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@classID", txtID.Text);
                cmd.Parameters.AddWithValue("@classname", txtname.Text);
                cmd.Parameters.AddWithValue("@majorID", txtmajorID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully!");
                showder();
               
            }
            else { MessageBox.Show("Update Fail!!"); }
        }
  
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtname.Text != "" && txtmajorID.Text != "")
            {
                cmd = new SqlCommand("delete class where classID=@classID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@classID", txtID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted");
                showder();
             
            }
            else { MessageBox.Show("Can not delete"); }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            Home displayMainForm = new Home();
            displayMainForm.Show();

            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmajorID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Class_Load(object sender, EventArgs e)
        {
            showder();
        }
    }
}
