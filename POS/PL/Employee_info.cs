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
    public partial class Employee_info : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        BL.HR hr = new BL.HR();
        public int sts = 0;
        public string clo = "";
        public string up = "";
        public Employee_info()
        {
            InitializeComponent();
        }

        private void Employee_info_Load(object sender, EventArgs e)
        {
            if(sts==0)
            {

                dgv_slr.DataSource = log.ne_slr(Convert.ToDouble(txtslr.Text));
                Job_t.DataSource = log.job_se("");
                Job_t.DisplayMember = "j_name";
                Job_t.ValueMember = "j_id";

                cdep.DataSource = log.dep_se("");
                cdep.DisplayMember = "dep_name";
                cdep.ValueMember = "dep_id";

                dgv_bd.DataSource = hr.bon();
                dgv_bd.Columns[0].Visible = false;
                    
            }else if(sts==1)
            {
                
                Job_t.DataSource = log.job_se("");
                Job_t.DisplayMember = "j_name";
                Job_t.ValueMember = "j_id";

                cdep.DataSource = log.dep_se("");
                cdep.DisplayMember = "dep_name";
                cdep.ValueMember = "dep_id";
                DataTable dts = hr.bonas(Convert.ToInt32(txtid.Text), "", "", 0, "get_U");
               

                DataTable emp = hr.empSP(Convert.ToInt32(txtid.Text), txtid.Text, "", "", DateTime.Now, "", 0, "", 0, "", "", "getD");
                DataTable ctr = hr.ContSP(Convert.ToInt32(txtid.Text), 0, 0, DateTime.Today, DateTime.Today, 0, 0, 0,0,"", "get");

                try
                {
                 //*******Emp_info load******
                 
                    txtname.Text = emp.Rows[0][1].ToString();
                    txt_tel.Text = emp.Rows[0][2].ToString();
                    address.Text = emp.Rows[0][3].ToString();
                    b_Date.Text = emp.Rows[0][4].ToString();
                    us_name.Text = emp.Rows[0][5].ToString();
                    u_id.Text = emp.Rows[0][11].ToString();
                    Job_t.Text = emp.Rows[0][6].ToString();
                    m_Sts.Text = emp.Rows[0][7].ToString();
                    P_no.Text = emp.Rows[0][8].ToString();
                    doc_ty.Text = emp.Rows[0][9].ToString();
                    id_no.Text = emp.Rows[0][10].ToString();

                    //dgv_bd.DataSource = hr.ContSP(Convert.ToInt32(txtid.Text), 0, 0, DateTime.Today, DateTime.Today, 0, 0, 0, 0, "", "get");


                //*******Contract_info load******
                    Job_t.SelectedValue = Convert.ToInt32(ctr.Rows[0][2].ToString());
                    cdep.SelectedValue = Convert.ToInt32(ctr.Rows[0][3].ToString());
                    
                    e_date.Value = Convert.ToDateTime(ctr.Rows[0][5]);
                    txtslr.Text = ctr.Rows[0][7].ToString();
                    txtlev.Text = ctr.Rows[0][8].ToString();
                    clong.SelectedIndex = Convert.ToInt32(ctr.Rows[0][11]);
                    
                    if (ctr.Rows[0][12].ToString()=="سنه")
                    {
                        yy.Checked = true;
                    }
                    else
                    {
                        mm.Checked = true;
                    }

                    s_date.Value = Convert.ToDateTime(ctr.Rows[0][4]);

                    dgv_bd.DataSource = log.e_blc();
                    dgv_slr.DataSource = log.ne_slr(Convert.ToDouble(txtslr.Text));
                    dgv_bd.Columns[0].Visible = false;

                    if (dts.Rows.Count > 0)
                    {
                        dgv_bd.DataSource = hr.bonas(Convert.ToInt32(txtid.Text), "", "", 0, "get_U");
                        up = "U";
                    }
                    else
                    {
                        dgv_bd.DataSource = hr.bon();
                        up = "A";
                    }
                    // dgv_bd.DataSource = hr.bon();
                    dgv_bd.Columns[0].Visible = false;

                }
                catch { return; }
            }

        }

        private void txtslr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgv_slr.DataSource = log.ne_slr(Convert.ToDouble(txtslr.Text));
            }catch
            {
                txtslr.Text = "0";
                dgv_slr.DataSource = log.ne_slr(Convert.ToDouble(txtslr.Text));
            }
        }

        private void txtslr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtlev_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txt_tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.nE_SLRTableAdapter.Fill(this.sMS_NEWDataSet3.NE_SLR, new System.Nullable<double>(((double)(System.Convert.ChangeType(sSToolStripTextBox.Text, typeof(double))))));
            //}
            //catch (System.Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message);
            //}

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btcon_Click(object sender, EventArgs e)
        {
           if(sts==0) 
            {
                DataTable dt = hr.get_l_Emp_id();
                txtid.Text = dt.Rows[0][0].ToString();
                hr.empSP(Convert.ToInt32(txtid.Text), txtname.Text, txt_tel.Text, address.Text, Convert.ToDateTime(b_Date.Value), u_id.Text, Convert.ToInt32(Job_t.SelectedValue), Convert.ToString(m_Sts.Text), Convert.ToInt32(P_no.Text), doc_ty.Text, id_no.Text, "Add");
                hr.ContSP(Convert.ToInt32(txtid.Text), Convert.ToInt32(Job_t.SelectedValue), Convert.ToInt32(cdep.SelectedValue), Convert.ToDateTime(s_date.Value), Convert.ToDateTime(e_date.Value), 0, Convert.ToDouble(txtslr.Text), Convert.ToInt32(txtlev.Text),clong.SelectedIndex,clo, "Add");
                for (int i = 0; i < dgv_bd.Rows.Count; i++)
                {
                    hr.bonas(Convert.ToInt32(txtid.Text), dgv_bd.Rows[i].Cells[0].Value.ToString(), dgv_bd.Rows[i].Cells[1].Value.ToString(), Convert.ToDouble(dgv_bd.Rows[i].Cells[2].Value.ToString()), "add");
                }
               MessageBox.Show("تم اضافة الموظف بنجاخ");
                hr.HR_LogSP(Convert.ToInt32(txtid.Text), 1, "موظف جديد", Program.UID,"Add");
                this.Close();
            }
           else if(sts==1)
           {
               hr.empSP(Convert.ToInt32(txtid.Text), txtname.Text, txt_tel.Text, address.Text, Convert.ToDateTime(b_Date.Value), u_id.Text, Convert.ToInt32(Job_t.SelectedValue), Convert.ToString(m_Sts.Text), Convert.ToInt32(P_no.Text), doc_ty.Text, id_no.Text, "Update");
               hr.ContSP(Convert.ToInt32(txtid.Text), Convert.ToInt32(Job_t.SelectedValue), Convert.ToInt32(cdep.SelectedValue), Convert.ToDateTime(s_date.Value), Convert.ToDateTime(e_date.Value), 0, Convert.ToDouble(txtslr.Text), Convert.ToInt32(txtlev.Text), clong.SelectedIndex, clo, "Update");
               for (int i = 0; i < dgv_bd.Rows.Count; i++)
               {
                   if (up == "U")
                   {
                       hr.bonas(Convert.ToInt32(txtid.Text), dgv_bd.Rows[i].Cells[0].Value.ToString(), dgv_bd.Rows[i].Cells[1].Value.ToString(), Convert.ToDouble(dgv_bd.Rows[i].Cells[2].Value.ToString()), "Update");
                   }
                   else if (up=="A")
                   {
                       hr.bonas(Convert.ToInt32(txtid.Text), dgv_bd.Rows[i].Cells[0].Value.ToString(), dgv_bd.Rows[i].Cells[1].Value.ToString(), Convert.ToDouble(dgv_bd.Rows[i].Cells[2].Value.ToString()), "add");
                   }
               }
               MessageBox.Show("تم تعديل الموظف بنجاخ");
               hr.HR_LogSP(Convert.ToInt32(txtid.Text), 4, " تخرير بيانات موظف ", Program.UID, "Add");

               this.Close();
           }
        }

        private void e_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void s_date_ValueChanged(object sender, EventArgs e)
        {
            if (mm.Checked == true)
            {
                e_date.Value = s_date.Value.AddMonths (Convert.ToInt32(clong.Text));
            }
            else
            {
                e_date.Value = s_date.Value.AddYears(Convert.ToInt32(clong.Text));    
            }
            

        }

        private void clong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mm.Checked == true)
            {
                e_date.Value = s_date.Value.AddMonths(Convert.ToInt32(clong.Text));
            }
            else
            {
                e_date.Value = s_date.Value.AddYears(Convert.ToInt32(clong.Text));
            }
        }

        private void mm_CheckedChanged(object sender, EventArgs e)
        {
            if (mm.Checked == true)
            {
                e_date.Value = s_date.Value.AddMonths(Convert.ToInt32(clong.Text));
                clo = "شهر";
            }
            else
            {
                e_date.Value = s_date.Value.AddYears(Convert.ToInt32(clong.Text));
                clo = "سنه";

            }
        }

        private void yy_CheckedChanged(object sender, EventArgs e)
        {
            if (mm.Checked == true)
            {
                e_date.Value = s_date.Value.AddMonths(Convert.ToInt32(clong.Text));
                clo = "شهر";
            }
            else
            {
                e_date.Value = s_date.Value.AddYears(Convert.ToInt32(clong.Text));
                clo = "سنه";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DGVFRM fr = new DGVFRM();
            fr.ty = "user";
            fr.ShowDialog();
            this.u_id.Text = fr.dgv.CurrentRow.Cells[0].Value.ToString();
            this.us_name.Text = fr.dgv.CurrentRow.Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            RPT.FRM_RPT_PRODUCT frw = new RPT.FRM_RPT_PRODUCT();
            this.Cursor = Cursors.AppStarting;
            int order_id = Convert.ToInt32(txtid.Text);
            RPT.EMP_Contract rpt = new RPT.EMP_Contract();
            rpt.Refresh();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.SetParameterValue("@id", Convert.ToInt32(txtid.Text));
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }
    }
}
