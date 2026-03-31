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
    public partial class Main_ACC : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
     void clrtxt()
        {
            id.Text="";
            id.Enabled=true;
            name.Text="";
            cre.Text="";
            button1.Enabled = true;
            dataGridView1.DataSource = log.pay_acc("getm", "a", 0, 0, 0);
        }
        public Main_ACC()
        {
            InitializeComponent();
            clrtxt();

        }

        private void Main_ACC_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            id.Enabled = false;
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cre.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            log.pay_acc("upm", name.Text, Convert.ToInt32(id.Text), 0, 0);
            clrtxt();
            MessageBox.Show("تم الحفظ بنجاح");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log.pay_acc("addm", name.Text, Convert.ToInt32(id.Text), 0, 0);
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
