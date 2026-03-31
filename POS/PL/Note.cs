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
    public partial class Note : Form
    {
        public string cas;
        Employees emp = new Employees();

        public Note()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btac_Click(object sender, EventArgs e)
        {
            if (cas == "Finsh")
            {
                emp.note = textBox1.Text;
                this.Close();
            }
            else { return; }
        }
    }
}
