using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.PL
{
    
    public partial class FRM_MAIN : Form
    {
        private static FRM_MAIN frm;

        void logout()
        {
            navBarControl1.Visible = false;
            FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = false;
            //  FRM_MAIN.getMainForm.reportToolStripMenuItem.Enabled = true;
            //FRM_MAIN.getMainForm.insurancesToolStripMenuItem.Enabled = true;
            //FRM_MAIN.getMainForm.backupRestorToolStripMenuItem.Enabled = true;
            // FRM_MAIN.getMainForm.tabControl1.Visible = true;
            //  FRM_MAIN.getMainForm.button1.Visible = true;
            Program.SelasMAN = "";
            //  Program.SelasMAN_ID = dt.Rows[0]["ID"].ToString();
            Program.group = "";
            Program.location = "";
            Program.UID = "";
            FRM_MAIN.getMainForm.companyToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.logint2 = DateTime.Now;
            FRM_MAIN.getMainForm.timer2.Enabled = false;
            //FRM_MAIN.getMainForm.timer3.Enabled = true;
            FRM_MAIN.getMainForm.groupBox5.Visible = false;
            FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = true;
            FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = false;

            
        }

        public DateTime logint2;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_MAIN getMainForm
        {
            get
            {
                if (frm==null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                 }
                return frm;
            }
        }
        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.productToolStripMenuItem.Enabled = false;
            this.customerToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Enabled = false;
            this.priToolStripMenuItem.Enabled = false;
//            this.backUPToolStripMenuItem.Enabled = false;
            //this.restoreToolStripMenuItem.Enabled = false;
        }

        private void restorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_SQL eee = new FRM_SQL();
            eee.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_login frm=new Frm_login();
            frm.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODECT frm = new FRM_ADD_PRODECT();
            frm.ShowDialog();
        }

        private void productManagmintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm= new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cATEGORIESManagmintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();

        }

        private void customersManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();

        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void orderManagmintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_ORDER_LIST frm = new FRM_ORDER_LIST();
            frm.ShowDialog();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void userManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.FRM_USER frm = new FRM_USER();
            frm.ShowDialog();
        }

        private void backUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            Program.UID = "";

            txttt.Text = DateTime.Now.ToString();
            this.Hide();
            SS ww = new SS();
            ww.ShowDialog();
            lt1.Text = Program.PC;
            lt2.Text = Program.IPA;

        }

        private void aboutMKPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.AboutBox1 frm = new AboutBox1();
            frm.ShowDialog();

        }

        private void contactASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.AboutBox2 frm = new AboutBox2();
            frm.ShowDialog();
        }

        private void supToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Sup s=new Sup();
            s.ShowDialog();
        }

        private void lisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sup_list ss = new Sup_list();
            ss.ShowDialog();
        }

        private void ordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_P_Order frm = new FRM_P_Order();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string t1 = DateTime.Now.ToLongTimeString();
            string d1 = DateTime.Now.ToShortDateString();

            label10.Text = d1 + "\n" + t1;
            label6.Text = Program.SelasMAN;
            label5.Text = Program.group;
            label3.Text = logint2.ToString();
            lab55.Text = Program.location;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - logint2;

            label7.Text = ts.ToString(@"hh\:mm\:ss");
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company frm = new Company();
            frm.ShowDialog();
        }

        private void refoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PL.Refond qwe = new PL.Refond();
           qwe.txtORef.Enabled = true;
           qwe.txtORef.ReadOnly = false;
            qwe.ShowDialog();
        }
        
        private void orderByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Order_date asd = new Order_date();
            asd.ShowDialog();
        }

        private void todayCashToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Today rpt = new RPT.Today();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
          //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Stock rpt = new RPT.Stock();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
           // rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void stockDetilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Stock_details rpt = new RPT.Stock_details();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Refresh();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void lowStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Low_Stock rpt = new RPT.Low_Stock();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Refresh();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void todayToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // FRM_Emp_cash emp = new FRM_Emp_cash();

            RPT.emp_today day = new RPT.emp_today();
            RPT.FRM_RPT_PRODUCT fr = new RPT.FRM_RPT_PRODUCT();
            day.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            day.DataSourceConnections[0].IntegratedSecurity = false;
            string date = DateTime.Now.ToShortDateString();
            string UIDV = Program.UID;
            string da2 = dateTimePicker1.Value.ToShortDateString();
            day.SetParameterValue("@today", Convert.ToDateTime(da2));
            day.SetParameterValue("@emp_name", UIDV);

            fr.CR1.ReportSource = day;
            fr.ShowDialog();
        }

        private void userOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void byDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee ert = new Employee();
            ert.ShowDialog();
        }

        private void printersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Printers prt = new Printers();
            prt.ShowDialog();
        }

        private void repotsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refondOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.Order_Report rere = new RPT.Order_Report();
            rere.ShowDialog();
        }

        private void refondOrderManagmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refond_List qwe=new Refond_List();
            qwe.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_login asd = new Frm_login();
            logout();
            asd.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Stock_details rpt = new RPT.Stock_details();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Refresh();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Today rpt = new RPT.Today();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.Low_Stock rpt = new RPT.Low_Stock();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetParameterValue("@date1", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            rpt.Refresh();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void productsSalesDetilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            RPT.Product_sales rpt = new RPT.Product_sales();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            RPT.Product_sales rpt = new RPT.Product_sales();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PL.Refond qwe = new PL.Refond();
            qwe.txtORef.Enabled = true;
            qwe.txtORef.ReadOnly = false;
            qwe.ShowDialog();
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Printers prt = new Printers();
            prt.ShowDialog();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            lt1.Text = Program.PC;
            lt2.Text = Program.IPA;
        }

        private void purchasesManagmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P_list frm = new PL.P_list();
            frm.ShowDialog();
        }

        private void settlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settlement st = new Settlement();
            st.ShowDialog();
        }
    }
}
