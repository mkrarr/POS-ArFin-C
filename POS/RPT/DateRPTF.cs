using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;


namespace POS.RPT
{
    public partial class DateRPTF : Form
    {
        public string ty = "";
        public DateRPTF()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ty == "pro")
            {
                this.Cursor = Cursors.WaitCursor;
                RPT.Sals_pro dat = new RPT.Sals_pro();
                RPT.FRM_Report frm = new FRM_Report();
                dat.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                dat.DataSourceConnections[0].IntegratedSecurity = false;

                ParameterFields paramFields = new ParameterFields();

                ParameterField paramField = new ParameterField();
                ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
                paramField.Name = "@s_date";
                paramDiscreteValue.Value = dateTimePicker1.Value;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField(); // <-- This line is added
                paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
                paramField.Name = "@Edate";
                paramDiscreteValue.Value = dateTimePicker2.Value;
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);

                paramField = new ParameterField(); // <-- This line is added
                paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
                paramField.Name = "@key";
                paramDiscreteValue.Value = "1";
                paramField.CurrentValues.Add(paramDiscreteValue);
                paramFields.Add(paramField);



                frm.crystalReportViewer1.ParameterFieldInfo = paramFields;
                frm.crystalReportViewer1.ReportSource = dat;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else if (ty == "SH")
            {
                this.Cursor = Cursors.WaitCursor;
                RPT.FRM_Report frm3 = new FRM_Report();
                RPT.Shift_Flow rpt = new RPT.Shift_Flow();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt.SetParameterValue("@date1", dateTimePicker1.Value);
                rpt.SetParameterValue("@date2", dateTimePicker2.Value);
                frm3.crystalReportViewer1.ReportSource = rpt;
                //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm3.ShowDialog();
             
           //RPT 2
                
                RPT.FRM_Report frm2 = new FRM_Report();
                RPT.SH_grph rpt2 = new RPT.SH_grph();
                rpt2.Refresh();
                rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt2.DataSourceConnections[0].IntegratedSecurity = false;

                rpt2.SetParameterValue("@date1", dateTimePicker1.Value);
                rpt2.SetParameterValue("@date2", dateTimePicker2.Value);
                frm2.crystalReportViewer1.ReportSource = rpt2;
                //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm2.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            else if (ty == "VAT")
            {
                this.Cursor = Cursors.WaitCursor;
                RPT.FRM_Report frm3 = new FRM_Report();
                RPT.RPT_VAT rpt = new RPT.RPT_VAT();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt.SetParameterValue("@date1", dateTimePicker1.Value);
                rpt.SetParameterValue("@date2", dateTimePicker2.Value);
                rpt.SetParameterValue("@act", "CUS");

                frm3.crystalReportViewer1.ReportSource = rpt;
                //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm3.ShowDialog();

                //RPT 2

                RPT.FRM_Report frm2 = new FRM_Report();
                RPT.RPT_VAT rpt2 = new RPT.RPT_VAT();
                rpt2.Refresh();
                rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt2.DataSourceConnections[0].IntegratedSecurity = false;

                rpt2.SetParameterValue("@date1", dateTimePicker1.Value);
                rpt2.SetParameterValue("@date2", dateTimePicker2.Value);
                rpt2.SetParameterValue("@act", "SUP");

                frm2.crystalReportViewer1.ReportSource = rpt2;
                //  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                //rpt.PrintToPrinter(1, false, 0, 0);
                frm2.ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

    }
}


