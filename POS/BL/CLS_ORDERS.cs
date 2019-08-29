using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POS.BL
{
    class CLS_ORDERS
    {
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
        public DataTable Sel_OR_RE(DateTime today)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@today", SqlDbType.DateTime);
            parm[0].Value = today;



            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Sel_OR_RE", parm);
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

        public DataTable get_l_o_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_o_id", null);
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

        public DataTable get_l_o_print()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_o_print", null);
            return dt;
        }


        public void ADD_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL,string UID,string IPA,string PC,string c_name)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[10];

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

            //ORDER_TOTAL

            DAL.ExecuteCommand("ADD_ORDER", parm);
            DAL.close();
        }

        public void ADD_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price,  float DISCOUNT, string AMOUNT, string TOTAL_AMOUNT)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

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

           

           


            DAL.ExecuteCommand("ADD_ORDER_DETAILS", parm);
            DAL.close();
        }


        public DataTable VQUN(string ID_PRODUCT, int QTE_ENTERED)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 30);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@QTE_ENTERED", SqlDbType.Int);
            parm[1].Value = QTE_ENTERED;


            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("VQUN", parm);
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

        public DataTable get_P_order(string key)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@key", SqlDbType.VarChar, 50);
            parm[0].Value = key;



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

        public void ADD_Refind(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL,int ID, string UID,string c_name)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[9];

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


            DAL.ExecuteCommand("ADD_Refond", parm);
            DAL.close();
        }

        public void ADD_refund_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price, float DISCOUNT, string AMOUNT, string TOTAL_AMOUNT,int ID)
        {
            var DAL = new DAL.DataAccessLayer();
            DAL.open();
            var parm = new SqlParameter[8];

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






            DAL.ExecuteCommand("ADD_refund_DETAILS", parm);
            DAL.close();
        }


    }
}
