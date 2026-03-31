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
    public partial class Stoors : Form
    {
        BL.CLS_PRODUCTS pro = new BL.CLS_PRODUCTS();

        public Stoors()
        {
            InitializeComponent();
            ty.DataSource = pro.stoors_SP(0, "0", "0", "0", "0", 0, 0, "ty");
            ty.ValueMember = "Val1";
            ty.DisplayMember = "Val2";

            sup.DataSource = pro.stoors_SP(0, "0", "0", "0", "0", 0, 0, "us");
            sup.ValueMember = "id";
            sup.DisplayMember = "FullName";
        }

        private void Stoors_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pro.stoors_SP(0, "0", "0", "0", "0", 0, 0, "Get");
            dataGridView1.Columns[7].Visible = false; dataGridView1.Columns[8].Visible = false; dataGridView1.Columns[9].Visible = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            sup.SelectedItem = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            add.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ty.SelectedItem = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            sts.SelectedIndex = Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value.ToString());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void cls()
        {
            id.Clear();
            name.Clear();
            add.Clear();
            tel.Clear();
            sts.SelectedIndex = -1;
            ty.SelectedIndex = 0;
            sup.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (id.TextLength == 0)
            {
               // try
                {
                    pro.stoors_SP(Convert.ToInt32(id.Text), name.Text, add.Text, tel.Text, sup.SelectedValue.ToString(), Convert.ToInt32(ty.SelectedValue), Convert.ToInt32(sts.SelectedIndex), "add");
                    dataGridView1.DataSource = pro.stoors_SP(0, "0", "0", "0", "0", 0, 0, "Get");
                    MessageBox.Show("تم الحفظ بنجاح");
                    cls();
                }
                //catch{

                //    MessageBox.Show("الرجاء التاكد من البيانات");
                //    return;
                //}
            
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pro.stoors_SP(Convert.ToInt32(id.Text), name.Text, add.Text, tel.Text, sup.SelectedValue.ToString(), Convert.ToInt32(ty.SelectedValue.ToString()), Convert.ToInt32(sts.SelectedIndex.ToString()), "UPd");
                dataGridView1.DataSource = pro.stoors_SP(0, "0", "0", "0", "0", 0, 0, "Get");
                cls();
            }
            catch
            {
                MessageBox.Show("الرجاء التاكد من البيانات");
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
          
        }
    }
}
