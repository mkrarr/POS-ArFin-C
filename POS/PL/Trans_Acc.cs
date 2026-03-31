using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace POS.PL
{
    public partial class Trans_Acc : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        DataTable tid = new DataTable();
        public Trans_Acc()
        {
            InitializeComponent();

            comboBox1.DataSource = ord.get_main_ACC();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = ord.get_main_ACC();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "id";

            comboBox2.Text = "";
            comboBox1.Text = "";



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Trans_Acc_Load(object sender, EventArgs e)
        {
           
            tid = ord.get_l_t_id();
            groupBox1.Text = tid.Rows[0][0].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = ord.get_main_acc2(Convert.ToInt32(comboBox1.SelectedValue));
            txtacc1.Text = Convert.ToDouble( dt1.Rows[0][2].ToString()).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = ord.get_main_acc2(Convert.ToInt32(comboBox2.SelectedValue));
            txtacc2.Text = Convert.ToDouble(dt2.Rows[0][2].ToString()).ToString();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if(Convert.ToDouble (txtacc1.Text)< Convert.ToDouble(txttran.Text))
            {
                MessageBox.Show("المبلغ المحول أكبر من الرصيد الحالي");
                return;
            }
            else
            {
                DataTable pid = ord.get_p_id();
                int p_id=Convert.ToInt32(pid.Rows[0][0].ToString());
                tid = ord.get_l_t_id();
                groupBox1.Text = tid.Rows[0][0].ToString();

                ord.upd_main_cr(Convert.ToInt32(comboBox2.SelectedValue), Convert.ToDouble(txttran.Text));
                ord.upd_main_cr(Convert.ToInt32(comboBox1.SelectedValue), (Convert.ToDouble(txttran.Text)*-1));
                ord.Add_trans_main(Program.UID, Convert.ToDouble(txttran.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue), DateTime.Now, textBox5.Text);

                ord.add_min_flow2(p_id, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDouble(txttran.Text), Convert.ToDouble(0), Convert.ToDouble(txttran.Text), Convert.ToInt32(comboBox2.SelectedValue), Convert.ToDateTime(DateTime.Now), Program.UID, Program.UID);
                ord.add_min_flow2(p_id, Convert.ToInt32(comboBox2.SelectedValue), Convert.ToDouble(0), Convert.ToDouble(txttran.Text), Convert.ToDouble(txttran.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDateTime(DateTime.Now), Program.UID, Program.UID);

                /*  this.Cursor = Cursors.WaitCursor;
                  int id = Convert.ToInt32(groupBox1.Text);
                  RPT.Rpt_main_trans2 rpt = new RPT.Rpt_main_trans2();
                 // rpt.Refresh();
                  rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                  rpt.DataSourceConnections[0].IntegratedSecurity = false;
                  RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                  rpt.SetParameterValue("@id", id);
                  frm.CR1.ReportSource = rpt;
                  frm.ShowDialog();
                  rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                //  rpt.PrintToPrinter(1, false, 0, 0);
                  this.Cursor = Cursors.Default;
                 // this.Refresh();*/

                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(groupBox1.Text);
                RPT.main_trRPT rpt = new RPT.main_trRPT();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@id", order_id);
                frm.CR1.ReportSource = rpt;
              //  frm.Show();
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
                rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;
              
                MessageBox.Show("   تم تحويل مبلغ  " +txttran.Text +"  من حساب  "+ comboBox1.Text+ "   الى حساب  " +comboBox2.Text+ "   ");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
