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
    public partial class MNTR_LS : Form
    {
        public MNTR_LS()
        {
            InitializeComponent();
        }

        private void MNTR_LS_Load(object sender, EventArgs e)
        {
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            dataGridView1.DataSource = ord.maintr_list();

        }

        private void button5_Click(object sender, EventArgs e)
        {


            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.main_trRPT rpt = new RPT.main_trRPT();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@id", order_id);
            frm.CR1.ReportSource = rpt;
              frm.Show();
           // rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
            //rpt.PrintToPrinter(1, false, 0, 0);
            this.Cursor = Cursors.Default;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
