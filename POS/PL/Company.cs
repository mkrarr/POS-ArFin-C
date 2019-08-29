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
using System.Globalization;


namespace POS.PL
{
    public partial class Company : Form
    {
        public Company()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            BL.CLS_LOGIN cls = new BL.CLS_LOGIN();
            if (txtadd.Text == string.Empty || txtname.Text == string.Empty || txtph1.Text == string.Empty)
            {
                MessageBox.Show("Chick Company Info", "Company", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                cls.ADD_Company(txtname.Text, txtadd.Text, txtph1.Text, txtph2.Text, txtemail.Text, txtmes.Text, byteImage);
                MessageBox.Show(" Company Info Save", "Company", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Company_Load(object sender, EventArgs e)
        {
            DataTable dt;
            BL.CLS_LOGIN log = new BL.CLS_LOGIN();
            dt = log.comp();
            txtname.Text = Convert.ToString(dt.Rows[0][0]);
            txtadd.Text = Convert.ToString(dt.Rows[0][1]);
            txtph1.Text = Convert.ToString(dt.Rows[0][2]);
            txtph2.Text = Convert.ToString(dt.Rows[0][3]);
            txtemail.Text = Convert.ToString(dt.Rows[0][4]);
            txtmes.Text = Convert.ToString(dt.Rows[0][5]);
        }

        private void button2_Click(object sender, EventArgs e)
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
