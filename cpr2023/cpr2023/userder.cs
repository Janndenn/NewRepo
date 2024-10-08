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

namespace cpr2023
{
    public partial class userder : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from userder", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
           
        }
        public userder()
        {
            InitializeComponent();
        }

        private void userder_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '\u25CF';
            txtverify.PasswordChar = '\u25CF';
            cd.connectder();
            sadaeng();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == txtverify.Text)
            {
                cmd = new SqlCommand("insert into userder values(@name, @surname,@position,@users,@pass)", cd.conder);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@surname", txtsurname.Text);
                cmd.Parameters.AddWithValue("@position", txtposition.Text);
                cmd.Parameters.AddWithValue("@users", txtuser.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    sadaeng();
                    txtid.Clear();
                    txtname.Clear();
                    txtsurname.Clear();
                    txtuser.Clear();
                    txtpassword.Clear();
                }
                else { MessageBox.Show("CAN NOT SAVE"); }
                
            }
            else
            {
                MessageBox.Show("DO NOT CORRECT!");
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if(txtid.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=DESKTOP-3B6JIUK; initial Catalog = salary_cpr2023; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select st_name, surname,position from staff where st_id=@st_id", tor);
                cc.Parameters.AddWithValue("@st_id", txtid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtname.Text = rdr.GetValue(0).ToString();
                    txtsurname.Text = rdr.GetValue(1).ToString();
                    txtposition.Text = rdr.GetValue(2).ToString();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
