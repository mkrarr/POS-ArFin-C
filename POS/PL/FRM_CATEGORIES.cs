using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace POS.PL
{
    public partial class FRM_CATEGORIES : Form
    {
      //  SqlConnection sqlcon;
        SqlConnection sqlcon = new SqlConnection(@"server=" + Properties.Settings.Default.Server + ";database=" + Properties.Settings.Default.Database + ";Integrated security=false;user id=" + Properties.Settings.Default.ID + ";password=" + Properties.Settings.Default.password + "");

       /*  if (Properties.Settings.Default.mode == "SQL")
            {
                sqlcon = new SqlConnection(@"server=" + Properties.Settings.Default.Server + ";database=" + Properties.Settings.Default.Database + ";Integrated security=false;user id="+ Properties.Settings.Default.ID +";password="+Properties.Settings.Default.password+"");

            }
            else 
            {
                sqlcon = new SqlConnection(@"server=" + Properties.Settings.Default.Server + ";database=" + Properties.Settings.Default.Database + "; Integrated Security=true");
            }*/


        SqlDataAdapter da;
        DataTable dt=new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;

    
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select ID_CAT as 'ID',DESCRIPTION_CAT as'Name' from CATEGORIES", sqlcon);
            da.Fill(dt);
            dataGridView1.DataSource=dt;

            txtID.DataBindings.Add("text", dt, "ID");
            txtDes.DataBindings.Add("text", dt, "name");
            bmb = this.BindingContext[dt];
            lab3.Text = (bmb.Position+1) + "  /  " + bmb.Count;


        }

        private void FRM_CATEGORIES_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Edit Done", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
           lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void txtDes_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnadd.Enabled = false;
            btnsave.Enabled = true;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            txtID.Text = id.ToString();
            txtDes.Focus();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb= new SqlCommandBuilder (da);
            da.Update(dt);
            MessageBox.Show("Add Done","Add",MessageBoxButtons.OK,MessageBoxIcon.Information);
            btnadd.Enabled=true;
            btnsave.Enabled=false;
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Delete Done", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lab3.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_cat rpt2 = new RPT.rpt_all_cat();
            rpt2.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt2.DataSourceConnections[0].IntegratedSecurity = false;
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt2.Refresh();
            frm.CR1.ReportSource = rpt2;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RPT.rpt_CAT_PRO rpt = new RPT.rpt_CAT_PRO();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.DataSourceConnections[0].SetConnection(Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.ID, Properties.Settings.Default.password);
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            rpt.Refresh();
            rpt.SetParameterValue("@id", Convert.ToInt32(txtID.Text));
            frm.CR1.ReportSource = rpt;
            frm.ShowDialog();
        }
    }
}
