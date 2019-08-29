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
    public partial class P_list : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        public P_list()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text);

        }

        private void P_list_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            /* MessageBox.Show("Print" + order_id + "order");
             RPT.Rpt_Order_print rptort = new RPT.Rpt_Order_print();
             RPT.FRM_Report frm = new RPT.FRM_Report();
             rptort.SetDataSource(ORD.get_order_details(order_id));
             frm.crystalReportViewer1.ReportSource = rptort;
             frm.ShowDialog();*/

            RPT.P_order rpt = new RPT.P_order();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetDataSource(ORD.get_order_details(order_id));
            //            rpt.SetParameterValue(order_id);
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            frm.Show();
            this.Cursor = Cursors.Default;
        }
    }
}
