using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace POS.PL
{
    public partial class SpScreen : SplashScreen
    {
        public SpScreen()
        {
            InitializeComponent();
            Program.UID = "";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SpScreen_Load(object sender, EventArgs e)
        {
            labelControl1.Text = "MK IT Services Copyright ©" + Convert.ToString(DateTime.Now.Year);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}