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
        public void add_dept(int c_ID, double n_dept)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];


            parm[0] = new SqlParameter("@c_ID", SqlDbType.Int);
            parm[0].Value = c_ID;

            parm[1] = new SqlParameter("@n_dept", SqlDbType.Int);
            parm[1].Value = n_dept;

            DAL.ExecuteCommand("add_dept", parm);
            DAL.close();
        }

        public void add_dept_s(int c_ID, double n_dept)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];


            parm[0] = new SqlParameter("@c_ID", SqlDbType.Int);
            parm[0].Value = c_ID;

            parm[1] = new SqlParameter("@n_dept", SqlDbType.Float);
            parm[1].Value = n_dept;

            DAL.ExecuteCommand("add_dept_s", parm);
            DAL.close();
        }


        public void ADD_P_ORDER(int ID_ORDER, DateTime DATE_ORDER, int CUSTOMER_ID, string DESCRIPTION_ORDER, string SelasMAN, string ORDER_TOTAL, string UID, string IPA, string PC, string c_name, double c_dept, double c_pay, int t_pay)
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

            DAL.ExecuteCommand("ADD_P_ORDER", parm);
            DAL.close();
        }

        public void ADD_P_ORDER_DETAILS(string ID_PRODUCT, int ID_ORDER, int QTE, string Price, double DISCOUNT, string AMOUNT, string TOTAL_AMOUNT,string Patch)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[8];

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

            parm[7] = new SqlParameter("@Patch", SqlDbType.VarChar, 250);
            parm[7].Value = Patch;




            DAL.ExecuteCommand("ADD_P_ORDER_DETAILS", parm);
            DAL.close();
        }

        public void add_nasryat(int id, string stats, double cash, string note,string u_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@stats", SqlDbType.NVarChar, 50);
            parm[1].Value = stats;

            parm[2] = new SqlParameter("@cash", SqlDbType.Float);
            parm[2].Value = cash;

            parm[3] = new SqlParameter("@note", SqlDbType.NVarChar, 500);
            parm[3].Value = note;

            parm[4] = new SqlParameter("@u_id", SqlDbType.NVarChar, 500);
            parm[4].Value = u_id;



            DAL.ExecuteCommand("add_nasryat", parm);
            DAL.close();
        }

        public DataTable get_l_N_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_N_id", null);
            return dt;
        }

    }
}
