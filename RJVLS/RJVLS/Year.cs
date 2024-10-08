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
    public partial class Year : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=projectRJVLS; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from years", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 260;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].HeaderText = "YearID";
            dataGridView1.Columns[1].HeaderText = "Years";
            con.Close();
        }
        public Year()
        {
            InitializeComponent();
            showder();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtyear.Text != "")
            {
                cmd = new SqlCommand("insert into years values(@YearID, @Years)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@YearID", txtID.Text);
                cmd.Parameters.AddWithValue("@Years", txtyear.Text);
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
            txtyear.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtyear.Text != "")
            {
                cmd = new SqlCommand("update years set Years=@Years where YearID=@YearID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@YearID", txtID.Text);
                cmd.Parameters.AddWithValue("@Years", txtyear.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully!");
                showder();
            }
            else { MessageBox.Show("Update Fail!!"); }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtyear.Text != "")
            {
                cmd = new SqlCommand("delete years where YearID=@YearID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@YearID", txtID.Text);
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
    }
}
