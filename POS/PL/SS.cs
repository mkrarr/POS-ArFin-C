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
    public partial class SS : Form
    {
                    PL.FRM_MAIN aa = new FRM_MAIN();
        
        public SS()
        {
            InitializeComponent();
            Program.UID = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            prg2.Increment(1);
            if (prg2.Value == 100)
            {
                timer1.Stop();
                prg2.Enabled=false;

               

                PL.Frm_login log = new Frm_login();
                if (Program.UID == "")
                {
                    log.Refresh();
                    this.Close();
                    log.ShowDialog();
                    

                }
                else { return; }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SS_Load(object sender, EventArgs e)
        {

        }
    }
}
