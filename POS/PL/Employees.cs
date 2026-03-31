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
    public partial class Employees : Form
    {
        BL.HR hr = new BL.HR();
        public string note = "";
        public Employees()
        {
            InitializeComponent();
        }

        private void btcon_Click(object sender, EventArgs e)
        {
            Employee_info ss = new Employee_info();
            ss.sts = 0;
            ss.ShowDialog();
            dataGridView1.DataSource = hr.empSP(0, key.Text, "", "", DateTime.Now, "", 0, "", 0, "", "", "get");

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hr.empSP(0, key.Text, "", "", DateTime.Now, "", 0, "", 0, "", "", "get");

        }

        private void key_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hr.empSP(0, key.Text, "", "", DateTime.Now, "", 0, "", 0, "", "", "get");

        }

        private void btac_Click(object sender, EventArgs e)
        {
            Employee_info ss = new Employee_info();
            ss.sts = 1;
            try
            {
                ss.txtid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ss.ShowDialog();
                dataGridView1.DataSource = hr.empSP(0, key.Text, "", "", DateTime.Now, "", 0, "", 0, "", "", "get");

            }
            catch
            {
                MessageBox.Show("الرجاء التاكد من تحديد الموظف");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btcnc_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[11].Value.ToString() != "موظف")
            {
                MessageBox.Show("الموظف مفصول مسبقاً ");
                return;
            }else
            if(MessageBox.Show("هل انت واثق من العمليه \n سوف تاثر العمليه على ملف الموظف وتحفظ باسمك","أيقاف موظف",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.Cancel)
            {
                return;
            }
            else
            {
                Note nt = new Note();
                nt.cas= "Finsh";
                nt.ShowDialog();
                note = nt.textBox1.Text;
                if (MessageBox.Show("هل انت واثق من العمليه  ", "أيقاف موظف", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                { return; }
                else
                {
                    hr.empSP(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), "", "", "", DateTime.Now, "", 0, "", 0, "", "", "stop");
                    hr.HR_LogSP(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), 3, note, Program.UID, "Add");
                }
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            RPT.FRM_RPT_PRODUCT frw = new RPT.FRM_RPT_PRODUCT();
            this.Cursor = Cursors.AppStarting;
            int order_id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.EMP_Contract rpt = new RPT.EMP_Contract();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@id", order_id);
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }
    }
}
