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
    public partial class FRM_ADD_USER : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public FRM_ADD_USER()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if(txtUID.Text == string.Empty || txtfname.Text == string.Empty || txtPass.Text == string.Empty ||cptype.Text == string.Empty)
            {
                 MessageBox.Show("Chick User Info", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
            }
            if (txtPass.Text != txtcpass.Text)
            {
                MessageBox.Show("Chick User Password", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtcpass.Clear();
                txtPass.Clear();
                txtPass.Focus();
                return;
            }
            try { 
            log.ADD_USER(txtUID.Text, txtfname.Text, txtPass.Text, cptype.Text);
            MessageBox.Show("User Added", "New User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtUID.Clear();
            txtPass.Clear();
            txtcpass.Clear();
            txtfname.Clear();
                this.Close();
        }catch
            {
                MessageBox.Show("   User ID Already Exists !    ", "New User", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

}

        private void txtcpass_Validated(object sender, EventArgs e)
        {
            if(txtPass.Text != txtcpass.Text )
            {
                MessageBox.Show("Chick User Password", "New User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
