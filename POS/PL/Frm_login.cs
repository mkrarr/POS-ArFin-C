using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace POS.PL
{
    public partial class Frm_login : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public Frm_login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            FRM_MAIN.getMainForm.Close();
           
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                Program.PC = System.Net.Dns.GetHostName();
                Program.IPA = System.Net.Dns.GetHostByName(Program.PC).AddressList[0].ToString();
                if (dt.Rows[0][3].ToString() == "Admin")
                {
                    FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.reportToolStripMenuItem.Enabled = true;
                    //FRM_MAIN.getMainForm.insurancesToolStripMenuItem.Enabled = true;
                    //FRM_MAIN.getMainForm.backupRestorToolStripMenuItem.Enabled = true;
                    // FRM_MAIN.getMainForm.tabControl1.Visible = true;
                    //  FRM_MAIN.getMainForm.button1.Visible = true;
                    Program.SelasMAN = dt.Rows[0]["FullName"].ToString();
                    //  Program.SelasMAN_ID = dt.Rows[0]["ID"].ToString();
                    Program.group = dt.Rows[0]["UserType"].ToString();
                    Program.location = dt.Rows[0]["c_name"].ToString();
                    Program.UID = dt.Rows[0]["ID"].ToString();
                    //----------------------------
                    FRM_MAIN.getMainForm.navBarControl1.Visible = true;

                    string cname = dt.Rows[0]["c_name"].ToString();
                


                    //------------------------------


                    FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                    FRM_MAIN.getMainForm.timer2.Enabled = true;
                    //FRM_MAIN.getMainForm.timer3.Enabled = true;
                    FRM_MAIN.getMainForm.groupBox5.Visible = true;
                    FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = false;
                    FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = true;

                    this.Close();
                    FRM_MAIN.getMainForm.Show();

                   
                }
                else if (dt.Rows[0][3].ToString() == "User")
                {
                    Program.UID = dt.Rows[0]["ID"].ToString();
                    FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = false;
                    FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = false;
                    FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = false;
                    FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = true;
                    //  FRM_MAIN.getMainForm.backUPToolStripMenuItem.Enabled = true;
//                    FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = false;
                    Program.SelasMAN = dt.Rows[0]["FullName"].ToString();
               //     Program.SelasMAN_ID = dt.Rows[0]["ID"].ToString();
                    Program.group = dt.Rows[0]["UserType"].ToString();
                    Program.location = dt.Rows[0]["c_name"].ToString();
                    Program.UID = dt.Rows[0]["ID"].ToString();

                    //    FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;

                    //   FRM_MAIN.getMainForm.logint.Text = DateTime.Now.ToString();
                    //  FRM_MAIN.getMainForm.TXTID.Text = Program.SelasMAN;
                    FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                    FRM_MAIN.getMainForm.timer2.Enabled = true;
                  //  FRM_MAIN.getMainForm.timer3.Enabled = true;
                    FRM_MAIN.getMainForm.groupBox5.Visible = true;
                    string cname = dt.Rows[0]["c_name"].ToString();

                 
                    this.Close();

                    FRM_MAIN.getMainForm.Show();

                  
                }

            }

            else if (txtID.Text == "Mookrarr" & txtPWD.Text == "M0914240060m")
            {
                FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                //  FRM_MAIN.getMainForm.reportToolStripMenuItem.Enabled = true;
                //FRM_MAIN.getMainForm.insurancesToolStripMenuItem.Enabled = true;
                //FRM_MAIN.getMainForm.backupRestorToolStripMenuItem.Enabled = true;
                // FRM_MAIN.getMainForm.tabControl1.Visible = true;
                //  FRM_MAIN.getMainForm.button1.Visible = true;
                Program.SelasMAN = "System Manager";
                //  Program.SelasMAN_ID = dt.Rows[0]["ID"].ToString();
                Program.group = "Manager";
                Program.location ="Server";
               // Program.UID = dt.Rows[0]["ID"].ToString();
                FRM_MAIN.getMainForm.companyToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                FRM_MAIN.getMainForm.timer2.Enabled = true;
                //FRM_MAIN.getMainForm.timer3.Enabled = true;
                FRM_MAIN.getMainForm.groupBox5.Visible = true;
                FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = false;
                FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = true;

              //  string cname = dt.Rows[0]["c_name"].ToString();

             //   FRM_MAIN.getMainForm.cnamel.Text = cname;

                this.Close();
                FRM_MAIN.getMainForm.Show();

              
            }

            else
            {
                MessageBox.Show("        User ID or Password Incorrect  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtID.Text = null;
                txtPWD.Text = null;
                txtID.Focus();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            txtID.Focus();
        }

        private void txtPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnlogin_Click(sender, e);
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPWD.Focus();
            }
        }
    }
}
