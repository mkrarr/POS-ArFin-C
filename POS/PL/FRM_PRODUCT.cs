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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace POS.PL
{
    public partial class FRM_PRODUCTS : Form
    {
        private static FRM_PRODUCTS frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_PRODUCTS getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCTS();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();

        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;

            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODECT frm = new FRM_ADD_PRODECT();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = prd.SearchProduct(textBox1.Text);
            this.dataGridView1.DataSource = dt;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Delete Product","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Delete Product Done","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

            }
            else{
                MessageBox.Show("Delete Product Stop", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODECT FRM = new FRM_ADD_PRODECT();
            FRM.txtref.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            FRM.txtdes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FRM.txtqte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            FRM.txtprice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            FRM.txtbprice.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            FRM.cmdcategories.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            FRM.Text = "Update Product: " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            FRM.btnok.Text = "Update";
            FRM.state = "update";
            FRM.txtref.ReadOnly = true;
            FRM.txtqte.ReadOnly = true;
            try
            {
                byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(image);
                FRM.pbox.Image = Image.FromStream(ms);
                FRM.ShowDialog();
            }
            catch
            {
                FRM.ShowDialog();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FRM_PREVIEW FRM = new FRM_PREVIEW();
            try
            {
                byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(image);
                FRM.pictureBox1.Image = Image.FromStream(ms);
            }
            catch
            {

            }
                FRM.ShowDialog();
        }

        private void FRM_PRODUCTS_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RPT.rpt_prd_single myReport = new RPT.rpt_prd_single();
            myReport.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            myReport.DataSourceConnections[0].IntegratedSecurity = false;
            myReport.Refresh();
          //  myReport.DataSourceConnections[0].IntegratedSecurity = false;
            myReport.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            RPT.FRM_RPT_PRODUCT myFORM = new RPT.FRM_RPT_PRODUCT();
            myFORM.CR1.ReportSource = myReport;
            myFORM.ShowDialog();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_prd myReport = new RPT.rpt_all_prd();
            myReport.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            myReport.DataSourceConnections[0].IntegratedSecurity = false;  
            RPT.FRM_RPT_PRODUCT myFORM = new RPT.FRM_RPT_PRODUCT();
            myReport.Refresh();

            
           
            myFORM.CR1.ReportSource = myReport;
            myFORM.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_prd myreport = new RPT.rpt_all_prd();

            ExportOptions expor = new ExportOptions();

            DiskFileDestinationOptions dfo = new DiskFileDestinationOptions();
            dfo.DiskFileName=@"e:\Report.xls";
            ExcelFormatOptions excel = new ExcelFormatOptions();
            expor = myreport.ExportOptions;
            expor.ExportDestinationType = ExportDestinationType.DiskFile;
            expor.ExportFormatType = ExportFormatType.Excel;
            expor.ExportFormatOptions = excel;
            expor.ExportDestinationOptions = dfo;
            myreport.Export();
            MessageBox.Show("Export Done", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);




            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PL.FRM_Stock STO = new FRM_Stock();
            STO.txtref.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            STO.txtname.Text=this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            STO.txtstock.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

            STO.ShowDialog();

        }
    }
}
