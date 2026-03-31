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
    public partial class s_debt : Form
    {
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        BL.Suppliers su = new BL.Suppliers();

        public s_debt()
        {
            InitializeComponent();
            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void s_debt_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cus.S_debt2(Convert.ToInt32(textBox3.Text));
            if (dataGridView1.Rows.Count <= 0)
            {
                butsave.Enabled = false;
            }
            else
            {
                textBox1.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (PAY_S.Checked == true)
                try
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
                catch { return; }
                }


        private void butsave_Click(object sender, EventArgs e)
        {
            string cmb = comboBox1.Text;
            if (comboBox1.Text == string.Empty || textBox4.Text == string.Empty || Convert.ToDouble(textBox4.Text) <= 0)
            {
                MessageBox.Show("       \t\t  تاكد من البيانات   \t\t ");
                return;
            }
           
                double cpay = Convert.ToDouble(textBox4.Text);
                if (PAY_S.Checked == false)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //ppp.Text = cpay.ToString();
                        double cdebt = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                        if (cpay <= cdebt)
                        {
                            //  ddd.Text = cdebt.ToString();
                            su.add_dept_s(Convert.ToInt32(textBox3.Text), cpay * -1);
                            cus.d_dept2(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), cpay);
                            ORD.add_cash_histoty(Program.UID, 0, cpay, Convert.ToInt32(comboBox1.SelectedValue), "سداد ديون مشتريات", textBox2.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), DateTime.Now, 11, Convert.ToInt32(textBox3.Text));
                            cpay = 0;
                        }
                        else
                           if (cpay >= cdebt)
                        {
                            su.add_dept_s(Convert.ToInt32(textBox3.Text), cdebt * -1);
                            cus.d_dept2(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), cdebt);
                            ORD.add_cash_histoty(Program.UID, 0, cdebt, Convert.ToInt32(comboBox1.SelectedValue), "سداد ديون مشتريات", textBox2.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), DateTime.Now, 11, Convert.ToInt32(textBox3.Text));
                            cpay = cpay - cdebt;
                        }
                        else if (cpay == 0)
                        {
                            return;
                        }
                    }
                }
                else if (PAY_S.Checked == true)
                {
                    // ddd.Text = cdebt.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    su.add_dept_s(Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox4.Text) * -1);
                    cus.d_dept2(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToDouble(textBox4.Text));
                    ORD.add_cash_histoty(Program.UID, 0, Convert.ToDouble(textBox4.Text), Convert.ToInt32(comboBox1.SelectedValue), " سداد ديون مشتريات", textBox2.Text, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), DateTime.Now, 11, Convert.ToInt32(textBox3.Text));
                }
                MessageBox.Show("       \t\t  تم سداد الديون العميل " + textBox2.Text + " \t\t ");
                this.Close();
            

        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox4.Text) < 0)
                {
                    textBox4.Text = textBox1.Text;
                }
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void PAY_S_CheckedChanged(object sender, EventArgs e)
        {
            if(PAY_S.Checked==true)
            {
              
                    try
                    {
                        textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    }
                
                catch
                {
                    return;
                }
            }else
            {
                textBox1.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            }
        }
    }
}
