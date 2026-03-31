using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace POS.PL
{
    
    public partial class TC_POS : DevExpress.XtraEditors.XtraForm
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        public TC_POS()
        {
            InitializeComponent();
           // PROGV.DataSource = prd.GET_ALL_PRODUCTS();
            catGV.DataSource = prd.GET_ALL_CATEGORIES();
            catGV.Columns[0].Visible = false;
            
            PROGV.Height = 40;
        }

        private void TC_POS_Load(object sender, EventArgs e)
        {

        }

        private void catGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PROGV.DataSource = prd.pro_TLS(Convert.ToInt32(catGV.CurrentRow.Cells[0].Value.ToString()));
                PROGV.Columns[0].Visible = false;
            }
            catch
            {
                return;
            }
        }
    }
}