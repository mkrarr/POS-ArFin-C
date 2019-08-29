using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace POS.BL
{
    class Suppliers
    {
        public void ADD_Sup(string First_name, string Last_name, string tel, string email, byte[] Picture)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50);
            parm[0].Value = First_name;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50);
            parm[1].Value = Last_name;

            parm[2] = new SqlParameter("@TEL", SqlDbType.NChar, 15);
            parm[2].Value = tel;

            parm[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 50);
            parm[3].Value = email;

            parm[4] = new SqlParameter("@IMAGE_CUSTOMER", SqlDbType.Image);
            parm[4].Value = Picture;

            DAL.ExecuteCommand("ADD_Sup", parm);
            DAL.close();
        }

        public DataTable get_l_P_o_print()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_P_o_print", null);
            return dt;
        }

        public void EDIT_Sup(string First_name, string Last_name, string tel, string email, byte[] Picture, int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50);
            parm[0].Value = First_name;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50);
            parm[1].Value = Last_name;

            parm[2] = new SqlParameter("@TEL", SqlDbType.NChar, 15);
            parm[2].Value = tel;

            parm[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 50);
            parm[3].Value = email;

            parm[4] = new SqlParameter("@IMAGE_Sup", SqlDbType.Image);
            parm[4].Value = Picture;


            parm[5] = new SqlParameter("@ID", SqlDbType.Int);
            parm[5].Value = ID;

            DAL.ExecuteCommand("EDIT_Sup", parm);
            DAL.close();
        }


        public DataTable GET_ALL_sup()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_sup", null);
            return dt;
        }

        public void Delete_Suppliers(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];


            parm[0] = new SqlParameter("@ID", SqlDbType.Int);
            parm[0].Value = ID;

            DAL.ExecuteCommand("Delete_Suppliers", parm);
            DAL.close();
        }

        
        public DataTable GET_ALL_Supp()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_Supp", null);
            return dt;
        }

        public DataTable Get_L_P_O()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Get_L_P_O", null);
            return dt;
        }

        public void ADD_P_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN,string UID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

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

            parm[5] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[5].Value = UID;



            DAL.ExecuteCommand("ADD_P_ORDER", parm);
            DAL.close();
        }

        public void ADD_P_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price, float DISCOUNT, string AMOUNT, string TOTAL_AMOUNT)
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






            DAL.ExecuteCommand("ADD_P_ORDER_DETAILS", parm);
            DAL.close();
        }
    }
}
