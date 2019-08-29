using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace POS.PL
{
    public partial class Settlement : Form
    {
        BL.CLS_PRODUCTS cls = new BL.CLS_PRODUCTS();
        public Settlement()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (cmbres.Text == "")
            {
                MessageBox.Show("       Check Your Data      ");
                return;
            }
            else
            {
                if (MessageBox.Show("\t Are you sure about this data? \n \t Inventory will be modified and can not retrieval", "Settled", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    //   MessageBox.Show("", "Settled Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
            frm.ShowDialog();
           
        }

        private void txtaqut_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void txtaqut_KeyPress(object sender, KeyPressEventArgs e)
        {
          
           
        }

        private void txtaqut_Validated(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Alt)
            {
                PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
                frm.ShowDialog();
            }

         }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
            frm.ShowDialog();
            this.dataGridView1.CurrentRow.Cells[0].Value = frm.dataGridView1.CurrentRow.Cells[0].Value;
            this.dataGridView1.CurrentRow.Cells[1].Value = frm.dataGridView1.CurrentRow.Cells[1].Value;
            this.dataGridView1.CurrentRow.Cells[2].Value = frm.dataGridView1.CurrentRow.Cells[2].Value;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[3].Value.ToString()=="")
            {
                dataGridView1.CurrentRow.Cells[3].Value = "0";
            }
            else
            {

                dataGridView1.CurrentRow.Cells[4].Value = (Convert.ToDouble(
                dataGridView1.CurrentRow.Cells[3].Value) - Convert.ToDouble(
                dataGridView1.CurrentRow.Cells[2].Value)).ToString();
            }
        }
    }
}
