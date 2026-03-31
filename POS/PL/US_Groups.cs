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
    public partial class US_Groups : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public US_Groups()
        {
            InitializeComponent();
            dataGridView1.DataSource = log.get_groups();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try {
                DataTable idt = log.us_groupid();
                textBox1.Text = idt.Rows[0][0].ToString();
                log.add_group(textBox2.Text, Convert.ToInt32(textBox1.Text));
                dataGridView1.DataSource = log.get_groups();
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("تم الأضافة بنجاح");
            }
            catch { return; }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btnadd.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            if (MessageBox.Show(" \n   هل انت واثق من العملية", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.de_us_gr(Convert.ToInt32(textBox1.Text));
                dataGridView1.DataSource = log.get_groups();
                textBox1.Text = "";
                textBox2.Text = "";
                    btnadd.Enabled = true;
                    MessageBox.Show("تم الحذف بنجاح");
                }
            }
            catch { return; }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try { 
            if (MessageBox.Show(" \n   هل انت واثق من العملية", "تعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.up_group(textBox2.Text, Convert.ToInt32(textBox1.Text));
                dataGridView1.DataSource = log.get_groups();
                textBox1.Text = "";
                textBox2.Text = "";
                btnadd.Enabled = true;
                MessageBox.Show("تم التعديل بنجاح");
                }
            }
            catch { return; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void US_Groups_Load(object sender, EventArgs e)
        {

        }
    }
}
