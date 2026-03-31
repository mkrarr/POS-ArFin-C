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
    public partial class Cash_Cloase : Form
    {
        public Cash_Cloase()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            dataGridView1.DataSource = ord.get_f_cash(Convert.ToDateTime(dateTimePicker1.Value));
            //dataGridView1.ColumnAdded(Int32);
        }
    }
}
