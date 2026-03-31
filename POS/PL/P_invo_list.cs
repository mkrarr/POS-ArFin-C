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
    public partial class P_invo_list : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();

        public P_invo_list()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = ord.searchPOrder("");
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.searchPOrder(textBox1.Text);
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.PS_INVO rpt = new RPT.PS_INVO();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
            // rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
           //rpt.PrintToPrinter(1, false, 0, 0);
            this.Cursor = Cursors.Default;
        }

        private void P_invo_list_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridView2.DataSource=ord.pinvo_dt(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            txttotal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtpay.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcid.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           Image img = ord.qrCode(txtoid.Text + "_", txtoid.Text);

            if (dataGridView2.Rows.Count > 0)
            {
                if (MessageBox.Show(" \n   \t هل انت واثق من العملية \t", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    this.txtoid.Text = ord.get_l_o_id().Rows[0][0].ToString();
                    ord.ADD_ORDER(Convert.ToInt32(txtoid.Text), DateTime.Now, Convert.ToInt32(txtcid.Text), "From P_Invoice - " + dataGridView1.CurrentRow.Cells[0].Value.ToString(), Program.SelasMAN, txttotal.Text, Program.UID, Program.IPA, Program.PC, "-", 0.00, Convert.ToDouble(txttotal.Text), Convert.ToInt32(txtpay.Text),1,"Cash","Name",0,0);
                    ord.add_cash_histoty(Program.UID, Convert.ToDouble(txttotal.Text), 0, Convert.ToInt32(txtpay.Text), "فاتورة مبيعات", dataGridView1.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(txtoid.Text), DateTime.Now, 1, Convert.ToInt32(txtcid.Text));

                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        ord.ADD_ORDER_DETAILS(dataGridView2.Rows[i].Cells[0].Value.ToString(),
                                                Convert.ToInt32(txtoid.Text),
                                               Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value),
                                                dataGridView2.Rows[i].Cells[2].Value.ToString(),
                                                Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value),
                                                dataGridView2.Rows[i].Cells[4].Value.ToString(),
                                                dataGridView2.Rows[i].Cells[6].Value.ToString());
                    }
                    ord.done_piv(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    MessageBox.Show("تم حفظ الامر بالرقم " + txtoid.Text + " ", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //------------------------------------------
                    dataGridView2.DataSource = "";
                    this.dataGridView1.DataSource = ord.searchPOrder("");
                    txttotal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    txtpay.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    txtcid.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //------------------------------------------
                    this.Cursor = Cursors.WaitCursor;
                    int order_id = Convert.ToInt32(txtoid.Text);
                    

                    RPT.order_InvoA4 rpt = new RPT.order_InvoA4();
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
                else { return; }
            }
            else
            {
                MessageBox.Show("الرجاء التاكد من البيانات", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
