using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POS.PL
{
    public partial class FRM_CUSTOMERS : Form
    {
        int ID;
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        

        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = cust.GET_ALL_CUST();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtf_name.Text = null;
            txtL_name.Text = null;
            txtemail.Text = null;
            txtPh.Text = null;
            pbox.Image = POS.Properties.Resources.ID2;
            btnsave.Enabled = true;
            btnadd.Enabled = false;
            txtf_name.Focus();
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File |*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] pic = ms.ToArray();
                cust.ADD_CUSTOMER(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic);
                MessageBox.Show("Add Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = cust.GET_ALL_CUST();
                btnsave.Enabled = false;
                btnadd.Enabled = true;


            }
            catch
            {
                MessageBox.Show("Any Erorr in add", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtf_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtL_name.Focus();

            }
        }

        private void txtL_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPh.Focus();

            }
        }

        private void txtPh_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsave.Focus();

            }
        }

        private void txtPh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtemail.Focus();

            }
        }

        private void FRM_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.txtref.Text = ID.ToString();
                dataGridView2.DataSource = cust.C_ORD(Convert.ToInt32(txtref.Text));
                this.txtf_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtL_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtPh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                dataGridView2.DataSource = cust.C_ORD(Convert.ToInt32(txtref.Text));
                MemoryStream ms = new MemoryStream(pic);
                pbox.Image = Image.FromStream(ms);
                
            }
            catch
            {
                return;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("Customer Not Select", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] pic = ms.ToArray();
                cust.EDIT_CUSTOMER(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic,ID);
                MessageBox.Show("Update Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = cust.GET_ALL_CUST();

            }
            catch
            {
                MessageBox.Show("Any Erorr in Update", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (ID == 0)
                {
                    MessageBox.Show("Customer Not Select", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Delete Customer " + txtf_name.Text + " " + txtL_name.Text + "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cust.Delete_cust(ID);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUST();

                }
            }else if(checkBox1.Checked == true)
            {
                if (ID == 0)
                {
                    MessageBox.Show("Customer Not Select", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Reset Customer "+txtf_name.Text +" "+txtL_name.Text +" ", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cust.Delete_cust2(ID);
                    this.dataGridView1.DataSource = cust.GET_ALL_CUST2();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cust.Search_cust(txtsea.Text);
            dataGridView1.Columns[5].Visible = false;
           

        }

        private void txtsea_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cust.Search_cust(txtsea.Text);
            dataGridView1.Columns[5].Visible = false;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtref.Text==string.Empty)
            {
                MessageBox.Show("       Select Customer Please      ","Erorr", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    int Cust_id = Convert.ToInt32(txtref.Text);
                    RPT.rpt_cus_Or rpt = new RPT.rpt_cus_Or();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.Refresh();
                    rpt.SetParameterValue("@ID_CUS", Cust_id);
                    frm.CR1.ReportSource = rpt;
                    frm.ShowDialog();
                    this.Cursor = Cursors.Default;
                }

                catch
                {
                    MessageBox.Show("       Select Customer        ", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;

                    return;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.txtref.Text = ID.ToString();
                this.txtf_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtL_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtPh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                dataGridView2.DataSource = cust.C_ORD(Convert.ToInt32(txtref.Text));
                MemoryStream ms = new MemoryStream(pic);
                pbox.Image = Image.FromStream(ms);

            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count < 2)
            {
                MessageBox.Show("       Select Order Please         ", "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                RPT.order_InvoA4 rpt = new RPT.order_InvoA4();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                this.dataGridView1.DataSource = cust.GET_ALL_CUST();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                button5.Text = "      Delete";
            }
            else if(checkBox1.Checked == true)
            {
                this.dataGridView1.DataSource = cust.GET_ALL_CUST2();
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                button5.Text = "      Reset";
            }
        }
    }
}
