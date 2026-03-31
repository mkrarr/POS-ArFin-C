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
using Spire.Barcode;
using QRCoder;
using IronBarCode;


namespace POS.PL
{

    public partial class Order_PAT : Form
    {
        Byte[] qr;
        string invt;
        double temp = 0;
        double add_pric = 0;
        double limit = 0;
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        BL.CLS_CUSTOMERS cus = new BL.CLS_CUSTOMERS();
        DataTable dt = new DataTable();
        DataTable ch = new DataTable();
        DataTable dx = new DataTable();


       
        void Calcoulatamount()
        {
            if (txtprice.Text != string.Empty && txtqut.Text != string.Empty)
            {
                double Amount = Convert.ToDouble(txtprice.Text) * Convert.ToDouble(txtqut.Text);
                txtamount.Text = Amount.ToString();
            }
        }

        //void qrcoceq()
        //{

        //    string data = "RNO: " + TXTOID.Text + "\n TAX-ID : " + Program.TAX_ID + "\n Zakat-ID: " + Program.ZKA_ID +
        //     "\n Ivoice Total: " + Convert.ToDouble(TXTAMOS.Text) + "\n TAX-Rate : " + Program.TAX_pr * Convert.ToDouble(TXTAMOS.Text) + "\n Zakat-Rate: " + Program.ZKA_pr * Convert.ToDouble(TXTAMOS.Text) +
        //     "\n\n\n Powerd By:-  MK IT Services +96659699343";

        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //    QR_BOX.Image = qrCodeImage;

        //    QR_BOX.Image.Save(Properties.Settings.Default.qr_path, System.Drawing.Imaging.ImageFormat.Png);
        //    try
        //    {
        //        //   pictureBox1.Image = QR_BOX.Image;
        //        QR_BOX.ImageLocation = Properties.Settings.Default.qr_path;
        //    }
        //    catch
        //    {
        //        QR_BOX.ImageLocation = Properties.Settings.Default.qr_path;
        //        MessageBox.Show("QR Erorr");
        //    }

        //}
        void qrcoceq()
        {
            Image V_qr;
            BL.ZatcaQrCodeGenerator zk2 = new BL.ZatcaQrCodeGenerator();
            string barc = "1";
            decimal AMT = Convert.ToDecimal(TXTAMOS.Text);
            double vatp = Program.TAX_pr;
            
            barc = zk2.GenerateQrCodeBase64(Program.location, Program.TAX_ID, DateTime.Now, AMT, Convert.ToDecimal(vatp * Convert.ToDouble(AMT)),TXTOID.Text);


            string data = barc;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            V_qr = qrCodeImage;

            MemoryStream ms = new MemoryStream();
            V_qr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();

            ORD.py_qr(Convert.ToInt32(TXTOID.Text), byteImage);
        }

        void Bar_codeG()
        {
            string data = TXTOID.Text;

            string barc = TXTOID.Text;
            Zen.Barcode.Code128BarcodeDraw brc = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pbox22.Image = brc.Draw(barc, 60);

            pbox22.Image.Save(Properties.Settings.Default.BR_path, System.Drawing.Imaging.ImageFormat.Png);
            try
            {
                //   pictureBox1.Image = QR_BOX.Image;
                pbox22.ImageLocation = Properties.Settings.Default.BR_path;
            }
            catch
            {
                pbox22.ImageLocation = Properties.Settings.Default.BR_path;
                MessageBox.Show("QR Erorr");
            }

        }
        void CalcoulatTotal()
        {
            if (txtamount.Text != string.Empty && txtdescount.Text != string.Empty)
            {
                if (chd.Checked == true)
                {
                    double descount = Convert.ToDouble(txtdescount.Text);
                    double Amount = Convert.ToDouble(txtamount.Text);
                    double Total = Amount - ((Amount * descount) / 100);

                    txttotal.Text = Total.ToString();
                }
                else
                {
                    double descount = Convert.ToDouble(txtdescount.Text);
                    double Amount = Convert.ToDouble(txtamount.Text);
                    double Total = Amount -descount;

                    txttotal.Text = Total.ToString();
                }
            }
        }

        void up_count()
        {
            int xxx = dgvPro.Rows.Count;
            int xx = xxx - 1;
            lblcount.Text = xx.ToString();
        }

        void chaqu()
        {
            ORD.add_chaque(TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToDateTime(date22.Text), Convert.ToDouble(c_total.Text), Convert.ToInt32(txtCID.Text), Convert.ToInt32(TXTOID.Text), Convert.ToInt32(comboBox1.SelectedValue));
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
            txtpatch.Clear();
            textBox1.Clear();

        }
        void newbt()
        {
            //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            butsave.Enabled = true;
            BUTNEW.Enabled = false;
            button3.Enabled = true;
            btnPrint.Enabled = true;
          //  Bar_codeG();
            try
            {
                qrcoceq();
            }
            catch { return; }

        }
        void clear_data()
        {
            if (ORD.FRTY().Rows[0][0].ToString() == "0")
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
                   pbox.Image = null; */
                TXTAMOS.Text = "0";
                Clearbox();
                dt.Clear();
                button3.Enabled = false;
                dgvPro.DataSource = null;
                txtCID.Text = "1";
                TXTCFNAME.Text = "";
                txtCLAST.Text = "Cash";
                txtcph.Text = "-";
                txtcemail.Text = "-";
                //comboBox1.Text = "";
                comboBox1.DataSource = ORD.get_pay();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "id";
                limit = 0;
                add_pric = 0;
                ins_cop.SelectedValue = 1;
                ins_prc.SelectedIndex = 0;
                TXTCFNAME.Text = Program.op_name;
                 
            }
            else
            {
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
                       pbox.Image = null; */
                    TXTAMOS.Text = "0";
                    Clearbox();
                    dt.Clear();
                    button3.Enabled = false;
                    dgvPro.DataSource = null;
                    txtCID.Text = "1";
                    TXTCFNAME.Text = "";
                    txtCLAST.Text = "Cash";
                    txtcph.Text = "-";
                    txtcemail.Text = "-";
                    //comboBox1.Text = "";
                    comboBox1.DataSource = ORD.get_pay();
                    comboBox1.DisplayMember = "Name";
                    comboBox1.ValueMember = "id";
                    limit = 0;
                    add_pric = 0;
                    ins_cop.SelectedValue = 1;
                    ins_prc.SelectedIndex = 0;
                    TXTCFNAME.Text = "OUT Pation";
                    newbt(); 
                    BUTNEW.Visible = false;
                }
            }
        }


        void Create_dt()
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Patch");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Discount (%)");
            dt.Columns.Add("Total");
            dt.Columns.Add("PPR");

            dgvPro.DataSource = dt;
        }






        void resizeDGV()
        {
            this.dgvPro.RowHeadersWidth = 63;
            this.dgvPro.Columns[0].Width = -1;
            this.dgvPro.Columns[1].Width = 70;
            this.dgvPro.Columns[2].Width = 70;
            this.dgvPro.Columns[3].Width = 165;
            this.dgvPro.Columns[4].Width = 95;
            this.dgvPro.Columns[5].Width = 99;
            this.dgvPro.Columns[6].Width = 115;
            this.dgvPro.Columns[7].Width = 101;
            this.dgvPro.Columns[9].Width = -1;

        }
        public Order_PAT()
        {
            InitializeComponent();
            clear_data();
             
            Create_dt();
            resizeDGV();
            this.TXToEMP.Text = Program.SelasMAN;
            this.txtuid.Text = Program.UID;

            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";

            ins_cop.DataSource = ORD.INS_LIST();
            ins_cop.DisplayMember = "name";
            ins_cop.ValueMember = "id";

            rel_comb.DataSource = ORD.get_rel();
            rel_comb.DisplayMember = "Val2";
            rel_comb.ValueMember = "Val1";

            ins_prc.DataSource = ORD.ins_prc();
            ins_prc.DisplayMember = "Val1";
            ins_prc.ValueMember = "Val1";

             this.dgvPro.Columns["PPR"].Visible = false;

            this.dgvPro.Columns[0].Width = -1;
            this.dgvPro.Columns[1].Width = 70;
            this.dgvPro.Columns[2].Width = 70;
            this.dgvPro.Columns[3].Width = 165;
            this.dgvPro.Columns[4].Width = 95;
            this.dgvPro.Columns[5].Width = 99;
            this.dgvPro.Columns[6].Width = 115;
            this.dgvPro.Columns[7].Width = 101;
            this.dgvPro.Columns[9].Width = -1;
          // this.dgvPro.Columns[9].Visible = false;


        }

        private void Order_PAT_Load(object sender, EventArgs e)
        {
            txtID.Focus();
            // Bar_codeG();
            //try
            //{
            //    qrcoceq();
            //}
            //catch { return; }
            ch = ORD.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
            if(ORD.s_type().Rows[0][0].ToString()=="1")
            {
                panel1.Visible = true;
                panel2.Visible = true;
                
            }
            else
            {
                panel1.Visible = true;
                panel2.Visible = true;
            }

            if (FRM_MAIN.getMainForm.الماليةToolStripMenuItem.Enabled == true)
            {
                txtprice.Enabled = true;
                txtprice.ReadOnly = false;
                dgvPro.Columns[9].Visible = false;

            }
            else
            {
                return;
            }
            txtID.Text = "";
            dgvPro.Columns[0].ReadOnly = true;
            dgvPro.Columns[1].ReadOnly = true;
            dgvPro.Columns[2].ReadOnly = true;
            dgvPro.Columns[4].ReadOnly = true;
            dgvPro.Columns[5].ReadOnly = true;
            dgvPro.Columns[6].ReadOnly = true;
            dgvPro.Columns[7].ReadOnly = true;
            dgvPro.Columns[8].ReadOnly = true;
           // dgvPro.Columns[9].ReadOnly = true;
            dgvPro.Columns[9].Visible = false;

            a1.Text = Properties.Settings.Default.Server;
            a2.Text = Properties.Settings.Default.Database;
            a3.Text = Properties.Settings.Default.ID;
            a4.Text = Properties.Settings.Default.password;
            /* int rowsno = dgvPro.Rows.Count;
           // int count = Convert.ToInt32(lblcount.Text);
            int lable = rowsno  - 1;
            lblcount.Text = "Product Count   "+lable.ToString();*/
            up_count();
            clear_data();
             



        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUST_LIST frm = new FRM_CUST_LIST();
            frm.ShowDialog();
            txtCID.Text = frm.dgvCL.CurrentRow.Cells[0].Value.ToString();
            TXTCFNAME.Text = frm.dgvCL.CurrentRow.Cells[1].Value.ToString() + " " + frm.dgvCL.CurrentRow.Cells[2].Value.ToString(); 
         //   txtCLAST.Text = frm.dgvCL.CurrentRow.Cells[2].Value.ToString();
            txtcph.Text = frm.dgvCL.CurrentRow.Cells[3].Value.ToString();
            try
            {
                txtcemail.Text = frm.dgvCL.CurrentRow.Cells[4].Value.ToString();

                byte[] Cpic = (byte[])frm.dgvCL.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(Cpic);
                pbox2.Image = Image.FromStream(ms);
            }
            catch { return; }


        }

        private void BUTNEW_Click(object sender, EventArgs e)
        {
            
           // this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            butsave.Enabled = true;
            BUTNEW.Enabled = false;
            button3.Enabled = true;
            btnPrint.Enabled = true;
            try
            {
                qrcoceq();
            }
            catch { return; }
           // Bar_codeG();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PL.FRM_PRO_LIST frm = new FRM_PRO_LIST();
            frm.ShowDialog();
            try
            {
                txtID.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                PL.Form2 ptl = new Form2();
                ptl.pid.Text = txtID.Text;
                ptl.prcc.Text = add_pric.ToString();
                
                ptl.ShowDialog();
                //if (ptl.dataGridView1.Rows.Count == 1)
                //{
                //    ptl.Close();
                //}
                //else { return; }
                txtpatch.Text = ptl.dataGridView1.CurrentRow.Cells[0].Value.ToString(); 
                txtname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtprice.Text = ptl.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtpprice.Text = ptl.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtqut.Focus();

            }
            catch { return; }
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

                        PL.Form2 ptl = new Form2();
                        ptl.pid.Text = txtID.Text;
                        ptl.prcc.Text = add_pric.ToString();
                        ptl.ShowDialog();
                        txtpatch.Text = ptl.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        txtname.Text = Convert.ToString(dt.Rows[0][1]);
                        txtprice.Text = ptl.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        txtpprice.Text = ptl.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        txtqut.Focus();

                        txtqut.Focus();
                    }
                    else
                        MessageBox.Show("الرجاء التاكد من المنتج ");
                }
                catch
                {
                    Clearbox();

                    return;
                }
            }
        }

        private void txtqut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtqut_KeyUp(object sender, KeyEventArgs e)
        {

            Calcoulatamount();
            CalcoulatTotal();
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

        private void txtdescount_KeyUp(object sender, KeyEventArgs e)
        {
            CalcoulatTotal();

        }

        private void txtdescount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                up_count();

                if (txtname.Text == "")
                {
                    txtID.Focus();
                    return;
                }
                else
                if (ORD.V_PTQ(txtID.Text, Convert.ToInt32(txtqut.Text),txtpatch.Text).Rows.Count < 1)
                {
                    MessageBox.Show("           Product    " + txtname.Text + "   Out of Stock        ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }else  if(prd.Ding_d(txtID.Text,"v_drg").Rows.Count >0)
                {
  if(MessageBox.Show( txtname.Text+ "\n"+ "هل انت متاكد من ان الصنف  مدرج بالطلب حسب التعليمات","الادوية",MessageBoxButtons.YesNo,MessageBoxIcon.Hand)==DialogResult.No)
  { return; }
                }

                for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                {
                    if (dgvPro.Rows[i].Cells[1].Value.ToString() == txtID.Text && dgvPro.Rows[i].Cells[2].Value.ToString() == txtpatch.Text )
                    {
                        //   MessageBox.Show("المنتج مطلوب مسبقاً الرجاء تعديل الكمية", "منتج", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        {
                            dgvPro.Rows[i].Cells[5].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[5].Value) + Convert.ToDouble(txtqut.Text)).ToString();
                            dgvPro.Rows[i].Cells[6].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[5].Value) * Convert.ToDouble(dgvPro.Rows[i].Cells[4].Value)).ToString();
                            dgvPro.Rows[i].Cells[8].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[6].Value) - (Convert.ToDouble(dgvPro.Rows[i].Cells[6].Value) * (Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value)) / 100)).ToString();

                            Clearbox();
                            return;
                        }


                    }

                }
                DataRow r = dt.NewRow();
                r[0] = txtID.Text;
                r[1] = txtpatch.Text;
                r[2] = txtname.Text;
                r[3] = txtprice.Text;
                r[4] = txtqut.Text;
                r[5] = txtamount.Text;
                r[6] = txtdescount.Text;
                r[7] = txttotal.Text;
                r[8] = txtpprice.Text;
             

                dt.Rows.Add(r);
                dgvPro.DataSource = dt;
                Clearbox();
                    this.dgvPro.Columns["PPR"].Visible = false;
                    this.dgvPro.Columns[9].Visible = false;
                   // this.dgvPro.Columns["0"].Visible = false;
                    this.dgvPro.Columns[0].Visible = false;
                TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                                where row.Cells[8].FormattedValue.ToString() != string.Empty
                                select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
                up_count();
                txtID.Focus();

            }
        }

        private void txtdescount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             ch = ORD.PAY_CH(Convert.ToInt32(comboBox1.SelectedValue));
            if (ch.Rows[0][0].ToString()=="1")
            {
                groupBox5.Visible = true;
            }
            else
            {
                groupBox5.Visible = false;
            }
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

            if (TXTOID.Text == string.Empty || txtCID.Text == string.Empty || dgvPro.Rows.Count < 2 || TXToTY.Text == string.Empty || comboBox1.Text == string.Empty)
            {
                MessageBox.Show("الرجاء التاكد من البيانات", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //             this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            //    butsave.Enabled = true;
            //   BUTNEW.Enabled = false;
            // btnPrint.Enabled = true;
            ////-----            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();-------

            try
            {
                qrcoceq();
            }
            catch { return; }
            Bar_codeG();

            barcodeb.Image.Save(Properties.Settings.Default.BR_path, System.Drawing.Imaging.ImageFormat.Png);
            pbox22.ImageLocation = Properties.Settings.Default.BR_path;


            if (ch.Rows[0][0].ToString() == "1")
            {
                chaqu();
            }
            else
            {
                groupBox5.Visible = false;

            }
            if (limit < Convert.ToDouble(txtamm2.Text) & limit > 0)
            {
                if (MessageBox.Show(" الطلب  اعلاء  من  السقف  اليومي  للمريض ", "سقف المريض", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
                {
                    return;
                }

                else
                {
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                    ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                    for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                    {
                        ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                                 Convert.ToInt32(TXTOID.Text),
                                                Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                                 dgvPro.Rows[i].Cells[4].Value.ToString(),
                                                 Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                                 dgvPro.Rows[i].Cells[6].Value.ToString(),
                                                 dgvPro.Rows[i].Cells[8].Value.ToString(),
                                                 dgvPro.Rows[i].Cells[2].Value.ToString(),
                                                (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                    }
                    //QR Save
                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    QR_BOX.Image.Save(Properties.Settings.Default.qr_path, System.Drawing.Imaging.ImageFormat.Png);
                    pictureBox1.ImageLocation = Properties.Settings.Default.qr_path;

                    MemoryStream ms = new MemoryStream();
                    QR_BOX.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();
                    ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);
                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    //Bar Code Save
                    Bar_codeG();
                    barcodeb.Image.Save(Properties.Settings.Default.BR_path);
                    pbox22.ImageLocation = Properties.Settings.Default.BR_path;
                    MemoryStream ms2 = new MemoryStream();
                    pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] btimg = ms2.ToArray();
                    ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);


                    ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                    //cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));
                    
                    MessageBox.Show("تم الحفظ بالرقم  " + TXTOID.Text + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear_data();


                }
            }
            else
            {

                           this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                {
                    ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                             Convert.ToInt32(TXTOID.Text),
                                            Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                             dgvPro.Rows[i].Cells[4].Value.ToString(),
                                             Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                             dgvPro.Rows[i].Cells[6].Value.ToString(),
                                             dgvPro.Rows[i].Cells[8].Value.ToString(),
                                             dgvPro.Rows[i].Cells[2].Value.ToString(),
                                            (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                }
                try
                {
                    qrcoceq();
                }
                catch { return; }
                QR_BOX.Image.Save(Properties.Settings.Default.qr_path, System.Drawing.Imaging.ImageFormat.Png);
                pictureBox1.ImageLocation = Properties.Settings.Default.qr_path;


                MemoryStream ms = new MemoryStream();
                QR_BOX.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);
                try
                {
                    qrcoceq();
                }
                catch { return; }

                Bar_codeG();
                barcodeb.Image.Save(Properties.Settings.Default.BR_path);
                pbox22.ImageLocation = Properties.Settings.Default.BR_path;
                MemoryStream ms2 = new MemoryStream();
                pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                byte[] btimg = ms2.ToArray();
                ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);


                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                //  cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));
               
                MessageBox.Show("تم الحفظ بالرقم " + TXTOID.Text + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ORD.qrCode(TXTOID.Text + "_" + TXTAMOS.Text, TXTOID.Text); 
                //  qrcoceq();


                clear_data();


            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            try
            {
                qrcoceq();
            }
            catch { return; }
            //Bar_codeG();



            invt = ORD.inv_ty().Rows[0][0].ToString();
            //   label25.Text = invt;


            if (TXTOID.Text == string.Empty || txtCID.Text == string.Empty || dgvPro.Rows.Count < 2 || TXToTY.Text == string.Empty || comboBox1.Text == "")
            {
                MessageBox.Show("الرجاء التاكد من البيانات", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable vcs = new DataTable();
            vcs = cus.v_cus(Convert.ToInt32(txtCID.Text));
            if (vcs.Rows.Count < 1)
            {
                MessageBox.Show("       Customer Not Found     ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            //       this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();
            if (ch.Rows[0][0].ToString() == "1")
            {
                chaqu();
            }
            else
            {
                groupBox5.Visible = false;

            }
            if (limit < Convert.ToDouble(txtamm2.Text) & limit > 0)
            {
                if (MessageBox.Show(" الطلب  اعلاء  من  السقف  اليومي  للمريض ", "سقف المريض", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                    ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                    for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                    {
                        ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                                 Convert.ToInt32(TXTOID.Text),
                                                Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                                 dgvPro.Rows[i].Cells[4].Value.ToString(),
                                                 Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                                 dgvPro.Rows[i].Cells[6].Value.ToString(),
                                                 dgvPro.Rows[i].Cells[8].Value.ToString(),
                                                 dgvPro.Rows[i].Cells[2].Value.ToString(),
                                                (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                    }
                    ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));


                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    MemoryStream ms = new MemoryStream();
                    QR_BOX.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();

                    ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);
                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }

                    //Bar Code Save
                    Bar_codeG();
                    MemoryStream ms2 = new MemoryStream();
                    pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] btimg = ms2.ToArray();
                    ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);

                    //       cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));




                    this.Cursor = Cursors.WaitCursor;



                    if (invt == "2")
                    {
                        RPT.ins_orderPR rpt = new RPT.ins_orderPR();
                        int order_id = Convert.ToInt32(TXTOID.Text);
                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@ID_ORDER", order_id);
                        frm.CR1.ReportSource = rpt;
                        //  frm.ShowDialog();
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            //   rpt.PrintToPrinter(1, false, 0, 0);
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else if (invt == "0")
                    {
                        RPT.s_order rpt = new RPT.s_order();
                        int order_id = Convert.ToInt32(TXTOID.Text);

                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@ID_ORDER", order_id);
                        frm.CR1.ReportSource = rpt;
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                        this.Cursor = Cursors.Default;
                    }

                    else if (invt == "1")
                    {
                        RPT.Rpt_ord_invo rpt = new RPT.Rpt_ord_invo();
                        int order_id = Convert.ToInt32(TXTOID.Text);

                        rpt.Refresh();
                        rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                        rpt.DataSourceConnections[0].IntegratedSecurity = false;
                        RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                        rpt.SetParameterValue("@ID_ORDER", order_id);
                        frm.CR1.ReportSource = rpt;
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            //    rpt.PrintToPrinter(1, false, 0, 0);
                        }
                        this.Cursor = Cursors.Default;
                    }
                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    //Bar_codeG();
                    MessageBox.Show("تم الحفظ بالرقم " + TXTOID.Text + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_data();


                }
            }
            else
            {
                //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                {
                    ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                             Convert.ToInt32(TXTOID.Text),
                                            Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                             dgvPro.Rows[i].Cells[4].Value.ToString(),
                                             Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                             dgvPro.Rows[i].Cells[6].Value.ToString(),
                                             dgvPro.Rows[i].Cells[8].Value.ToString(),
                                             dgvPro.Rows[i].Cells[2].Value.ToString(),
                                            (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                }
                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                try
                {
                    qrcoceq();
                }
                catch { return; }
                MemoryStream ms = new MemoryStream();
                QR_BOX.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);
                try
                {
                    qrcoceq();
                }
                catch { return; }

                //Bar Code Save
                Bar_codeG();
                MemoryStream ms2 = new MemoryStream();
                pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                byte[] btimg = ms2.ToArray();
                ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);

                //   cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));

                try
                {
                    qrcoceq();
                }
                catch { return; }



                this.Cursor = Cursors.WaitCursor;
                if (invt == "2")
                {
                    RPT.ins_orderPR rpt = new RPT.ins_orderPR();
                    int order_id = Convert.ToInt32(TXTOID.Text);
                    rpt.Refresh();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.SetParameterValue("@ID_ORDER", order_id);
                    frm.CR1.ReportSource = rpt;
                    try
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    catch
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (invt == "0")
                {
                    RPT.s_order rpt = new RPT.s_order();
                    int order_id = Convert.ToInt32(TXTOID.Text);

                    rpt.Refresh();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.SetParameterValue("@ID_ORDER", order_id);
                    frm.CR1.ReportSource = rpt;
                    try
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    catch
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else if (invt == "1")
                {
                    RPT.Rpt_ord_invo rpt = new RPT.Rpt_ord_invo();
                    int order_id = Convert.ToInt32(TXTOID.Text);

                    rpt.Refresh();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.SetParameterValue("@ID_ORDER", order_id);
                    frm.CR1.ReportSource = rpt;
                    try
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    catch
                    {
                        for (int k = 0; k < Program.RC; k++)
                        {
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                try
                {
                    qrcoceq();
                }
                catch { return; }
                //Bar_codeG();
                MessageBox.Show("تم الحفظ بالرقم " + TXTOID.Text + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_data();


            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

            try
            {
                qrcoceq();
            }
            catch { return; }
            //Bar_codeG();




            if (TXTOID.Text == string.Empty || txtCID.Text == string.Empty || dgvPro.Rows.Count < 2 || TXToTY.Text == string.Empty || comboBox1.Text == "")
            {
                MessageBox.Show("الرجاء التاكد من البيانات", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable vcs = new DataTable();
            vcs = cus.v_cus(Convert.ToInt32(txtCID.Text));
            if (vcs.Rows.Count < 1)
            {
                MessageBox.Show("       Customer Not Found     ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

            if (ch.Rows[0][0].ToString() == "1")
            {
                ORD.add_chaque(TXTCFNAME.Text, Convert.ToDateTime(date22.Text), Convert.ToDouble(c_total.Text), Convert.ToInt32(txtCID.Text), Convert.ToInt32(TXTOID.Text), Convert.ToInt32(comboBox1.SelectedValue));
            }
            else
            {
                groupBox5.Visible = false;
            }
            if (limit < Convert.ToDouble(txtamm2.Text) & limit > 0)
            {
                if (MessageBox.Show(" الطلب  اعلاء  من  السقف  اليومي  للمريض ", "سقف المريض", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
                {
                    return;
                }

                else
                {
                    //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                    ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                    for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                    {
                        ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                                Convert.ToInt32(TXTOID.Text),
                                               Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                                dgvPro.Rows[i].Cells[4].Value.ToString(),
                                                Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                                dgvPro.Rows[i].Cells[6].Value.ToString(),
                                                dgvPro.Rows[i].Cells[8].Value.ToString(),
                                                dgvPro.Rows[i].Cells[2].Value.ToString(),
                                                (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                    }

                    ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    MemoryStream ms = new MemoryStream();
                    QR_BOX.Image.Save(ms, QR_BOX.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();
                    ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);

                    try
                    {
                        qrcoceq();
                    }
                    catch { return; }
                    //Bar Code Save
                    Bar_codeG();
                    MemoryStream ms2 = new MemoryStream();
                    pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] btimg = ms2.ToArray();
                    ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);

                    //  cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));

                    this.Cursor = Cursors.WaitCursor;
                    int order_id = Convert.ToInt32(TXTOID.Text);
                    RPT.order_InvoA4P rpt = new RPT.order_InvoA4P();
                    rpt.Refresh();
                    rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                    rpt.DataSourceConnections[0].IntegratedSecurity = false;
                    RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                    rpt.SetParameterValue("@ID_ORDER", order_id);
                    frm.CR1.ReportSource = rpt;
                    try
                    {
                        for (int k = 0; k < Program.IC; k++)
                        {
                            rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                            rpt.PrintToPrinter(Program.IC, false, 0, 0);
                        }
                    }
                    catch
                    {
                        for (int k = 0; k < Program.IC; k++)
                        {
                            rpt.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("تم الحفظ بالرقم:  " + TXTOID.Text + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_data();

                }
            }
            else
            {
                //this.TXTOID.Text = ORD.get_l_o_id().Rows[0][0].ToString();

                ORD.ADD_ORDER(Convert.ToInt32(TXTOID.Text), DateTime.Now, Convert.ToInt32(txtCID.Text), TXToTY.Text, TXToEMP.Text, txtamm2.Text, txtuid.Text, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToDouble(txtdep.Text), Convert.ToDouble(txtpay.Text), Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(ins_cop.SelectedValue), txtCLAST.Text, TXTCFNAME.Text, Convert.ToInt32(rel_comb.SelectedValue), Convert.ToDouble(ins_prc.SelectedValue));
                for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                {
                    ORD.ADD_ORDER_DETAILS_PT(dgvPro.Rows[i].Cells[1].Value.ToString(),
                                            Convert.ToInt32(TXTOID.Text),
                                           Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value),
                                            dgvPro.Rows[i].Cells[4].Value.ToString(),
                                            Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value),
                                            dgvPro.Rows[i].Cells[6].Value.ToString(),
                                            dgvPro.Rows[i].Cells[8].Value.ToString(),
                                            dgvPro.Rows[i].Cells[2].Value.ToString(),
                                            (Convert.ToDouble(dgvPro.Rows[i].Cells[9].Value) * Convert.ToInt32(dgvPro.Rows[i].Cells[5].Value)));
                }

                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(txtpay.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text + ' ' + txtCLAST.Text, Convert.ToInt32(TXTOID.Text), DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                try
                {
                    qrcoceq();
                }
                catch { return; }
                MemoryStream ms = new MemoryStream();
                QR_BOX.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                ORD.save_QR(Convert.ToInt32(TXTOID.Text), byteImage);
                try
                {
                    qrcoceq();
                }
                catch { return; }
                //Bar Code Save
                Bar_codeG();
                MemoryStream ms2 = new MemoryStream();
                pbox22.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Png);
                byte[] btimg = ms2.ToArray();
                ORD.save_Bar(Convert.ToInt32(TXTOID.Text), btimg);

                //cus.add_dept(Convert.ToInt32(txtCID.Text), Convert.ToDouble(txtdep.Text));

                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(TXTOID.Text);
                RPT.order_InvoA4P rpt = new RPT.order_InvoA4P();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                try
                {
                    for (int k = 0; k < Program.IC; k++)
                    {
                        rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                        rpt.PrintToPrinter(Program.IC, false, 0, 0);
                    }
                }
                catch
                {
                    for (int k = 0; k < Program.IC; k++)
                    {
                        rpt.PrintToPrinter(Program.IC, false, 0, 0);
                    }
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("تم الحفظ بالرقم:  " + TXTOID.Text + "    ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_data();

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTAMOS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qrcoceq();
                txtamm2.Text = TXTAMOS.Text;
                //txtdep.Text = (Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text)).ToString();
                //txtpay.Text = txtamm2.Text;
                txtpay.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) * Convert.ToDouble(ins_prc.SelectedValue))).ToString();
                txtdep.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text))).ToString();
            }
            catch {
                txtamm2.Text = TXTAMOS.Text;
                //txtdep.Text = (Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text)).ToString();
                //txtpay.Text = txtamm2.Text;
                txtpay.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) * Convert.ToDouble(ins_prc.SelectedValue))).ToString();
                txtdep.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text))).ToString();
                return; }
            txtamm2.Text = TXTAMOS.Text;
            //txtdep.Text = (Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text)).ToString();
            //txtpay.Text = txtamm2.Text;
            txtpay.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) * Convert.ToDouble(ins_prc.SelectedValue))).ToString();
            txtdep.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text))).ToString();
        }

        private void txtpay_TextChanged(object sender, EventArgs e)
        {
            if (txtpay.Text == "")
            {
                txtpay.Text = "0";
                return;
            }
            txtdep.Text = (Convert.ToDouble(TXTAMOS.Text) - Convert.ToDouble(txtpay.Text)).ToString();
        }

        private void dgvPro_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = dgvPro.CurrentRow.Cells[1].Value.ToString();
                txtpatch.Text = dgvPro.CurrentRow.Cells[2].Value.ToString();
                txtname.Text = dgvPro.CurrentRow.Cells[3].Value.ToString();
                txtprice.Text = dgvPro.CurrentRow.Cells[4].Value.ToString();
                txtqut.Text = dgvPro.CurrentRow.Cells[5].Value.ToString();
                txtamount.Text = dgvPro.CurrentRow.Cells[6].Value.ToString();
                txtdescount.Text = dgvPro.CurrentRow.Cells[7].Value.ToString();
                txttotal.Text = dgvPro.CurrentRow.Cells[8].Value.ToString();
                dgvPro.Rows.RemoveAt(dgvPro.CurrentRow.Index);
                txtqut.Focus();
            }
            catch
            {
                MessageBox.Show("لا توجد بيانات");
                return;
            }
        }

        private void dgvPro_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                            where row.Cells[8].FormattedValue.ToString() != string.Empty
                            select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
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

        private void txtdep_TextChanged(object sender, EventArgs e)
        {
            c_total.Text = txtpay.Text;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ins_prc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtpay.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) * Convert.ToDouble(ins_prc.SelectedValue))).ToString();
            txtdep.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text))).ToString();

        }

        private void ins_cop_SelectedIndexChanged(object sender, EventArgs e)
        {
            limit = Convert.ToDouble(ORD.get_ins_limit(Convert.ToInt32(ins_cop.SelectedValue)).Rows[0][0].ToString());
            add_pric = Convert.ToDouble(ORD.get_ins_limit(Convert.ToInt32(ins_cop.SelectedValue)).Rows[0][1].ToString());

          //  TXToTY.Text = limit.ToString() + " ++ " + add_pric.ToString();
        }

        private void dgvPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtamm2_TextChanged(object sender, EventArgs e)
        {
            txtpay.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) * Convert.ToDouble(ins_prc.SelectedValue))).ToString();
            txtdep.Text = Convert.ToDecimal((Convert.ToDouble(txtamm2.Text) - Convert.ToDouble(txtpay.Text))).ToString();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                CalcoulatTotal();
                if (textBox1.Text == "")
                    return;
                else
                {
                    // txtID.Text = textBox1.Text;

                    try
                    {
                        DataTable dt = new DataTable();
                        dt = prd.SearchProduct(textBox1.Text);
                        if (dt.Rows.Count > 0)
                        {
                            txtID.Text = Convert.ToString(dt.Rows[0][0]);
                            txtname.Text = Convert.ToString(dt.Rows[0][1]);

                            PL.Form2 ptl = new Form2();
                            ptl.pid.Text = txtID.Text;
                            ptl.prcc.Text = add_pric.ToString();
                            ptl.ShowDialog();
                            txtpatch.Text = ptl.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                           // txtname.Text = Convert.ToString(dt.Rows[0][1]);
                            txtprice.Text = ptl.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                            txtpprice.Text = ptl.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                            txtqut.Text = "1";
                            txttotal.Text = txtprice.Text;
                            txtamount.Text = txtprice.Text;
                            CalcoulatTotal();

                            up_count();
                            txtdescount_KeyDown(sender, e);



                            if (ORD.V_PTQ(txtID.Text, Convert.ToInt32(txtqut.Text), txtpatch.Text).Rows.Count < 1)
                            {
                                MessageBox.Show("           Product    " + txtname.Text + "   Out of Stock        ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;

                            }
                            for (int i = 0; i < dgvPro.Rows.Count - 1; i++)
                            {
                                if (dgvPro.Rows[i].Cells[1].Value.ToString() == txtID.Text && dgvPro.Rows[i].Cells[2].Value.ToString() == txtpatch.Text)
                                {
                                    //   MessageBox.Show("المنتج مطلوب مسبقاً الرجاء تعديل الكمية", "منتج", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                                    dgvPro.Rows[i].Cells[5].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[5].Value) + Convert.ToDouble(txtqut.Text)).ToString();
                                    dgvPro.Rows[i].Cells[6].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[5].Value) * Convert.ToDouble(dgvPro.Rows[i].Cells[4].Value)).ToString();
                                    dgvPro.Rows[i].Cells[8].Value = (Convert.ToDouble(dgvPro.Rows[i].Cells[6].Value) - (Convert.ToDouble(dgvPro.Rows[i].Cells[6].Value) * (Convert.ToDouble(dgvPro.Rows[i].Cells[7].Value)) / 100)).ToString();

                                    Clearbox();
                                    return;



                                }
                                else
                                {
                                    txtdescount_KeyDown(sender, e);

                                    DataRow r = dt.NewRow();
                                    r[0] = txtID.Text;
                                    r[1] = txtpatch.Text;
                                    r[2] = txtname.Text;
                                    r[3] = txtprice.Text;
                                    r[4] = txtqut.Text;
                                    r[5] = txtamount.Text;
                                    r[6] = txtdescount.Text;
                                    r[7] = txttotal.Text;
                                    r[8] = txtpprice.Text;


                                    dt.Rows.Add(r);
                                    dgvPro.DataSource = dt;
                                    Clearbox();
                                    this.dgvPro.Columns["PPR"].Visible = false;
                                    this.dgvPro.Columns[9].Visible = false;
                                    //this.dgvPro.Columns["0"].Visible = false;
                                    this.dgvPro.Columns[0].Visible = false;
                                    TXTAMOS.Text = (from DataGridViewRow row in dgvPro.Rows
                                                    where row.Cells[8].FormattedValue.ToString() != string.Empty
                                                    select Convert.ToDouble(row.Cells[8].FormattedValue)).Sum().ToString();
                                    up_count();

                                    //    Clearbox();

                                }
                            }
                        }
                        else
                            MessageBox.Show("الرجاء التاكد من المنتج ");
                        Clearbox();
                    }
                    catch
                    {
                        Clearbox();

                        return;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtID.Text = textBox1.Text;
        }

        private void label25_Click(object sender, EventArgs e)
        {
            TC_POS tc = new TC_POS();
            tc.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void QR_BOX_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File |*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                QR_BOX.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void txtdescount_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTOID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                qrcoceq();
            }
            catch { return; }
        }

        private void txtprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtqut.Focus();
            }
        }

        private void txtqut_Validating(object sender, CancelEventArgs e)
        {
            if(txtqut.Text=="0"||txtqut.Text=="" && txtID.Text!=""&&txtpatch.Text!=""&& txtname.Text!="")
            {
                txtqut.Focus();
            }else if(txtID.Text=="") { txtID.Focus(); } else { return; }
        }

        private void chd_CheckedChanged(object sender, EventArgs e)
        {
            if(chd.Checked==true)
            {
                label17.Text = " (%) الخصم ";
            }
            else
            {
                label17.Text = "  الخصم ";
            }
        }
    }
}
