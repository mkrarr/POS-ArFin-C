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
    public partial class POP_ORD : Form
    {
        BL.CLS_ORDERS cls = new BL.CLS_ORDERS();
        public int o_id = 0;
        public POP_ORD()
        {
            InitializeComponent();
        }

        private void POP_ORD_Load(object sender, EventArgs e)
        {
            DataTable dt = cls.Get_POS_DT(o_id);
            user.Text = dt.Rows[0][0].ToString();
            c_id.Text = dt.Rows[0][1].ToString();
            c_name.Text = dt.Rows[0][2].ToString();
            pay.Text = dt.Rows[0][4].ToString();
            NO.Text = dt.Rows[0][5].ToString();
            date.Text = dt.Rows[0][6].ToString();
            Note.Text = dt.Rows[0][7].ToString();

            dataGridView1.DataSource = cls.Get_POS_DTp(o_id);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 15;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            double tot = (from DataGridViewRow row in dataGridView1.Rows
                          where row.Cells[4].FormattedValue.ToString() != string.Empty
                          select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
            Total.Text = tot.ToString("N2");

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            RPT.POS_INV rpt = new RPT.POS_INV();
            int order_id = o_id;

            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            //for (int k = 0; k < Program.RC; k++)

            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            rpt.PrintToPrinter(Program.IC, false, 0, 0);

            //frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
