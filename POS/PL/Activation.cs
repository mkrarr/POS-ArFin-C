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
    public partial class Activation : Form
    {
        public Activation()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if(textEdit1.Text==Program.Act1|| textEdit1.Text == Program.Act2|| textEdit1.Text == Program.Act3)
            {
                Properties.Settings.Default.Actev = true;
                Properties.Settings.Default.Save();
                MessageBox.Show("\t تم التفعيل \t");
                this.Close();
                FRM_MAIN fg = new FRM_MAIN();
                fg.Show();
            }
            else
            {
                Properties.Settings.Default.Actev = false;
                MessageBox.Show("\t لم يتم التفعيل \t");
                this.Close();
                FRM_MAIN fg = new FRM_MAIN();
                FRM_MAIN.getMainForm.Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            FRM_MAIN.getMainForm.Close();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                simpleButton2_Click(sender, e);
            }
        }
    }
}
