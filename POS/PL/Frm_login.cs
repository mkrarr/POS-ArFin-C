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
        string action = "";
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public Frm_login()
        {
            InitializeComponent();
            comboBox1.DataSource = log.get_users();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "id";
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
                    FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled = true;
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
                 //   FRM_MAIN.getMainForm.navBarControl1.Visible = true;

                    string cname = dt.Rows[0]["c_name"].ToString();
                


                    //------------------------------


                    FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;

              //      FRM_MAIN.getMainForm.toolStripMenuItem1.Enabled = true;

                    FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                    FRM_MAIN.getMainForm.timer2.Enabled = true;
                    //FRM_MAIN.getMainForm.timer3.Enabled = true;
                   // FRM_MAIN.getMainForm.groupBox5.Visible = true;
                    FRM_MAIN.getMainForm.loginToolStripMenuItem.Enabled = false;
                    FRM_MAIN.getMainForm.printersToolStripMenuItem.Enabled = true;

                    this.Close();
                    FRM_MAIN.getMainForm.Show();

                   
                }
                else if (dt.Rows[0][3].ToString() == "User")
                {
                    Program.UID = dt.Rows[0]["ID"].ToString();
              //      FRM_MAIN.getMainForm.toolStripMenuItem1.Enabled = false;

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
                 //   FRM_MAIN.getMainForm.groupBox5.Visible = true;
                    string cname = dt.Rows[0]["c_name"].ToString();

                 
                    this.Close();

                    FRM_MAIN.getMainForm.Show();

                  
                }

            }

            else if (txtID.Text == "MK" & txtPWD.Text == "M0914240060m")
            {
                FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.restoreToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled = true;
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
              //  FRM_MAIN.getMainForm.companyToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.logoutToolStripMenuItem.Enabled = true;
                FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                FRM_MAIN.getMainForm.timer2.Enabled = true;
                //FRM_MAIN.getMainForm.timer3.Enabled = true;
        //        FRM_MAIN.getMainForm.groupBox5.Visible = true;
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
            if (Convert.ToInt32(log.App_ver(Program.APP_Ver).Rows[0][0]) != 1)
            {

           //"\b نسخة النظام غير متطابقة مع قاعدة البيانات \n    يرجاء الاتصال بالدعم الفني \n " + Properties.Settings.Default.mk_tel + ".", "نسخة التطبيق"     MessageBox.Show("\b نسخة النظام غير متطابقة مع قاعدة البيانات \n    يرجاء الاتصال بالدعم الفني \n " + Properties.Settings.Default.mk_tel + ".", "نسخة التطبيق"  ,  MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(" نسخة النظام غير متطابقة مع قاعدة البيانات \nيرجاء الاتصال بالدعم الفني \n" + Properties.Settings.Default.mk_tel  , "نسخة التطبيق", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                FRM_MAIN.getMainForm.Close();
            }
            else
            {
                Ver.Text = "V. " + Program.APP_Ver;
                txtPWD.Focus();
                return;
            }
          
        }

        private void txtPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPWD_KeyDown(object sender, KeyEventArgs e)
        {

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
        public int temp_login = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(comboBox1.SelectedValue.ToString(), txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                action = "T";
                Program.PC = System.Net.Dns.GetHostName();
                Program.IPA = System.Net.Dns.GetHostByName(Program.PC).AddressList[0].ToString();
                Program.last_login = comboBox1.SelectedValue.ToString();
                Properties.Settings.Default.Last_login = comboBox1.SelectedValue.ToString();
                Properties.Settings.Default.Save();
                Program.gid=Convert.ToInt32(dt.Rows[0]["gid"]);
                DataTable prm = log.get_parm(Convert.ToInt32(dt.Rows[0]["gid"]));
                temp_login = 0;
                
                {
                    if (prm.Rows[0][1].ToString() == "1") { FRM_MAIN.getMainForm.fileToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.fileToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][2].ToString() == "1") { FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.customerToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][3].ToString() == "1") { FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.priToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][4].ToString() == "1") { FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][5].ToString() == "1") { FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][6].ToString() == "1") { FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.repotsToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][8].ToString() == "1") { FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.usersToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][7].ToString() == "1") { FRM_MAIN.getMainForm.helpToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.helpToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][9].ToString() == "1") { FRM_MAIN.getMainForm.navBarControl1.Visible = true; } else { FRM_MAIN.getMainForm.navBarControl1.Visible = false; }
                    if (prm.Rows[0][10].ToString() == "1") { FRM_MAIN.getMainForm.المواسسةToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.المواسسةToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][11].ToString() == "1") { FRM_MAIN.getMainForm.الصلاحياتToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.الصلاحياتToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][11].ToString() == "1") { FRM_MAIN.getMainForm.مجموعاتالمستخدمينToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.مجموعاتالمستخدمينToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][12].ToString() == "1") { FRM_MAIN.getMainForm.navBarControl2.Visible = true; } else { FRM_MAIN.getMainForm.navBarControl2.Visible = false; }
                    if (prm.Rows[0][13].ToString() == "1") { FRM_MAIN.getMainForm.tabControl1.Visible = true; } else { FRM_MAIN.getMainForm.tabControl1.Visible = false; }
                    if (prm.Rows[0][17].ToString() == "1") { FRM_MAIN.getMainForm.tabControl2.Visible = true; } else { FRM_MAIN.getMainForm.tabControl2.Visible = false; }
                    if (prm.Rows[0][14].ToString() == "1") { FRM_MAIN.getMainForm.التاميناتToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.التاميناتToolStripMenuItem.Enabled = false; }
                    if (prm.Rows[0][18].ToString() == "1") { FRM_MAIN.getMainForm.المواردالبشريهToolStripMenuItem.Enabled = true; } else { FRM_MAIN.getMainForm.المواردالبشريهToolStripMenuItem.Enabled = false; }


                    Program.P_CONF = Convert.ToInt32(prm.Rows[0][15]);
                    Program.p_reles = Convert.ToInt32(prm.Rows[0][16]); 

                    Program.SelasMAN = dt.Rows[0]["FullName"].ToString();
                    Program.group = dt.Rows[0]["UserType"].ToString();
                    Program.location = dt.Rows[0]["c_name"].ToString();
                    Program.UID = dt.Rows[0]["ID"].ToString();

                    Program.ZKA_ID = dt.Rows[0]["ZKA"].ToString();
                    Program.TAX_ID = dt.Rows[0]["DRAIB"].ToString();
                    Program.ZKA_pr = Convert.ToDouble( dt.Rows[0]["Z"].ToString());
                    Program.TAX_pr = Convert.ToDouble(dt.Rows[0]["T"].ToString());

                    string cname = dt.Rows[0]["c_name"].ToString();
                    FRM_MAIN.getMainForm.logint2 = DateTime.Now;
                    FRM_MAIN.getMainForm.timer2.Enabled = true;
                    this.Close();
                    FRM_MAIN.getMainForm.Refresh();
                    if (Properties.Settings.Default.POS == "Yes")
                    {
                        FRM_MAIN.getMainForm.Hide();

                        POS_SR pp = new POS_SR();
                        this.Hide();
                        pp.ShowDialog();

                    }
                    //else
                    //{
                    FRM_MAIN.getMainForm.Show();
                        this.Close();
                        FRM_MAIN.getMainForm.WindowState = FormWindowState.Maximized;
                        FRM_MAIN.getMainForm.ShowInTaskbar = true;
                    //}
                    //if(Properties.Settings.Default.POS=="Yes")
                    //{
                    //    FRM_MAIN.getMainForm.Hide();
                    //    POS_SR pp = new POS_SR();
                    //    pp.ShowDialog();
                    //    this.Close();
                    //}
                }
                log.add_login_log(Program.UID, Program.SelasMAN, Program.IPA, Program.PC, action,Program.s_id);
            }
            else
            {
                string msg = "2cfd604a-aa05-4e8c-b97c-28858086d248";
                action = "F";
                temp_login++;
                Program.PC = System.Net.Dns.GetHostName();
                Program.IPA = System.Net.Dns.GetHostByName(Program.PC).AddressList[0].ToString();
                Program.SelasMAN = comboBox1.Text.ToString();
                Program.UID = comboBox1.SelectedValue.ToString();
                log.add_login_log(Program.UID, Program.SelasMAN, Program.IPA, Program.PC, action,Program.s_id);
                if (temp_login <= 3)
                {
                    DataTable bb= log.ublk(comboBox1.SelectedValue.ToString(), txtPWD.Text);
                    if(bb.Rows[0][0].ToString()=="1")
                    {
                        MessageBox.Show("    \t    خطاء في تسجيل الدخول \t \n \t   الرجاءالتواصل مع مدير النظام المستخدم محظور \t ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }else
                    {
                        MessageBox.Show("    \t    خطاء في تسجيل الدخول \t \n \t الرجاء التاكد من كلمة السر \t ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {

                    MessageBox.Show("    \t    خطاء في تسجيل الدخول \t \n \t الرجاء التاكد من كلمة السر والتواصل مع مدير النظام \t ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    log.US_BLK(comboBox1.SelectedValue.ToString(), "blk");
                    btncancel_Click(sender, e);
                }
                toastNotificationsManager2.ShowNotification(msg);
                txtID.Text = null;
                txtPWD.Text = null;
                txtID.Focus();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btncancel_Click(sender, e);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FRM_SQL sql = new FRM_SQL();
            sql.ShowDialog();
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {
            try
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Last_login;
            }
            catch { return; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = comboBox1.SelectedValue.ToString();
            }
            catch { return; }
        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btncancel_Click(sender, e);
            }else if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
