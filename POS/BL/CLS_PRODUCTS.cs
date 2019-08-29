using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace POS.BL
{
    class CLS_PRODUCTS
    {
        public DataTable GET_ALL_CATEGORIES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CATEGORIES", null);
            return dt;
        }
        public void ADD_PRODUCT(int ID_CAT, string LABEL_PRODUCT, string ID_PRODUCT, int QTE, string PRICE, string BPRICE, byte[] IMG)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm=new SqlParameter [7];

            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_CAT;

            parm[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,50);
            parm[1].Value = ID_PRODUCT;

            parm[2] = new SqlParameter("@LABEL", SqlDbType.VarChar, 50);
            parm[2].Value = LABEL_PRODUCT;

            parm[3] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[3].Value = QTE;

            parm[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            parm[4].Value = PRICE;

            parm[5] = new SqlParameter("@BPRICE", SqlDbType.VarChar, 50);
            parm[5].Value = BPRICE;

            parm[6] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[6].Value = IMG;

            DAL.ExecuteCommand("ADD_PRODUCT", parm);
            DAL.close();
        }

        public void Add_sett(string p_id,string o_qu, string n_qu, string d_qu, string e_id, string note, string res)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@p_id", SqlDbType.VarChar, 50);
            parm[0].Value = p_id;

            parm[1] = new SqlParameter("@o_qu", SqlDbType.VarChar, 50);
            parm[1].Value = o_qu;

            parm[2] = new SqlParameter("@n_qu", SqlDbType.VarChar, 50);
            parm[2].Value = n_qu;

            parm[3] = new SqlParameter("@d_qu", SqlDbType.VarChar, 50);
            parm[3].Value = d_qu;

            parm[4] = new SqlParameter("@e_id", SqlDbType.VarChar, 50);
            parm[4].Value = e_id;

            parm[5] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            parm[5].Value = note;

            parm[6] = new SqlParameter("@res", SqlDbType.VarChar, 50);
            parm[6].Value = res;

            DAL.ExecuteCommand("Add_sett", parm);
            DAL.close();
        }

        public void UPDATE_PRODUCT(int ID_CAT, string LABEL_PRODUCT, string ID_PRODUCT, int QTE, string PRICE,string BPRICE, byte[] IMG)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_CAT;

            parm[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar, 50);
            parm[1].Value = ID_PRODUCT;

            parm[2] = new SqlParameter("@LABEL", SqlDbType.VarChar, 50);
            parm[2].Value = LABEL_PRODUCT;

            parm[3] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[3].Value = QTE;

            parm[4] = new SqlParameter("@PRICE", SqlDbType.VarChar, 50);
            parm[4].Value = PRICE;

            parm[5] = new SqlParameter("@BPRICE", SqlDbType.VarChar, 50);
            parm[5].Value = BPRICE;

            parm[6] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[6].Value = IMG;

            DAL.ExecuteCommand("UPDATE_PRODUCT", parm);
            DAL.close();
        }


        public void UPDATE_Stock(string ID_PRODUCT, int QTE)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,50);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[1].Value = QTE;

            DAL.ExecuteCommand("UPDATE_Stock", parm);
            DAL.close();
        }



        public DataTable VerifyProductID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0]= new SqlParameter("@ID",SqlDbType.VarChar,50);
            parm[0].Value=ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("VerifyProductID", parm);
            DAL.close();
            return dt;
        }
        public DataTable GET_ALL_PRODUCTS()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_PRODUCTS", null);
            return dt;
        }

        public DataTable SearchProduct(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SearchProduct", parm);
            DAL.close();
            return dt;
        }

        public DataTable GET_IMAGE_PRODUCT(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_IMAGE_PRODUCT", parm);
            DAL.close();
            return dt;
        }


        public void DeleteProduct( string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar,50);
            parm[0].Value = ID;
            DAL.ExecuteCommand("DeleteProduct", parm);
            DAL.close();
        }

        internal void UPDATE_Stock()
        {
            throw new NotImplementedException();
        }
    }

}
