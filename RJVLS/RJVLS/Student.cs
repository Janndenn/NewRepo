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
    public partial class Student : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=projectRJVLS; Integrated Security=true");
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
        public Student()
        {
            InitializeComponent();
            showder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtstid.Text != "" && txtfname.Text != "" && txtlname.Text != "" && txtgender.Text != "" && dateTimePicker1.Text != "" && txtmobile.Text != "" && txtclassID.Text !="")
            {
                cmd = new SqlCommand("insert into student values(@STDID, @FName, @LName, @Gender, @Borndate, @Mobile, @classID)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@STDID", txtstid.Text);
                cmd.Parameters.AddWithValue("@FName", txtfname.Text);
                cmd.Parameters.AddWithValue("@LName", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@Borndate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@classID",txtclassID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("saved");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("Please insert the data"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtstid.Text != "" && txtfname.Text != "" && txtlname.Text != "" && txtgender.Text != "" && dateTimePicker1.Text != "" && txtmobile.Text != "" && txtclassID.Text != "")
            {
                cmd = new SqlCommand("update student set FName=@FName, LName=@LName, Gender=@Gender, Borndate=@Borndate, Mobile=@Mobile, classID=@classID where STDID=@STDID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@STDID", txtstid.Text);
                cmd.Parameters.AddWithValue("@FName", txtfname.Text);
                cmd.Parameters.AddWithValue("@LName", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                cmd.Parameters.AddWithValue("@Borndate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@classID", txtclassID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("updated");
                dataGridView1.Refresh();
                showder();
            }
            else { MessageBox.Show("Can not update"); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtstid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtlname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtfname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtgender.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtmobile.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtclassID.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtstid.Text != "" && txtfname.Text != "" && txtlname.Text != "" && txtgender.Text != "" && dateTimePicker1.Text != "" && txtmobile.Text != "" && txtclassID.Text != "")
            {
                cmd = new SqlCommand("delete student where STDID=@STDID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@STDID", txtstid.Text);
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
