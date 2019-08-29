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
            this.Cursor = Cursors.WaitCursor;

            dat.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            dat.DataSourceConnections[0].IntegratedSecurity = false;

            //  dat.SetParameterValue("@S_Date", date1.Text);


            //dat.SetParameterValue("@E_Date", date2.Text);


            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
            paramField.Name = "@Date1";
            paramDiscreteValue.Value = date1.Text;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);

            paramField = new ParameterField(); // <-- This line is added
            paramDiscreteValue = new ParameterDiscreteValue();  // <-- This line is added
            paramField.Name = "@Date2";
            paramDiscreteValue.Value = date2.Text;
            paramField.CurrentValues.Add(paramDiscreteValue);
            paramFields.Add(paramField);



            frm.CR1.ParameterFieldInfo = paramFields;
            frm.CR1.ReportSource = dat;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
