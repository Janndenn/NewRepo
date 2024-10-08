using Microsoft.Reporting.WinForms;
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

namespace final
{
    public partial class frmReportSale : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        public frmReportSale()
        {
            InitializeComponent();
        }

        private void frmReportSale_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void getdata()
        {
            string start = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            string end = DateTime.Parse(dateTimePicker2.Text).ToString("yyyy-MM-dd");
            //MessageBox.Show(dateTimePicker1.Text);
            string sql = "select a.code, a.valuedt, a.result, c.cus_name, b.emp_name from sale as a join employee as b on a.emp_id = b.emp_id join customer as c on a.cus_id = c.cus_id where a.valuedt between '" + start.ToString() + "' and '" + end.ToString() + "'";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ReportDataSource rpds = new ReportDataSource("DataSet3", dt);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rpds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMainMenu frm = new frmMainMenu();
            frm.Show();
        }
    }
}
