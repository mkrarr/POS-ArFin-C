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
    public partial class test_Con : Form
    {
        public test_Con()
        {
            InitializeComponent();
        
        }

        private void test_Con_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=" + Properties.Settings.Default.Server + ";Initial Catalog=" + Properties.Settings.Default.Database + ";User ID=" + Properties.Settings.Default.ID + ";Password=" + Properties.Settings.Default.password + "";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                FRM_SQL frm = new FRM_SQL();
                frm.ShowDialog();
            }
        }
    }
}
