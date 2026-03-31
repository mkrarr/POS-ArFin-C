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
using System.Data.SqlClient;
using System.Globalization;

namespace POS.PL
{
    public partial class P_Refond : Form
    {
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        DataTable dt = new DataTable();
        DataTable dtch = new DataTable();

        int p_ty = 2;
        int test_ch = 0;

        void Calcoulatamount()
        {
            if (txtprice.Text != string.Empty && txtqut.Text != string.Empty)
            {
                double Amount = Convert.ToDouble(txtprice.Text) * Convert.ToDouble(txtqut.Text);
                txtamount.Text = Amount.ToString();
            }
        }



        void CalcoulatTotal()
        {
            if (txtamount.Text != string.Empty && txtdescount.Text != string.Empty)
            {
                double descount = Convert.ToDouble(txtdescount.Text);
                double Amount = Convert.ToDouble(txtamount.Text);
                double Total = Amount - ((Amount * descount) / 100);

                txttotal.Text = Total.ToString();
            }
        }

        void up_count()
        {
            int xxx = dgvPro.Rows.Count;
            int xx = xxx - 1;
            lblcount.Text = xx.ToString();

            TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                            where row.Cells[8].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
        }

        void Clearbox()
        {
            txtID.Clear();
            txtname.Clear();
            txtprice.Clear();
            txtbatch.Clear();
            txtqut.Clear();
            txtamount.Clear();
            txtdescount.Text = "0";
            txttotal.Clear();
            button4.Focus();

        }

        void clear_data()
        {
            butsave.Enabled = false;
            BUTNEW.Enabled = true;
            TXTOID.Clear();
            btnPrint.Enabled = false;
            TXToTY.Text = "-";
           /* TXTCFNAME.Clear();
              txtCLAST.Clear();
              txtcph.Clear();
              txtcemail.Clear();
              txtCID.Clear();
              pbox.Image =  ;*/
            TXTAMOS.Text = "0.00";
            Clearbox();
            dt.Clear();
            dgvPro.DataSource = null;
        }


        void Create_dt()
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Batch");
            dt.Columns.Add("    Name    ");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Discount (%)");
            dt.Columns.Add("Total");
            dgvPro.DataSource = dt;
        }
        
        void resizeDGV()
        {
            this.dgvPro.RowHeadersWidth = 63;


        }
        public P_Refond()
        {
            InitializeComponent();
            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
            Create_dt();
            resizeDGV();
            this.TXToEMP.Text = Program.SelasMAN;
            this.txtuid.Text = Program.UID;
             //this.dgvPro.Columns[0].Visible = false;

            this.dgvPro.Columns[0].Width = -1;
            this.dgvPro.Columns[1].Width = 70;
            this.dgvPro.Columns[2].Width = 165;
            this.dgvPro.Columns[3].Width = 95;
            this.dgvPro.Columns[4].Width = 99;
            this.dgvPro.Columns[5].Width = 115;
            this.dgvPro.Columns[6].Width = 101; this.dgvPro.Columns[7].Width = 101; this.dgvPro.Columns[8].Width = 101;
            this.dgvPro.Columns[6].ValueType = typeof(Double); //this.dgvPro.Columns[7].ValueType = typeof(Double); this.dgvPro.Columns[8].ValueType = typeof(Double);


            this.dgvPro.Columns[0].Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dto;
            BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
            if (txtORef.Text == "")
            {
                MessageBox.Show("Invoice Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            dto = ord.Get_P_ord_r(Convert.ToInt32(txtORef.Text));
            if (dto.Rows.Count > 0)
            {
                // asd = 1;
                dataGridView1.DataSource = ord.get_P_r_pro(Convert.ToInt32(txtORef.Text));
                txtCID.Text = dto.Rows[0][2].ToString();
                TXTCFNAME.Text = dto.Rows[0][6].ToString();
                txtCLAST.Text = dto.Rows[0][7].ToString();
                txtcph.Text = dto.Rows[0][8].ToString();
                txtcemail.Text = dto.Rows[0][9].ToString();
                oDATE1.Value = Convert.ToDateTime(dto.Rows[0][1]);
                //  txtold.Text = dto.Rows[0][4].ToString();
                //  txtonote.Text = dto.Rows[0][3].ToString();
                txtodebt.Text = dto.Rows[0][10].ToString();
                txtopay.Text = dto.Rows[0][11].ToString();
                txtototal.Text = dto.Rows[0][5].ToString();

                if (dto.Rows[0][12].ToString() == "3")
                {
                    // groupBox5.Visible = true;
                    dtch = ord.GET_CH_REF(Convert.ToInt32(txtORef.Text), p_ty);
                    if (dtch.Rows.Count == 1)
                    {
                        test_ch = 1;
                        comboBox1.SelectedValue = 3;
                        groupBox5.Text = dtch.Rows[0][0].ToString();
                        date22.Value = Convert.ToDateTime(dtch.Rows[0][2].ToString());
                    }
                    else
                    {
                        test_ch = 0;
                    }

                }
            }

            else
            {
                MessageBox.Show("Invoice Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void txtORef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataTable dto;
                BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
                if (txtORef.Text == "")
                {
                    MessageBox.Show("Invoice Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                dto = ord.Get_P_ord_r(Convert.ToInt32(txtORef.Text));
                if (dto.Rows.Count > 0)
                {
                    // asd = 1;
                    dataGridView1.DataSource = ord.get_P_r_pro(Convert.ToInt32(txtORef.Text));
                    txtCID.Text = dto.Rows[0][2].ToString();
                    TXTCFNAME.Text = dto.Rows[0][6].ToString();
                    txtCLAST.Text = dto.Rows[0][7].ToString();
                    txtcph.Text = dto.Rows[0][8].ToString();
                    txtcemail.Text = dto.Rows[0][9].ToString();
                    oDATE1.Value = Convert.ToDateTime(dto.Rows[0][1]);
                    //  txtold.Text = dto.Rows[0][4].ToString();
                    //  txtonote.Text = dto.Rows[0][3].ToString();
                    txtodebt.Text = dto.Rows[0][10].ToString();
                    txtopay.Text = dto.Rows[0][11].ToString();
                    txtototal.Text = dto.Rows[0][5].ToString();
                }

                else
                {
                    MessageBox.Show("Invoice Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }

        private void P_Refond_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtbatch.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtqut.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtamount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtdescount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txttotal.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtdescount.Focus();
        }

        private void txtqut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtqut.Text != string.Empty)
            {
                Calcoulatamount();
                CalcoulatTotal();
                txtdescount.Focus();
            }
        }

        private void txtdescount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtdescount.Text == "" || Convert.ToDouble(txtdescount.Text) < 0 || Convert.ToDouble(txtdescount.Text) > 100)
                {
                    MessageBox.Show("           Not Allow...       ");
                    txtdescount.Text = "0";
                    txtdescount.Focus();
                    return;
                }
                else
                    up_count();

                /* if (ORD.VQUN(txtID.Text, Convert.ToInt32(txtqut.Text)).Rows.Count < 1)
                 {
                     MessageBox.Show("Stock is LOW", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;

                 }*/
                for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                {
                    if (dgvPro.Rows[i].Cells[1].Value.ToString() == txtID.Text)
                    {
                        if (MessageBox.Show("       Product Orady in list        \n             add as new", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            Clearbox();
                            return;
                        }
                        else
                        {
                            up_count();
                        }

                    }

                }
                DataRow r = dt.NewRow();
                r[0] = txtID.Text;
                r[1] = txtbatch.Text;
                r[2] = txtname.Text;
                r[3] = txtprice.Text;
                r[4] = txtqut.Text;
                r[5] = txtamount.Text;
                r[6] = txtdescount.Text;
                r[7] = txttotal.Text;

                dt.Rows.Add(r);
                dgvPro.DataSource = dt;
                Clearbox();
                TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                                where row.Cells[8].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
                up_count();

            }
        }

        private void txtdescount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtdescount_TextChanged(object sender, EventArgs e)
        {
            if (txtdescount.Text == "" || Convert.ToDouble(txtdescount.Text) < 0 || Convert.ToDouble(txtdescount.Text) > 100)
            {
                MessageBox.Show("           Not Allow...       ");
                txtdescount.Text = "0";
                Calcoulatamount();
                CalcoulatTotal();
                return;
            }
        }

        private void txtdescount_KeyUp(object sender, KeyEventArgs e)
        {
            CalcoulatTotal();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPro_DoubleClick(sender, e);
        }

        private void dgvPro_DoubleClick(object sender, EventArgs e)
        {
                 try
            {
                txtID.Text = dgvPro.CurrentRow.Cells[1].Value.ToString();
                txtbatch.Text = dgvPro.CurrentRow.Cells[2].Value.ToString();
                txtname.Text = dgvPro.CurrentRow.Cells[3].Value.ToString();
                txtprice.Text = dgvPro.CurrentRow.Cells[4].Value.ToString();
                txtqut.Text = dgvPro.CurrentRow.Cells[5].Value.ToString();
                txtamount.Text = dgvPro.CurrentRow.Cells[6].Value.ToString();
                txtdescount.Text = dgvPro.CurrentRow.Cells[7].Value.ToString();
                txttotal.Text = dgvPro.CurrentRow.Cells[8].Value.ToString();
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
                up_count();
                txtqut.Focus();
            }
                catch
            {
                return;
            }
       }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up_count();

            try
            {
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
                up_count();

            }
            catch { return; }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPro.DataSource = dt;
        }

        private void BUTNEW_Click(object sender, EventArgs e)
        {

            this.TXTOID.Text = ORD.get_L_R_P().Rows[0][0].ToString();
            butsave.Enabled = true;
            BUTNEW.Enabled = false;
            btnPrint.Enabled = true;
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            if (TXTOID.Text == string.Empty || txtCID.Text == string.Empty || dgvPro.Rows.Count < 2 || TXToTY.Text == string.Empty)
            {
                MessageBox.Show("Fill All Information", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (TXToEMP.Text == string.Empty)
            {
                MessageBox.Show("You are not  login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PL.Frm_login log = new Frm_login();
                this.Close();
                log.ShowDialog();
                return;
            }
            this.TXTOID.Text = ORD.get_L_R_P().Rows[0][0].ToString();
            //    butsave.Enabled = true;
            //   BUTNEW.Enabled = false;
            // btnPrint.Enabled = true;
            string tot = txtamount.Text;
            ORD.ADD_P_Refind(Convert.ToInt32(txtORef.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, TXTAMOS.Text, Convert.ToInt32(TXTOID.Text), txtuid.Text, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text));
            ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "أسترداد مشتريات ", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now,6, Convert.ToInt32(txtCID.Text));

            for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
            {
                ORD.ADD_P_refund_DETAILS(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                       Convert.ToInt32(txtORef.Text),
                                      Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                       dgvPro.Rows[i].Cells[4].Value.ToString(),
                                       Convert.ToInt32(dgvPro.Rows[i].Cells[7].Value),
                                       dgvPro.Rows[i].Cells[6].Value.ToString(),
                                       dgvPro.Rows[i].Cells[8].Value.ToString(),
                                       Convert.ToInt32(TXTOID.Text),dgvPro.Rows[i].Cells[2].Value.ToString());



            }
            //if (test_ch == 1)
            //{
            //    ORD.up_chaqu(Convert.ToInt32(groupBox5.Text), Convert.ToDouble(c_total.Text));
            //}
            //else { return; }
            MessageBox.Show("          Refond Save Done...          ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            clear_data();
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (TXTOID.Text == string.Empty || txtCID.Text == string.Empty || dgvPro.Rows.Count < 2 || TXToTY.Text == string.Empty)
            {
                MessageBox.Show("Fill All Information", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (TXToEMP.Text == string.Empty)
            {
                MessageBox.Show("You are not  login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PL.Frm_login log = new Frm_login();
                this.Close();
                log.ShowDialog();
                return;
            }
            this.TXTOID.Text = ORD.get_L_R_P().Rows[0][0].ToString();
            //    butsave.Enabled = true;
            //   BUTNEW.Enabled = false;
            // btnPrint.Enabled = true;
            string tot = txtamount.Text;
            ORD.ADD_P_Refind(Convert.ToInt32(txtORef.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, TXTAMOS.Text, Convert.ToInt32(TXTOID.Text), txtuid.Text, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text));
            ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text),0, Convert.ToInt32(comboBox1.SelectedValue), "أسترداد مشتريات ", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now,6, Convert.ToInt32(txtCID.Text));

            for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
            {
                ORD.ADD_P_refund_DETAILS(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                       Convert.ToInt32(txtORef.Text),
                                      Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                       dgvPro.Rows[i].Cells[4].Value.ToString(),
                                       Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                       dgvPro.Rows[i].Cells[6].Value.ToString(),
                                       dgvPro.Rows[i].Cells[8].Value.ToString(),
                                       Convert.ToInt32(TXTOID.Text),dgvPro.Rows[i].Cells[2].Value.ToString());
            }
            if (test_ch == 1)
            {
                ORD.up_chaqu(Convert.ToInt32(groupBox5.Text), Convert.ToDouble(c_total.Text));
            }
            

            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(TXTOID.Text);
            RPT.p_ref_invo rpt = new RPT.p_ref_invo();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@ID_ORDER", order_id);
            frm.CR1.ReportSource = rpt;
            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
            rpt.PrintToPrinter(1, false, 0, 0);
            this.Cursor = Cursors.Default;
            MessageBox.Show("Order Save", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear_data();
            this.Close();
        }

        private void txtpay_TextChanged(object sender, EventArgs e)
        {

            if (txtpay.Text == "")
            {
                txtpay.Text = "0.00";
                return;
            }
            txtdep.Text = (Convert.ToDouble(TXTAMOS.Text) - Convert.ToDouble(txtpay.Text)).ToString();
            

        }

        private void txtdep_TextChanged(object sender, EventArgs e)
        {

            if (txtdep.Text == "")
            {
                txtdep.Text = "0";
                return;
            }
            txtpay.Text = (Convert.ToDouble(TXTAMOS.Text) - Convert.ToDouble(txtdep.Text)).ToString();
            c_total.Text = txtdep.Text;
        }

        private void txtpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtqut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void TXTAMOS_TextChanged(object sender, EventArgs e)
        {
            txtpay.Text = TXTAMOS.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 3)
            {
                groupBox5.Visible = true;
            }
            else
            {
                groupBox5.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
