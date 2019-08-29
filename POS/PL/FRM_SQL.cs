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
    public partial class FRM_SQL : Form
    {
      
        public FRM_SQL()
        {
            InitializeComponent();
            txtserver.Text = Properties.Settings.Default.Server;
            txtdatabase.Text = Properties.Settings.Default.Database;
            if (Properties.Settings.Default.mode == "SQL")
            {

                rbsql.Checked = true;
                txtid.Text = Properties.Settings.Default.ID;
                txtPWD.Text = Properties.Settings.Default.password;
            }
            else
            {
                rbwin.Checked = true;
                txtid.Clear();
                txtPWD.Clear();
                txtid.ReadOnly = true;
                txtPWD.ReadOnly = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void Restore_Load(object sender, EventArgs e)
        {
            if (rbsql.Checked)
            {
                txtid.ReadOnly = false;
                txtPWD.ReadOnly = false;
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = txtserver.Text;
            Properties.Settings.Default.Database = txtdatabase.Text;
            Properties.Settings.Default.mode = rbsql.Checked == true ? "SQL" : "Windows";
            Properties.Settings.Default.ID = txtid.Text;
            Properties.Settings.Default.password = txtPWD.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("SQL Connection Save", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();

        }

        private void rbsql_CheckedChanged(object sender, EventArgs e)
        {
            txtid.ReadOnly = false;
            txtPWD.ReadOnly = false;
        }

        private void rbwin_CheckedChanged(object sender, EventArgs e)
        {
            txtid.ReadOnly = true;
            txtPWD.ReadOnly = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
