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
using System.Xml.Linq;

namespace finalthesis
{
    public partial class supplier : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        connecting cd = new connecting();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from supplier", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;


            dataGridView1.Columns[0].HeaderText = "ລະຫັດຜູ້ສະໜອງ";
            dataGridView1.Columns[1].HeaderText = "ຊື້";
            dataGridView1.Columns[2].HeaderText = "ບ້ານ";
            dataGridView1.Columns[3].HeaderText = "ເມືອງ";
            dataGridView1.Columns[4].HeaderText = "ແຂວງ";
            dataGridView1.Columns[5].HeaderText = "ປະເທດ";
            dataGridView1.Columns[6].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[7].HeaderText = "Email";
        
        }
        public supplier()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtname.Text != "" && txtvl.Text !="" && txtdt.Text !="" && txtpv.Text !="" && txtcountry.Text !="" && txttel.Text !="" && txtemail.Text !="")
            {
                cmd = new SqlCommand("insert into supplier values(@supid,@supname,@village,@district,@province,@country,@tel,@email)", cd.conder);
                cmd.Parameters.AddWithValue("@supid", txtid.Text);
                cmd.Parameters.AddWithValue("@supname", txtname.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@village", txtvl.Text);
                cmd.Parameters.AddWithValue("@district", txtdt.Text);
                cmd.Parameters.AddWithValue("@province", txtpv.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@tel", txttel.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved");
                dataGridView1.Refresh();
                show();
            }
            else { MessageBox.Show("please insert the data"); }
        }
    }
}
