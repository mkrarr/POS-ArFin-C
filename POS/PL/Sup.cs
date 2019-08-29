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
   
    public partial class Sup : Form
    {
        int ID;
        BL.Suppliers sup = new BL.Suppliers();
       
       
       
        public Sup()
        {
            InitializeComponent();
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtf_name.Text = null;
            txtL_name.Text = null;
            txtemail.Text = null;
            txtPh.Text = null;
            pbox.Image = POS.Properties.Resources.ID2;
            btnsave.Enabled = true;
            btnadd.Enabled = false;
            txtf_name.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] pic = ms.ToArray();
                sup.ADD_Sup(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic);
                MessageBox.Show("Add Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = sup.GET_ALL_sup();
                btnsave.Enabled = false;
                btnadd.Enabled = true;


            }
            catch
            {
                MessageBox.Show("Any Erorr in add", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            try
            {
               // int ID_S = Convert.ToInt32(txtref.Text);
                int Cust_id = Convert.ToInt32(txtref.Text);
                RPT.P_Supp rpt = new RPT.P_Supp();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@ID_Supp", Cust_id);
                frm.CR1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;

                /*RPT.P_Supp rpt2 = new RPT.P_Supp();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt2.SetParameterValue("@ID_Sup",ID_S);

                rpt2.Refresh();
                frm.CR1.ReportSource = rpt2;
                frm.ShowDialog();*/
            }
            catch
            {
                MessageBox.Show("Select Suppliare");
                this.Cursor = Cursors.Default;

                return;
            }
        }

        private void Sup_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = sup.GET_ALL_sup();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("Suppliers Not Select", "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] pic = ms.ToArray();
               sup.EDIT_Sup(txtf_name.Text, txtL_name.Text, txtPh.Text, txtemail.Text, pic, ID);
                MessageBox.Show("Update Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dataGridView1.DataSource = sup.GET_ALL_sup();

            }
            catch
            {
                MessageBox.Show("Any Erorr in Update", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.txtref.Text = ID.ToString();
                this.txtf_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtL_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtPh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.txtemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte[] pic = (byte[])dataGridView1.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(pic);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image File |*.jpg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Customer Not Select", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Delete Customer..", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sup.Delete_Suppliers(ID);
                this.dataGridView1.DataSource = sup.GET_ALL_sup();


                txtref.Text = null;
                txtf_name.Text = null;
                txtL_name.Text = null;
                txtemail.Text = null;
                txtPh.Text = null;
                pbox.Image = POS.Properties.Resources.ID2;
                btnsave.Enabled = false;
                btnadd.Enabled = true;
                txtf_name.Focus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
