using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using QRCoder;


namespace POS.PL
{


    public partial class POS_SR : Form
    {
        public int temp = 0;
       public  int sst = 0;
        Image qr, br;
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        BL.CLS_ORDERS ORD = new BL.CLS_ORDERS();
        int O_ID = 0;
        DataTable dt = new DataTable();
        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();
        //string connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True;";
        //SqlConnection connection = new SqlConnection(connectionString);

        void qrcoceq()
        {
            Image V_qr;
            BL.ZatcaQrCodeGenerator zk2 = new BL.ZatcaQrCodeGenerator();
            string barc = "";
            decimal AMT = Convert.ToDecimal(TXTAMOS.Text);
            double vatp = Program.TAX_pr;

            barc = zk2.GenerateQrCodeBase64(Program.location, Program.TAX_ID, DateTime.Now, AMT, Convert.ToDecimal(vatp * Convert.ToDouble(AMT)),O_ID.ToString());


            string data = barc;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            V_qr = qrCodeImage;

            MemoryStream ms = new MemoryStream();
            V_qr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();

            ORD.py_qr(Convert.ToInt32(O_ID), byteImage);
        }

        void Bar_codeG()
        {
            string data = O_ID.ToString();

            string barc = O_ID.ToString();
            Zen.Barcode.Code128BarcodeDraw brc = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            br = brc.Draw(barc, 60);

            br.Save(Properties.Settings.Default.BR_path, System.Drawing.Imaging.ImageFormat.Png);

            MemoryStream ms = new MemoryStream();
            br.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();

            ORD.py_br(Convert.ToInt32(O_ID), byteImage);
            try
            {
                //   pictureBox1.Image = QR_BOX.Image;
                //  br = Properties.Settings.Default.BR_path;
            }
            catch
            {
                //  pbox22.ImageLocation = Properties.Settings.Default.BR_path;
                MessageBox.Show("QR Erorr");
            }

        }


        void Create_dt()
        {
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("TOTAL");


            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns["Name"].Width = 15;

            // dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        //  CATButton_Click
        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string productId = clickedButton.Tag.ToString();
            DataTable pdt = pro.pos_pr_ID(productId);
            // Add product to order list, update total, etc.
            // Example: AddToOrder(productId);
            //dataGridView2.DataSource = pro.pos_pr_ID(productId);
            string ID = pdt.Rows[0][0].ToString();
            string name = pdt.Rows[0][1].ToString();
            string price = pdt.Rows[0][2].ToString();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (pdt.Rows[0][0].ToString() == dataGridView1.Rows[i].Cells[0].Value.ToString())
                {
                    dataGridView1.Rows[i].Cells[3].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)) + Convert.ToInt32(QUT.Text);
                    dataGridView1.Rows[i].Cells[4].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)) * (Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
                    // dataGridView1.Rows[i].Cells[3].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)) + 1;
                    double tot2 = (from DataGridViewRow row in dataGridView1.Rows
                                   where row.Cells[4].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
                    TXTAMOS.Text = tot2.ToString("N2");
                    QUT.Text = "1";
                    return;
                }
            }
            DataRow r = dt.NewRow();
            r[0] = ID;
            r[1] = name;
            r[2] = price;
            r[3] = QUT.Text;
            r[4] = "";

            dt.Rows.Add(r);
            dataGridView1.DataSource = dt;
            //  dt.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = (Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value)) * (Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
            }
            double tot = (from DataGridViewRow row in dataGridView1.Rows
                          where row.Cells[4].FormattedValue.ToString() != string.Empty
                          select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
            TXTAMOS.Text = tot.ToString("N2");
            QUT.Text = "1";
            ADDAD.Text = "عدد:" + (Convert.ToDouble(dataGridView1.Rows.Count)-1).ToString("N2");
            double kmya = (from DataGridViewRow row in dataGridView1.Rows
                           where row.Cells[3].FormattedValue.ToString() != string.Empty
                           select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum();
            KMIA.Text = "الكمية:" + kmya.ToString("N2");

        }

        private void CATButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string productId = clickedButton.Tag.ToString();
            //    DataTable pdt = pro.pos_pr_ID(productId);
            // Add product to order list, update total, etc.
            // Example: AddToOrder(productId);
            //dataGridView2.DataSource = pro.pos_pr_ID(productId);
            LoadProducts(productId);
        }

        public DataTable GetProductsByCategory(string category)
        {
            DataTable dt = new DataTable();
            dt = pro.pos_pr(Convert.ToInt32(category));
            return dt;

        }

        public DataTable GETCategory(string category)
        {
            DataTable Cdt = new DataTable();
            Cdt = pro.GET_ALL_CATEGORIES();
            return Cdt;
        }

        private void LoadProducts(string category)
        {
            flowLayoutPanelProducts.Controls.Clear();
            DataTable products = GetProductsByCategory(category);

            foreach (DataRow row in products.Rows)
            {
                int newWidth = 85;
                int newHeight = 85;
                Bitmap resizedImage = new Bitmap(newWidth, newHeight);
                byte[] Cpic = (byte[])row["img"];
                MemoryStream ms = new MemoryStream(Cpic);
                using (Graphics g = Graphics.FromImage(resizedImage))
                {
                    g.DrawImage(Image.FromStream(ms), 0, 0, newWidth, newHeight);
                }

                Button productButton = new Button();
              //  byte[] Cpic = (byte[])row["img"];
               
                //  pictureBox1.Image = Image.FromStream(ms);
                productButton.Image = resizedImage; 
                productButton.ImageAlign = ContentAlignment.BottomCenter;
              
                productButton.TextImageRelation = TextImageRelation.ImageAboveText;
                productButton.TextAlign = ContentAlignment.BottomCenter;
                productButton.Cursor = Cursors.Hand;

                productButton.Text = row["ProductName"].ToString() + Environment.NewLine + "ر.س" + Convert.ToDecimal(row["Price"]).ToString("N2");
                productButton.Tag = row["ProductID"]; // Store ProductID in Tag
                productButton.Size = new Size(150, 150);
                productButton.Click += ProductButton_Click;
                flowLayoutPanelProducts.Controls.Add(productButton);
            }
        }

        private void LoadCAT(string category)
        {
            flowLayoutPanelCAT.Controls.Clear();
            DataTable CAT = GETCategory(category);

            foreach (DataRow row2 in CAT.Rows)
            {
                Button CATButton = new Button();
                //byte[] Cpic = (byte[])row["img"];
                //MemoryStream ms = new MemoryStream(Cpic);
                ////  pictureBox1.Image = Image.FromStream(ms);
                //CATButton.Image = Image.FromStream(ms);
                //CATButton.ImageAlign = ContentAlignment.BottomCenter;
                //CATButton.TextImageRelation = TextImageRelation.ImageAboveText;
                //CATButton.TextAlign = ContentAlignment.BottomCenter;
                CATButton.Cursor = Cursors.Hand;

                CATButton.Text = row2["DESCRIPTION_CAT"].ToString();//+ Environment.NewLine + "ر.س" + Convert.ToDecimal(row2["Price"]).ToString("N2");
                CATButton.Tag = row2["ID_CAT"]; // Store ProductID in Tag
                CATButton.Size = new Size(100, 60);
                CATButton.Click += CATButton_Click;
                flowLayoutPanelCAT.Controls.Add(CATButton);
            }
        }

        public POS_SR()
        {
            InitializeComponent();
            comboBox1.DataSource = ORD.get_pay();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "id";
        }

        private void POS_SR_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = ord.loft_POS(Program.s_id);
            Create_dt();
            txtCID.Text = "1";
            TXTCFNAME.Text = "عميل عام";
            Note.Text = "";
            BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
            string t1 = DateTime.Now.ToLongTimeString();
            string d1 = DateTime.Now.ToShortDateString();
            label10.Text = d1 + "\n" + t1;
            label6.Text = Program.SelasMAN;
            label5.Text = Program.group;
            //label3.Text = Program.log_TM.ToString();
            lab55.Text = Program.location;

            int newWidth = (int)(this.ClientSize.Width - 439);
            flowLayoutPanelProducts.Width = newWidth;
            sidePanel1.Width = newWidth;
            LoadCAT("");
            LoadProducts("3");
           // Create_dt();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double qt = Convert.ToDouble(QUT.Text);
            QUT.Text = (qt + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double qt = Convert.ToDouble(QUT.Text);
            QUT.Text = (qt - 1).ToString();
            double percentage = 0.75; // 75%
            int newWidth = (int)(this.ClientSize.Width - 439);
            flowLayoutPanelProducts.Width = newWidth;
            sidePanel1.Width = newWidth;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable ddd = ord.get_l_PT();
            int asd = Convert.ToInt32(ddd.Rows[0][0].ToString());
            if (dataGridView1.Rows.Count <= 1)
            {
                MessageBox.Show("لا توجد بيانات  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    ord.ADD_POS_TMP(Program.s_id, dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), Note.Text,asd);
                }
                dt.Clear();
                txtCID.Text = "1";
                TXTCFNAME.Text = "عميل عام";
                Note.Text = "";
                MessageBox.Show("تم الحفظ الفاتورة مواقتاَ ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.DataSource = ord.loft_POS(Program.s_id);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - Program.log_TM;

            label7.Text = ts.ToString(@"d\+hh\:mm\:ss");

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string t1 = DateTime.Now.ToLongTimeString();
            string d1 = DateTime.Now.ToShortDateString();
            label10.Text = d1 + "\n" + t1;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                double qt = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                dataGridView1.CurrentRow.Cells[3].Value = (qt + 1).ToString();
                dataGridView1.CurrentRow.Cells[4].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value)) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value));

                double tot = (from DataGridViewRow row in dataGridView1.Rows
                              where row.Cells[4].FormattedValue.ToString() != string.Empty
                              select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
                TXTAMOS.Text = tot.ToString("N2");
                ADDAD.Text = "عدد:" + (Convert.ToDouble(dataGridView1.Rows.Count) - 1).ToString("N2");
                double kmya = (from DataGridViewRow row in dataGridView1.Rows
                               where row.Cells[3].FormattedValue.ToString() != string.Empty
                               select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum();
                KMIA.Text = "الكمية:" + kmya.ToString("N2");
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                double qt = Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                if (qt == 1)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                    //dataGridView1.CurrentRow.Cells[3].Value = (qt - 1).ToString();

                    dataGridView1.CurrentRow.Cells[4].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value)) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value));

                    double tot = (from DataGridViewRow row in dataGridView1.Rows
                                  where row.Cells[4].FormattedValue.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
                    TXTAMOS.Text = tot.ToString("N2");
                    ADDAD.Text = "عدد:" + (Convert.ToDouble(dataGridView1.Rows.Count) - 1).ToString("N2");
                    double kmya = (from DataGridViewRow row in dataGridView1.Rows
                                   where row.Cells[3].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum();
                    KMIA.Text = "الكمية:" + kmya.ToString("N2");
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[3].Value = (qt - 1).ToString();
                    dataGridView1.CurrentRow.Cells[4].Value = (Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value)) * (Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value));

                    double tot = (from DataGridViewRow row in dataGridView1.Rows
                                  where row.Cells[4].FormattedValue.ToString() != string.Empty
                                  select Convert.ToDouble(row.Cells[4].FormattedValue)).Sum();
                    TXTAMOS.Text = tot.ToString("N2");
                    ADDAD.Text = "عدد:" + (Convert.ToDouble(dataGridView1.Rows.Count) - 1).ToString("N2");
                    double kmya = (from DataGridViewRow row in dataGridView1.Rows
                                   where row.Cells[3].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[3].FormattedValue)).Sum();
                    KMIA.Text = "الكمية:" + kmya.ToString("N2");
                }
            } else if (e.KeyCode == Keys.F2)
            {
                button4_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                button5_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                button6_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                button7_Click(sender, e);
            }
            else { return; }
        }

        private void POS_SR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sst !=5)
            {
                FRM_MAIN.getMainForm.Hide();
                this.Hide();
                FRM_MAIN.getMainForm.logoutToolStripMenuItem_Click(sender, e);
            }
            else
            {
                this.Close();
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        { 
            if(FRM_MAIN.getMainForm.productToolStripMenuItem.Enabled==true)
            {
                FRM_MAIN.getMainForm.pOSToolStripMenuItem1_Click(sender,e);
                this.Hide();
            }else { return; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_CUST_LIST frm = new FRM_CUST_LIST();
            frm.ShowDialog();
            txtCID.Text = frm.dgvCL.CurrentRow.Cells[0].Value.ToString();
            TXTCFNAME.Text = frm.dgvCL.CurrentRow.Cells[1].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form popupForm = new MyPopupForm(); // Replace MyPopupForm with your actual form class name

            popupForm.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            dataGridView2.DataSource = ord.loft_POS(Program.s_id);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = ord.loft_POS(Program.s_id);
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {

            DataTable pdt=ord.POS_ProT(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
           dataGridView1.DataSource= ord.POS_ProT(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
           temp=Convert.ToInt32(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanelProducts_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                button4_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                button5_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                button6_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                button7_Click(sender, e);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void POS_SR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                button4_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                button5_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                button6_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                button7_Click(sender, e);
            }else { return; }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            O_ID = Convert.ToInt32(ORD.get_l_o_id().Rows[0][0].ToString());
            if (dataGridView1.Rows.Count <= 1)
            {
                return;
            }
            else
            {
                ord.ADD_POS_ORD(Convert.ToInt32(txtCID.Text), Program.SelasMAN, Convert.ToDouble(TXTAMOS.Text), Program.UID, Program.IPA, Program.PC, TXTCFNAME.Text, Convert.ToInt32(comboBox1.SelectedValue), O_ID, Note.Text);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    ORD.ADD_POS_ORD_D(dataGridView1.Rows[i].Cells[0].Value.ToString(), O_ID, Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString()), Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString()));
                }
                qrcoceq(); Bar_codeG();
                ORD.add_cash_histoty(Program.UID, Convert.ToDouble(TXTAMOS.Text), 0, Convert.ToInt32(comboBox1.SelectedValue), "فاتورة مبيعات", TXTCFNAME.Text, O_ID, DateTime.Now, 1, Convert.ToInt32(txtCID.Text));
                ord.up_POS_TMP(Program.s_id, temp);
                RPT.POS_INV rpt = new RPT.POS_INV();
                int order_id = O_ID;

                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_ORDER", order_id);
                frm.CR1.ReportSource = rpt;
                //for (int k = 0; k < Program.RC; k++)

                rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterR;
                rpt.PrintToPrinter(Program.IC, false, 0, 0);

                //frm.ShowDialog();
                this.Cursor = Cursors.Default;

                MessageBox.Show("تم الحفظ بالرقم  " + O_ID.ToString() + "  ", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dt.Clear();
                txtCID.Text = "1";
                TXTCFNAME.Text = "عميل عام";
                Note.Text = "";
                dataGridView2.DataSource = ord.loft_POS(Program.s_id);

            }
        }
    }
}
