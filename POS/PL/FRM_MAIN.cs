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

        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

       public void logout()
        {
            //navBarControl1.Visible = false;
            FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = false;
          //  FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = false;
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
          //  FRM_MAIN.getMainForm.companyToolStripMenuItem.Enabled = false;
           // FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = false;
            FRM_MAIN.getMainForm.logint2 = DateTime.Now;
            FRM_MAIN.getMainForm.timer2.Enabled = false;
            //FRM_MAIN.getMainForm.timer3.Enabled = true;
    //        FRM_MAIN.getMainForm.groupBox5.Visible = false;
            FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = true;
            //FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = false;

            
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
            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            BL.CLS_LOGIN log = new BL.CLS_LOGIN();
            try
            {
                log.shift_ls();
            }
            catch
            {
                FRM_SQL sql = new FRM_SQL();
                MessageBox.Show("لا يمكن الوصول لفاعدة البيانات الرجاء التاكد من بيانات الاتصال", "قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sql.ShowDialog();
                return;
            }
            Program.shift_id = log.shift_ls().Rows[0][1].ToString();
            Program.shift_name = log.shift_ls().Rows[0][2].ToString();
            shiftlb.Text = Program.shift_name;

            this.ShowInTaskbar = false;
           
            if (frm == null)
                frm = this;
            this.productToolStripMenuItem.Enabled = false;
            this.customerToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Enabled = false;
            this.priToolStripMenuItem.Enabled = false;
            //this.backUPToolStripMenuItem.Enabled = false;
            //this.restoreToolStripMenuItem.Enabled = false;
            ex_listgv.DataSource = prd.ex_list();

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
            if (Program.PAT == "0")
            {
                PL.FRM_ORDERS frm = new FRM_ORDERS();
                frm.ShowDialog();
            }else
            {
                PL.Order_PAT frm = new Order_PAT();
                frm.ShowDialog();
            }
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
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();  
            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            BL.CLS_CUSTOMERS cs = new BL.CLS_CUSTOMERS();

            //--------------------SIS_ID----------------------
            DataTable ss = log.sis_id();
            if (ss.Rows[0][0].ToString() == "Error")
            {
                if (ss.Rows[0][0].ToString() == "Error")
                {
                    return;
                }
                else
                {
                    Program.s_id = ss.Rows[0][0].ToString();
                }
                return;
            }
            else
            {
                Program.s_id = ss.Rows[0][0].ToString();
            }
            //------------------------------------------------

            DataTable dd = log.GET_FRM();
            Program.PAT = log.pth_s().Rows[0][0].ToString();
            daterr.Value = DateTime.Now;
            if (dd.Rows[0][0].ToString() == "1") { toolStripSeparator13.Visible = true; فاتورةمبدائيةToolStripMenuItem.Visible = true; أدارنالفواتيرالمبدائيةToolStripMenuItem.Visible = true; } else { toolStripSeparator13.Visible = false; فاتورةمبدائيةToolStripMenuItem.Visible = false; أدارنالفواتيرالمبدائيةToolStripMenuItem.Visible = false; }
            if (dd.Rows[1][0].ToString() == "1") الماليةToolStripMenuItem.Visible = true; else الماليةToolStripMenuItem.Visible = false;
            if (dd.Rows[2][0].ToString() == "1") التاميناتToolStripMenuItem.Visible = true; else التاميناتToolStripMenuItem.Visible = false;
            if (dd.Rows[3][0].ToString() == "1") Ding_drag.Visible = true; else Ding_drag.Visible = false;
            if (dd.Rows[4][0].ToString() == "1") المخازنToolStripMenuItem.Visible = true; else المخازنToolStripMenuItem.Visible = false;
            
            Program.op_name = cs.op_name().Rows[0][0].ToString();
            Program.RC = Convert.ToInt32(ord.print_Copy().Rows[0][0].ToString());
            Program.IC=Convert.ToInt32(ord.print_Copy().Rows[1][0].ToString());
            Program.ccl = ord.ccl().Rows[0][0].ToString();
            // TODO: This line of code loads data into the 'sMS_FINDataSet.GET_ALL_PRODUCTS' table. You can move, or remove it, as needed.
         //   this.gET_ALL_PRODUCTSTableAdapter.Fill(this.sMS_FINDataSet.GET_ALL_PRODUCTS);
            verlb.Text = "رقم الاصداره: " + Program.APP_Ver;
            Program.log_TM = DateTime.Now;
            this.Text=this.Text +" -"+Program.APP_Ver;
        //    if (Program.PAT == "1") { navBarItem11.Visible = false;navBarItem17.Visible = false;فاتورةمبدائيةToolStripMenuItem.Visible = false; أدارنالفواتيرالمبدائيةToolStripMenuItem.Visible = false; فاتورةمبدائيةToolStripMenuItem.Enabled = false; أدارنالفواتيرالمبدائيةToolStripMenuItem.Enabled = false; }
            try
            {
                {
                    //Properties.Settings.Default.Actev = false;
                    //Properties.Settings.Default.Save();
                }


                DataTable exd = log.test_EX(DateTime.Now);


                Program.UID = "";

                txttt.Text = DateTime.Now.ToString();
                this.Hide();
                if (exd.Rows.Count == 0 && Properties.Settings.Default.Actev == false)
                {
                    MessageBox.Show("\t أنتهة صلاحية النسخة  \t");
                    PL.Activation reer = new Activation();
                    reer.Show();
                    return;
                    if (Properties.Settings.Default.Actev == false)
                    {
                        this.Close();
                        return;
                    }
                    else {
                        this.Show();
                        return;
                    }
                }
                SS ww = new SS();
                ww.ShowDialog();
                lt1.Text = Program.PC;
                lt2.Text = Program.IPA;
                DataTable ls = new DataTable();
                DataTable cin = new DataTable();
                DataTable co = new DataTable();
                ls = prd.low_stock2();
                cin = ord.chaqu_rpt1_3(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                co = ord.chaqu_rpt2_4(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

                blkuser.DataSource = log.US_BLK("", "get");
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "تفعيل";
                btn.Name = "button";
                btn.Text = "تفعيل";
                btn.UseColumnTextForButtonValue = true;
                blkuser.Columns.Add(btn);
                dataGridco.DataSource = ord.chaqu_rpt1(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

                dataGridco.Columns[0].Visible = false;
                dataGridco.Columns[1].Visible = false;
                dataGridco.Columns[6].Visible = false;

                dataGridcin.DataSource = ord.chaqu_rpt2(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

                dataGridcin.Columns[0].Visible = false;
                dataGridcin.Columns[1].Visible = false;
                dataGridcin.Columns[6].Visible = false;

                dataGridView1.DataSource = prd.low_stock2();
                // dataGridView1.Columns[1].Visible = false;


                dataGridView2.DataSource = prd.get_main_GR();
                dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";
                dataGridView3.DataSource = prd.get_main_GR2();
                dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
                //notif not = new notif();
                //not.ShowDialog();

                dgv_ls2.DataSource = prd.low_stock2();
                dgv_ex2.DataSource = prd.ex_list();

                dgv_inc.DataSource = prd.get_main_GR3(Program.UID);
                dgv_inc.Columns[1].DefaultCellStyle.Format = "N2";
                dgv_inc.Columns[2].DefaultCellStyle.Format = "N2";

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



            }
            catch {
                this.Hide();
                //this.OnTabStopChanged();
                Frm_login f = new Frm_login();
                f.ShowDialog();
                return; }
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
            BL.CLS_PRODUCTS prd=new BL.CLS_PRODUCTS();
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            string t1 = DateTime.Now.ToLongTimeString();
            string d1 = DateTime.Now.ToShortDateString();
            label10.Text = d1 + "\n" + t1;
            label6.Text = Program.SelasMAN;
            label5.Text = Program.group;
            label3.Text = logint2.ToString();
            lab55.Text = Program.location;
            ssid.Text = "رقم الجلسة: " + Program.s_id;


            //BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            //BL.CLS_ORDERS ord = new BL.CLS_ORDERS();

            //dataGridco.DataSource = ord.chaqu_rpt1(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            //dataGridco.Columns[0].Visible = false;
            //dataGridco.Columns[1].Visible = false;
            //dataGridco.Columns[6].Visible = false;

            //dataGridcin.DataSource = ord.chaqu_rpt2(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            //dataGridcin.Columns[0].Visible = false;
            //dataGridcin.Columns[1].Visible = false;
            //dataGridcin.Columns[6].Visible = false;

            //dataGridView1.DataSource = prd.low_stock2();

            //dataGridView2.DataSource = prd.get_main_GR();
            //dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";

            //dataGridView3.DataSource = prd.get_main_GR2();
            //dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            //dataGridView3.Columns[2].DefaultCellStyle.Format = "N2";

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

            label7.Text = ts.ToString(@"d\+hh\:mm\:ss");
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
            //---------------
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.DateRpt rpt = new RPT.DateRpt();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt.SetParameterValue("@id", "NULL");
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
            //--------------

            this.Cursor = Cursors.WaitCursor;
            //DateTime today = DateTime.Now;
            RPT.cash_user rpt2 = new RPT.cash_user();
            rpt.Refresh();
            rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt2.DataSourceConnections[0].IntegratedSecurity = false;
          //  RPT.FRM_RPT_PRODUCT frm2 = new RPT.FRM_RPT_PRODUCT();
            rpt2.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@id", "NULL");

            frm.CR1.ReportSource = rpt2;
          //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.rpt_all_prd rpt = new RPT.rpt_all_prd();
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
            {
                RPT.emp_today day = new RPT.emp_today();
                RPT.FRM_RPT_PRODUCT frw = new RPT.FRM_RPT_PRODUCT();
                day.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                day.DataSourceConnections[0].IntegratedSecurity = false;
                string date = DateTime.Now.ToShortDateString();
                string UIDV = Program.UID;
                string da2 = DateTime.Now.ToString();
                day.SetParameterValue("@today", DateTime.Now);
                day.SetParameterValue("@eday", DateTime.Now);
                day.SetParameterValue("@emp_name", UIDV);

                frw.CR1.ReportSource = day;
                frw.ShowDialog();
            }
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

        public void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_login asd = new Frm_login();
            logout();
            asd.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            eerr.Visible = false;
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            PL.a_dept rpt = new PL.a_dept();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //  rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            RPT.S_ALL_DEP rpt = new RPT.S_ALL_DEP();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //  rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            newOrderToolStripMenuItem_Click(sender, e);
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

        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PL.Cur frm = new Cur();
            frm.Show();
        }

        private void تعديلالأسعارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            U_price upd = new U_price();
            upd.Show();
        }

        private void أستلامسدادنقديةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cash cs = new cash();
            cs.ShowDialog();
        }

        private void أستلامسدادنقديةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cash cs = new cash();
            cs.ShowDialog();
        }

        private void العملةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Cur frm = new Cur();
            frm.Show();
        }

        private void كلالديونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            PL.a_dept rpt = new a_dept();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
          //  rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void crToolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            RPT.Sales rpt = new RPT.Sales();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
         //   rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void أستردادمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P_Refond refo = new P_Refond();
            refo.ShowDialog();
        }

        private void ترحيلالتحصيلاليوميToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ترحلالتحصيلاليوميToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.c_close clsd = new c_close();
            clsd.ShowDialog();
        }

        private void الشيكاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notif not = new notif();
            not.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            BL.CLS_LOGIN log = new BL.CLS_LOGIN();

            Program.shift_id = log.shift_ls().Rows[0][1].ToString();
            Program.shift_name = log.shift_ls().Rows[0][2].ToString();
            shiftlb.Text = Program.shift_name;

            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            
            blkuser.DataSource = log.US_BLK("", "get");
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Button";
            //btn.Name = "button";
            //btn.Text = "Hit me";
            //btn.UseColumnTextForButtonValue = true;
            //blkuser.Columns.Add(btn);

            dataGridco.DataSource = ord.chaqu_rpt1_3(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;
            dataGridco.Columns[8].Visible = false;

            dataGridcin.DataSource = ord.chaqu_rpt2_4(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;
            dataGridcin.Columns[8].Visible = false;

            dataGridView1.DataSource = prd.low_stock2();
            ex_listgv.DataSource = prd.ex_list();
            dataGridView2.DataSource = prd.get_main_GR();
            dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";

            dataGridView3.DataSource = prd.get_main_GR2();
            dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView3.Columns[2].DefaultCellStyle.Format = "N2";

            dataGridView3.DataSource = prd.get_main_GR2();
            dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView3.Columns[2].DefaultCellStyle.Format = "N2";

            dgv_ls2.DataSource = prd.low_stock2();
            dgv_ex2.DataSource = prd.ex_list();

            dgv_inc.DataSource = prd.get_main_GR3(Program.UID);
            dgv_inc.Columns[1].DefaultCellStyle.Format = "N2";
            dgv_inc.Columns[2].DefaultCellStyle.Format = "N2";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //int today = 0;
            //RPT.s_dept rpt = new RPT.s_dept();
            //rpt.Refresh();
            //rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            //rpt.DataSourceConnections[0].IntegratedSecurity = false;
            //RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            ////  rpt.SetParameterValue("@id", today);
            //frm.CR1.ReportSource = rpt;
            ////  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            ////rpt.PrintToPrinter(1, false, 0, 0);
            //frm.ShowDialog();
            //this.Cursor = Cursors.Default;
        }

        private void تحويلToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void فاتورةمبدائيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            P_inov frm = new P_inov();
            frm.ShowDialog();
        }

        private void أدارنالفواتيرالمبدائيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.P_invo_list frt = new P_invo_list();
            frt.ShowDialog();
        }

        private void الحساباتالرئسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ديونالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int today = 0;
            RPT.S_ALL_DEP rpt = new RPT.S_ALL_DEP();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            //  rpt.SetParameterValue("@id", today);
            frm.CR1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_inov frm = new P_inov();
            frm.ShowDialog();
        }

        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PL.FRM_P_Order frm = new FRM_P_Order();
            frm.ShowDialog();
        }

        private void النثرياتوالمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Nasryat nas = new frm_Nasryat();
            nas.ShowDialog();
        }

        private void النثرياتوالمصروفاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_Nasryat nas = new frm_Nasryat();
            nas.ShowDialog();
        }

        private void navBarItem15_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            cash cs = new cash();
            cs.ShowDialog();
        }

        private void الصلاحياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paem ss = new paem();
            ss.ShowDialog();
        }

        private void مجموعاتالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            US_Groups frt = new US_Groups();
            frt.ShowDialog();
        }

        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.DateRpt rpt = new RPT.DateRpt();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString())); 
            rpt.SetParameterValue("@id", Program.UID);

            frm.CR1.ReportSource = rpt;

            frm.ShowDialog();
            this.Cursor = Cursors.Default;
            //---------------------------------------------
            this.Cursor = Cursors.WaitCursor;
            //DateTime today = DateTime.Now;
            RPT.cash_user rpt2 = new RPT.cash_user();
            rpt.Refresh();
            rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt2.DataSourceConnections[0].IntegratedSecurity = false;
            //  RPT.FRM_RPT_PRODUCT frm2 = new RPT.FRM_RPT_PRODUCT();
            rpt2.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@id", Program.UID);

            frm.CR1.ReportSource = rpt2;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

 

          
        }

        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            newOrderToolStripMenuItem_Click(sender, e);

        }

        private void navBarItem17_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            P_inov frm = new P_inov();
            frm.ShowDialog();
        }

        private void navBarItem21_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Printers prt = new Printers();
            prt.ShowDialog();
        }

        private void navBarItem24_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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

        private void المواسسةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company co = new Company();
            co.ShowDialog();
        }

        private void تقريرتسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.Login_rpt login = new RPT.Login_rpt();
            login.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void البيعبالارباحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.DateRPTF rrr = new RPT.DateRPTF();
            rrr.ty = "pro";
            rrr.ShowDialog();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            timer3.Stop();
            timer3.Enabled = false;

           

        }

        private void lab55_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          notmn.ShowNotification("50db2dde-3a44-467e-af89-001d3654934b");
          notmn.ShowNotification("8d8abd8c-d048-46db-8ed1-09ae05e3dcab");

        }

        private void filterControl1_Click(object sender, EventArgs e)
        {

        }

        private void الشركاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ins_Form ins = new Ins_Form();
            ins.ShowDialog();
        }

        private void المطالباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.Ins_REport frm = new RPT.Ins_REport();
            frm.ShowDialog();
        }

        private void التحصيلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PAY_SET pp = new PAY_SET();
            pp.ShowDialog();
        }

        private void الحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_ACC mm = new Main_ACC();
            mm.ShowDialog();
        }

        private void تحويلToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             Trans_Acc tr = new Trans_Acc();
                        tr.ShowDialog();
        }

        private void قائمةالتحويلاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MNTR_LS tr = new MNTR_LS();
            tr.ShowDialog();
        }

        private void navBarItem19_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DateTime today = DateTime.Now;
            RPT.DateRpt rpt = new RPT.DateRpt();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt.SetParameterValue("@id", Program.UID);

            frm.CR1.ReportSource = rpt;

            frm.ShowDialog();
            this.Cursor = Cursors.Default;
            //---------------------------------------------
            this.Cursor = Cursors.WaitCursor;
            //DateTime today = DateTime.Now;
            RPT.cash_user rpt2 = new RPT.cash_user();
            rpt.Refresh();
            rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt2.DataSourceConnections[0].IntegratedSecurity = false;
            //  RPT.FRM_RPT_PRODUCT frm2 = new RPT.FRM_RPT_PRODUCT();
            rpt2.SetParameterValue("@date1", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@date2", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            rpt2.SetParameterValue("@id", Program.UID);

            frm.CR1.ReportSource = rpt2;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;


        }

        private void عرضالأغلاقاليوميToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MAIN_LS ggg = new MAIN_LS();
            ggg.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PL.c_close clsd = new c_close();
            clsd.ShowDialog();
        }

        private void انتهاءالصلاحيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RPT.EXP_report rpt = new RPT.EXP_report();
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

        list ls = new list();
        private void كرتحركةصنفمحددToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.sts = "P";
            emp.ShowDialog();
        }

        private void قائمةالمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ls.st = 1;
            ls.ShowDialog();
        }

        private void قائمةالنثرياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ls.st = 2;
            ls.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL.CLS_LOGIN log = new BL.CLS_LOGIN();

            Program.shift_id = log.shift_ls().Rows[0][1].ToString();
            Program.shift_name = log.shift_ls().Rows[0][2].ToString();
            shiftlb.Text = Program.shift_name;

            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            blkuser.DataSource = log.US_BLK("", "get");
            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Button";
            //btn.Name = "button";
            //btn.Text = "Hit me";
            //btn.UseColumnTextForButtonValue = true;
            //blkuser.Columns.Add(btn);
            dataGridco.DataSource = ord.chaqu_rpt1_3(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;
            dataGridco.Columns[8].Visible = false;

            dataGridcin.DataSource = ord.chaqu_rpt2_4(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;
            dataGridcin.Columns[8].Visible = false;

            dataGridView1.DataSource = prd.low_stock2();
            ex_listgv.DataSource = prd.ex_list();
            dataGridView2.DataSource = prd.get_main_GR();
            dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";

            dataGridView3.DataSource = prd.get_main_GR2();
            dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView3.Columns[2].DefaultCellStyle.Format = "N2";

        }

        private void المخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stoors str = new Stoors();
            str.ShowDialog();
        }

        private void تدفقالتغديهللوردياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.DateRPTF rrr = new RPT.DateRPTF();
            rrr.ty = "SH";
            rrr.ShowDialog();
        }

        private void Ding_drag_Click(object sender, EventArgs e)
        {
            Ding_drg dng = new Ding_drg ();
            dng.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (daterr.Text == "")
            { return; }
            else
            {
                RPT.Year_ARPAH rbh = new RPT.Year_ARPAH();
                RPT.FRM_RPT_PRODUCT frw = new RPT.FRM_RPT_PRODUCT();
                rbh.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rbh.DataSourceConnections[0].IntegratedSecurity = false;
                rbh.SetParameterValue("@year", Convert.ToInt32(daterr.Text));
                frw.CR1.ReportSource = rbh;
                frw.ShowDialog();

                RPT.Year_rphcrs rbh2 = new RPT.Year_rphcrs();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rbh2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rbh2.DataSourceConnections[0].IntegratedSecurity = false;
                rbh2.SetParameterValue("@year", Convert.ToInt32(daterr.Text));
                frm.CR1.ReportSource = rbh2;
                frm.ShowDialog();
                eerr.Visible = false;

                RPT.Arpah_users rbh3 = new RPT.Arpah_users();
                RPT.FRM_RPT_PRODUCT frm2 = new RPT.FRM_RPT_PRODUCT();
                rbh3.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rbh3.DataSourceConnections[0].IntegratedSecurity = false;
                rbh3.SetParameterValue("@year", Convert.ToInt32(daterr.Text));
                frm.CR1.ReportSource = rbh3;
                frm.ShowDialog();
                eerr.Visible = false;
            }
        }

        private void التقاريرالسنويهToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;

            daterr.Value = DateTime.Now;
            var point = new Point(posX-5, 10);
            this.eerr.Location = point;

            
            eerr.Visible = true;
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            daterr.Value = DateTime.Now;
            eerr.Visible = false;
        }

        private void dASHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSB fff = new DSB();
            fff.Show();
        }

        private void الموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PL.Employees emp = new Employees();
            emp.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            eerr.Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Attin att = new Attin();
            att.ShowDialog();
        }

        private void إنتهاءالصلاحيهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finsh_dgv ff = new Finsh_dgv();
            ff.ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            tabControl2.Visible = true;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            tabControl1.Visible = true;
        }

        private void tabControl2_MouseClick(object sender, MouseEventArgs e)
        {
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            BL.CLS_PRODUCTS prd=new BL.CLS_PRODUCTS();
            dataGridco.DataSource = ord.chaqu_rpt1(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;

            dataGridcin.DataSource = ord.chaqu_rpt2(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;

            dataGridView1.DataSource = prd.low_stock2();
            // dataGridView1.Columns[1].Visible = false;


            dataGridView2.DataSource = prd.get_main_GR();
            dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView3.DataSource = prd.get_main_GR2();
            dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            //notif not = new notif();
            //not.ShowDialog();

            dgv_ls2.DataSource = prd.low_stock2();
            dgv_ex2.DataSource = prd.ex_list();

            dgv_inc.DataSource = prd.get_main_GR3(Program.UID);
            dgv_inc.Columns[1].DefaultCellStyle.Format = "N2";
            dgv_inc.Columns[2].DefaultCellStyle.Format = "N2";



        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();

            dataGridco.DataSource = ord.chaqu_rpt1(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;

            dataGridcin.DataSource = ord.chaqu_rpt2(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;

            dataGridView1.DataSource = prd.low_stock2();
            // dataGridView1.Columns[1].Visible = false;


            dataGridView2.DataSource = prd.get_main_GR();
            dataGridView2.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridView3.DataSource = prd.get_main_GR2();
            dataGridView3.Columns[1].DefaultCellStyle.Format = "N2";
            //notif not = new notif();
            //not.ShowDialog();

            dgv_ls2.DataSource = prd.low_stock2();
            dgv_ex2.DataSource = prd.ex_list();

            dgv_inc.DataSource = prd.get_main_GR3(Program.UID);
            dgv_inc.Columns[1].DefaultCellStyle.Format = "N2";
            dgv_inc.Columns[2].DefaultCellStyle.Format = "N2";



        }

        private void الحركةحسبالوردياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT._2date ddd = new RPT._2date();
            ddd.CS = "Sh";ddd.ShowDialog();
        }

        private void لوحةالبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSB fff = new DSB();
            fff.ShowDialog();
        }

        private void simpleButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                eerr.Visible = false;
            }
        }

        private void blkuser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {try
                {
                    log.US_BLK(blkuser.CurrentRow.Cells[1].Value.ToString(), "rls");
                    MessageBox.Show("تم تفعيل المستخدم  " + blkuser.CurrentRow.Cells[2].Value.ToString() + " بنجاح");
                    blkuser.DataSource = log.US_BLK("", "get");
                }
                catch { return; }

            }
        }

        private void navBarItem23_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            لوحةالبياناتToolStripMenuItem_Click(sender, e);
        }

        private void ضريبةالقيمةالمضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPT.DateRPTF ff = new RPT.DateRPTF();
            ff.ty = "VAT";ff.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POS_SR po = new PL.POS_SR();
            po.ShowDialog();
        }

        private void pOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POS_SR po = new PL.POS_SR();
            po.ShowDialog();
        }

        public void pOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            POS_ST st = new PL.POS_ST();
            st.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            test ss = new test();
            ss.ShowDialog();
        }

        private void اليومياتالغيرمغلقةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            not_close nnn = new PL.not_close();
            nnn.ShowDialog();
        }
    }
}
