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
    public partial class Position : Form
    {
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Connectder cd = new Connectder();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void sadaeng()
        {
            adt = new SqlDataAdapter("select * from position", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 280;
            dataGridView1.Columns[1].Width = 350;

            dataGridView1.Columns[0].HeaderText = "ລະຫັດ";
            dataGridView1.Columns[1].HeaderText = "ຊື່ຕຳແໜ່ງ";
        }
        public Position()
        {
            InitializeComponent();
        }

        private void Position_Load(object sender, EventArgs e)
        {
            cd.connectder();
            sadaeng();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into position values(@po_name)", cd.conder);
            cmd.Parameters.AddWithValue("@po_name", txtposition.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT SAVE"); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtposition.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update position set po_name=@po_name where po_id=@po_id", cd.conder);
            cmd.Parameters.AddWithValue("@po_id", ID.Text);
            cmd.Parameters.AddWithValue("@po_name", txtposition.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT UPDATE"); }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("delete position where po_name=@po_name", cd.conder);
            cmd.Parameters.AddWithValue("@po_name", txtposition.Text);
            if (cmd.ExecuteNonQuery() == 1)
            {
                sadaeng();
            }
            else { MessageBox.Show("CAN NOT DELETE"); }
        }
    }
}
