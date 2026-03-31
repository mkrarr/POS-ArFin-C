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
    public partial class list : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        public int st = 0;
        public list()
        {
            InitializeComponent();

        }

        private void list_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.list_Cash_Nsr(textBox1.Text,st) ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.list_Cash_Nsr(textBox1.Text, st);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(st==1)
            {
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
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
            }
            else if(st==2)
            {

            }
        }
    }
}
