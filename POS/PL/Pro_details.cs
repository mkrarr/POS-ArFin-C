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
    public partial class Pro_details : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();
        New_Patch pat = new New_Patch();

        public Pro_details()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pro_details_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pro.Patch_list2(label1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pat.stt = 0;
           
            pat.txtqte.ReadOnly = false;
            pat.txtdes.Text = label2.Text;
            pat.txtref.Text = label1.Text;
            pat.txtqte.Text = "";
            pat.edate.Value = DateTime.Now;
            pat.mdate.Value = DateTime.Now;
            pat.txtppri.Text = "0";
            pat.txtspri.Text = "0";
            pat.ShowDialog();

            dataGridView1.DataSource = pro.Patch_list2(label1.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pat.stt = 1;
            pat.txtqte.ReadOnly = true;
            pat.txtdes.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            pat.txtref.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            pat.txtqte.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            pat.edate.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[3].Value.ToString());
            pat.mdate.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells[4].Value.ToString());
            pat.txtppri.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            pat.txtspri.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            pat.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            pro.stop_patch(label1.Text, dataGridView1.CurrentRow.Cells[1].Value.ToString());
            MessageBox.Show("تم تعديل حالة الباتش");
            if (checkBox1.Checked == true)
            {
                dataGridView1.DataSource = pro.Patch_list3(label1.Text);
            }
            else
            {
                dataGridView1.DataSource = pro.Patch_list2(label1.Text);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                dataGridView1.DataSource = pro.Patch_list3(label1.Text);
                button4.Visible = true;
            }else
            {
                dataGridView1.DataSource = pro.Patch_list2(label1.Text);
                button4.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pro.stop_patch2(label1.Text, dataGridView1.CurrentRow.Cells[1].Value.ToString());
            MessageBox.Show("تم تعديل حالة الباتش");
            if (checkBox1.Checked == true)
            {
                dataGridView1.DataSource = pro.Patch_list3(label1.Text);
                
            }
            else
            {
                dataGridView1.DataSource = pro.Patch_list2(label1.Text);
            }
        }
    }
}
