using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS.PL
{
    public partial class FRM_Stock : Form
    {
        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();

        public FRM_Stock()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            int nstock = Convert.ToInt32(txtnsto.Text);
            int AStock = Convert.ToInt32(txtstock.Text);
            int ADQUT = nstock + AStock;

          pro.UPDATE_Stock(txtref.Text, ADQUT);
          FRM_PRODUCTS FRM = new FRM_PRODUCTS();
        //  FRM.dataGridView1.DataSource = pro.GET_ALL_PRODUCTS();
          FRM_PRODUCTS.getMainForm.dataGridView1.DataSource = pro.GET_ALL_PRODUCTS();
          this.Close();
            MessageBox.Show("Stock Update Saccesful...", "Update Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
