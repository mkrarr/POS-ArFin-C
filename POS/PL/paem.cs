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
    public partial class paem : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        void getss()
        {
            DataTable dt = new DataTable();
            dt = log.get_parm(Convert.ToInt32(comboBox1.SelectedValue));

            a1.SelectedIndex = Convert.ToInt32(dt.Rows[0][1].ToString());
            a2.SelectedIndex = Convert.ToInt32(dt.Rows[0][2].ToString());
            a3.SelectedIndex = Convert.ToInt32(dt.Rows[0][3].ToString());
            a4.SelectedIndex = Convert.ToInt32(dt.Rows[0][4].ToString());
            a5.SelectedIndex = Convert.ToInt32(dt.Rows[0][5].ToString());
            a6.SelectedIndex = Convert.ToInt32(dt.Rows[0][6].ToString());
            a7.SelectedIndex = Convert.ToInt32(dt.Rows[0][7].ToString());
            a8.SelectedIndex = Convert.ToInt32(dt.Rows[0][8].ToString());
            a9.SelectedIndex = Convert.ToInt32(dt.Rows[0][9].ToString());
            a10.SelectedIndex = Convert.ToInt32(dt.Rows[0][10].ToString());
            a11.SelectedIndex = Convert.ToInt32(dt.Rows[0][12].ToString());
            nat.SelectedIndex = Convert.ToInt32(dt.Rows[0][13].ToString());
            inv.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.inv);
            PAT.SelectedIndex = Convert.ToInt32(Properties.Settings.Default.PAT);
            ins.SelectedIndex = Convert.ToInt32(dt.Rows[0][14].ToString());
            p_con.SelectedIndex = Convert.ToInt32(dt.Rows[0][15].ToString());
            p_rel.SelectedIndex = Convert.ToInt32(dt.Rows[0][16].ToString());
            nat2.SelectedIndex = Convert.ToInt32(dt.Rows[0][17].ToString());
            hr.SelectedIndex = Convert.ToInt32(dt.Rows[0][18].ToString());



        }
        public paem()
        {
            InitializeComponent();
            comboBox1.DataSource = log.get_groups();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" \n   \t هل انت واثق من العملية \t", "تعديل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                log.up_parm(a1.SelectedIndex, a2.SelectedIndex, a3.SelectedIndex, a4.SelectedIndex, a5.SelectedIndex, a6.SelectedIndex, a7.SelectedIndex, a8.SelectedIndex, a9.SelectedIndex, a10.SelectedIndex, Convert.ToInt32(comboBox1.SelectedValue) ,a11.SelectedIndex,nat.SelectedIndex,ins.SelectedIndex,p_con.SelectedIndex,p_rel.SelectedIndex,nat2.SelectedIndex, hr.SelectedIndex);
                Properties.Settings.Default.inv = inv.SelectedIndex.ToString();
                Properties.Settings.Default.PAT = PAT.SelectedIndex.ToString();
                Properties.Settings.Default.Save();
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getss();
        }

        private void paem_Load(object sender, EventArgs e)
        {
            getss();
        }
    }
}
