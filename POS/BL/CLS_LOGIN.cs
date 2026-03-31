using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS.BL
{
    class CLS_LOGIN
    {

        public DataTable comp()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("comp", null);
            return dt;
        }

        public DataTable sis_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("sis_id", null);
            return dt;
        }

        public DataTable list_user()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("list_user", null);
            return dt;
        }

        public DataTable pth_s()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("PTH_S", null);
            return dt;
        }

        public DataTable GET_FRM()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_FRM", null);
            return dt;
        }

        public DataTable Options_prc()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Options_prc", null);
            return dt;
        }

        public DataTable dep_set()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("dep_set", null);
            return dt;
        }

        public DataTable shift_ls()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("shift_ls", null);
            return dt;
        }

        public DataTable e_blc()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("e_blc", null);
            return dt;
        }
        //*************************************//********
        public DataTable get_groups()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_groups", null);
            return dt;
        }

        public DataTable get_main_hisLS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_main_hisLS", null);
            return dt;

        }

        //    test_EX
        public DataTable test_EX(DateTime ndate)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ndate", SqlDbType.DateTime);
            parm[0].Value = ndate;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("test_EX", parm);
            DAL.close();
            return dt;
        }

        public DataTable App_ver(string  key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@key", SqlDbType.NVarChar , 25);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("App_ver", parm);
            DAL.close();
            return dt;
        }

        public DataTable notif(DateTime year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.NVarChar, 25);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("notif", parm);
            DAL.close();
            return dt;
        }

        public DataTable MACC_FDIT(DateTime year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.NVarChar, 25);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("MACC_FDIT", parm);
            DAL.close();
            return dt;
        }

        public DataTable sh_dbg(DateTime year)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@year", SqlDbType.NVarChar, 25);
            parm[0].Value = year;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("sh_dbg", parm);
            DAL.close();
            return dt;
        }
        //US_BLK
        public DataTable US_BLK(string id,string act)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@id", SqlDbType.NVarChar, 250);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@act", SqlDbType.NVarChar, 250);
            parm[1].Value = act;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("US_BLK", parm);
            DAL.close();
            return dt;
        }
        //   ne_slr

        public DataTable ne_slr(double ss)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ss", SqlDbType.Float);
            parm[0].Value = ss;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("ne_slr", parm);
            DAL.close();
            return dt;
        }

        public DataTable job_se(string key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@key", SqlDbType.NVarChar, 25);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("job_se", parm);
            DAL.close();
            return dt;
        }
        public DataTable dep_se(string key)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@key", SqlDbType.NVarChar, 25);
            parm[0].Value = key;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("dep_se", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_log_key(string action)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@action", SqlDbType.NVarChar,20);
            parm[0].Value = action;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_log_key", parm);
            DAL.close();
            return dt;
        }

        public DataTable get_log_rpt(string action,string key,DateTime date1,DateTime date2)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[4];
            parm[0] = new SqlParameter("@action", SqlDbType.NVarChar, 20);
            parm[0].Value = action;

            parm[1] = new SqlParameter("@key", SqlDbType.NVarChar, 550);
            parm[1].Value = key;

            parm[2] = new SqlParameter("@date1", SqlDbType.Date);
            parm[2].Value = date1;

            parm[3] = new SqlParameter("@date2", SqlDbType.Date);
            parm[3].Value = date2;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("get_log_rpt", parm);
            DAL.close();
            return dt;
        }

        public DataTable pay_acc(string action, string name, int id, int m_acc,int ch)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[5];
            parm[0] = new SqlParameter("@action", SqlDbType.NVarChar, 20);
            parm[0].Value = action;

            parm[1] = new SqlParameter("@name", SqlDbType.NVarChar, 550);
            parm[1].Value = name;

            parm[2] = new SqlParameter("@id", SqlDbType.Int);
            parm[2].Value = id;

            parm[3] = new SqlParameter("@m_acc", SqlDbType.Int);
            parm[3].Value = m_acc;

            parm[4] = new SqlParameter("@ch", SqlDbType.Int);
            parm[4].Value = ch;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("pay_acc", parm);
            DAL.close();
            return dt;
        }


        public void ADD_Company(string Name, string Address, string Tel1, string Tel2, string Email, string mas, byte[] logo, string flag, string p_msg, string zka, string DRAIB)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[11];

            parm[0] = new SqlParameter("@Name", SqlDbType.VarChar, 150);
            parm[0].Value = Name;

            parm[1] = new SqlParameter("@Address", SqlDbType.VarChar, 150);
            parm[1].Value = Address;

            parm[2] = new SqlParameter("@Tel1", SqlDbType.VarChar, 150);
            parm[2].Value = Tel1;

            parm[3] = new SqlParameter("@Tel2", SqlDbType.VarChar, 150);
            parm[3].Value = Tel2;

            parm[4] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            parm[4].Value = Email;

            parm[5] = new SqlParameter("@mas", SqlDbType.VarChar, 50);
            parm[5].Value = mas;

            parm[6] = new SqlParameter("@logo", SqlDbType.Image);
            parm[6].Value = logo;

            parm[7] = new SqlParameter("@p_msg", SqlDbType.VarChar, 50);
            parm[7].Value = p_msg;

            parm[8] = new SqlParameter("@flag", SqlDbType.VarChar, 50);
            parm[8].Value = flag;

            parm[9] = new SqlParameter("@zka", SqlDbType.VarChar, 150);
            parm[9].Value = zka;

            parm[10] = new SqlParameter("@DRAIB", SqlDbType.VarChar, 150);
            parm[10].Value = DRAIB;



            DAL.ExecuteCommand("ADD_Company", parm);
            DAL.close();
        }

        public void add_login_log(string u_id, string u_name, string c_ip, string c_name, string action, string s_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@u_id", SqlDbType.VarChar, 150);
            parm[0].Value = u_id;

            parm[1] = new SqlParameter("@u_name", SqlDbType.VarChar, 150);
            parm[1].Value = u_name;

            parm[2] = new SqlParameter("@c_ip", SqlDbType.VarChar, 150);
            parm[2].Value = c_ip;

            parm[3] = new SqlParameter("@c_name", SqlDbType.VarChar, 150);
            parm[3].Value = c_name;

            parm[4] = new SqlParameter("@action", SqlDbType.VarChar, 50);
            parm[4].Value = action;

            parm[5] = new SqlParameter("@s_id", SqlDbType.NVarChar, 100);
            parm[5].Value = s_id;




            DAL.ExecuteCommand("add_login_log", parm);
            DAL.close();
        }

        public void up_options(int o_id, string val1, string val2, string val3  )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@val1", SqlDbType.VarChar, 150);
            parm[0].Value = val1;

            parm[1] = new SqlParameter("@val2", SqlDbType.VarChar, 150);
            parm[1].Value = val2;

            parm[2] = new SqlParameter("@val3", SqlDbType.VarChar, 150);
            parm[2].Value = val3;

            parm[3] = new SqlParameter("@o_id", SqlDbType.Int);
            parm[3].Value = o_id;

           



            DAL.ExecuteCommand("up_options", parm);
            DAL.close();
        }


        public void add_c_Pay (string r, string s, double  cash, int ty, DateTime date, string u_id,string name)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@r", SqlDbType.VarChar, 500);
            parm[0].Value = r;

            parm[1] = new SqlParameter("@s", SqlDbType.VarChar, 50);
            parm[1].Value = s;

            parm[2] = new SqlParameter("@cash", SqlDbType.Money);
            parm[2].Value = cash;

            parm[3] = new SqlParameter("@ty", SqlDbType.Int);
            parm[3].Value = ty;

            parm[4] = new SqlParameter("@date", SqlDbType.DateTime);
            parm[4].Value = date;

            parm[5] = new SqlParameter("@u_id", SqlDbType.VarChar, 250);
            parm[5].Value = u_id;

            parm[6] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[6].Value = name;


            DAL.ExecuteCommand("add_c_Pay", parm);
            DAL.close();
        }

        public DataTable LOGIN (string ID, string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[1].Value = PWD;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SP_LOGIN", parm);
            return dt;
        }
        public DataTable ublk(string ID, string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[1].Value = PWD;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("ublk", parm);
            return dt;
        }

        public DataTable us_groupid()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[0];
          

           
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("us_groupid", parm);
            return dt;
        }

        public DataTable get_parm(int ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.Int);
            parm[0].Value = ID;

            

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_parm", parm);
            return dt;
        }

        public void Delete_user(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];


            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar,50);
            parm[0].Value = ID;

            DAL.ExecuteCommand("Delete_user", parm);
            DAL.close();
        }

        public void EDIT_USER(string ID, string Name, string PWD, string Type,int ug )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
            parm[1].Value = Name;

            parm[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            parm[3].Value = Type;

            parm[4] = new SqlParameter("@ug", SqlDbType.Int);
            parm[4].Value = ug;

            DAL.ExecuteCommand("EDIT_USER", parm);
            DAL.close();
        }
        //    de_us_gr
        public void de_us_gr( int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@id", SqlDbType.NVarChar, 150);
            parm[0].Value = id;
            

            DAL.ExecuteCommand("de_us_gr", parm);
            DAL.close();
        }

        public void add_group(string Name, int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@name", SqlDbType.NVarChar, 150);
            parm[0].Value = Name;

            parm[1] = new SqlParameter("@id", SqlDbType.Int);
            parm[1].Value = id;

            DAL.ExecuteCommand("add_group", parm);
            DAL.close();
        }

        public void up_group(string Name, int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@name", SqlDbType.NVarChar, 150);
            parm[0].Value = Name;

            parm[1] = new SqlParameter("@id", SqlDbType.Int);
            parm[1].Value = id;

            DAL.ExecuteCommand("up_group", parm);
            DAL.close();
        }

        public void ADD_USER(string ID, string Fullname, string PWD, string UserType,int ug)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[5];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@Fullname", SqlDbType.VarChar, 50);
            parm[1].Value = Fullname;

            parm[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            parm[3].Value = UserType;

            parm[4] = new SqlParameter("@ug", SqlDbType.Int);
            parm[4].Value = ug;


            DAL.ExecuteCommand("ADD_USER", parm);
            DAL.close();
        }

        public void up_parm(int f, int s, int p, int pr, int a, int r, int h, int u, int sd, int c, int id,int sd2,int nat,int ins,int p_con,int p_reles,int nat2,int hr)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[18];

            parm[0] = new SqlParameter("@f", SqlDbType.Int);
            parm[0].Value = f;

            parm[1] = new SqlParameter("@s", SqlDbType.Int);
            parm[1].Value = s;

            parm[2] = new SqlParameter("@p", SqlDbType.Int);
            parm[2].Value = p;

            parm[3] = new SqlParameter("@pr", SqlDbType.Int);
            parm[3].Value = pr;

            parm[4] = new SqlParameter("@a", SqlDbType.Int);
            parm[4].Value = a;

            parm[5] = new SqlParameter("@r", SqlDbType.Int);
            parm[5].Value = r;

            parm[6] = new SqlParameter("@h", SqlDbType.Int);
            parm[6].Value = h;

            parm[7] = new SqlParameter("@u", SqlDbType.Int);
            parm[7].Value = u;

            parm[8] = new SqlParameter("@sd", SqlDbType.Int);
            parm[8].Value = sd;

            parm[9] = new SqlParameter("@c", SqlDbType.Int);
            parm[9].Value = c;

            parm[10] = new SqlParameter("@id", SqlDbType.Int);
            parm[10].Value = id;

            parm[11] = new SqlParameter("@sd2", SqlDbType.Int);
            parm[11].Value = sd2;

            parm[12] = new SqlParameter("@nat", SqlDbType.Int);
            parm[12].Value = nat;

            parm[13] = new SqlParameter("@ins", SqlDbType.Int);
            parm[13].Value = ins;

            parm[14] = new SqlParameter("@p_con", SqlDbType.Int);
            parm[14].Value = p_con;

            parm[15] = new SqlParameter("@p_reles", SqlDbType.Int);
            parm[15].Value = p_reles;

            parm[16] = new SqlParameter("@nat2", SqlDbType.Int);
            parm[16].Value = nat2;

            parm[17] = new SqlParameter("@hr", SqlDbType.Int);
            parm[17].Value = hr;


            DAL.ExecuteCommand("up_parm", parm);
            DAL.close();
        }

        public DataTable get_users()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_users", null);
            return dt;
        }

        public DataTable getalluser()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("getalluser", null);
            return dt;
        }

    }
}
