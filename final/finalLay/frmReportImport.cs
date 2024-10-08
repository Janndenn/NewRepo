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
    public partial class frmReportImport : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        public frmReportImport()
        {
            InitializeComponent();
        }

        private void frmReportImport_Load(object sender, EventArgs e)
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
            string sql = "select b.code, b.valuedt, c.pro_name, a.qty, a.total from import_detail as a join import as b on a.import_code=b.code join product as c on a.product_id=c.product_id where b.valuedt between '" + start.ToString() + "' and '" + end.ToString() + "'";
            cmd = new SqlCommand(sql, db.Connect());
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            ReportDataSource rpds = new ReportDataSource("DataSet8", dt);
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
