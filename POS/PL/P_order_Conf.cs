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
    public partial class P_order_Conf : Form
    {
       public  int st;
        BL.CLS_ORDERS ord2 = new BL.CLS_ORDERS();

        void LoadF()
        {
            if(st==0)
            {
                btac.Enabled = true;
                btcon.Enabled = false;
                btcnc.Enabled = true;
                comboBox1.Enabled = false;

            }
            else if (st == 1)
            {
                btac.Enabled = false;
                btcon.Enabled = true;
                btcnc.Enabled = false;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[8].ReadOnly = true;
                comboBox1.Enabled = true;

                textBox14.Text = (from DataGridViewRow row in dataGridView1.Rows
                                  where row.Cells[8].FormattedValue.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
            }
        }
        public P_order_Conf()
        {
            InitializeComponent();
            comboBox1.DataSource = ord2.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            LoadF();

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXToTY_TextChanged(object sender, EventArgs e)
        {

        }

        private void P_order_Conf_Load(object sender, EventArgs e)
        {
            DataTable dt = ord2.p_ord_conf(Convert.ToInt32(TXTOID.Text), 2);
            txtcid.Text = dt.Rows[0][0].ToString();
            txtcnm.Text = dt.Rows[0][1].ToString();
            TXToTY.Text = dt.Rows[0][2].ToString();
            comboBox1.SelectedValue = dt.Rows[0][4].ToString();
            TXToEMP.Text = dt.Rows[0][5].ToString();
            dateTimePicker1.Value=Convert.ToDateTime(dt.Rows[0][6].ToString());

            dataGridView1.DataSource = ord2.p_ord_conf(Convert.ToInt32(TXTOID.Text), 1);
            dataGridView1.Columns[4].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;

            DataTable ch = ord2.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
            if (ch.Rows[0][0].ToString() == "1")
            {
                groupBox5.Visible = true;
            }
            else
            {
                groupBox5.Visible = false;
            }

            LoadF();
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Columns[6].ReadOnly = false;
                dataGridView1.Columns[8].ReadOnly = false;

                dataGridView1.CurrentRow.Cells[6].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value) * Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value)).ToString();
                dataGridView1.CurrentRow.Cells[8].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value) - (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value) / 100))).ToString();

                textBox14.Text = (from DataGridViewRow row in dataGridView1.Rows
                                where row.Cells[8].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();

                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[8].ReadOnly = true;
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[6].ReadOnly = false;
            dataGridView1.Columns[8].ReadOnly = false;
            
            dataGridView1.CurrentRow.Cells[6].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[4].Value) * Convert.ToDouble(dataGridView1.CurrentRow.Cells[5].Value)).ToString();
            dataGridView1.CurrentRow.Cells[8].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value) - (Convert.ToDouble(dataGridView1.CurrentRow.Cells[6].Value) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells[7].Value) / 100))).ToString();

            textBox14.Text = (from DataGridViewRow row in dataGridView1.Rows
                              where row.Cells[8].FormattedValue.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();

            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[8].ReadOnly = true;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                ord2.Conf_P_pro(Convert.ToInt32(TXTOID.Text), dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value), st, 0, 0, 0, Program.UID,dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            MessageBox.Show("تم تنفبذ الامر بالرقم     "+TXTOID.Text +"");
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btcon_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                ord2.Conf_P_pro(Convert.ToInt32(TXTOID.Text), dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value), st, Convert.ToDouble(textBox14.Text), Convert.ToDouble(txtdpt.Text), Convert.ToDouble(txtpay.Text), Program.UID, dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            BL.Suppliers ord = new BL.Suppliers();
            
            
           
            ord.add_dept_s(Convert.ToInt32(txtcid.Text), Convert.ToDouble(txtdpt.Text));
            ord2.add_cash_histoty(Program.UID, 0, Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مشتريات", txtcnm.Text, Convert.ToInt32(TXTOID.Text),  DateTime.Now,2, Convert.ToInt32(txtcid.Text));
            if (groupBox5.Visible == true)
            {
                ord2.add_chaque2(txtcnm.Text, Convert.ToDateTime(date22.Text), Convert.ToDouble(c_total.Text), Convert.ToInt32(txtcid.Text), Convert.ToInt32(TXTOID.Text), Convert.ToInt32(comboBox1.SelectedValue));
                MessageBox.Show("تم تنفبذ الامر بالرقم      " + TXTOID.Text + "");
                this.Close();
            }
            else
            {
                MessageBox.Show("تم تنفبذ الامر بالرقم      " + TXTOID.Text + "");
                this.Close();
            }
           
        }

        private void btcnc_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                ord2.Conf_P_pro(Convert.ToInt32(TXTOID.Text), dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value), 3, 0, 0, 0, Program.UID, dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
              MessageBox.Show("تم تنفبذ الامر بالرقم      " + TXTOID.Text + "");
              this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtdpt.Text = (Convert.ToDecimal(textBox14.Text) - Convert.ToDecimal(txtpay.Text)).ToString();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            txtpay.Text = (Convert.ToDecimal(textBox14.Text) - Convert.ToDecimal(txtdpt.Text)).ToString();
        }

        private void txtdpt_TextChanged(object sender, EventArgs e)
        {
            c_total.Text = txtdpt.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable ch = ord2.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
            if (ch.Rows[0][0].ToString() == "1")
            {
                groupBox5.Visible = true;
            }
            else
            {
                groupBox5.Visible = false;
            }
        }
    }
}
