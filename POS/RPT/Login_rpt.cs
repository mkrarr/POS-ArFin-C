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


namespace POS.RPT
{
    public partial class Login_rpt : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        string act = "";
        public Login_rpt()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.DataSource = log.get_log_key("c");
            comboBox1.DisplayMember = "c_name";
            comboBox1.ValueMember = "c_name";
            act = "c";

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox1.DataSource = log.get_log_key("u");
            comboBox1.DisplayMember = "u_name";
            comboBox1.ValueMember = "u_id";
            act = "u";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                dataGridView1.DataSource = log.get_log_rpt(act, comboBox1.SelectedValue.ToString(), date1.Value, date2.Value);
            int cou = dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[8].Value.ToString()) == "True")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.RoyalBlue;
                }else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void all_CheckedChanged(object sender, EventArgs e)
        {

           
            act = "all";
            comboBox1.Enabled = false;
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RPT.Login_rptt dat = new RPT.Login_rptt();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[8].Value.ToString()) == "True")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.RoyalBlue;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
    }
}
