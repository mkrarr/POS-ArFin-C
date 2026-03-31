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
    public partial class Ding_drg : Form
    {
        BL.CLS_PRODUCTS prod = new BL.CLS_PRODUCTS();
        public Ding_drg()
        {
            InitializeComponent();
            dataGridView1.DataSource = prod.Ding_d("", "get");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PL.FRM_PRO_LIST pro = new FRM_PRO_LIST();
            pro.ShowDialog();
            idtx.Text = pro.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            nametx.Text = pro.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTable dx= prod.Ding_d(idtx.Text, "V_drg");
            if(dx.Rows.Count > 0)
            {
                return;
            }else
            {
                if(MessageBox.Show("هل انت متاكد من ان الصنف  "+ nametx.Text+" دواء مخدر او خطير","الادوية",MessageBoxButtons.YesNo,MessageBoxIcon.Hand)==DialogResult.Yes)
                {
                     prod.Ding_d(idtx.Text, "add");
                     dataGridView1.DataSource = prod.Ding_d(idtx.Text, "get");
                }else
                { return; }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متاكد من ان الصنف  " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "  ليس دواء مخدر او خطير", "الادوية", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                {
                     prod.Ding_d(dataGridView1.CurrentRow.Cells[1].Value.ToString(), "del");
                     dataGridView1.DataSource = prod.Ding_d(idtx.Text, "get");
                }
           else { return; }
        }
    }
}
