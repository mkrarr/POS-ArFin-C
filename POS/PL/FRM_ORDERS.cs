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
    public partial class FRM_ORDERS : Form
    {
        double temp = 0;
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        DataTable dt = new DataTable();
        
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
                double Total = Amount - ((Amount * descount )/ 100);

                txttotal.Text = Total.ToString();
             }
        }

        void up_count()
        {
            int xxx = dgvPro.Rows.Count;
            int xx = xxx - 1;
            lblcount.Text = xx.ToString();
        }
            
        void Clearbox()
        {
            txtID.Clear();
            txtname.Clear();
            txtprice.Clear();
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
          /*  TXTCFNAME.Clear();
            txtCLAST.Clear();
            txtcph.Clear();
            txtcemail.Clear();
            txtCID.Clear();
            pbox.Image = null; */
            TXTAMOS.Text = "0";
            Clearbox();
            dt.Clear();
            dgvPro.DataSource = null;  

        }


        void Create_dt()
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
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
        public FRM_ORDERS()
        {
            InitializeComponent();
           Create_dt();
            resizeDGV();
            this.TXToEMP.Text = Program.SelasMAN;
            this.txtuid.Text = Program.UID;

           // this.dgvPro.Columns[0].Visible = false;

            this.dgvPro.Columns[0].Width = -1;
            this.dgvPro.Columns[1].Width = 70;
            this.dgvPro.Columns[2].Width = 165;
            this.dgvPro.Columns[3].Width = 95;
            this.dgvPro.Columns[4].Width = 99;
            this.dgvPro.Columns[5].Width = 115;
            this.dgvPro.Columns[6].Width = 101;
 


        }

        private void BUTNEW_Click(object sender, EventArgs e)
        {
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            butsave.Enabled = true;
            BUTNEW.Enabled = false;
            btnPrint.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUST_LIST frm = new FRM_CUST_LIST();
            frm.ShowDialog();
            txtCID.Text = frm.dgvCL.CurrentRow.Cells[0].Value.ToString();
            TXTCFNAME.Text = frm.dgvCL.CurrentRow.Cells[1].Value.ToString();
            txtCLAST.Text = frm.dgvCL.CurrentRow.Cells[2].Value.ToString();
            txtcph.Text = frm.dgvCL.CurrentRow.Cells[3].Value.ToString();
            txtcemail.Text = frm.dgvCL.CurrentRow.Cells[4].Value.ToString();

            byte[] Cpic = (byte[]) frm.dgvCL.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(Cpic);
            pbox.Image = Image.FromStream(ms);




        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_ORDERS_Load(object sender, EventArgs e)
        {
            dgvPro.Columns[0].ReadOnly = true;
            dgvPro.Columns[1].ReadOnly = true;
            dgvPro.Columns[2].ReadOnly = true;
            dgvPro.Columns[4].ReadOnly = true;
            dgvPro.Columns[5].ReadOnly = true;
            dgvPro.Columns[6].ReadOnly = true;
            dgvPro.Columns[7].ReadOnly = true;
            a1.Text = Properties.Settings.Default.Server;
            a2.Text = Properties.Settings.Default.Database;
            a3.Text = Properties.Settings.Default.ID;
            a4.Text = Properties.Settings.Default.password;
            /* int rowsno = dgvPro.Rows.Count;
           // int count = Convert.ToInt32(lblcount.Text);
            int lable = rowsno  - 1;
            lblcount.Text = "Product Count   "+lable.ToString();*/
            up_count();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
            frm.ShowDialog();
            txtID.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtprice.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtqut.Focus();



        }

        private void txtqut_KeyPress(object sender, KeyPressEventArgs e)
        {

            if(!char.IsDigit(e.KeyChar)&& e.KeyChar!=8 && e.KeyChar !=Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtqut_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtqut_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && txtqut.Text != string.Empty)
            {
                Calcoulatamount();
                CalcoulatTotal();
                txtdescount.Focus();
            }
        }

        private void txtqut_KeyUp(object sender, KeyEventArgs e)
        {
           
            Calcoulatamount();
             CalcoulatTotal();
            
        }

        private void txtdescount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtdescount_KeyUp(object sender, KeyEventArgs e)
        {
            CalcoulatTotal();
        }

        private void txtdescount_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
                {
                    up_count();

                    if(txtname.Text=="")
                    {
                        txtID.Focus();
                        return;
                    }else
                    if (ORD.VQUN(txtID.Text, Convert.ToInt32(txtqut.Text)).Rows.Count < 1)
                    {
                        MessageBox.Show("           Product    "+txtname.Text +"   Out of Stock        ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    for (int i = 0; i < dgvPro.Rows.Count -1 ; i++)
                    {
                        if (dgvPro.Rows[i].Cells[1].Value.ToString() == txtID.Text)
                        {
                            if (MessageBox.Show("Product add as new", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                    r[1] = txtname.Text;
                    r[2] = txtprice.Text;
                    r[3] = txtqut.Text;
                    r[4] = txtamount.Text;
                    r[5] = txtdescount.Text;
                    r[6] = txttotal.Text;

                    dt.Rows.Add(r);
                    dgvPro.DataSource = dt;
                    Clearbox();
                    TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                                    where row.Cells[7].FormattedValue.ToString() != string.Empty
                                    select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString();
                    up_count();

                }
        }

        private void txtdescount_TextChanged(object sender, EventArgs e)
        {
            if (txtdescount.Text == "" || Convert.ToInt32(txtdescount.Text) < 0 || Convert.ToInt32(txtdescount.Text) > 100)
            {
                MessageBox.Show("           Not Allow...       ");
                txtdescount.Text = "0";
                Calcoulatamount();
                CalcoulatTotal();
                return;
            }
        }

        private void txtdescount_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dgvPro_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = dgvPro.CurrentRow.Cells[1].Value.ToString();
                txtname.Text = dgvPro.CurrentRow.Cells[2].Value.ToString();
                txtprice.Text = dgvPro.CurrentRow.Cells[3].Value.ToString();
                txtqut.Text = dgvPro.CurrentRow.Cells[4].Value.ToString();
                txtamount.Text = dgvPro.CurrentRow.Cells[5].Value.ToString();
                txtdescount.Text = dgvPro.CurrentRow.Cells[6].Value.ToString();
                txttotal.Text = dgvPro.CurrentRow.Cells[7].Value.ToString();
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
                txtqut.Focus();
            }
            catch
            {
                return;
            }
        }

        private void dgvPro_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                            where row.Cells[7].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvPro_DoubleClick(sender, e);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up_count();

            try
            {
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
            }
            catch { return; }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up_count();

            dt.Clear();
            dgvPro.Refresh();
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            up_count();

             if (dgvPro.Rows.Count<2)
            {
                MessageBox.Show("Select Product to Delete");

                 return;
            }
            else
            {
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
            }
        
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            if(TXTOID.Text==string.Empty || txtCID.Text== string.Empty || dgvPro.Rows.Count<2|| TXToTY.Text==string.Empty)
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
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
        //    butsave.Enabled = true;
         //   BUTNEW.Enabled = false;
           // btnPrint.Enabled = true;
            ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), Convert.ToDateTime(oDATE1.Text), Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text,txtamm2.Text,txtuid.Text,Program.IPA,Program.PC,TXTCFNAME.Text);
            
            for(int i=0; i<dgvPro.Rows.Count-1;i++)
            {
                ORD.ADD_ORDER_DETAILS(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                       Convert.ToInt32(TXTOID.Text),
                                      Convert.ToInt32(dgvPro.Rows[i].Cells[4].Value),
                                       dgvPro.Rows[i].Cells[3].Value.ToString(),
                                       Convert.ToInt32(dgvPro.Rows[i].Cells[6].Value),
                                       dgvPro.Rows[i].Cells[5].Value.ToString(),
                                       dgvPro.Rows[i].Cells[7].Value.ToString());



               
            }
            MessageBox.Show("Order Save", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear_data();      
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable vcs = new DataTable();
            vcs = cus.v_cus(Convert.ToInt32(txtCID.Text));
            if(vcs.Rows.Count<1)
            {
                MessageBox.Show("       Customer Not Found     ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

            ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), Convert.ToDateTime(oDATE1.Text), Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text);

            for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
            {
                ORD.ADD_ORDER_DETAILS(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                       Convert.ToInt32(TXTOID.Text),
                                      Convert.ToInt32(dgvPro.Rows[i].Cells[4].Value),
                                       dgvPro.Rows[i].Cells[3].Value.ToString(),
                                       Convert.ToInt32(dgvPro.Rows[i].Cells[6].Value),
                                       dgvPro.Rows[i].Cells[5].Value.ToString(),
                                       dgvPro.Rows[i].Cells[7].Value.ToString());




            }

            this.Cursor = Cursors.WaitCursor;
            int order_id = Convert.ToInt32(TXTOID.Text);
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
            MessageBox.Show("       Order "+ TXTOID.Text +" Save      ", "Orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear_data();


        }

        private void txtID_Validated(object sender, EventArgs e)
        {
          

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text == "")
                {
                    PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
                    frm.ShowDialog();
                    txtID.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtprice.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtqut.Focus();
                }
                try
                {
                    DataTable dt = new DataTable();
                    dt = prd.SearchProduct(txtID.Text);
                    if (dt.Rows.Count > 0)
                    {
                        txtID.Text = Convert.ToString(dt.Rows[0][0]);
                        txtname.Text = Convert.ToString(dt.Rows[0][1]);
                        txtprice.Text = Convert.ToString(dt.Rows[0][3]);

                        txtqut.Focus();
                    }
                    else
                        MessageBox.Show("not found");
                }
                catch
                {
                    Clearbox();

                    return;
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPro_RowErrorTextChanged(object sender, DataGridViewRowEventArgs e)
        {
           
        }

        private void dgvPro_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            


        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void TXTAMOS_TextChanged(object sender, EventArgs e)
        {
            txtamm2.Text = TXTAMOS.Text;
        }

        private void txtdescount_Validated(object sender, EventArgs e)
        {
            if (txtdescount.Text == "" || Convert.ToInt32(txtdescount.Text) < 0 || Convert.ToInt32(txtdescount.Text) > 100)
            {
                MessageBox.Show("           Not Allow...       ");
                txtdescount.Text = "0";

                return;
            }
        }

        private void dgvPro_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvPro.CurrentRow.Cells[5].Value = (Convert.ToDouble(dgvPro.CurrentRow.Cells[3].Value) * Convert.ToDouble(dgvPro.CurrentRow.Cells[4].Value)).ToString();
                dgvPro.CurrentRow.Cells[7].Value = (Convert.ToDouble(dgvPro.CurrentRow.Cells[5].Value) - (Convert.ToDouble(dgvPro.CurrentRow.Cells[5].Value) * Convert.ToDouble(dgvPro.CurrentRow.Cells[6].Value) / 100)).ToString();
            }
            catch
            {
                errorProvider1.SetError(dgvPro, "Please Enter Name");
                dgvPro.CurrentRow.Cells[3].Value = temp.ToString();
            }
        }

        private void dgvPro_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            temp = Convert.ToDouble(dgvPro.CurrentRow.Cells[3].Value);
        }

        private void dgvPro_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            double val;
            Control edit = dgvPro.EditingControl;
            if (edit != null && !Double.TryParse(e.FormattedValue.ToString(), out val))
            {
                dgvPro.CurrentRow.Cells[3].Value = temp.ToString();
                e.Cancel = true;
                
                errorProvider1.SetError(edit, "Numeric value required");
                errorProvider1.SetIconAlignment(edit, ErrorIconAlignment.MiddleLeft);
               
                errorProvider1.SetIconPadding(edit, -75); // icon displays on left side of cell 
            }
        }
    }
}
