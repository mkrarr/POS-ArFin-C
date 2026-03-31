using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.RPT
{
    
    public partial class _2date : Form
    {
        public string CS="Sh";
        public _2date()
        {
            InitializeComponent();
        }

        private void _2date_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(CS=="Sh")
            {
                this.Cursor = Cursors.WaitCursor;
              //  int order_id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                RPT.Shift_Flow rpt = new RPT.Shift_Flow();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@date1", Convert.ToDateTime(dateEdit1.Text));
                rpt.SetParameterValue("@date2", Convert.ToDateTime(dateEdit2.Text));

                frm.CR1.ReportSource = rpt;
                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm.ShowDialog();
                this.Cursor = Cursors.Default;

                this.Cursor = Cursors.WaitCursor;
                //  int order_id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                RPT.SH_grph rpt2 = new RPT.SH_grph();
                rpt2.Refresh();
                rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt2.DataSourceConnections[0].IntegratedSecurity = false;
           //     RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt2.SetParameterValue("@date1", Convert.ToDateTime(dateEdit1.Text));
                rpt2.SetParameterValue("@date2", Convert.ToDateTime(dateEdit2.Text));

                frm.CR1.ReportSource = rpt2;
                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm.ShowDialog();
                this.Cursor = Cursors.Default;


                this.Cursor = Cursors.WaitCursor;
                //  int order_id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                RPT.Shift_MACC rpt3 = new RPT.Shift_MACC();
                rpt3.Refresh();
                rpt3.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt3.DataSourceConnections[0].IntegratedSecurity = false;
                //     RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt3.SetParameterValue("@date1", Convert.ToDateTime(dateEdit1.Text));
                rpt3.SetParameterValue("@date2", Convert.ToDateTime(dateEdit2.Text));

                frm.CR1.ReportSource = rpt3;
                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
