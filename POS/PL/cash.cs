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
    public partial class cash : Form
    {
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        void chaqu3()
        {
            ORD.add_chaque3(txtname.Text, Convert.ToDateTime(date.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32("00"), Convert.ToInt32(textBox3.Text),Convert.ToInt32(comboBox1.SelectedValue));
        }

        void chaqu4()
        {
            ORD.add_chaque4(txtname.Text, Convert.ToDateTime(date.Text), Convert.ToDouble(textBox2.Text), Convert.ToInt32("00"), Convert.ToInt32(textBox3.Text), Convert.ToInt32(comboBox1.SelectedValue));
        }

        public cash()
        {
            InitializeComponent();
            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }

        private void cmbres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cash_Load(object sender, EventArgs e)
        {
            textBox3.Text= ORD.get_l_c_id().Rows[0][0].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("\t\t تاكد من البيانات \t\t");
                return;
            }
            else
            {
                textBox3.Text = ORD.get_l_c_id().Rows[0][0].ToString();

                if (radioButton1.Checked == true)
                {

                    {
                        log.add_c_Pay(textBox1.Text, radioButton1.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue), DateTime.Now, Program.UID, txtname.Text);
                        //   ORD.add_cash_histoty(Program.UID, Convert.ToDouble(textBox2.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), radioButton1.Text, txtname.Text, 9990001, DateTime.Now);
                        //Chaqu

                        if (Convert.ToInt32(comboBox1.SelectedValue) == 3 || Convert.ToInt32(comboBox1.SelectedValue) == 33)
                        {
                            chaqu3();
                        }
                        else
                        {
                            try
                            {
                                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(textBox2.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), radioButton1.Text, txtname.Text, 9990001, DateTime.Now, 3, 0);
                                date.Visible = false;
                            }
                            catch { return; }
                        }


                        //report

                        this.Cursor = Cursors.WaitCursor;
                        int order_id = Convert.ToInt32(textBox3.Text);
                        RPT.c_in_out rpt = new RPT.c_in_out();
                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@id", order_id);
                        frm.CR1.ReportSource = rpt;
                        rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                        rpt.PrintToPrinter(1, false, 0, 0);
                        this.Cursor = Cursors.Default;
                        this.Close();
                    }

                }
                else if (radioButton2.Checked == true)
                {

                    {
                        log.add_c_Pay(textBox1.Text, radioButton2.Text, Convert.ToDouble(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue), DateTime.Now, Program.UID, txtname.Text);
                        //   ORD.add_cash_histoty(Program.UID, 0, Convert.ToDouble(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue), radioButton2.Text,txtname.Text , 9990002, DateTime.Now);
                        //chaqu

                        if (Convert.ToInt32(comboBox1.SelectedValue) == 3 || Convert.ToInt32(comboBox1.SelectedValue) == 33)
                        {
                            chaqu4();
                        }
                        else
                        {
                            ORD.add_cash_histoty(Program.UID, 0, Convert.ToDouble(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue), radioButton1.Text, txtname.Text, 9990002, DateTime.Now, 4, 0);
                            date.Visible = false;

                        }

                        //Report
                        this.Cursor = Cursors.WaitCursor;
                        int order_id = Convert.ToInt32(textBox3.Text);
                        RPT.c_in_out rpt = new RPT.c_in_out();
                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@id", order_id);
                        frm.CR1.ReportSource = rpt;
                        rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                        rpt.PrintToPrinter(1, false, 0, 0);
                        this.Cursor = Cursors.Default;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("\t \t تاكد من البيانات  \t \t");
                    return;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable ch = ORD.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
            if (ch.Rows[0][0].ToString() == "1")
            {
                date.Visible = true;
            }
            else
            {
                date.Visible = false;
            }
        }
    }
}
