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
    public partial class U_price : Form
    {
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public U_price()
        {
            InitializeComponent();
            comboBox1.DataSource = prd.GET_ALL_CATEGORIES();
            comboBox1.DisplayMember = "DESCRIPTION_CAT";
            comboBox1.ValueMember = "ID_CAT";
        }

        private void U_price_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Enabled = false;
            }
           else
            {
                comboBox1.Enabled = true;

            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    prd.UP_price2(Convert.ToDouble(textBox1.Text));
                    MessageBox.Show("\t \t تم تعديل الأسعار \t \t");
                    this.Close();
                }
                catch
                {
                    return;
                }
            }
                else
            {
                try
                {
                    prd.UP_price(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDouble(textBox1.Text));
                    MessageBox.Show("\t \t تم تعديل الأسعار \t \t");
                    this.Close();
                }
                catch
                {
                    return;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
