using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS.BL
{
    class HR
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


        public DataTable d_dept(int o_id, double n_dept2)
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

        public DataTable dayss(int mm, int yy)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@mm", SqlDbType.Int);
            parm[0].Value = mm;

            parm[1] = new SqlParameter("@yy", SqlDbType.Int);
            parm[1].Value = yy;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("dayss", parm);
            DAL.close();
            return dt;
        }

        public DataTable att_rpt(int eid,int mm, int yy,DateTime date,string act)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@eid", SqlDbType.Int);
            parm[0].Value = eid;

            parm[1] = new SqlParameter("@yy", SqlDbType.Int);
            parm[1].Value = yy;
           
            parm[2] = new SqlParameter("@mm", SqlDbType.Int);
            parm[2].Value = mm;

            parm[3] = new SqlParameter("@date", SqlDbType.Int);
            parm[3].Value = date;

            parm[4] = new SqlParameter("@act", SqlDbType.Int);
            parm[4].Value = act;
                       
            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("att_rpt", parm);
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

        public void ADD_CUSTOMER(string First_name, string Last_name, string tel, string email, byte[] Picture)
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

            DAL.ExecuteCommand("ADD_CUSTOMER", parm);
            DAL.close();
        }




        public DataTable HR_LogSP(int e_id, int LTY, string LSTS, string UID, string act)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
          //  DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@E_ID", SqlDbType.Int);
            parm[0].Value = e_id;

            parm[1] = new SqlParameter("@LTY", SqlDbType.Int);
            parm[1].Value = LTY;

            parm[2] = new SqlParameter("@LSTS", SqlDbType.NVarChar, 50);
            parm[2].Value = LSTS;

            parm[3] = new SqlParameter("@UID", SqlDbType.VarChar, 500);
            parm[3].Value = UID;

            parm[4] = new SqlParameter("@act", SqlDbType.NVarChar, 50);
            parm[4].Value = act;


            

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("HR_LogSP", parm);
            return dt;
        }

        public DataTable att(int eid,DateTime date,int stats, int mm, int yy,string act,string comm)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[7];
            parm[0] = new SqlParameter("@date", SqlDbType.Date);
            parm[0].Value = date;

            parm[1] = new SqlParameter("@eid", SqlDbType.Int);
            parm[1].Value = eid;

            parm[2] = new SqlParameter("@stats", SqlDbType.Int);
            parm[2].Value = stats;

            parm[3] = new SqlParameter("@yy", SqlDbType.Int);
            parm[3].Value = yy;

            parm[4] = new SqlParameter("@mm", SqlDbType.Int);
            parm[4].Value = mm;

            parm[5] = new SqlParameter("@act", SqlDbType.NVarChar,10);
            parm[5].Value = act;

            parm[6] = new SqlParameter("@comm", SqlDbType.NVarChar, 10);
            parm[6].Value = comm;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("att", parm);
            DAL.close();
            return dt;
        }

        public DataTable bonas(int e_id, string BL_TY, string note, double cash, string act)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            //  DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@E_ID", SqlDbType.Int);
            parm[0].Value = e_id;

            parm[1] = new SqlParameter("@BL_TY", SqlDbType.NVarChar,50);
            parm[1].Value = BL_TY;

            parm[2] = new SqlParameter("@note", SqlDbType.NVarChar, 500);
            parm[2].Value = note;

            parm[3] = new SqlParameter("@cash", SqlDbType.Money);
            parm[3].Value = cash;

            parm[4] = new SqlParameter("@act", SqlDbType.NVarChar, 50);
            parm[4].Value = act;
           



            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("bonas", parm);
            return dt;
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

        public void add_dept(int c_ID, double n_dept)
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

        public DataTable empSP(int id, string name, string tel, string address, DateTime bdate, string uid, int job, string mstats, int per_count, string id_ty, string id_no, string actian)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[12];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[1].Value = name;

            parm[2] = new SqlParameter("@tel", SqlDbType.VarChar, 50);
            parm[2].Value = tel;

            parm[3] = new SqlParameter("@address", SqlDbType.VarChar, 500);
            parm[3].Value = address;

            parm[4] = new SqlParameter("@bdate", SqlDbType.Date);
            parm[4].Value = bdate;

            parm[5] = new SqlParameter("@uid", SqlDbType.VarChar, 250);
            parm[5].Value = uid;

            parm[6] = new SqlParameter("@job", SqlDbType.Int);
            parm[6].Value = job;

            parm[7] = new SqlParameter("@mstats", SqlDbType.VarChar, 50);
            parm[7].Value = mstats;

            parm[8] = new SqlParameter("@per_cont", SqlDbType.Int);
            parm[8].Value = per_count;

            parm[9] = new SqlParameter("@id_ty", SqlDbType.VarChar, 50);
            parm[9].Value = id_ty;

            parm[10] = new SqlParameter("@id_no", SqlDbType.VarChar, 50);
            parm[10].Value = id_no;

            parm[11] = new SqlParameter("@actan", SqlDbType.VarChar, 50);
            parm[11].Value = actian;






            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("employee_SP", parm);
            return dt;
        }

        public DataTable ContSP(int eid, int job,int dep,DateTime sdate,DateTime edate,int renew,double slr,int lev,int clong,string cl_co, string actian)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[11];

            parm[0] = new SqlParameter("@eid", SqlDbType.Int);
            parm[0].Value = eid;

            parm[1] = new SqlParameter("@job", SqlDbType.Int);
            parm[1].Value = job;

            parm[2] = new SqlParameter("@dep", SqlDbType.Int);
            parm[2].Value = dep;

            parm[3] = new SqlParameter("@sdate", SqlDbType.Date);
            parm[3].Value = sdate ;

            parm[4] = new SqlParameter("@edate", SqlDbType.Date);
            parm[4].Value = edate;

            parm[5] = new SqlParameter("@renew", SqlDbType.Int);
            parm[5].Value = renew;

            parm[6] = new SqlParameter("@slr", SqlDbType.Money);
            parm[6].Value = slr;

            parm[7] = new SqlParameter("@lev", SqlDbType.Int);
            parm[7].Value = lev;


            parm[8] = new SqlParameter("@actan", SqlDbType.VarChar, 50);
            parm[8].Value = actian;

            parm[9] = new SqlParameter("@clong", SqlDbType.Int);
            parm[9].Value = clong;

            parm[10] = new SqlParameter("@cl_co", SqlDbType.VarChar, 50);
            parm[10].Value = cl_co;



            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Contract_SP", parm);
            return dt;
        }


        public DataTable get_l_Emp_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
           

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_Emp_id", null);
            DAL.close();
            return dt;
        }
        public DataTable bon()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
           

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("bon", null);
            DAL.close();
            return dt;
        }
        
    }
}
