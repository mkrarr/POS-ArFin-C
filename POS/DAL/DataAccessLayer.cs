using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace POS.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlconnection;
        public DataAccessLayer()
        {
            if (Properties.Settings.Default.mode == "SQL")
            {
                sqlconnection = new SqlConnection(@"server=" + Properties.Settings.Default.Server + ";database=" + Properties.Settings.Default.Database + ";Integrated security=false;user id="+ Properties.Settings.Default.ID +";password="+Properties.Settings.Default.password+"");

            }
            else 
            {
                sqlconnection = new SqlConnection(@"server=" + Properties.Settings.Default.Server + ";database=" + Properties.Settings.Default.Database + "; Integrated Security=true");
            }
            }
        public void Conn()
        {
             SqlConnection con = new SqlConnection(@"server=192.168.1.9\SQLEXPRESS,1433;database=Product_DB;Integrated security=false;user id=admin22;password=123456");

        }
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open ();
            }
        }
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
       //Select**
        public DataTable SelectData (string stored_procedure, SqlParameter[] parm)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if(parm != null)
            {
                for (int i=0;i<parm.Length;i++)
                {
                    sqlcmd.Parameters.Add(parm[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //isert-updat-delet**
        public void ExecuteCommand(string Stored_procedure, SqlParameter[]parm)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = Stored_procedure;
            sqlcmd.Connection = sqlconnection;

            if(parm != null)
            {
                sqlcmd.Parameters.AddRange(parm);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
