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
    public partial class Ins_REport : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        public Ins_REport()
        {
            InitializeComponent();
            ins_com.DataSource = ord.INS_LIST();
            ins_com.DisplayMember = "name";
            ins_com.ValueMember = "id";
        }

        private void Ins_REport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ins_com.SelectedValue != null)
            {
                dataGridView1.DataSource = ord.ins_Detals_ls(Convert.ToInt32(ins_com.SelectedValue), date1.Value, date2.Value);
                textBox1.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[6].FormattedValue.ToString() != string.Empty
                              select Convert.ToDecimal(row.Cells[6].FormattedValue)).Sum().ToString();
            }
            else
            {
                MessageBox.Show("\t تاكد من البيانات \t", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int id = Convert.ToInt32(ins_com.SelectedValue);
            RPT.RPT_Ins_Clemas rpt = new RPT.RPT_Ins_Clemas();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@ins_id", id);
            rpt.SetParameterValue("@date1", date1.Value);
            rpt.SetParameterValue("@date2", date2.Value);

            frm.CR1.ReportSource = rpt;
            try
            {
               // rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
            }
            catch
            {
              //  rpt.PrintToPrinter(1, false, 0, 0);
            }
            frm.ShowDialog();

            RPT.RPT_INS_Sumary rpt2 = new RPT.RPT_INS_Sumary();
            rpt2.Refresh();
            rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt2.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm2 = new RPT.FRM_RPT_PRODUCT();
            rpt2.SetParameterValue("@ins_id", id);
            rpt2.SetParameterValue("@date1", date1.Value);
            rpt2.SetParameterValue("@date2", date2.Value);

            frm2.CR1.ReportSource = rpt2;
            try
            {
                // rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
            }
            catch
            {
                //  rpt.PrintToPrinter(1, false, 0, 0);
            }
            frm2.ShowDialog();

            this.Cursor = Cursors.Default;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
