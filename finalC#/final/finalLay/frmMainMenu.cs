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

namespace final
{
    public partial class frmMainMenu : Form
    {
        DbConnect db = new DbConnect();

        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(db.userid);
        }

        private void ອອກລະບບToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void ຈດການຂມນພະນກງານToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUser frm = new frmUser();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນສດທToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRole frm = new frmRole();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void ຈດການຂມນໂປຣໂມຊນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromotion frm = new frmPromotion();
            this.Hide();
            frm.Show();
        }

        private void ຂາຍສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPos frm = new frmPos();
            frm.MdiParent = this;
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
        }

        private void ລາຍງານຂມນພະນກງານToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportSaleEmp frm = new frmReportSaleEmp();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportProduct frm = new frmReportProduct();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນການຂາຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportSale frm = new frmReportSale();
            this.Hide();
            frm.Show();
        }

        private void ຂມນໃບບນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportBuy frm = new frmReportBuy();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນປະເພດສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນຍຫສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBrand frm = new frmBrand();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນຫວໜວຍສນຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnit frm = new frmUnit();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນອດຕາແລກປຽນToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExchange frm = new frmExchange();
            this.Hide();
            frm.Show();
        }

        private void ຈດການຂມນລກຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOrder frm = new frmOrder();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPos frm = new frmPos();
            this.Hide();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport();
            this.Hide();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmProblem frm = new frmProblem();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນສນຄາມບນຫາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportProblem frm = new frmReportProblem();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນຜສະໜອງToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportSupplier frm = new frmReportSupplier();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນລກຄາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportCustomer frm = new frmReportCustomer();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນນຳເຂາຕາມວນທເວລາToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportImport frm = new frmReportImport();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນລາຍຮບToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportIncome frm = new frmReportIncome();
            this.Hide();
            frm.Show();
        }

        private void ລາຍງານຂມນລາຍຈາຍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportExpend frm = new frmReportExpend();
            this.Hide();
            frm.Show();
        }
    }
}
