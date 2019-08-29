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
        
        public void ADD_Company(string Name, string Address, string Tel1, string Tel2, string Email, string mas, byte[] logo)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

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



            DAL.ExecuteCommand("ADD_Company", parm);
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

        public void EDIT_USER(string ID, string Name, string PWD, string Type)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
            parm[1].Value = Name;

            parm[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@Type", SqlDbType.VarChar, 50);
            parm[3].Value = Type;

          
            DAL.ExecuteCommand("EDIT_USER", parm);
            DAL.close();
        }

        public void ADD_USER(string ID, string Fullname, string PWD, string UserType)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@Fullname", SqlDbType.VarChar, 50);
            parm[1].Value = Fullname;

            parm[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            parm[2].Value = PWD;

            parm[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            parm[3].Value = UserType;


            DAL.ExecuteCommand("ADD_USER", parm);
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
