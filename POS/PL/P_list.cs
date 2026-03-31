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
    public partial class P_list : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        P_order_Conf of = new P_order_Conf();
        int pcon;
        int prel;

        void  btn()
        {
            if(comboBox1.SelectedIndex==0)
            {
                if (prel == 1)
                {
                    button1.Enabled = true;
                    button1.Text = "تصديق";
                }
                else
                {
                    button1.Enabled = false;
                    button1.Text = "تصديق";
                }

            }
            else   if (comboBox1.SelectedIndex == 1)
            {
                if (pcon == 1)
                {
                    button1.Enabled = true; 
                    button1.Text = "تأكيد";

                }
                else
                {
                    button1.Enabled = false;
                    button1.Text = "تأكيد";
                }
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                button1.Enabled = false;
            }
        }
        public P_list()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text,comboBox1.SelectedIndex);
            btn();

        }
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        private void P_list_Load(object sender, EventArgs e)
        {
            DataTable prm = log.get_parm(Convert.ToInt32(Program.gid));
            pcon = Convert.ToInt32(prm.Rows[0][15]);
            prel = Convert.ToInt32(prm.Rows[0][16]); 


            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text, comboBox1.SelectedIndex);
            btn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                RPT.P_order rpt = new RPT.P_order();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@oid", order_id);
                frm.CR1.ReportSource = rpt;
                frm.Show();
                this.Cursor = Cursors.Default;
            }
            else if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                RPT.p_requst rpt = new RPT.p_requst();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@oid", order_id);
                frm.CR1.ReportSource = rpt;
                frm.Show();
                this.Cursor = Cursors.Default;
                 }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            of.st = comboBox1.SelectedIndex;
            P_order_Conf frm = new P_order_Conf();
            frm.st = comboBox1.SelectedIndex;
            frm.TXTOID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.ShowDialog();
            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text, comboBox1.SelectedIndex);
            btn();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = ord.get_P_order(textBox1.Text, comboBox1.SelectedIndex);
            btn();

        }
    }
}
