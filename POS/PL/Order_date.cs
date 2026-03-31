using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace POS.PL
{
    public partial class Order_date : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        RPT.DateRpt dat = new RPT.DateRpt();
        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
        RPT.FRM_Report frm3 = new RPT.FRM_Report();
        public Order_date()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime D1 = Convert.ToDateTime(date1.Text);
            DateTime D2 = Convert.ToDateTime(date2.Text);

           
            this.dataGridView1.DataSource = ord.RPT_Date(D1, D2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string D1 = date1.Value.ToString("MM/dd/yyyy");
            string D2 = date2.Value.ToString("MM/dd/yyyy");


            this.Cursor = Cursors.WaitCursor;

            dat.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            dat.DataSourceConnections[0].IntegratedSecurity = false;

            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "@Date1";
            paramDiscreteValue.Value = D1;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "@Date2";
            paramDiscreteValue.Value = D2;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "@id";
            paramDiscreteValue.Value = "NULL";
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);



            frm.CR1.ParameterFieldInfo = paramFields;
            frm.CR1.ReportSource = dat;
            frm.ShowDialog();

          //-------------
            RPT.cash_user rpt = new RPT.cash_user();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
           
            rpt.SetParameterValue("@date1",D1);
            rpt.SetParameterValue("@date2", D2);
            rpt.SetParameterValue("@id", "NULL");
            frm3.crystalReportViewer1.ReportSource = rpt;
            //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
            //rpt.PrintToPrinter(1, false, 0, 0);
            frm3.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
