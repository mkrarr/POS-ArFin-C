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
    
    public partial class Recipt : Form
    {
        public double deb = 0; 
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        public Recipt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUST_LIST cus = new FRM_CUST_LIST();
            cus.ShowDialog();
            textBox3.Text=  cus.dgvCL.CurrentRow.Cells[0].Value.ToString();
            txtnname.Text = cus.dgvCL.CurrentRow.Cells[1].Value.ToString() + " " + cus.dgvCL.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0")
            {
                ord.set_cus(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox2.Text),deb);
                MessageBox.Show("\t تم التحوبل \t", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("\t لم يتم تحديد العميل الجديد \t", "تم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recipt_Load(object sender, EventArgs e)
        {

        }
    }
}
