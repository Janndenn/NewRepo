using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testthesis
{
    public partial class user : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from userr", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;

            dataGridView1.Columns[0].HeaderText = "UserID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "SURNAME";
            dataGridView1.Columns[3].HeaderText = "USER";
            dataGridView1.Columns[4].HeaderText = "PASSWORD";
            
        }
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '\u25CF';
            cd.connect();
            show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtid.Text !="" && txtname.Text !="")
            {

                cmd = new SqlCommand("insert into userr values(@userid,@namee, @surname,@userr,@pass)", cd.conder);
                cmd.Parameters.AddWithValue("@userid", txtid.Text);
                cmd.Parameters.AddWithValue("@namee", txtname.Text);
                cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@userr", txtuser.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=JANNDENN\SQLEXPRESS; initial Catalog = testthesis; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select emname, emsurname from employee where emid=@emid", tor);
                cc.Parameters.AddWithValue("@emid", txtid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtname.Text = rdr.GetValue(0).ToString();
                    txtsurname.Text = rdr.GetValue(1).ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtuser.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "")
            {
                cmd = new SqlCommand("delete userr where userid=@userid", cd.conder);
                cmd.Parameters.AddWithValue("@userid", txtid.Text);
                cmd.Parameters.AddWithValue("@namee", txtname.Text);
                cmd.Parameters.AddWithValue("@userr", txtsurname.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("deleted");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please click on the data"); }
        }
    }
}
