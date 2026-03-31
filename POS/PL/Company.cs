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

                cls.ADD_Company(txtname.Text, txtadd.Text, txtph1.Text, txtph2.Text, txtemail.Text, txtmes.Text, byteImage,txtflag.Text,txtPmsg.Text,zka.Text,tax.Text);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    cls.up_options(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString());
                }
                MessageBox.Show(" Company Info Save", "Company", MessageBoxButtons.OK, MessageBoxIcon.Question);

                this.Close();
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
            txtPmsg.Text = Convert.ToString(dt.Rows[0][8]);
            txtflag.Text = Convert.ToString(dt.Rows[0][9]);
            tax.Text = Convert.ToString(dt.Rows[0][11]);
            zka.Text = Convert.ToString(dt.Rows[0][10]);
            dataGridView1.DataSource = log.Options_prc();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].ReadOnly = true;

           

          //  dataGridView1.Columns[3].ReadOnly = true;
            //   dataGridView1.Columns[5].ReadOnly = false;

            try
            {
              

                byte[] Cpic = (byte[])dt.Rows[0][7];
                MemoryStream ms = new MemoryStream(Cpic);
                pbox.Image = Image.FromStream(ms);
            }
            catch { return; }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this.Size = this.MaximumSize;
            //button1.Location = new Point(571, 400);
            //btnsave.Location = new Point(464, 400);
            //dataGridView1.Visible = true;
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Size = this.MaximumSize;
            button1.Location = new Point(571, 400);
            btnsave.Location = new Point(464, 400);
            dataGridView1.Visible = true;
        }
    }
}
