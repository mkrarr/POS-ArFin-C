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
    public partial class not_close : Form
    {
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();
        string sd;
        public not_close()
        {
            InitializeComponent();
        }

        private void daterr_ValueChanged(object sender, EventArgs e)
        {
            date.DataSource = ord.not_close(Convert.ToInt32(daterr.Text));
        }

        private void date_DoubleClick(object sender, EventArgs e)
        {
            sd = date.CurrentRow.Cells[0].Value.ToString();
            dataGrid2.DataSource = ord.get_f_cash2(Convert.ToDateTime(sd));
            dataGrid2.Columns[0].Visible = false;
            dataGrid2.Columns[6].Visible = false;

            dataGrid2.Columns[6].ReadOnly = false;
            dataGrid2.Columns[5].ReadOnly = true;
            dataGrid2.Columns[4].ReadOnly = true;
            dataGrid2.Columns[3].ReadOnly = true;
            dataGrid2.Columns[2].ReadOnly = true;
            dataGrid2.Columns[1].ReadOnly = true;
            dataGrid2.Columns[0].ReadOnly = true;
            dataGrid2.Columns[5].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[3].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[4].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[7].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[7].ReadOnly = false;

            for (int i = 0; i < dataGrid2.Rows.Count; i++)
            {
                dataGrid2.Rows[i].Cells[7].Value = dataGrid2.Rows[i].Cells[5].Value;
                dataGrid2.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void not_close_Load(object sender, EventArgs e)
        {
            daterr.Value = DateTime.Now;

        }

        private void date_DoubleClick_1(object sender, EventArgs e)
        {

            sd = date.CurrentRow.Cells[0].Value.ToString();
            dataGrid2.DataSource = ord.get_f_cash2(Convert.ToDateTime(sd));

            dataGrid2.Columns[0].Visible = false;
            dataGrid2.Columns[1].Visible = false;
            dataGrid2.Columns[8].Visible = false;
            dataGrid2.Columns[9].Visible = false;

            dataGrid2.Columns[9].ReadOnly = false;
            // dataGrid2.Columns[8].ReadOnly = true;
            dataGrid2.Columns[7].ReadOnly = true;
            dataGrid2.Columns[6].ReadOnly = true;
            dataGrid2.Columns[5].ReadOnly = true;
            dataGrid2.Columns[4].ReadOnly = true;
            dataGrid2.Columns[3].ReadOnly = true;
            dataGrid2.Columns[2].ReadOnly = true;
            dataGrid2.Columns[1].ReadOnly = true;
            dataGrid2.Columns[0].ReadOnly = true;
            dataGrid2.Columns[7].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[6].DefaultCellStyle.Format = "N2";
            dataGrid2.Columns[6].DefaultCellStyle.Format = "N2";
            //dataGrid2.Columns[9].DefaultCellStyle.Format = "N2";

            for (int i = 0; i < dataGrid2.Rows.Count; i++)
            {
                dataGrid2.Rows[i].Cells[9].Value = dataGrid2.Rows[i].Cells[7].Value;
                dataGrid2.Columns[9].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c_close cc = new PL.c_close();
            cc.dateEdit1.Value = Convert.ToDateTime(sd);
            cc.button1_Click(sender, e);
            cc.ShowDialog();
            date.DataSource = ord.not_close(Convert.ToInt32(daterr.Text));

        }
    }
}
