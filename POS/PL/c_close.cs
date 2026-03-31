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
    public partial class c_close : Form
    {
    
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        string dat = DateTime.Now.ToShortDateString();
        public c_close()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
         //   dataGrid2.Rows.Clear();
            if ((ord.v_main(Convert.ToDateTime(dateEdit1.Value)).Rows[0][0].ToString()=="-1"  )) 
            {
                MessageBox.Show("\t\t  لا يمكن اغلاق اليوم الحالي \t\t");

                //this.Close();
                return;
            }

            else if (Convert.ToInt32((ord.v_main(Convert.ToDateTime(dateEdit1.Value)).Rows[0][0].ToString()))>=1)  

            {
                MessageBox.Show(" \t\t   تم التحويل مسبفاً     \t\t    ");
                //this.Close();
                return;
            }
            else if ((ord.v_main(Convert.ToDateTime(dateEdit1.Value)).Rows[0][0].ToString() == "0"))
            {
                if (ord.get_f_cash2(Convert.ToDateTime(dateEdit1.Value)).Rows.Count == 0)
                {
                    MessageBox.Show(" \t\t     لا توجد عمليات     \t\t    ");

                    return;
                }
                else
                {
                    if (Program.ccl == "0")
                    {
                        dataGrid2.DataSource = ord.get_f_cash2(Convert.ToDateTime(dateEdit1.Value));
                        dataGrid2.Columns[0].Visible = false;
                        dataGrid2.Columns[6].Visible = false;

                        dataGrid2.Columns[6].ReadOnly = false;
                        dataGrid2.Columns[5].ReadOnly = true;
                        dataGrid2.Columns[4].ReadOnly = true;
                        dataGrid2.Columns[3].ReadOnly = true;
                        dataGrid2.Columns[2].ReadOnly = true;
                        dataGrid2.Columns[1].ReadOnly = true;
                        dataGrid2.Columns[0].ReadOnly = true;
                        dataGrid2.Columns[5].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[3].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[4].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[7].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[7].ReadOnly = false;

                        for (int i = 0; i < dataGrid2.Rows.Count; i++)
                        {
                            dataGrid2.Rows[i].Cells[7].Value = dataGrid2.Rows[i].Cells[5].Value;
                            dataGrid2.DefaultCellStyle.BackColor = Color.Red;
                        }
                        //DataGridViewCellStyle { BackColor=Color [Window], ForeColor=Color [ControlText], SelectionBackColor=Color [Highlight], SelectionForeColor=Color [HighlightText], Font=[Font: Name=Cairo, Size=9, Units=3, GdiCharSet=0, GdiVerticalFont=False], NullValue=0.00, Format=N2, WrapMode=False, Alignment=MiddleLeft }
                    }
                    else if (Program.ccl == "1")
                    {
                        dataGrid2.DataSource = ord.get_f_cash2(Convert.ToDateTime(dateEdit1.Value));
                    
                        dataGrid2.Columns[0].Visible = false;
                        dataGrid2.Columns[1].Visible = false;
                        dataGrid2.Columns[8].Visible = false;

                        dataGrid2.Columns[9].ReadOnly = false;
                     // dataGrid2.Columns[8].ReadOnly = true;
                        dataGrid2.Columns[7].ReadOnly = true;
                        dataGrid2.Columns[6].ReadOnly = true;
                        dataGrid2.Columns[5].ReadOnly = true;
                        dataGrid2.Columns[4].ReadOnly = true;
                        dataGrid2.Columns[3].ReadOnly = true;
                        dataGrid2.Columns[2].ReadOnly = true;
                        dataGrid2.Columns[1].ReadOnly = true;
                        dataGrid2.Columns[0].ReadOnly = true;
                        dataGrid2.Columns[7].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[6].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[6].DefaultCellStyle.Format = "N2";
                        dataGrid2.Columns[9].DefaultCellStyle.Format = "N2";

                        for (int i = 0; i < dataGrid2.Rows.Count; i++)
                        {
                            dataGrid2.Rows[i].Cells[9].Value = dataGrid2.Rows[i].Cells[7].Value;
                            dataGrid2.Columns[9].DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void dataGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
              if (Program.ccl == "0")
                  dataGrid2.CurrentRow.Cells[7].Value = dataGrid2.CurrentRow.Cells[5].Value;
             else if (Program.ccl == "1")
                  dataGrid2.CurrentRow.Cells[9].Value = dataGrid2.CurrentRow.Cells[7].Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGrid2.Rows.Count > 0)
            {
                label2.Text = ord.get_min_id().Rows[0][0].ToString();
                if (Program.ccl == "0")
                {
                    for (int i = 0; i < dataGrid2.Rows.Count; i++)
                    {
                        ord.add_min_flow(Convert.ToInt32(label2.Text), Convert.ToInt32(dataGrid2.Rows[i].Cells[0].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[3].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[4].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[7].Value), Convert.ToInt32(dataGrid2.Rows[i].Cells[6].Value), Convert.ToDateTime(dateEdit1.Value), Program.UID);
                        ord.set_Credit(Convert.ToInt32(dataGrid2.Rows[i].Cells[5].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[6].Value));
                     
                       

                    }
                }
                else if (Program.ccl == "1")
                {
                    for (int i = 0; i < dataGrid2.Rows.Count; i++)
                    {
                        ord.add_min_flow2(Convert.ToInt32(label2.Text), Convert.ToInt32(dataGrid2.Rows[i].Cells[0].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[5].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[6].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[9].Value), Convert.ToInt32(dataGrid2.Rows[i].Cells[8].Value), Convert.ToDateTime(dateEdit1.Value), Program.UID, dataGrid2.Rows[i].Cells[1].Value.ToString());
                        ord.set_Credit(Convert.ToInt32(dataGrid2.Rows[i].Cells[8].Value), Convert.ToDouble(dataGrid2.Rows[i].Cells[9].Value));
                       
  }
                }
                this.Cursor = Cursors.WaitCursor;
                int order_id = Convert.ToInt32(label2.Text);
                RPT.tr_rpt rpt = new RPT.tr_rpt();
                RPT.ACC_cloas rpt2 = new RPT.ACC_cloas();
                rpt.Refresh();
                rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt.DataSourceConnections[0].IntegratedSecurity = false;

                rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
                rpt2.DataSourceConnections[0].IntegratedSecurity = false;
             
                RPT.FRM_Report frm = new RPT.FRM_Report();
                RPT.FRM_Report frm2 = new RPT.FRM_Report();
                rpt.SetParameterValue("@P_id", order_id);
                rpt2.SetParameterValue("@P_id", order_id);

                frm.TopMost = true;
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.Show();
                frm2.TopMost = true;

                frm2.crystalReportViewer1.ReportSource = rpt2;
                frm2.Show();

                //rpt.PrintOptions.PrinterName = Properties.Settings.Default.PrinterRPT;
                //  rpt.PrintToPrinter(1, false, 0, 0);
                this.Cursor = Cursors.Default;

                MessageBox.Show(" \t\t     تــم تـرحــيــل الــحــســابــات    \t\t", "تم");

                this.Close();
              
            }
            else {
                MessageBox.Show(" \t\t لا توجد بيانات  \t\t");
                dataGrid2.DataSource = "";
                dataGrid2.Columns.Clear();
                dataGrid2.Rows.Clear();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void c_close_Load(object sender, EventArgs e)
        {
            label2.Text = ord.get_min_id().Rows[0][0].ToString();
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //  dataGrid2.Rows.Clear();
        //    dataGrid2.AutoGenerateColumns = false;
            dataGrid2.Columns.Clear();
            dataGrid2.DataSource = null;
            for (int i = 0; i < dataGrid2.Rows.Count; i++)
            {
                dataGrid2.Rows.RemoveAt(i);
            }
        }
    }
}
