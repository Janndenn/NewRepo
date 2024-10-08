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
    public partial class employeerecord : Form
    {
        string imder = null;
        SqlDataAdapter adt = new SqlDataAdapter();
        DataSet ds = new DataSet();
        ConnectionString cd = new ConnectionString();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        public void show()
        {
            adt = new SqlDataAdapter("select * from employee", cd.conder);
            adt.Fill(ds);
            ds.Tables[0].Clear();
            adt.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Width = 150;
            dataGridView2.Columns[6].Width = 150;
            dataGridView2.Columns[7].Width = 150;
            dataGridView2.Columns[8].Width = 180;
            dataGridView2.Columns[9].Width = 150;
            dataGridView2.Columns[10].Width = 180;
            dataGridView2.Columns[11].Width = 150;
            dataGridView2.Columns[12].Width = 100;
            dataGridView2.Columns[13].Width = 150;


            dataGridView2.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView2.Columns[1].HeaderText = "ເພດ";
            dataGridView2.Columns[2].HeaderText = "ຊື່";
            dataGridView2.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView2.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ";
            dataGridView2.Columns[5].HeaderText = "ອາຍຸ";
            dataGridView2.Columns[6].HeaderText = "ບ້ານ";
            dataGridView2.Columns[7].HeaderText = "ເມືອງ";
            dataGridView2.Columns[8].HeaderText = "ແຂວງ";
            dataGridView2.Columns[9].HeaderText = "ເບີໂທ";
            dataGridView2.Columns[10].HeaderText = "email";
            dataGridView2.Columns[11].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView2.Columns[12].HeaderText = "ລະຫັດຜ່ານ";
            dataGridView2.Columns[13].HeaderText = "ຮູບພາບ";

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 150;
            dataGridView1.Columns[7].Width = 150;
            dataGridView1.Columns[8].Width = 180;
            dataGridView1.Columns[9].Width = 150;
            dataGridView1.Columns[10].Width = 180;
            dataGridView1.Columns[11].Width = 150;
            dataGridView1.Columns[12].Width = 100;
            dataGridView1.Columns[13].Width = 150;
            dataGridView1.Columns[0].HeaderText = "ລະຫັດພະນັກງານ";
            dataGridView1.Columns[1].HeaderText = "ເພດ";
            dataGridView1.Columns[2].HeaderText = "ຊື່";
            dataGridView1.Columns[3].HeaderText = "ນາມສະກຸນ";
            dataGridView1.Columns[4].HeaderText = "ວັນເດືອນປີເກີດ";
            dataGridView1.Columns[5].HeaderText = "ອາຍຸ";
            dataGridView1.Columns[6].HeaderText = "ບ້ານ";
            dataGridView1.Columns[7].HeaderText = "ເມືອງ";
            dataGridView1.Columns[8].HeaderText = "ແຂວງ";
            dataGridView1.Columns[9].HeaderText = "ເບີໂທ";
            dataGridView1.Columns[10].HeaderText = "email";
            dataGridView1.Columns[11].HeaderText = "ມື້ເຂົ້າເຮັດວຽກ";
            dataGridView1.Columns[12].HeaderText = "ລະຫັດຜ່ານ";
            dataGridView1.Columns[13].HeaderText = "ຮູບພາບ";
        }
        public employeerecord()
        {
            InitializeComponent();
        }

        private void employeerecord_Load(object sender, EventArgs e)
        {
            cd.connect();
            show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Assuming you have a DateTimePicker named dateTimePicker1
            DateTime selectedDate = txtdate.Value.Date;

            // Connection string - replace with your actual connection string
            string connectionString = "Data Source=JANNDENN\\SQLEXPRESS;Initial Catalog=testthesis;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM employee WHERE birthday = @birthday";
                SqlDataAdapter adt = new SqlDataAdapter(query, connection);

                // Add the parameter and its value
                adt.SelectCommand.Parameters.AddWithValue("@birthday", selectedDate);

                DataTable dt = new DataTable();
                adt.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }


    }
}
