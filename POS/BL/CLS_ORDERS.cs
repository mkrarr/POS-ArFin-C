using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Spire.Barcode;
using System.Drawing;
namespace POS.BL
{
    class CLS_ORDERS
    {

        public void py_qr(int id, byte[] img)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@img", SqlDbType.Image);
            parm[1].Value = img;


            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("py_qr", parm);
            DAL.close();
            //  return dt;
        }

        public void ADD_POS_TMP(string s_id,string i_id,string i_name,string price,string qut,string total,string note,int asd)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[8];

            parm[0] = new SqlParameter("@s_id", SqlDbType.NVarChar, 500);
            parm[0].Value = s_id;


            parm[1] = new SqlParameter("@i_id", SqlDbType.NVarChar, 500);
            parm[1].Value = i_id;


            parm[2] = new SqlParameter("@i_name", SqlDbType.NVarChar, 500);
            parm[2].Value = i_name;


            parm[3] = new SqlParameter("@price", SqlDbType.NVarChar, 500);
            parm[3].Value = price;


            parm[4] = new SqlParameter("@qut", SqlDbType.NVarChar, 500);
            parm[4].Value = qut;


            parm[5] = new SqlParameter("@total", SqlDbType.NVarChar, 500);
            parm[5].Value = total;


            parm[6] = new SqlParameter("@note", SqlDbType.NVarChar, 500);
            parm[6].Value = note;


            parm[7] = new SqlParameter("@asd", SqlDbType.Int);
            parm[7].Value = asd;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ADD_POS_TMP", parm);
            DAL.close();
            //  return dt;
        }


        public void py_br(int id, byte[] img)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@img", SqlDbType.Image);
            parm[1].Value = img;


            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("py_br", parm);
            DAL.close();
            //  return dt;
        }

        public DataTable refund_list(string key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@key", SqlDbType.VarChar, 50);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("refund_list", parm);
            DAL.close();
            return dt;
        }

        public DataTable not_close(int year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.VarChar, 50);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("not_close", parm);
            DAL.close();
            return dt;
        }

        public DataTable Get_POS_DT(Int32 o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@o_id", SqlDbType.BigInt);
            parm[0].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Get_POS_DT", parm);
            DAL.close();
            return dt;
        }

        
            public DataTable Get_POS_DTp(int o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Get_POS_DTp", parm);
            DAL.close();
            return dt;
        }

        //  up_POS_TMP

        public DataTable up_POS_TMP(string s_id,int o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@s_id", SqlDbType.NVarChar,50);
            parm[0].Value = s_id;

            parm[1] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[1].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("up_POS_TMP", parm);
            DAL.close();
            return dt;
        }
        public DataTable POS_ProT(int o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("POS_ProT", parm);
            DAL.close();
            return dt;
        }

        public DataTable loft_POS(string s_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@s_id", SqlDbType.NVarChar,500);
            parm[0].Value = s_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("loft_POS", parm);
            DAL.close();
            return dt;
        }


        public DataTable p_ord_conf(int oid,int act)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@oid", SqlDbType.Int);
            parm[0].Value = oid;

            parm[1] = new SqlParameter("@act", SqlDbType.Int);
            parm[1].Value = act;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("p_ord_conf", parm);
            DAL.close();
            return dt;
        }

  public Image qrCode( string cont,string name)
   {
         BarcodeSettings.ApplyKey("your key");//you need a key from e-iceblue, otherwise the watermark 'E-iceblue' will be shown in barcode
            BarcodeSettings settings = new BarcodeSettings();
            settings.Type = BarCodeType.QRCode;
            settings.Unit = GraphicsUnit.Pixel;
            settings.ShowText = false;
            settings.ResolutionType = ResolutionType.UseDpi;
            //input data
            string data = "12345";
            settings.Data = data;
            if (cont != null && cont.Length > 0)
            {
                data = cont;
                settings.Data = data;
            }

            settings.X = 7;
            settings.QRCodeECL = QRCodeECL.Q;
            BarCodeGenerator generator = new BarCodeGenerator(settings);
            Image QRbarcode = generator.GenerateImage();
            //display QR code image in picture box
            Image img = QRbarcode;
            img.Save(""+Properties.Settings.Default.qr_path+""+name
                +".png", System.Drawing.Imaging.ImageFormat.Png);
            return img;
    }  
        public DataTable pinvo_dt(int i_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@i_id", SqlDbType.Int);
            parm[0].Value = i_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("pinvo_dt", parm);
            DAL.close();
            return dt;
        }

        public DataTable set_reject(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("set_reject", parm);
            DAL.close();
            return dt;
        }

        public DataTable set_pay(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("set_pay", parm);
            DAL.close();
            return dt;
        }

        public void set_p_pay(int o_id,double pay)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@pay", SqlDbType.Float);
            parm[1].Value = pay;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("set_p_pay", parm);
            DAL.close();
           
        }

        public void done_piv(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

           
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("done_piv", parm);
            DAL.close();

        }

        public void set_o_pay(int o_id, double pay)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@pay", SqlDbType.Float);
            parm[1].Value = pay;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("set_o_pay", parm);
            DAL.close();
          
        }

        public DataTable chaqu_rpt1(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt1", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt11(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt11", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt22(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt22", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt33(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt33", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt44(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt44", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt1_3(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt1_3", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt2_4(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt2_4", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt2(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@DATE", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt2", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt3(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@DATE", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt3", parm);
            DAL.close();
            return dt;
        }

        public DataTable chaqu_rpt4(DateTime key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@DATE", SqlDbType.DateTime);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("chaqu_rpt4", parm);
            DAL.close();
            return dt;
        }

        public DataTable v_main(DateTime date)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[0].Value = date;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("v_main", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_f_cash(DateTime date)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.SmallDateTime);
            parm[0].Value = date;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_f_cash", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_f_cash2(DateTime date)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@date", SqlDbType.SmallDateTime);
            parm[0].Value = date;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_f_cash", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_r_pro(int o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_r_pro", parm);
            DAL.close();
            return dt;
        }


        public DataTable get_P_r_pro(int o_id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_P_r_pro", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_main_acc2(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_main_acc2", parm);
            DAL.close();
            return dt;
        }

        public void upd_main_cr(int id,double crdt)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@crdt", SqlDbType.Float);
            parm[1].Value = crdt;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("upd_main_cr", parm);
            DAL.close();
          //  return dt;
        }

        public void save_QR(int id, byte[] QR)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@QR", SqlDbType.Image);
            parm[1].Value = QR;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Save_QR", parm);
            DAL.close();
            //  return dt;
        }

        public void save_Bar(int id, byte[] QR)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@QR", SqlDbType.Image);
            parm[1].Value = QR;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("save_Bar", parm);
            DAL.close();
            //  return dt;
        }


        public void delete_ins(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("delete_ins", parm);
            DAL.close();
            //  return dt;
        }


        public void delete_ins2(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;
            
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("delete_ins2", parm);
            DAL.close();
            //  return dt;
        }
        public DataTable Sel_OR_RE(DateTime today,DateTime date2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@today", SqlDbType.DateTime);
            parm[0].Value = today;

            parm[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            parm[1].Value = date2;



            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Sel_OR_RE", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_ins_limit(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_ins_limit", parm);
            DAL.close();
            return dt;
        }

        public DataTable ins_Detals_ls(int ins_id,DateTime date1,DateTime date2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@ins_id", SqlDbType.Int);
            parm[0].Value = ins_id;

            parm[1] = new SqlParameter("@date1", SqlDbType.Date);
            parm[1].Value = date1;

            parm[2] = new SqlParameter("@date2", SqlDbType.Date);
            parm[2].Value = date2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ins_Detals_ls", parm);
            DAL.close();
            return dt;
        }

        public DataTable Conf_P_pro(int o_id, string p_id, double amt, double t_amt, double c_qut, int sts, double total, double dbt, double pay, string uid, string pat)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[11];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@p_id", SqlDbType.NVarChar , 500);
            parm[1].Value = p_id;

            parm[2] = new SqlParameter("@amt", SqlDbType.Float);
            parm[2].Value = amt;

            parm[3] = new SqlParameter("@t_amt", SqlDbType.Float);
            parm[3].Value = t_amt;

            parm[4] = new SqlParameter("@c_qut", SqlDbType.Float);
            parm[4].Value = c_qut;

            parm[5] = new SqlParameter("@sts", SqlDbType.Int);
            parm[5].Value = sts;

            parm[6] = new SqlParameter("@dbt", SqlDbType.Float);
            parm[6].Value = dbt;

            parm[7] = new SqlParameter("@pay", SqlDbType.Float);
            parm[7].Value = pay;

            parm[8] = new SqlParameter("@total", SqlDbType.Float);
            parm[8].Value = total;

            parm[9] = new SqlParameter("@U_ID", SqlDbType.NVarChar, 500);
            parm[9].Value = uid;

            parm[10] = new SqlParameter("@pat", SqlDbType.NVarChar, 500);
            parm[10].Value = pat;

         

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Conf_P_pro", parm);
            DAL.close();
            return dt;
        }

        public DataTable RPT_Date(DateTime Date1, DateTime date2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@date1", SqlDbType.DateTime);
            parm[0].Value = Date1;

            parm[1] = new SqlParameter("@date2", SqlDbType.DateTime);
            parm[1].Value = date2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ord_date", parm);
            DAL.close();
            return dt;
        }

        public DataTable list_Cash_Nsr(string key, int sts)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@key", SqlDbType.NVarChar , 250);
            parm[0].Value = key;

            parm[1] = new SqlParameter("@sts", SqlDbType.Int);
            parm[1].Value = sts;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("list_Cash_Nsr", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_l_o_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_o_id", null);
            return dt;
        }

        public DataTable get_l_PT()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_PT", null);
            return dt;
        }


        public DataTable get_p_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_p_id", null);
            return dt;
        }

        //public DataTable ful_CASH_Y()
        //{
        //    DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
        //    SqlParameter[] parm = new SqlParameter[2];

        //    DAL.open();
        //    DataTable dt = new DataTable();
        //    dt = DAL.SelectData("ful_CASH_Y", null);
        //    return dt;
        //}

        public DataTable ful_CASH_Y(DateTime year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.NVarChar, 25);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ful_CASH_Y", parm);
            DAL.close();
            return dt;
        }
        public DataTable cash_mnth()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("cash_mnth", null);
            return dt;
        }
     

        public DataTable top_5(DateTime year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.NVarChar, 25);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("top_5", parm);
            DAL.close();
            return dt;
        }


        public DataTable get_l_INV_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_INV_id", null);
            return dt;
        }

        public DataTable s_type()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("s_type", null);
            return dt;
        }

        public DataTable get_l_c_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_c_id", null);
            return dt;
        }

        public DataTable ccl()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("ccl", null);
            return dt;
        }

        public DataTable FRTY()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("FRTY", null);
            return dt;
        }


        public DataTable get_l_t_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_t_id", null);
            return dt;
        }

        public DataTable get_ins()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_ins", null);
            return dt;
        }

        public DataTable get_ins2()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_ins2", null);
            return dt;
        }

        public DataTable get_main_ACC()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_main_ACC", null);
            return dt;
        }

        public DataTable get_pay()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_pay", null);
            return dt;
        }


        public DataTable get_L_R()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_L_R", null);
            return dt;
        }

        public DataTable INS_LIST()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("INS_LIST", null);
            return dt;
        }
      // ins_prc

        public DataTable maintr_list()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("maintr_list", null);
            return dt;
        }
      

        public DataTable ins_prc()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("ins_prc", null);
            return dt;
        }

        public DataTable get_rel()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_rel", null);
            return dt;
        }

        public DataTable get_L_R_P()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_L_R_P", null);
            return dt;
        }

        public DataTable get_l_o_print()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_o_print", null);
            return dt;
        }

        public DataTable print_Copy()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("print_Copy", null);
            return dt;
        }


        public void ADD_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL,string UID,string IPA,string PC,string c_name,double c_dept,double c_pay,int t_pay,int ins_id,string ins_card,string pat_name,int rel_id,double Cov_pr)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[18];

            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            parm[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            parm[1].Value = DATE_ORDER;

            parm[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            parm[2].Value = CUSTOMER_ID;
            
            parm[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar, 250);
            parm[3].Value = DESCRIPTION_ORDER;

            parm[4] = new SqlParameter("@SelasMAN", SqlDbType.VarChar, 50);
            parm[4].Value = SelasMAN;

            parm[5] = new SqlParameter("@ORDER_TOTAL", SqlDbType.VarChar, 50);
            parm[5].Value = ORDER_TOTAL;

            parm[6] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[6].Value = UID;

            parm[7] = new SqlParameter("@IPA", SqlDbType.VarChar, 250);
            parm[7].Value = IPA;

            parm[8] = new SqlParameter("@pc", SqlDbType.VarChar, 250);
            parm[8].Value = PC;

            parm[9] = new SqlParameter("@c_name", SqlDbType.VarChar, 500);
            parm[9].Value = c_name;

            parm[10] = new SqlParameter("@c_dept", SqlDbType.Float);
            parm[10].Value = c_dept;

            parm[11] = new SqlParameter("@c_pay", SqlDbType.Float);
            parm[11].Value = c_pay;

            parm[12] = new SqlParameter("@t_pay", SqlDbType.Float);
            parm[12].Value = t_pay;

            parm[13] = new SqlParameter("@ins_id", SqlDbType.Int);
            parm[13].Value = ins_id;

            parm[14] = new SqlParameter("@ins_card", SqlDbType.NVarChar,150);
            parm[14].Value = ins_card;

            parm[15] = new SqlParameter("@pat_name", SqlDbType.NVarChar , 500);
            parm[15].Value = pat_name;

            parm[16] = new SqlParameter("@rel_id", SqlDbType.Int);
            parm[16].Value = rel_id;

            parm[17] = new SqlParameter("@Cov_pr", SqlDbType.Float);
            parm[17].Value = Cov_pr;

          

            //ORDER_TOTAL

            DAL.ExecuteCommand("ADD_ORDER", parm);
            DAL.close();
        }

        public void ADD_POS_ORD(int c_id, string u_name,double total,string u_id,string ip,string pc,string c_name,int py_ty,int o_id,string note)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[10];

            parm[0] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[0].Value = c_id;

            parm[1] = new SqlParameter("@u_name", SqlDbType.NVarChar ,500);
            parm[1].Value = u_name;

            parm[2] = new SqlParameter("@total", SqlDbType.Money);
            parm[2].Value = total;

            parm[3] = new SqlParameter("@u_id", SqlDbType.NVarChar, 250);
            parm[3].Value = u_id;

            parm[4] = new SqlParameter("@ip", SqlDbType.NVarChar, 150);
            parm[4].Value = ip;

            parm[5] = new SqlParameter("@pc", SqlDbType.NVarChar, 150);
            parm[5].Value = pc;

            parm[6] = new SqlParameter("@c_name", SqlDbType.NVarChar, 750);
            parm[6].Value = c_name;

            parm[7] = new SqlParameter("@py_ty", SqlDbType.Int);
            parm[7].Value = py_ty;


            parm[8] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[8].Value = o_id;

            parm[9] = new SqlParameter("@note", SqlDbType.NVarChar, 1750);
            parm[9].Value = note;

            //ORDER_TOTAL

            DAL.ExecuteCommand("ADD_POS_ORD", parm);
            DAL.close();
        }

        public void ADD_POS_ORD_D(string pro_id,int o_id,double qut,double price,double total)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@pro_id", SqlDbType.NVarChar ,250);
            parm[0].Value = pro_id;

            parm[1] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[1].Value = o_id;

            parm[2] = new SqlParameter("@qut", SqlDbType.Float);
            parm[2].Value =qut;

            parm[3] = new SqlParameter("@price", SqlDbType.Money);
            parm[3].Value = price;

            parm[4] = new SqlParameter("@total", SqlDbType.Money);
            parm[4].Value = total;


            //ORDER_TOTAL

            DAL.ExecuteCommand("ADD_POS_ORD_D", parm);
            DAL.close();
        }

        public void Add_INVO(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL, string UID, string IPA, string PC, string c_name, double c_dept, double c_pay, int t_pay)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[13];

            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            parm[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            parm[1].Value = DATE_ORDER;

            parm[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            parm[2].Value = CUSTOMER_ID;

            parm[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar, 250);
            parm[3].Value = DESCRIPTION_ORDER;

            parm[4] = new SqlParameter("@SelasMAN", SqlDbType.VarChar, 50);
            parm[4].Value = SelasMAN;

            parm[5] = new SqlParameter("@ORDER_TOTAL", SqlDbType.VarChar, 50);
            parm[5].Value = ORDER_TOTAL;

            parm[6] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[6].Value = UID;

            parm[7] = new SqlParameter("@IPA", SqlDbType.VarChar, 250);
            parm[7].Value = IPA;

            parm[8] = new SqlParameter("@pc", SqlDbType.VarChar, 250);
            parm[8].Value = PC;

            parm[9] = new SqlParameter("@c_name", SqlDbType.VarChar, 500);
            parm[9].Value = c_name;

            parm[10] = new SqlParameter("@c_dept", SqlDbType.Float);
            parm[10].Value = c_dept;

            parm[11] = new SqlParameter("@c_pay", SqlDbType.Float);
            parm[11].Value = c_pay;

            parm[12] = new SqlParameter("@t_pay", SqlDbType.Float);
            parm[12].Value = t_pay;

            //ORDER_TOTAL

            DAL.ExecuteCommand("Add_INVO", parm);
            DAL.close();
        }


        public void Add_trans_main(string u_id,double cash,int a_from,int a_to,DateTime tdate,string resp )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@u_id", SqlDbType.NVarChar ,250);
            parm[0].Value = u_id;

            parm[1] = new SqlParameter("@cash", SqlDbType.Float);
            parm[1].Value = cash;

            parm[2] = new SqlParameter("@a_from", SqlDbType.Int);
            parm[2].Value = a_from;

            parm[3] = new SqlParameter("@a_to", SqlDbType.Int);
            parm[3].Value = a_to;

            parm[4] = new SqlParameter("@tdate", SqlDbType.DateTime);
            parm[4].Value = tdate;

            parm[5] = new SqlParameter("@resp", SqlDbType.VarChar, 500);
            parm[5].Value = resp;

          

            //ORDER_TOTAL

            DAL.ExecuteCommand("Add_trans_main", parm);
            DAL.close();
        }
        //---------------------------------

        public void Add_INS_Company(string name, double limitation, string  Class, string supervisor, string telphone, string email, double add_pri,string add)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[8];

            parm[0] = new SqlParameter("@name", SqlDbType.NVarChar, 500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@limitation", SqlDbType.Float);
            parm[1].Value = limitation;

            parm[2] = new SqlParameter("@Class", SqlDbType.NChar,15);
            parm[2].Value = Class;

            parm[3] = new SqlParameter("@supervisor", SqlDbType.NVarChar,1500);
            parm[3].Value = supervisor;

            parm[4] = new SqlParameter("@telphone", SqlDbType.NVarChar,15);
            parm[4].Value = telphone;

            parm[5] = new SqlParameter("@email", SqlDbType.VarChar, 500);
            parm[5].Value = email;

            parm[6] = new SqlParameter("@add_pri", SqlDbType.Float);
            parm[6].Value = add_pri;

            parm[7] = new SqlParameter("@add", SqlDbType.VarChar, 500);
            parm[7].Value = add;



            

            DAL.ExecuteCommand("Add_INS_Company", parm);
            DAL.close();
        }

        public void UP_INS_Company(string name, double limitation, string Class, string supervisor, string telphone, string email, double add_pri, string add,int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@name", SqlDbType.NVarChar, 500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@limitation", SqlDbType.Float);
            parm[1].Value = limitation;

            parm[2] = new SqlParameter("@Class", SqlDbType.NChar, 15);
            parm[2].Value = Class;

            parm[3] = new SqlParameter("@supervisor", SqlDbType.NVarChar, 1500);
            parm[3].Value = supervisor;

            parm[4] = new SqlParameter("@telphone", SqlDbType.NVarChar, 15);
            parm[4].Value = telphone;

            parm[5] = new SqlParameter("@email", SqlDbType.VarChar, 500);
            parm[5].Value = email;

            parm[6] = new SqlParameter("@add_pri", SqlDbType.Float);
            parm[6].Value = add_pri;

            parm[7] = new SqlParameter("@add", SqlDbType.VarChar, 500);
            parm[7].Value = add;

            parm[8] = new SqlParameter("@id", SqlDbType.VarChar, 500);
            parm[8].Value = id;


            DAL.ExecuteCommand("UP_INS_Company", parm);
            DAL.close();
        }

        //------------------------
        public void up_chaqu( int id,double crd)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@crd", SqlDbType.Float);
            parm[1].Value = crd;

            DAL.ExecuteCommand("up_chaqu", parm);
            DAL.close();
        }



        public void add_chaque(string name,DateTime date,double cradet,int c_id,int o_id,int pay_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@name", SqlDbType.VarChar ,500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@data", SqlDbType.DateTime);
            parm[1].Value = date;

            parm[2] = new SqlParameter("@cradet", SqlDbType.Float);
            parm[2].Value = cradet;

            parm[3] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[3].Value = c_id;

            parm[4] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[4].Value = o_id;

            parm[5] = new SqlParameter("@pay_id", SqlDbType.Int);
            parm[5].Value = pay_id;

            DAL.ExecuteCommand("add_chaque", parm);
            DAL.close();
        }

        public void add_chaque4(string name, DateTime date, double cradet, int c_id, int o_id, int pay_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@data", SqlDbType.DateTime);
            parm[1].Value = date;

            parm[2] = new SqlParameter("@cradet", SqlDbType.Float);
            parm[2].Value = cradet;

            parm[3] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[3].Value = c_id;

            parm[4] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[4].Value = o_id;

            parm[5] = new SqlParameter("@pay_id", SqlDbType.Int);
            parm[5].Value = pay_id;

            DAL.ExecuteCommand("add_chaque4", parm);
            DAL.close();
        }

        public void add_chaque3(string name, DateTime date, double cradet, int c_id, int o_id, int pay_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@data", SqlDbType.DateTime);
            parm[1].Value = date;

            parm[2] = new SqlParameter("@cradet", SqlDbType.Float);
            parm[2].Value = cradet;

            parm[3] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[3].Value = c_id;

            parm[4] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[4].Value = o_id;

            parm[5] = new SqlParameter("@pay_id", SqlDbType.Int);
            parm[5].Value = pay_id;

            DAL.ExecuteCommand("add_chaque3", parm);
            DAL.close();
        }


        public void add_chaque2(string name, DateTime date, double cradet, int c_id, int o_id,int pay_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[0].Value = name;

            parm[1] = new SqlParameter("@data", SqlDbType.DateTime);
            parm[1].Value = date;

            parm[2] = new SqlParameter("@cradet", SqlDbType.Float);
            parm[2].Value = cradet;

            parm[3] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[3].Value = c_id;

            parm[4] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[4].Value = o_id;

            parm[5] = new SqlParameter("@pay_id", SqlDbType.Int);
            parm[5].Value = pay_id;
            DAL.ExecuteCommand("add_chaque2", parm);
            DAL.close();
        }


        //--------------------------------


        public void add_cash_histoty (string u_id,double debt,double credit,int type,string note,string c_id,int o_id,DateTime date,int o_ty,int c_id2)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[10];

            parm[0] = new SqlParameter("@u_id", SqlDbType.NVarChar ,500);
            parm[0].Value = u_id;

            parm[1] = new SqlParameter("@debt", SqlDbType.Money);
            parm[1].Value = debt;

            parm[2] = new SqlParameter("@credit", SqlDbType.Money);
            parm[2].Value = credit;

            parm[3] = new SqlParameter("@type", SqlDbType.Int);
            parm[3].Value = type;

            parm[4] = new SqlParameter("@note", SqlDbType.NVarChar,500);
            parm[4].Value = note;

            parm[5] = new SqlParameter("@c_id", SqlDbType.NVarChar,500);
            parm[5].Value = c_id;

            parm[6] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[6].Value = o_id;

            parm[7] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[7].Value = date;

            parm[8] = new SqlParameter("@o_ty", SqlDbType.Int);
            parm[8].Value = o_ty;

            parm[9] = new SqlParameter("@c_id2", SqlDbType.Int);
            parm[9].Value = c_id2;


            DAL.ExecuteCommand("add_cash_histoty", parm);
            DAL.close();
        }



        //------------------------------


        public void set_cus(int o_id, int c_id,int o_cus ,double deb)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@c_id", SqlDbType.Int);
            parm[1].Value = c_id;

            parm[2] = new SqlParameter("@o_cus", SqlDbType.Int);
            parm[2].Value = o_cus;

            parm[3] = new SqlParameter("@debt", SqlDbType.Float);
            parm[3].Value = deb;


            DAL.ExecuteCommand("set_cus", parm);
            DAL.close();
        }


        //------------------

        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, double QTE, string Price,  double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Float);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@Price", SqlDbType.VarChar, 50);
            parm[3].Value = Price;

            parm[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            parm[6].Value = TOTAL_AMOUNT;

           

           


            DAL.ExecuteCommand("ADD_ORDER_DETAILS", parm);
            DAL.close();
        }

        public DataTable inv_ty()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("inv_ty", null);
            return dt;
        }

        public void ADD_ORDER_DETAILS_PT(string ID_PRODUCT, int ID_ORDER, double QTE, string Price, double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT, string patch,double p_price)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Float);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@Price", SqlDbType.VarChar, 50);
            parm[3].Value = Price;

            parm[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            parm[6].Value = TOTAL_AMOUNT;


            parm[7] = new SqlParameter("@patch", SqlDbType.VarChar, 250);
            parm[7].Value = patch;

            parm[8] = new SqlParameter("@p_price", SqlDbType.Float);
            parm[8].Value = p_price;



            DAL.ExecuteCommand("ADD_ORDER_DETAILS_PT", parm);
            DAL.close();
        }

        public void ADD_Invo_DETAILS(string ID_PRODUCT, int ID_ORDER, double QTE, string Price, double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Float);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@Price", SqlDbType.VarChar, 50);
            parm[3].Value = Price;

            parm[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            parm[6].Value = TOTAL_AMOUNT;






            DAL.ExecuteCommand("ADD_Invo_DETAILS", parm);
            DAL.close();
        }


        public DataTable VQUN(string ID_PRODUCT, double QTE_ENTERED)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@QTE_ENTERED", SqlDbType.Float);
            parm[1].Value = QTE_ENTERED;


            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("VQUN", parm);
            DAL.close();
            return dt;
        }

        public DataTable PAY_CH(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("PAY_CH", parm);
            DAL.close();
            return dt;
        }

        public DataTable V_PTQ(string ID_PRODUCT, int QTE_ENTERED,string PT)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@QTE_ENTERED", SqlDbType.Int);
            parm[1].Value = QTE_ENTERED;

            parm[2] = new SqlParameter("@PT", SqlDbType.NVarChar ,200);
            parm[2].Value = PT;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("V_PTQ", parm);
            DAL.close();
            return dt;
        }


        public DataTable get_order_details(int ID_ORDER)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;
                      
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_order_details", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_order_details_forprint()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_order_details_forprint", null);
            DAL.close();
            return dt;
        }


        public DataTable searchOrder(string Crit )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Crit", SqlDbType.VarChar,50);
            parm[0].Value = Crit;

          

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("searchOrder", parm);
            DAL.close();
            return dt;
        }

        public DataTable searchOrders(string Crit)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Crit", SqlDbType.VarChar, 50);
            parm[0].Value = Crit;



            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("searchOrders", parm);
            DAL.close();
            return dt;
        }

        public DataTable searchPOrder(string Crit)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@Crit", SqlDbType.VarChar, 50);
            parm[0].Value = Crit;



            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("searchPOrder", parm);
            DAL.close();
            return dt;
        }


        public DataTable get_P_order(string key,int st)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@key", SqlDbType.VarChar, 50);
            parm[0].Value = key;

            parm[1] = new SqlParameter("@st", SqlDbType.Int);
            parm[1].Value = st;


            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_P_order", parm);
            DAL.close();
            return dt;
        }

        public DataTable Get_ord_r(int ID_ORDER)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Get_ord_r", parm);
            DAL.close();
            return dt;
        }

        public DataTable GET_CH_REF(int o_id,int p_ty)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@p_ty", SqlDbType.Int);
            parm[1].Value = p_ty;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("GET_CH_REF", parm);
            DAL.close();
            return dt;
        }

        public DataTable Get_P_ord_r(int ID_ORDER)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Get_P_ord_r", parm);
            DAL.close();
            return dt;
        }

        public void ADD_Refind(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL,int ID, string UID,string c_name,double dapt,double c_pay)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[11];

            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            parm[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            parm[1].Value = DATE_ORDER;

            parm[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            parm[2].Value = CUSTOMER_ID;

            parm[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar, 250);
            parm[3].Value = DESCRIPTION_ORDER;

            parm[4] = new SqlParameter("@SelasMAN", SqlDbType.VarChar, 50);
            parm[4].Value = SelasMAN;

            parm[5] = new SqlParameter("@ORDER_TOTAL", SqlDbType.VarChar, 50);
            parm[5].Value = ORDER_TOTAL;

            parm[6] = new SqlParameter("@ID", SqlDbType.Int);
            parm[6].Value = ID;

            parm[7] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[7].Value = UID;

            parm[8] = new SqlParameter("@c_name", SqlDbType.VarChar, 250);
            parm[8].Value = c_name;

            parm[9] = new SqlParameter("@dapt", SqlDbType.Float);
            parm[9].Value = dapt;

            parm[10] = new SqlParameter("@c_pay", SqlDbType.Float);
            parm[10].Value = c_pay;


            DAL.ExecuteCommand("ADD_Refond", parm);
            DAL.close();
        }

        public void ADD_refund_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price, double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT,int ID,string pat)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@Price", SqlDbType.VarChar, 50);
            parm[3].Value = Price;

            parm[4] = new SqlParameter("@DISCOUNT", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@AMOUNT", SqlDbType.VarChar, 50);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@TOTAL_AMOUNT", SqlDbType.VarChar, 50);
            parm[6].Value = TOTAL_AMOUNT;

            parm[7] = new SqlParameter("@ID", SqlDbType.Int);
            parm[7].Value = ID;

            parm[8] = new SqlParameter("@pat", SqlDbType.NVarChar, 200);
            parm[8].Value = pat;




            DAL.ExecuteCommand("ADD_refund_DETAILS", parm);
            DAL.close();
        }



        public void ADD_P_Refind(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL, int ID, string UID, string c_name, double dapt,double c_pay)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[11];

            parm[0] = new SqlParameter("@ID_ORDER", SqlDbType.Int);
            parm[0].Value = ID_ORDER;

            parm[1] = new SqlParameter("@DATE_ORDER", SqlDbType.DateTime);
            parm[1].Value = DATE_ORDER;

            parm[2] = new SqlParameter("@CUSTOMER_ID", SqlDbType.Int);
            parm[2].Value = CUSTOMER_ID;

            parm[3] = new SqlParameter("@DESCRIPTION_ORDER", SqlDbType.VarChar, 250);
            parm[3].Value = DESCRIPTION_ORDER;

            parm[4] = new SqlParameter("@SelasMAN", SqlDbType.VarChar, 50);
            parm[4].Value = SelasMAN;

            parm[5] = new SqlParameter("@ORDER_TOTAL", SqlDbType.VarChar, 50);
            parm[5].Value = ORDER_TOTAL;

            parm[6] = new SqlParameter("@ID", SqlDbType.Int);
            parm[6].Value = ID;

            parm[7] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[7].Value = UID;

            parm[8] = new SqlParameter("@c_name", SqlDbType.VarChar, 250);
            parm[8].Value = c_name;

            parm[9] = new SqlParameter("@dapt", SqlDbType.Float);
            parm[9].Value = dapt;

            parm[10] = new SqlParameter("@c_pay", SqlDbType.Float);
            parm[10].Value = c_pay;


            DAL.ExecuteCommand("ADD_P_Refond", parm);
            DAL.close();
        }

        public void ADD_P_refund_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price, double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT, int ID,string bat)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@ID_P", SqlDbType.NVarChar, 500);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@O_ID", SqlDbType.Int);
            parm[1].Value = ID_ORDER;

            parm[2] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[2].Value = QTE;

            parm[3] = new SqlParameter("@Price", SqlDbType.Money, 500);
            parm[3].Value = Price;

            parm[4] = new SqlParameter("@Dic", SqlDbType.Float);
            parm[4].Value = DISCOUNT;

            parm[5] = new SqlParameter("@amt", SqlDbType.Money, 500);
            parm[5].Value = AMOUNT;

            parm[6] = new SqlParameter("@T_amt", SqlDbType.Money, 500);
            parm[6].Value = TOTAL_AMOUNT;

            parm[7] = new SqlParameter("@N_ID", SqlDbType.Int);
            parm[7].Value = ID;

            parm[8] = new SqlParameter("@bat", SqlDbType.NVarChar, 500);
            parm[8].Value = bat;

            
            DAL.ExecuteCommand("ADD_P_refund_DETAILS", parm);
            DAL.close();
        }

        //-------------------------------------------------
        public void set_Credit(int id, double NCRD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@NCRD", SqlDbType.Float);
            parm[1].Value = NCRD;

            DAL.ExecuteCommand("set_Credit", parm);
            DAL.close();
        }

        public void add_min_flow(int p_id, int acc_id,double crid,double debt,double total,int main_acc,DateTime date,string u_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[8];

            parm[0] = new SqlParameter("@p_id", SqlDbType.Int);
            parm[0].Value = p_id;

            parm[1] = new SqlParameter("@acc_id", SqlDbType.Int);
            parm[1].Value = acc_id;

            parm[2] = new SqlParameter("@crid", SqlDbType.Float);
            parm[2].Value = crid;

            parm[3] = new SqlParameter("@debt", SqlDbType.Float);
            parm[3].Value = debt;

            parm[4] = new SqlParameter("@total", SqlDbType.Float);
            parm[4].Value = total;

            parm[5] = new SqlParameter("@main_acc", SqlDbType.Int);
            parm[5].Value = main_acc;

            parm[6] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[6].Value = date;

            parm[7] = new SqlParameter("@u_id", SqlDbType.NVarChar ,500);
            parm[7].Value = u_id;



            DAL.ExecuteCommand("add_min_flow", parm);
            DAL.close();
        }

        public void add_min_flow2(int p_id, int acc_id, double crid, double debt, double total, int main_acc, DateTime date, string u_id,string EU_ID )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@p_id", SqlDbType.Int);
            parm[0].Value = p_id;

            parm[1] = new SqlParameter("@acc_id", SqlDbType.Int);
            parm[1].Value = acc_id;

            parm[2] = new SqlParameter("@crid", SqlDbType.Float);
            parm[2].Value = crid;

            parm[3] = new SqlParameter("@debt", SqlDbType.Float);
            parm[3].Value = debt;

            parm[4] = new SqlParameter("@total", SqlDbType.Float);
            parm[4].Value = total;

            parm[5] = new SqlParameter("@main_acc", SqlDbType.Int);
            parm[5].Value = main_acc;

            parm[6] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[6].Value = date;

            parm[7] = new SqlParameter("@u_id", SqlDbType.NVarChar, 500);
            parm[7].Value = u_id;

            parm[8] = new SqlParameter("@eU_ID", SqlDbType.NVarChar, 500);
            parm[8].Value = EU_ID;



            DAL.ExecuteCommand("add_min_flow", parm);
            DAL.close();
        }


        public DataTable get_min_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_min_id", null);
            return dt;
        }

    }
}
