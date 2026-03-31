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
    public partial class Ins_Form : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();

        void clr_text()
        {
            txtid.Text = null;
            txtname.Text = null;
            txttel.Text = null;
            txtsup.Text = null;
            txtemail.Text = null;
            txtadd.Text = null;
            txtaddpr.Text = null;
            txtlim.Text = null;
            txtclass.Text = null;
            button1.Enabled = true;
            dataGridView1.Columns[1].Frozen = true;
        }
        public Ins_Form()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Ins_Form_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ord.get_ins();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[1].Frozen = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                dataGridView1.Columns[1].Frozen = false;
                dataGridView1.DataSource = ord.get_ins();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[1].Frozen = true;
                button4.Text = "حذف";
            }
            else if (checkBox1.Checked == true)
            {
                dataGridView1.Columns[1].Frozen = false;
                dataGridView1.DataSource = ord.get_ins2();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[1].Frozen = true;
                button4.Text = "تفعيل";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ord.Add_INS_Company(txtname.Text, Convert.ToDouble(txtlim.Text), Convert.ToString(txtclass.SelectedItem), txtsup.Text, txttel.Text, txtemail.Text, Convert.ToDouble(txtaddpr.Text), txtadd.Text);
            MessageBox.Show("تم الحفظ بنجاح");
            if (checkBox1.Checked == false)
            {
                dataGridView1.Columns[1].Frozen = false;
                dataGridView1.DataSource = ord.get_ins();
                button4.Text = "حذف";
                dataGridView1.Columns[1].Frozen = true;

            }
            else
            {
                dataGridView1.Columns[1].Frozen = false;
                dataGridView1.DataSource = ord.get_ins2();
                button4.Text = "تفعيل";
                dataGridView1.Columns[1].Frozen = true;

            }
            clr_text();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            button1.Enabled = false;
            txtid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtlim.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.txtclass.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtsup.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txttel.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtemail.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtaddpr.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtadd.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtid.Text!="" & checkBox1.Checked==false)
            {
                dataGridView1.Columns[1].Frozen = false;
                ord.delete_ins(Convert.ToInt32(txtid.Text));
                dataGridView1.DataSource = ord.get_ins();
                button4.Text = "حذف";
                dataGridView1.Columns[1].Frozen = true;
            }
            else if (txtid.Text != "" & checkBox1.Checked == true)
            {
                dataGridView1.Columns[1].Frozen = false;
                ord.delete_ins2(Convert.ToInt32(txtid.Text));
                dataGridView1.DataSource = ord.get_ins2();
                button4.Text = "تفعيل";
                dataGridView1.Columns[1].Frozen = true;
            }
            clr_text();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            ord.UP_INS_Company(txtname.Text, Convert.ToDouble(txtlim.Text), Convert.ToString(txtclass.SelectedItem), txtsup.Text, txttel.Text, txtemail.Text, Convert.ToDouble(txtaddpr.Text), txtadd.Text,Convert.ToInt32(txtid.Text));
            MessageBox.Show("تم التعديل بنجاح");
            if (checkBox1.Checked == false)
            {
                dataGridView1.Columns[1].Frozen = false;
                dataGridView1.DataSource = ord.get_ins();
                button4.Text = "حذف";
                dataGridView1.Columns[1].Frozen = true;
            }
            else
            { 
                dataGridView1.Columns[1].Frozen = false;
            dataGridView1.DataSource = ord.get_ins2();
                button4.Text = "تفعيل";
            dataGridView1.Columns[1].Frozen = true;
        }
            clr_text();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txtid.Text=="")
            {
                this.Close();
            }
            else
            {
                clr_text();
            }
        }

        private void txtaddpr_Validating(object sender, CancelEventArgs e)
        {
            if(Convert.ToDouble(txtaddpr.Text)>1)
            {
                txtaddpr.Text = (Convert.ToDouble(txtaddpr.Text) / 100).ToString();
            }
        }
    }
}
