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
    public partial class Order_Report : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        RPT.Trans dat = new RPT.Trans();

        RPT.FRM_RPT_PRODUCT frm = new FRM_RPT_PRODUCT();
        public Order_Report()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.Sel_OR_RE(Convert.ToDateTime(date2.Text), Convert.ToDateTime(DATE1.Text));
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;


        }

        private void Order_Report_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.p_ref_invo rpt = new RPT.p_ref_invo();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
