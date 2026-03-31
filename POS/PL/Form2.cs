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
    
    public partial class Form2 : Form
    {
        public static string p_id = "";
        public  double prc;

        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();

            dataGridView1.DataSource = pro.Patch_list(pid.Text,Convert.ToDouble(prcc.Text));
            if(dataGridView1.Rows.Count==1)
            {
                this.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                this.Close();
            }
            }
    }
}
