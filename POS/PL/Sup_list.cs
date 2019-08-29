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
    public partial class Sup_list : Form
    {
        BL.Suppliers cust = new BL.Suppliers();

        public Sup_list()
        {
            InitializeComponent();
            this.dgvCL.DataSource = cust.GET_ALL_sup();
            this.dgvCL.Columns[0].Visible = false;
            this.dgvCL.Columns[5].Visible = false;
        }

        private void Sup_list_Load(object sender, EventArgs e)
        {

        }

        private void dgvCL_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCL_DoubleClick_1(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
