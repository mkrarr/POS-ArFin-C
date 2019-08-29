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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            BL.CLS_LOGIN log = new BL.CLS_LOGIN();
            comboBox1.DataSource = log.get_users();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RPT.emp_today day = new RPT.emp_today();
            RPT.FRM_RPT_PRODUCT fr = new RPT.FRM_RPT_PRODUCT();
            day.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            day.DataSourceConnections[0].IntegratedSecurity = false;
            string date = DateTime.Now.ToShortDateString();
            string UIDV = Program.UID;
            string da2 = dateTimePicker1.Value.ToShortDateString();
            day.SetParameterValue("@today", Convert.ToDateTime(da2));
            day.SetParameterValue("@emp_name", comboBox1.SelectedValue.ToString());
            fr.CR1.ReportSource = day;
            fr.ShowDialog();
        }
    }
}
