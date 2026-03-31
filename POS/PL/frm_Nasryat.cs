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
   
    public partial class frm_Nasryat : Form
    {
        BL.Suppliers sup = new BL.Suppliers();
        BL.CLS_ORDERS ord2 = new BL.CLS_ORDERS();
        public frm_Nasryat()
        {
            InitializeComponent();
            comboBox1.DataSource = ord2.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Nasryat_Load(object sender, EventArgs e)
        {

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
                // BL.CLS_ORDERS ord2 = new BL.CLS_ORDERS();
                if (Convert.ToInt32(comboBox1.SelectedValue) == 3 || Convert.ToInt32(comboBox1.SelectedValue) == 33)
                {
                    groupBox1.Text = sup.get_l_N_id().Rows[0][0].ToString();
                    sup.add_nasryat(Convert.ToInt32(groupBox1.Text), cmbstats.Text, Convert.ToDouble(cash.Text), note.Text, Program.UID);
                    //  ord2.add_cash_histoty(Program.UID, 0, Convert.ToDouble(cash.Text), Convert.ToInt32(comboBox1.SelectedValue), " نثريات و مصوفات", note.Text, Convert.ToInt32(groupBox1.Text), DateTime.Now, 100, 0000);
                    ord2.add_chaque4(cmbstats.Text, Convert.ToDateTime(date.Text), Convert.ToDouble(cash.Text), Convert.ToInt32("10101010"), Convert.ToInt32(groupBox1.Text), Convert.ToInt32(comboBox1.SelectedValue));

                    MessageBox.Show("\t تم الحفظ \t");
                    this.Close();
                }
                else
                {
                    groupBox1.Text = sup.get_l_N_id().Rows[0][0].ToString();
                    sup.add_nasryat(Convert.ToInt32(groupBox1.Text), cmbstats.Text, Convert.ToDouble(cash.Text), note.Text, Program.UID);
                    ord2.add_cash_histoty(Program.UID, 0, Convert.ToDouble(cash.Text), Convert.ToInt32(comboBox1.SelectedValue), " نثريات و مصوفات", note.Text, Convert.ToInt32(groupBox1.Text), DateTime.Now, 100, 0000);
                    //    ord2.add_chaque4(note.Text, Convert.ToDateTime(date.Text), Convert.ToDouble(cash.Text), Convert.ToInt32("987"), Convert.ToInt32(groupBox1.Text), Convert.ToInt32(comboBox1.SelectedValue));
                    MessageBox.Show("\t\t تم الحفظ \t\t", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable ch = ord2.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
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
