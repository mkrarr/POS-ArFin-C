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
    public partial class FRM_ADD_PRODECT : Form
    {
        


        public string state = "add";
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public FRM_ADD_PRODECT()
        {
            InitializeComponent();
            cmdcategories.DataSource = prd.GET_ALL_CATEGORIES();
            cmdcategories.DisplayMember = "DESCRIPTION_CAT";
            cmdcategories.ValueMember = "ID_CAT";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter="Image File |*.jpg;*.png";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                pbox.Image=Image.FromFile(ofd.FileName);
            }
        }

        private void FRM_ADD_PRODECT_Load(object sender, EventArgs e)
        {

        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                prd.ADD_PRODUCT(Convert.ToInt32(cmdcategories.SelectedValue), txtdes.Text, txtref.Text, Convert.ToInt32(txtqte.Text), txtprice.Text,txtbprice.Text, byteImage);
                MessageBox.Show("Add Saccesful...", "Add Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();
                prd.UPDATE_PRODUCT(Convert.ToInt32(cmdcategories.SelectedValue), txtdes.Text, txtref.Text, Convert.ToInt32(txtqte.Text), txtprice.Text,txtbprice.Text, byteImage);
                MessageBox.Show("Update Saccesful...", "Update Proccess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
                FRM_PRODUCTS.getMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void txtref_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtref_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable DT = new DataTable();
                DT = prd.VerifyProductID(txtref.Text);
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("ID User ", "Add Proccess", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtref.Focus();
                    txtref.SelectionStart = 0;
                    txtref.SelectionLength = txtref.TextLength;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtqte_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
