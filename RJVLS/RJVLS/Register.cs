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
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=projectRJVLS; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from register", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Resgister ID";
            dataGridView1.Columns[1].HeaderText = "Student ID";
            dataGridView1.Columns[2].HeaderText = "Year ID";
            con.Close();
        }
        
        public Register()
        {
            InitializeComponent();
            showder();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtID.Text !="" && txtstid.Text != "" && txtyearID.Text != "")
            {
                cmd = new SqlCommand("insert into register values(@registerID, @STDID, @yearID)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@registerID",txtID.Text);
                cmd.Parameters.AddWithValue("@STDID", txtstid.Text);
                cmd.Parameters.AddWithValue("@yearID", txtyearID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtstid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtyearID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtstid.Text != "" && txtyearID.Text != "")
            {
                cmd = new SqlCommand("update register set STDID=@STDID, yearID=@yearID where registerID=@registerID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@registerID", txtID.Text);
                cmd.Parameters.AddWithValue("@STDID", txtstid.Text);
                cmd.Parameters.AddWithValue("@yearID", txtyearID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update successfully!");
                showder();
            }
            else { MessageBox.Show("Update Fail!!"); }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && txtstid.Text != "" && txtyearID.Text != "")
            {
                cmd = new SqlCommand("delete register where registerID=@registerID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@registerID", txtID.Text);
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
