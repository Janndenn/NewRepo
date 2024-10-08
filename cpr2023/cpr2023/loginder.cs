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


namespace cpr2023
{
    public partial class loginder : Form
    {
       
        public loginder()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '\u25CF';
        }
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();

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

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\u25CF';

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginder_Load(object sender, EventArgs e)
        {
            cd.connectder();
        }
    }
}
