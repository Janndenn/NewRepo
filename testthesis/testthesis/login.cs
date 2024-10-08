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
    public partial class login : Form
    {
        
        public login()
        {
            InitializeComponent();
            txtpass.PasswordChar = '\u25CF';
        }
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();


        private void login_Load(object sender, EventArgs e)
        {
            cd.connect();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=JANNDENN\\SQLEXPRESS;Initial Catalog=testthesis;Integrated Security=True"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT userr, pass FROM userr WHERE userr = @userr AND pass = @pass";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@userr", txtuser.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpass.Text);

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                this.Hide();
                                MainForm f1 = new MainForm();
                                f1.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = '\u25CF';
        }
    }
}
