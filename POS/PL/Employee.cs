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
        public string sts = "E";
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
            if (sts == "P")
            {
                RPT.pro_TRLOG cash = new RPT.pro_TRLOG();
                RPT.FRM_RPT_PRODUCT fr = new RPT.FRM_RPT_PRODUCT();
                cash.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                cash.DataSourceConnections[0].IntegratedSecurity = false;


                cash.SetParameterValue("@date1", dateTimePicker1.Value);
                cash.SetParameterValue("@date2", dateTimePicker2.Value);
                cash.SetParameterValue("@id", id.Text);
                fr.CR1.ReportSource = cash;
                fr.ShowDialog();
            }
            else
            {
                {
                    RPT.emp_today day = new RPT.emp_today();
                    RPT.FRM_RPT_PRODUCT fr = new RPT.FRM_RPT_PRODUCT();
                    day.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    day.DataSourceConnections[0].IntegratedSecurity = false;
                    string date = DateTime.Now.ToShortDateString();
                    string UIDV = Program.UID;
                    string da2 = dateTimePicker1.Value.ToShortDateString();
                    day.SetParameterValue("@today", dateTimePicker1.Value);
                    day.SetParameterValue("@eday", dateTimePicker2.Value);
                    day.SetParameterValue("@emp_name", comboBox1.SelectedValue.ToString());
                    fr.CR1.ReportSource = day;
                    fr.ShowDialog();
                }
                {
                    RPT.emp_cash2 cash = new RPT.emp_cash2();
                    RPT.FRM_RPT_PRODUCT fr = new RPT.FRM_RPT_PRODUCT();
                    cash.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    cash.DataSourceConnections[0].IntegratedSecurity = false;


                    cash.SetParameterValue("@date1", dateTimePicker1.Value);
                    cash.SetParameterValue("@date2", dateTimePicker2.Value);
                    cash.SetParameterValue("@u_id", comboBox1.SelectedValue);
                    fr.CR1.ReportSource = cash;
                    fr.ShowDialog();
                }
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            if(sts=="P")
            {
                comboBox1.Visible = false;
                label2.Text = "الصنف";
                id.Visible = false;
                name.Visible = true;
                btt.Visible = true;
                this.Text = "كرت الحركه";
            }
            else 
            {
                comboBox1.Visible = true;
                label2.Text = "الموظف";
                id.Visible = false;
                name.Visible = false;
                btt.Visible = false;
                this.Text = "حركة الموظف";


            }
        }

        private void btt_Click(object sender, EventArgs e)
        {
            PL.FRM_PRO_LIST XXX = new FRM_PRO_LIST();
            XXX.ShowDialog();
            id.Text = XXX.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = XXX.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        //   id.Text= Convert.ToString( XXX.dataGridView1.CurrentRow.Cells[0].Value);
          // id.Text = Convert.ToString(XXX.dataGridView1.CurrentRow.Cells[0].Value);
        } 
    }
}
