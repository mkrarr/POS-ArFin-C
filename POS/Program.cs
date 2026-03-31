using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string SelasMAN;
        public static string group;
        public static int gid;
        public static DateTime log_TM;
        public static string location;
        public static string UID;
        public static string PC;
        public static string IPA;
        public static string shift_id;
        public static string shift_name;
        public static string last_login;
        public static int P_CONF;
        public static int p_reles;
        public static string Act1="0914240060";
        public static string Act2 = "ASD@123";
        public static string Act3="M0914240060m";
        public static string PAT = "";
        public static string APP_Ver = "2.10";
        public static string ccl = "-1";
        public static Int32 RC = 1;
        public static Int32 IC = 1;
        public static string op_name;
        public static string ZKA_ID;
        public static string TAX_ID;
        public static double ZKA_pr;
        public static double TAX_pr;
        public static string s_id = "-";


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new PL.FRM_MAIN());
           
        }
    }
}
