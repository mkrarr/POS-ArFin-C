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
    public partial class invo : Form
    {
        public invo()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          Properties.Settings.Default.inv= comboBox1.SelectedIndex.ToString();
          Properties.Settings.Default.Save();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedIndex.ToString();

        }

        private void invo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.inv);
            label2.Text = Properties.Settings.Default.inv;

        }
    }
}
