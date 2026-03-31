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
    
    public partial class PAY_SET : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        void clrtxt()
        {
            id.Text = "";
            id.Enabled = true;
            name.Text = "";
            ch.SelectedIndex = -1;
            button1.Enabled = true;
            dataGridView1.DataSource = log.pay_acc("getp", "a", 0, 0, 0);
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            m_acc.DataSource =  log.pay_acc("getm", "a", 0, 0, 0);
            m_acc.ValueMember = "#";
            m_acc.DisplayMember = "الحساب";

        }
        public PAY_SET()
        {
            InitializeComponent();
            clrtxt();

        }

        private void PAY_SET_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            m_acc.SelectedValue = Convert.ToInt64(dataGridView1.CurrentRow.Cells[2].Value);
            ch.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.pay_acc("addp", name.Text, Convert.ToInt32(id.Text), Convert.ToInt32(m_acc.SelectedValue), ch.SelectedIndex);
            clrtxt();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.pay_acc("upp", name.Text, Convert.ToInt32(id.Text), Convert.ToInt32(m_acc.SelectedValue), ch.SelectedIndex);
            clrtxt();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
                this.Close();
            else
                clrtxt();
        }
    }
}
