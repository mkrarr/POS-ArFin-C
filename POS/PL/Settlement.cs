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
            if (cmbres.Text == ""|| dataGridView1.Rows.Count<=1)
            {
                MessageBox.Show("       الرجاء التاكد من ادخال البيانات     ");
                return;
            }
            else
            {
                if (MessageBox.Show("\t هل انت متاكد من البيانات المدخله؟ \n \t سيتم تعديل المخزون ولا يمكن التراجع عن العملية", "جــرد", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    //   MessageBox.Show("", "Settled Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("سيتم خفظ العمليه باسمك هل انت واثق من ذلك؟", "جــرد", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        textBox2.Text = cls.get_l_s_id().Rows[0][0].ToString();
                        cls.Add_sett(Convert.ToInt32(textBox2.Text), Program.UID, textBox1.Text, cmbres.Text);

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {                      
                            cls.UPDATE_Stock(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value), dataGridView1.Rows[i].Cells[1].Value.ToString());
                            cls.add_sett_ditails(dataGridView1.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value), Convert.ToInt32(textBox2.Text), dataGridView1.Rows[i].Cells[1].Value.ToString());
                        }
                        this.Cursor = Cursors.WaitCursor;
                        int id = Convert.ToInt32(textBox2.Text);
                        RPT.rpt_stam rpt = new RPT.rpt_stam();
                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@id", id);
                        frm.CR1.ReportSource = rpt;
                        rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                        rpt.PrintToPrinter(1, false, 0, 0);
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("تـم حـفـطـ الـتـسـويـة");
                        this.Close();
                    }
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

            if (e.KeyCode == Keys.Space)
            {
                PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
                frm.ShowDialog();
                this.dataGridView1.CurrentRow.Cells[0].Value = frm.dataGridView1.CurrentRow.Cells[0].Value;
                this.dataGridView1.CurrentRow.Cells[2].Value = frm.dataGridView1.CurrentRow.Cells[1].Value;
                PL.Form2 ptl = new Form2();
                ptl.prcc.Text = "0";
                ptl.pid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ptl.ShowDialog();
                this.dataGridView1.CurrentRow.Cells[1].Value = ptl.dataGridView1.CurrentRow.Cells[0].Value;
                this.dataGridView1.CurrentRow.Cells[3].Value = ptl.dataGridView1.CurrentRow.Cells[3].Value;

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
            frm.ShowDialog();
            this.dataGridView1.CurrentRow.Cells[0].Value = frm.dataGridView1.CurrentRow.Cells[0].Value;
            this.dataGridView1.CurrentRow.Cells[2].Value = frm.dataGridView1.CurrentRow.Cells[1].Value;
            PL.Form2 ptl = new Form2();
            ptl.prcc.Text = "0";
            ptl.pid.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ptl.ShowDialog();
            this.dataGridView1.CurrentRow.Cells[1].Value = ptl.dataGridView1.CurrentRow.Cells[0].Value;
            this.dataGridView1.CurrentRow.Cells[3].Value = ptl.dataGridView1.CurrentRow.Cells[3].Value;
   
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

                dataGridView1.CurrentRow.Cells[5].Value = (Convert.ToDouble(
                dataGridView1.CurrentRow.Cells[4].Value) - Convert.ToDouble(
                dataGridView1.CurrentRow.Cells[3].Value)).ToString();
            }
        }

        private void Settlement_Load(object sender, EventArgs e)
        {
            textBox2.Text = cls.get_l_s_id().Rows[0][0].ToString();
        }
    }
}
