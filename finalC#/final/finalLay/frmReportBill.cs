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
    public partial class frmReportBill : Form
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        DbConnect db = new DbConnect();
        string codes = null;
        public frmReportBill(string code)
        {
            InitializeComponent();
            textBox1.Text = code;
        }

        private void frmReportBill_Load(object sender, EventArgs e)
        {
        }

        private void getdata()
        {
            try
            {
                string sql = "select * from sale where code = " + codes;
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ReportParameter parameters = new ReportParameter("code", row["code"].ToString());
                    ReportParameter parameters1 = new ReportParameter("code", row["code"].ToString());
                    ReportParameter parameters2 = new ReportParameter("date", row["valuedt"].ToString());
                    ReportParameter parameters3 = new ReportParameter("sum", row["total"].ToString());
                    ReportParameter parameters4 = new ReportParameter("discount", row["discount"].ToString());
                    ReportParameter parameters5 = new ReportParameter("total", row["result"].ToString());
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.LocalReport.SetParameters(parameters1);
                    this.reportViewer1.LocalReport.SetParameters(parameters2);
                    this.reportViewer1.LocalReport.SetParameters(parameters3);
                    this.reportViewer1.LocalReport.SetParameters(parameters4);
                    this.reportViewer1.LocalReport.SetParameters(parameters5);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ກະລຸນາປ້ອນລະຫັດບິນ!");
            }
            
            
        }

        private void getDetaildata()
        {
            if (textBox1.Text != "")
            {
                string sql = "select a.sale_detail_id, a.sale_ful_id, b.pro_name as product_id, a.price, a.qty, a.total from sale_detail as a join product as b on a.product_id = b.product_id where a.sale_ful_id = " + codes;
                cmd = new SqlCommand(sql, db.Connect());
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                ReportDataSource rpds = new ReportDataSource("DataSetDetail", dt);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rpds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codes = textBox1.Text;
            getdata();
            getDetaildata();
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
