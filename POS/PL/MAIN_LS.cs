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
    public partial class MAIN_LS : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public MAIN_LS()
        {
            InitializeComponent();
            dataGridView1.DataSource = log.get_main_hisLS();
        }

        private void MAIN_LS_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            RPT.ACC_cloas dat = new RPT.ACC_cloas();
            dat.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            dat.DataSourceConnections[0].IntegratedSecurity = false;
            dat.SetParameterValue("@p_id", Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.CR1.ReportSource = dat;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
