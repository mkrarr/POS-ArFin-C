using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS.BL
{
    class CLS_CUSTOMERS
    {
        public DataTable C_ORD(int ID_CUS)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_CUS", SqlDbType.Int);
            parm[0].Value = ID_CUS;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("C_ORD", parm);
            DAL.close();
            return dt;
        }

        public DataTable v_cus(int id)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("v_cus", parm);
            DAL.close();
            return dt;
        }

        public void ADD_CUSTOMER(string First_name, string Last_name, string  tel, string email, byte[] Picture)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.VarChar,50);
            parm[0].Value = First_name;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50);
            parm[1].Value = Last_name;

            parm[2] = new SqlParameter("@TEL", SqlDbType.NChar, 15);
            parm[2].Value = tel;

            parm[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar,50);
            parm[3].Value = email;

            parm[4] = new SqlParameter("@IMAGE_CUSTOMER", SqlDbType.Image);
            parm[4].Value = Picture;

            DAL.ExecuteCommand("ADD_CUSTOMER", parm);
            DAL.close();
        }




        public void EDIT_CUSTOMER(string First_name, string Last_name, string tel, string email, byte[] Picture,int ID)
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

            parm[4] = new SqlParameter("@IMAGE_CUSTOMER", SqlDbType.Image);
            parm[4].Value = Picture;
            
            
            parm[5] = new SqlParameter("@ID", SqlDbType.Int);
            parm[5].Value = ID;

            DAL.ExecuteCommand("EDIT_CUSTOMER", parm);
            DAL.close();
        }


        public void Delete_cust(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

          
            parm[0] = new SqlParameter("@ID", SqlDbType.Int);
            parm[0].Value = ID;

            DAL.ExecuteCommand("Delete_cust", parm);
            DAL.close();
        }

        public void Delete_cust2(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];


            parm[0] = new SqlParameter("@ID", SqlDbType.Int);
            parm[0].Value = ID;

            DAL.ExecuteCommand("Delete_cust2", parm);
            DAL.close();
        }



        public DataTable GET_ALL_CUST()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CUST", null);
            return dt;
        }

        public DataTable GET_ALL_CUST2()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CUST2", null);
            return dt;
        }

        public DataTable Search_cust(string criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm =new SqlParameter [1];
            parm[0] = new SqlParameter("@criterion", SqlDbType.VarChar, 50);
            parm[0].Value = criterion;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Search_cust", parm);
            return dt;
        }
        public DataTable Cus_ORDER(int ID_CUS)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_CUS", SqlDbType.Int);
            parm[0].Value = ID_CUS;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Cus_ORDER", parm);
            DAL.close();
            return dt;
        }
    }
}
