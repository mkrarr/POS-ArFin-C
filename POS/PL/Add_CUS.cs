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

namespace POS.PL
{
    public partial class Add_CUS : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        public string fcase ="add";
        public int cid = 0;
        public Add_CUS()
        {
            InitializeComponent();
        }

        private void Add_CUS_Load(object sender, EventArgs e)
        {
            if (fcase == "add")
            {
                txtf_name.Text = null;
                txtL_name.Text = null;
                txtemail.Text = null;
                txtPh.Text = null;
                pbox.Image = POS.Properties.Resources.ID2;
                btnsave.Enabled = true;
                txtf_name.Focus();
            }else if (fcase=="updt")
            {
                DataTable cdt = cust.get_cus(cid);
                if(cdt.Rows.Count != 0)
                {
                    txtf_name.Text = cdt.Rows[0][0].ToString();
                    txtL_name.Text = cdt.Rows[0][1].ToString();
                    txtPh.Text = cdt.Rows[0][2].ToString();
                    txtemail.Text = cdt.Rows[0][3].ToString();
                    txtvat.Text = cdt.Rows[0][4].ToString();
                    txtcr.Text = cdt.Rows[0][5].ToString();
                    txtcity.Text = cdt.Rows[0][6].ToString();
                    txtadd.Text = cdt.Rows[0][7].ToString();

                    byte[] pic = (byte[])cdt.Rows[0][8]; 
                 //   dataGridView2.DataSource = cust.C_ORD(Convert.ToInt32(txtref.Text));
                    MemoryStream ms = new MemoryStream(pic);
                    pbox.Image = Image.FromStream(ms);

                    btnsave.Enabled = true;

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
            FRM_CUST_LIST lst = new PL.FRM_CUST_LIST();
            try
            {
                if (fcase == "add")
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    byte[] pic = ms.ToArray();
                    cust.ADD_CUSTOMER(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic, txtcity.Text, txtadd.Text, txtvat.Text, txtcr.Text);
                    MessageBox.Show("تم الاضافة", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }else
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    byte[] pic = ms.ToArray();
                    cust.EDIT_CUSTOMER(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic,cid, txtcity.Text, txtadd.Text, txtvat.Text, txtcr.Text);
                    MessageBox.Show("تم التعديل", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("يرجاء التاكد من البيانات", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File |*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
