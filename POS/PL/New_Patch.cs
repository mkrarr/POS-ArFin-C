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
    public partial class New_Patch : Form
    {
        public  int stt=0;
        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();
        public New_Patch()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Patch_Load(object sender, EventArgs e)
        {
            if(stt==0)
            {
                btnok.Text = "حفظ";
                label8.Text =  stt.ToString();
            }else if(stt==1)
            {
                btnok.Text = "تعديل";
                this.Text = "تعديل باتش";
                label8.Text = stt.ToString();

            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (stt == 0)
            {
               
                if(pro.add_patch(txtref.Text, txtqte.Text, Convert.ToDateTime(edate.Text), Convert.ToDateTime(mdate.Text), Convert.ToInt32("0"), Convert.ToDouble(txtspri.Text), Convert.ToDouble(txtppri.Text)).Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("\t تمت الاضافة \t");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("\t لم تمت الاضافة رقم الباتش موجود مسبقاً \t");
                    
                }
                
            }
            else if(stt==1)
            {
                pro.up_patch(txtref.Text, txtqte.Text, Convert.ToDateTime(edate.Text), Convert.ToDateTime(mdate.Text),  Convert.ToDouble(txtspri.Text), Convert.ToDouble(txtppri.Text));
                MessageBox.Show("\t تمت التعديل \t");
                this.Close();
            }
        }
    }
}
