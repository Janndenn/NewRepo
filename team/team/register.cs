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
    public partial class register : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connectjah cd = new connectjah();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from userder", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
        }
            public register()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void register_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '\u25CF';
            txtverify.PasswordChar = '\u25CF';
            cd.connectja();
            sadaeng();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                SqlConnection tor = new SqlConnection(@"Data Source=DESKTOP-3B6JIUK; initial Catalog = team; integrated security = True");
                tor.Open();
                SqlCommand cc = new SqlCommand("select Emname, Emsurname, Position from employee where Emid=@Emid", tor);
                cc.Parameters.AddWithValue("@Emid", txtid.Text);
                SqlDataReader rdr = cc.ExecuteReader();
                while (rdr.Read())
                {
                    txtname.Text = rdr.GetValue(0).ToString();
                    txtsurname.Text = rdr.GetValue(1).ToString();
                    txtposition.Text = rdr.GetValue(2).ToString();

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == txtverify.Text)
            {
                cmd = new SqlCommand("insert into userder values(@id, @name, @surname,@position,@users,@pass)", cd.conder);
                cmd.Parameters.AddWithValue("@id", txtid.Text);
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
                    txtposition.Clear();
                    txtuser.Clear();
                    txtpassword.Clear();
                    txtverify.Clear();
                }
                else { MessageBox.Show("CAN NOT SAVE"); }

            }
            else
            {
                MessageBox.Show("DO NOT CORRECT!");
            }
        }
    }
}
