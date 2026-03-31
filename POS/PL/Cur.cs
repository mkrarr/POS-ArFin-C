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
    public partial class Cur : Form
    {
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        public Cur()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void butsave_Click(object sender, EventArgs e)
        {
            cus.set_cur(Convert.ToDouble(textBox2.Text));
            cus.add_his(DateTime.Now, Convert.ToDouble(textBox2.Text));
            MessageBox.Show("   \t \t تم تعديل سعر الدولار\t \t");
            this.Close();

        }

        private void Cur_Load(object sender, EventArgs e)
        {
            this.textBox1.Text =  cus.get_cur().Rows[0][0].ToString(); ;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
