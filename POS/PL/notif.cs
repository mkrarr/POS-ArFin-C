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
    public partial class notif : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        BL.Suppliers su = new BL.Suppliers();

        void ref_data()
        {
         //   -----------------
            dataGridco.DataSource = ord.chaqu_rpt11(DateTime.Now);

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;
        //    -----------------
            dataGridcin.DataSource = ord.chaqu_rpt22(DateTime.Now);

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;
         //   --------3--------
            dataGrid3.DataSource = ord.chaqu_rpt33(DateTime.Now);

            dataGrid3.Columns[0].Visible = false;
            dataGrid3.Columns[1].Visible = false;
            dataGrid3.Columns[6].Visible = false;
         //   -------4--------
            dataGrid4.DataSource = ord.chaqu_rpt44(DateTime.Now);

            dataGrid4.Columns[0].Visible = false;
            dataGrid4.Columns[1].Visible = false;
            dataGrid4.Columns[6].Visible = false;
        }
        public notif()
        {
            InitializeComponent();
        }

        private void notif_Load(object sender, EventArgs e)
        {
            //---------------------out--------------
            dataGridco.DataSource = ord.chaqu_rpt11(DateTime.Now);

            dataGridco.Columns[0].Visible = false;
            dataGridco.Columns[1].Visible = false;
            dataGridco.Columns[6].Visible = false;
            dataGridco.Columns[8].Visible = false;
            //-------------in-----------------
            dataGridcin.DataSource = ord.chaqu_rpt22(DateTime.Now);

            dataGridcin.Columns[0].Visible = false;
            dataGridcin.Columns[1].Visible = false;
            dataGridcin.Columns[6].Visible = false;
            dataGridcin.Columns[8].Visible = false;
            //--------3--------
            dataGrid3.DataSource = ord.chaqu_rpt33(DateTime.Now);

            dataGrid3.Columns[0].Visible = false;
            dataGrid3.Columns[1].Visible = false;
            dataGrid3.Columns[6].Visible = false;
            dataGrid3.Columns[8].Visible = false;
            //-------4--------
            dataGrid4.DataSource = ord.chaqu_rpt44(DateTime.Now);

            dataGrid4.Columns[0].Visible = false;
            dataGrid4.Columns[1].Visible = false;
            dataGrid4.Columns[6].Visible = false;
            dataGrid4.Columns[8].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab==tabPage2)
            {       
                ord.set_p_pay(Convert.ToInt32(dataGridcin.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridcin.CurrentRow.Cells[3].Value));
                ord.set_pay(Convert.ToInt32(dataGridcin.CurrentRow.Cells[0].Value));
                ord.add_cash_histoty(Program.UID, 0,Convert.ToDouble(dataGridcin.CurrentRow.Cells[3].Value), Convert.ToInt32(dataGridcin.CurrentRow.Cells[8].Value), " فاتورة مشتريات ", dataGridcin.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGridcin.CurrentRow.Cells[5].Value), DateTime.Now,2, Convert.ToInt32(dataGridcin.CurrentRow.Cells[1].Value));
                double n_debt = (Convert.ToDouble(dataGridcin.CurrentRow.Cells[3].Value) * -1);
                su.add_dept_s(Convert.ToInt32(dataGridcin.CurrentRow.Cells[1].Value), n_debt);  
                //report 

                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridcin.CurrentRow.Cells[5].Value);
                RPT.P_order rpt = new RPT.P_order();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
                ref_data();
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                
                ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                ord.set_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[0].Value));
                ord.add_cash_histoty(Program.UID, Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value) ,0, Convert.ToInt32(dataGridco.CurrentRow.Cells[8].Value), " فاتورة مبيعات ", dataGridco.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), DateTime.Now,1,Convert.ToInt32(dataGridco.CurrentRow.Cells[1].Value));
                double n_debt = (Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value) * -1);
                cus.add_dept(Convert.ToInt32(dataGridco.CurrentRow.Cells[1].Value), n_debt);
                //report
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value);
                RPT.order_InvoA4P rpt = new RPT.order_InvoA4P();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT; 
                rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;
                ref_data();

                //-----------------------
             
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                if (Convert.ToInt32(dataGrid4.CurrentRow.Cells[1].Value) != 10101010)
                {
                    //ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                    ord.set_pay(Convert.ToInt32(dataGrid4.CurrentRow.Cells[0].Value));
                    ord.add_cash_histoty(Program.UID, 0, Convert.ToDouble(dataGrid4.CurrentRow.Cells[3].Value), Convert.ToInt32(dataGrid4.CurrentRow.Cells[8].Value), "أستلام نقدية", dataGrid4.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGrid4.CurrentRow.Cells[5].Value), DateTime.Now, 3, 0);
                    //report

                    this.Cursor = Cursors.WaitCursor;
                    int order_id = Convert.ToInt32(dataGrid4.CurrentRow.Cells[5].Value);
                    RPT.c_in_out rpt = new RPT.c_in_out();
                    rpt.Refresh();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.SetParameterValue("@id", order_id);
                    frm.CR1.ReportSource = rpt;
                    rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                    rpt.PrintToPrinter(1, false, 0, 0);
                    this.Cursor = Cursors.Default;
                    ref_data();
                }
                else
                {
                    //ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                    ord.set_pay(Convert.ToInt32(dataGrid4.CurrentRow.Cells[0].Value));
                    ord.add_cash_histoty(Program.UID, 0, Convert.ToDouble(dataGrid4.CurrentRow.Cells[3].Value), Convert.ToInt32(dataGrid4.CurrentRow.Cells[8].Value), "أستلام نقدية", dataGrid4.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGrid4.CurrentRow.Cells[5].Value), DateTime.Now, 3, 0);
                    ref_data();
                }
                //--------
            }

            else if (tabControl1.SelectedTab == tabPage5)
            {

                //ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                ord.set_pay(Convert.ToInt32(dataGrid3.CurrentRow.Cells[0].Value));
                ord.add_cash_histoty(Program.UID, Convert.ToDouble(dataGrid3.CurrentRow.Cells[3].Value) , 0, Convert.ToInt32(dataGrid3.CurrentRow.Cells[8].Value), "دفع نقدية", dataGrid3.CurrentRow.Cells[2].Value.ToString(), Convert.ToInt32(dataGrid3.CurrentRow.Cells[5].Value), DateTime.Now,4,0);

              this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGrid3.CurrentRow.Cells[5].Value);
        RPT.c_in_out rpt = new RPT.c_in_out();
        rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
        rpt.SetParameterValue("@id", order_id);
                frm.CR1.ReportSource = rpt;
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;
                ref_data();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {

                ord.set_reject(Convert.ToInt32(dataGridcin.CurrentRow.Cells[0].Value));
                ref_data();
                // MessageBox.Show("       Order " + order_id.ToString() + " Save      ", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {

                ord.set_reject(Convert.ToInt32(dataGridco.CurrentRow.Cells[0].Value));
                ref_data();

            }
            else if (tabControl1.SelectedTab == tabPage4)
            {

                //ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                ord.set_reject(Convert.ToInt32(dataGrid4.CurrentRow.Cells[0].Value));
                ref_data();
            }

            else if (tabControl1.SelectedTab == tabPage5)
            {

                //ord.set_o_pay(Convert.ToInt32(dataGridco.CurrentRow.Cells[5].Value), Convert.ToDouble(dataGridco.CurrentRow.Cells[3].Value));
                ord.set_reject(Convert.ToInt32(dataGrid3.CurrentRow.Cells[0].Value));

                ref_data();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
