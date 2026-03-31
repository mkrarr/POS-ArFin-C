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

        public DataTable c_debt(int ID_CUS)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_CUS", SqlDbType.Int);
            parm[0].Value = ID_CUS;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("c_debt", parm);
            DAL.close();
            return dt;
        }

        public DataTable S_debt2(int ID_CUS)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID_CUS", SqlDbType.Int);
            parm[0].Value = ID_CUS;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("S_debt2", parm);
            DAL.close();
            return dt;
        }


        public DataTable d_dept(int o_id,double n_dept2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@n_dept2", SqlDbType.Money);
            parm[1].Value = n_dept2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("d_dept", parm);
            DAL.close();
            return dt;
        }

        public DataTable d_dept2(int o_id, double n_dept2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[0].Value = o_id;

            parm[1] = new SqlParameter("@n_dept2", SqlDbType.Money);
            parm[1].Value = n_dept2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("d_dept2", parm);
            DAL.close();
            return dt;
        }

        public DataTable set_cur(double val)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@val", SqlDbType.Float);
            parm[0].Value = val;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("set_cur", parm);
            DAL.close();
            return dt;
        }

        public DataTable add_his(DateTime date, double val)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@date", SqlDbType.Date);
            parm[0].Value = date;

            parm[1] = new SqlParameter("@val", SqlDbType.Float);
            parm[1].Value = val;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("add_his", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_cur()
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[0];


            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_cur", parm);
            DAL.close();
            return dt;
        }

        public DataTable op_name()
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[0];


            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("op_name", parm);
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

        public void ADD_CUSTOMER(string First_name, string Last_name, string  tel, string email, byte[] Picture,string city,string address,string vat,string cr)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[9];

            parm[0] = new SqlParameter("@FIRST_NAME", SqlDbType.NVarChar,500);
            parm[0].Value = First_name;

            parm[1] = new SqlParameter("@LAST_NAME", SqlDbType.NVarChar, 500);
            parm[1].Value = Last_name;

            parm[2] = new SqlParameter("@TEL", SqlDbType.NVarChar, 15);
            parm[2].Value = tel;

            parm[3] = new SqlParameter("@EMAIL", SqlDbType.NVarChar, 50);
            parm[3].Value = email;

            parm[4] = new SqlParameter("@IMAGE_CUSTOMER", SqlDbType.Image);
            parm[4].Value = Picture;

          
            parm[5] = new SqlParameter("@city", SqlDbType.NVarChar, 250);
            parm[5].Value = city;

            parm[6] = new SqlParameter("@address", SqlDbType.NVarChar, 500);
            parm[6].Value = address;

            parm[7] = new SqlParameter("@vat", SqlDbType.NVarChar, 50);
            parm[7].Value = vat;

            parm[8] = new SqlParameter("@cr", SqlDbType.NVarChar,50);
            parm[8].Value = cr;

            DAL.ExecuteCommand("ADD_CUSTOMER", parm);
            DAL.close();
        }




        public void EDIT_CUSTOMER(string First_name, string Last_name, string tel, string email, byte[] Picture,int ID, string city, string address, string vat, string cr)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[10];

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


            parm[9] = new SqlParameter("@city", SqlDbType.NVarChar, 250);
            parm[9].Value = city;

            parm[6] = new SqlParameter("@address", SqlDbType.NVarChar, 500);
            parm[6].Value = address;

            parm[7] = new SqlParameter("@vat", SqlDbType.NVarChar, 50);
            parm[7].Value = vat;

            parm[8] = new SqlParameter("@cr", SqlDbType.NVarChar, 50);
            parm[8].Value = cr;

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

        public void add_dept(int c_ID,double n_dept)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];


            parm[0] = new SqlParameter("@c_ID", SqlDbType.Int);
            parm[0].Value = c_ID;

            parm[1] = new SqlParameter("@n_dept", SqlDbType.Float);
            parm[1].Value = n_dept;

            DAL.ExecuteCommand("add_dept", parm);
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


     
        public DataTable get_cus(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.Int);
            parm[0].Value = ID;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_cus", parm);
            DAL.close();
            return dt;
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
