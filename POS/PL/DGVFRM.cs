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
    public partial class DGVFRM : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        BL.HR hr = new BL.HR();
        public string ty = "";
        public string key = "";
        public DGVFRM()
        {
            InitializeComponent();
        }

        private void DGVFRM_Load(object sender, EventArgs e)
        {
            if(ty=="user")
            {
                dgv.DataSource = log.list_user();
            }
          else  if(ty=="Emp")
            {
                dgv.DataSource = hr.att(Convert.ToInt32(0), DateTime.Now, 0, Convert.ToInt32(0), Convert.ToInt32(0), "eget","");
            }
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Space)
            {
                this.Close();
            }
        }
    }
}
