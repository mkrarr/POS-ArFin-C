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
    public partial class Attin : Form
    {
        int ss = 0;
        BL.HR hr=new BL.HR();
        DataTable sz = new DataTable();
        void clrdg()
        {
            //dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
        }
        void add_com()
        {

         //   DataGridViewComboBoxColumn dgvCmb = new DataGridViewComboBoxColumn();

         //   dgvCmb.HeaderText = "الحاله";

         //   dgvCmb.Items.Add("حضور");
         //   dgvCmb.Items.Add("تاخير");
         //   dgvCmb.Items.Add("غياب");
         //   dgvCmb.Items.Add("إزن");


         //   dgvCmb.Name = "cmbName";
         ////   Finally add that newly created ComboBox into the DataGridView.
         //   dataGridView1.Columns.Add(dgvCmb);

        }
        public Attin()
        {
            InitializeComponent();
        }

        private void Attin_Load(object sender, EventArgs e)
        {
            clrdg();
            DataTable dt = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text),"uget","");
            if (dt.Rows.Count > 0)
            {
                ss = 2;
                dataGridView1.DataSource = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
                add_com();
                sz = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", "");
                sztxt.Text = sz.Rows[0][0].ToString();
            }
            else
            {
                ss = 1;
                this.dataGridView1.DataSource = hr.dayss(Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text));
                add_com();
            }
        }

        private void mm_ValueChanged(object sender, EventArgs e)
        {
            clrdg();
            DataTable dt2 = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "e_case", "");
            ss = Convert.ToInt32(dt2.Rows[0][0].ToString());
            DataTable dt = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
            if (ss!=0)
            {
                
                dataGridView1.DataSource = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
                add_com();
                sz = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", "");
                sztxt.Text = sz.Rows[0][0].ToString();
            }
            else if(ss==0)
            {
                this.dataGridView1.DataSource = hr.dayss(Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text));
                add_com();
            }
        }

        private void yy_ValueChanged(object sender, EventArgs e)
        {

            clrdg();
            DataTable dt2 = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "e_case", "");
            ss = Convert.ToInt32(dt2.Rows[0][0].ToString());
            DataTable dt = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
            if (ss!=0)
            {
                dataGridView1.DataSource = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
                add_com();
                sz = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", "");
                sztxt.Text = sz.Rows[0][0].ToString();

            }
            else if(ss==0)
            {
                this.dataGridView1.DataSource = hr.dayss(Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text));
                add_com();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btcon_Click(object sender, EventArgs e)
        {
            DataTable dt2 = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "e_case", "");
            ss = Convert.ToInt32(dt2.Rows[0][0].ToString());
            if (ss !=0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "updat", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "att_sz", dataGridView1.Rows[i].Cells[2].Value.ToString());
                  sz=  hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", dataGridView1.Rows[i].Cells[2].Value.ToString());
                  sztxt.Text = sz.Rows[0][0].ToString();
                }
            }
           else if (ss == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "add", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "att_sz", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    sz = hr.att(Convert.ToInt32(txtid.Text), Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value.ToString()), Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString()), Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", dataGridView1.Rows[i].Cells[2].Value.ToString());
                    sztxt.Text = sz.Rows[0][0].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clrdg();
            DGVFRM dg = new DGVFRM();
            dg.ty = "Emp";
            dg.ShowDialog();
            txtid.Text = dg.dgv.CurrentRow.Cells[0].Value.ToString();
            txtname.Text = dg.dgv.CurrentRow.Cells[1].Value.ToString();
            DataTable dt2 = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "e_case", "");
            ss= Convert.ToInt32(dt2.Rows[0][0].ToString());
            DataTable dt = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
            if (ss != 0)
            {
                
                dataGridView1.DataSource = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "uget","");
                add_com();
                sz = hr.att(Convert.ToInt32(txtid.Text), DateTime.Now, 0, Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text), "szget", "");
                sztxt.Text = sz.Rows[0][0].ToString();

            }
            else if(ss==0)
            {
                
                this.dataGridView1.DataSource = hr.dayss(Convert.ToInt32(mm.Text), Convert.ToInt32(yy.Text));
                add_com();

            }

        }
    }
}
