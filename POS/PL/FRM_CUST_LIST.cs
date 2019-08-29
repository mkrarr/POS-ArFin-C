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
    public partial class FRM_CUST_LIST : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
 
        public FRM_CUST_LIST()
        {
            InitializeComponent();
            this.dgvCL.DataSource = cust.GET_ALL_CUST();
            this.dgvCL.Columns[0].Visible = false;
            this.dgvCL.Columns[5].Visible = false;
        }

        private void FRM_CUST_LIST_Load(object sender, EventArgs e)
        {

        }

        private void d(object sender, EventArgs e)
        {

        }

        private void dgvCL_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           dgvCL.DataSource= cust.Search_cust(textBox1.Text);
           this.dgvCL.Columns[0].Visible = false;
           this.dgvCL.Columns[5].Visible = false;
        }
    }
}
