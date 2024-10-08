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

namespace lab2
{
    public partial class department : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK; initial Catalog=lab2; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from department", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        public department()
        {
            InitializeComponent();
            showder();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 displayMainForm = new Form1();
            displayMainForm.Show();

            this.Close();
        }
    }
}
