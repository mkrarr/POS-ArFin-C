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
    public partial class Printer_list : Form
    {
        public string sts = "";

        public Printer_list()
        {
            InitializeComponent();
        }

        private void Printer_list_Load(object sender, EventArgs e)
        {
            GetAllPrinterList();
        }

        private void GetAllPrinterList()
        {
            ManagementScope objScope = new ManagementScope(ManagementPath.DefaultPath); //For the local Access
            objScope.Connect();

            SelectQuery selectQuery = new SelectQuery();
            selectQuery.QueryString = "Select * from win32_Printer";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher(objScope, selectQuery);
            ManagementObjectCollection MOC = MOS.Get();
            foreach (ManagementObject mo in MOC)
            {
                lstPrinterList.Items.Add(mo["Name"].ToString());

            }
        }

        private void lstPrinterList_DoubleClick(object sender, EventArgs e)
        {
            PL.Printers po = new Printers();
            if (sts == "R")
            {
                po.txtrep.Text = lstPrinterList.SelectedItem.ToString();
                this.Close();

            }
            else if (sts == "I")
            {
                po.txtinv.Text = lstPrinterList.SelectedItem.ToString();
                this.Close();


            }
        }
    }
}
