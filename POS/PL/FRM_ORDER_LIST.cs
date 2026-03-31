using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POS.PL
{
    public partial class FRM_ORDER_LIST : Form

    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();

        public FRM_ORDER_LIST()
        {
            InitializeComponent();
            //this.dataGridView1.DataSource=ord.searchOrders("");
            //dataGridView1.Rows[5].Visible = false;
            //dataGridView1.Rows[6].Visible = false;
        }

        private void FRM_ORDER_LIST_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.searchOrders(textBox1.Text);
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            if  (FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled == true)
            {
                button2.Enabled = true;
            }
            else { return; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.searchOrders(textBox1.Text);
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string invt = ord.inv_ty().Rows[0][0].ToString();
            //   label25.Text = invt;
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            /* MessageBox.Show("Print" + order_id + "order");
             RPT.Rpt_Order_print rptort = new RPT.Rpt_Order_print();
             RPT.FRM_Report frm = new RPT.FRM_Report();
             rptort.SetDataSource(ORD.get_order_details(order_id));
             frm.crystalReportViewer1.ReportSource = rptort;
             frm.ShowDialog();*/
            if (invt=="1")
            {
                RPT.Rpt_ord_invo rpt = new RPT.Rpt_ord_invo();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                // rpt.SetDataSource(ORD.get_order_details(order_id));
                //            rpt.SetParameterValue(order_id);
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else if (invt == "0")
            {
                RPT.s_order rpt = new RPT.s_order();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                // rpt.SetDataSource(ORD.get_order_details(order_id));
                //            rpt.SetParameterValue(order_id);
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else if (invt == "2")
            {
                RPT.ins_orderPR rpt = new RPT.ins_orderPR();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                // rpt.SetDataSource(ORD.get_order_details(order_id));
                //            rpt.SetParameterValue(order_id);
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PL.Refond refo=new PL.Refond();
            refo.txtORef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            refo.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Recipt res = new Recipt();
            res.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            res.textBox2.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            res.txtoname.Text= this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            res.deb = Convert.ToDouble(this.dataGridView1.CurrentRow.Cells[5].Value.ToString());
            res.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            /* MessageBox.Show("Print" + order_id + "order");
             RPT.Rpt_Order_print rptort = new RPT.Rpt_Order_print();
             RPT.FRM_Report frm = new RPT.FRM_Report();
             rptort.SetDataSource(ORD.get_order_details(order_id));
             frm.crystalReportViewer1.ReportSource = rptort;
             frm.ShowDialog();*/
           
            RPT.order_InvoA4P rpt = new RPT.order_InvoA4P();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetDataSource(ORD.get_order_details(order_id));
            //            rpt.SetParameterValue(order_id);
            rpt.SetParameterValue("@ID_ORDER", order_id);
            
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            /* MessageBox.Show("Print" + order_id + "order");
             RPT.Rpt_Order_print rptort = new RPT.Rpt_Order_print();
             RPT.FRM_Report frm = new RPT.FRM_Report();
             rptort.SetDataSource(ORD.get_order_details(order_id));
             frm.crystalReportViewer1.ReportSource = rptort;
             frm.ShowDialog();*/

            RPT.vat_inv_A4 rpt = new RPT.vat_inv_A4();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            // rpt.SetDataSource(ORD.get_order_details(order_id));
            //            rpt.SetParameterValue(order_id);
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
