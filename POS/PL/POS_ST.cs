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
    public partial class POS_ST : Form
    {
        String SS = "";
        public POS_ST()
        {
            InitializeComponent();
        }

        private void POS_ST_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.POS== "Yes")
            {
                toggleSwitch1.IsOn = true;
            }
            else
            {
                toggleSwitch1.IsOn = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                SS = "Yes";
            }else
            {
                SS = "No";
            }
            Properties.Settings.Default.POS = SS;
            Properties.Settings.Default.Save();
            this.Close();

        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == true)
            {
                SS = "Yes";
            }
            else
            {
                SS = "No";
            }
        }
    }
}
