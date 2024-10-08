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

namespace sakthesis
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3B6JIUK\\SQLEXPRESS; initial Catalog=team; Integrated Security=true");
        SqlCommand cmd;
        SqlDataAdapter adt;
        DataTable dt = new DataTable();
        private void showder()
        {
            con.Open();
            DataTable dt = new DataTable();
            adt = new SqlDataAdapter("Select * from ss ", con);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        public Form3()
        {
            InitializeComponent();
            showder();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void txtjam_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Show();
        }
    }
}
