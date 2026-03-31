using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace POS.PL
{
    public partial class Printers : Form
    {
        public Printers()
        {
            InitializeComponent();
            txtinv.Text= Properties.Settings.Default.PrinterR ;
            txtrep.Text= Properties.Settings.Default.PrinterRPT ;
            imgP.Text = Properties.Settings.Default.m_path;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrinterR = txtinv.Text;
            Properties.Settings.Default.PrinterRPT = txtrep.Text;
            Properties.Settings.Default.qr_path = imgP.Text + @"\MKQR.png";
            Properties.Settings.Default.BR_path = imgP.Text + @"\MKBR.png";
            Properties.Settings.Default.m_path = imgP.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("          تم تعديل الضبط          ", "الضبط", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PL.Printer_list pr = new Printer_list();
            pr.label1.Text = "Invoice Printer";
            pr.sts = "I";
            pr.ShowDialog();
            if (pr.sts == "I")
            {
                txtinv.Text = pr.lstPrinterList.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            PL.Printer_list pr = new Printer_list();
            pr.label1.Text = "Report Printer";
            pr.sts = "R";
            pr.ShowDialog();
            if (pr.sts == "R")
            {
                txtrep.Text = pr.lstPrinterList.SelectedItem.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Printers_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ff = new FolderBrowserDialog();
            ff.ShowDialog();
            imgP.Text=ff.SelectedPath.ToString();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
