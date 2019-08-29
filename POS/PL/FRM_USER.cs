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
    public partial class FRM_USER : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        void clear()
        {
            txtref.Clear();
            txtf_name.Clear();
            txtPh.Clear();
            txtL_name.Clear();
            cptype.Visible = false;
            dataGridView1.DataSource = log.getalluser();


        }
        public FRM_USER()
        {
            InitializeComponent();
            dataGridView1.DataSource = log.getalluser();
        }

        private void FRM_USER_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.txtref.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.txtf_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtL_name.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtPh.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.cptype.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cptype.Visible = true;
                txtref.ReadOnly = true;
                txtf_name.ReadOnly = true;


               
            }
            catch
            {
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtref.Text != "")
            {
                if (MessageBox.Show("Delete User Account..", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    log.Delete_user(txtref.Text);
                    dataGridView1.DataSource = log.getalluser();
                    clear();

                }
            }
            else
            {
               MessageBox.Show("Select User Account..", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            PL.FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            log.EDIT_USER(txtref.Text, txtf_name.Text, txtL_name.Text, cptype.Text);
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtref_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtL_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtf_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
