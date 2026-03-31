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
    public partial class Debt : Form
    {
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
       
        public Debt()
        {
            InitializeComponent();
            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }

        private void Debt_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = cus.c_debt(Convert.ToInt32(textBox3.Text));
            if(dataGridView1.Rows.Count<=0)
            {
                butsave.Enabled = false;


            }else
            {
                textBox1.Text = (from DataGridViewRow row in dataGridView1.Rows
                                 where row.Cells[3].FormattedValue.ToString() != string.Empty
                                 select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum().ToString();
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (PAY_S.Checked == true)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                dataGridView1.DataSource = cus.c_debt(Convert.ToInt32(textBox3.Text));
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
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.Text == string.Empty || textBox4.Text == string.Empty||Convert.ToDouble (textBox4.Text)==0)
            {
                MessageBox.Show("       \t\t  تاكد من البيانات   \t\t ");
                return;
            }
          
                double cpay = Convert.ToDouble(textBox4.Text);
            if(PAY_S.Checked==false)
            { 
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ppp.Text = cpay.ToString();
                    double cdebt = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    if (cpay <= cdebt)
                    {
                        ddd.Text = cdebt.ToString();
                        cus.add_dept(Convert.ToInt32(textBox3.Text), cpay * -1);
                        cus.d_dept(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), cpay);
                        ORD.add_cash_histoty(Program.UID, cpay, 0, Convert.ToInt32(comboBox1.SelectedValue), "سداد ديون", textBox2.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), DateTime.Now, 33, Convert.ToInt32(textBox3.Text));
                        cpay = 0;
                    }
                    else
                       if (cpay >= cdebt && cpay > 0)
                    {
                        cus.add_dept(Convert.ToInt32(textBox3.Text), cdebt * -1);
                        cus.d_dept(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), cdebt);
                        ORD.add_cash_histoty(Program.UID, cdebt, 0, Convert.ToInt32(comboBox1.SelectedValue), "سداد ديون", textBox2.Text, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), DateTime.Now, 33, Convert.ToInt32(textBox3.Text));
                        cpay = cpay - cdebt;
                    }
                    else if (cpay <= 0)
                    {
                        return;
                    }
                }
            }
            else if (PAY_S.Checked == true)
            {
                // ddd.Text = cdebt.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cus.add_dept(Convert.ToInt32(textBox3.Text), Convert.ToDouble(textBox4.Text) * -1);
                cus.d_dept(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToDouble(textBox4.Text));
                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(textBox4.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "سداد ديون", textBox2.Text, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), DateTime.Now, 11, Convert.ToInt32(textBox3.Text));
            }
            MessageBox.Show("       \t\t  تم سداد الديون العميل " + textBox2.Text + " \t\t ");
                this.Close();

            }
        

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
            catch { return; }
        }

        private void PAY_S_CheckedChanged(object sender, EventArgs e)
        {
            if (PAY_S.Checked == true)
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
                else
                {
                    return;
                }
            }
            else
            {
                dataGridView1.DataSource = cus.c_debt(Convert.ToInt32(textBox3.Text));
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
        }
    }
}
