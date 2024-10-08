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

namespace team
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '\u25CF';
        }
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string username, password;

            cmd = new SqlCommand("SELECT users, pass FROM userder", cd.conder);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                username = Convert.ToString(dr[0]);
                password = Convert.ToString(dr[1]);

                if (txtUsername.Text == username && txtPassword.Text == password)
                {
                    Form1 f = new Form1();
                    f.Show();
                    this.Hide();

                }
             
            }
   
            dr.Close();
        }

        private void loginform_Load(object sender, EventArgs e)
        {
            cd.connectja();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
