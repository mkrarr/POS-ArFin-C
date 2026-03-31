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
    public partial class MyPopupForm : Form
    {
        BL.CLS_ORDERS cls = new BL.CLS_ORDERS();
        public MyPopupForm()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt=cls.Get_POS_DT(Convert.ToInt32(textEdit1.Text));
            if(dt.Columns.Count==1)
            {
                MessageBox.Show("تاكد من رقم الطلب ");
                return;
            } else
            {
                POP_ORD pp = new PL.POP_ORD();
                pp.o_id = Convert.ToInt32(textEdit1.Text);
                pp.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
