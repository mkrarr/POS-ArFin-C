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
    public partial class Refond_List : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        public Refond_List()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = ord.refund_list("");

        }

        private void Refond_List_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.refund_list(textBox1.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


            RPT.Ref_inv_A4 rpt = new RPT.Ref_inv_A4();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetDataSource(ORD.get_order_details(order_id));
            //            rpt.SetParameterValue(order_id);
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            if (MessageBox.Show("You wont To print it", "Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;
            }
            else
            {
                frm.ShowDialog();
            }
        }
    }
}
