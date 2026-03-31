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
        public DataTable g_name()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("g_name", null);
            return dt;
        }

    

        public DataTable pos_pr(int CAT_ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@CAT_ID", SqlDbType.NVarChar, 250);
            parm[0].Value = CAT_ID;



            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("pos_pr", parm);
            return dt;
        }

        public DataTable pos_pr_ID(string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@id", SqlDbType.NVarChar, 250);
            parm[0].Value = id;

            

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("pos_pr_ID", parm);
            return dt;
        }

        public DataTable pro_type()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("pro_type", null);
            return dt;
        }

        public DataTable GET_ALL_CATEGORIES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_CATEGORIES", null);
            return dt;
        }
        public DataTable Ding_d(string code,string act)
        {
            var DAL = new DAL.DataAccessLayer();
            var parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@code", SqlDbType.NVarChar, 25);
            parm[0].Value = code ;

            parm[1] = new SqlParameter("@act", SqlDbType.NVarChar, 25);
            parm[1].Value = act;

            DAL.open();
            var dt = new DataTable();
            dt = DAL.SelectData("Ding_d", parm);
            DAL.close();
            return dt;
        }

        public void ADD_PRODUCT(int ID_CAT, string LABEL_PRODUCT, string ID_PRODUCT, int QTE, string PRICE, string BPRICE, byte[] IMG,string mn ,int p_ty)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm=new SqlParameter [9];

            parm[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            parm[0].Value = ID_CAT;

            parm[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.NVarChar,500);
            parm[1].Value = ID_PRODUCT;

            parm[2] = new SqlParameter("@LABEL", SqlDbType.NVarChar, 500);
            parm[2].Value = LABEL_PRODUCT;

            parm[3] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[3].Value = QTE;

            parm[4] = new SqlParameter("@PRICE", SqlDbType.NVarChar, 500);
            parm[4].Value = PRICE;

            parm[5] = new SqlParameter("@BPRICE", SqlDbType.NVarChar, 500);
            parm[5].Value = BPRICE;

            parm[6] = new SqlParameter("@IMG", SqlDbType.Image);
            parm[6].Value = IMG;

            parm[7] = new SqlParameter("@mn", SqlDbType.NVarChar, 500);
            parm[7].Value = mn;

            parm[8] = new SqlParameter("@p_ty", SqlDbType.Int);
            parm[8].Value = p_ty;

            DAL.ExecuteCommand("ADD_PRODUCT", parm);
            DAL.close();
        }

        public DataTable add_patch(string ID_PRODUCT, string patch, DateTime e_date, DateTime m_date, int qut, Double s_PRICE, double p_price)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[7];

            parm[0] = new SqlParameter("@id_prodact", SqlDbType.NVarChar,250);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@patch", SqlDbType.VarChar, 50);
            parm[1].Value = patch;

            parm[2] = new SqlParameter("@e_date", SqlDbType.DateTime);
            parm[2].Value = e_date;

            parm[3] = new SqlParameter("@m_date", SqlDbType.DateTime);
            parm[3].Value = m_date;

            parm[4] = new SqlParameter("@qut", SqlDbType.Int);
            parm[4].Value = qut;

            parm[5] = new SqlParameter("@s_PRICE", SqlDbType.Float);
            parm[5].Value = s_PRICE;

            parm[6] = new SqlParameter("@p_price", SqlDbType.Float);
            parm[6].Value = p_price;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("add_patch", parm);
            return dt;
        }

        public DataTable stoors_SP(int id, string name, string add, string tel, string sup, int ty, int sts, string action)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[8];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@name", SqlDbType.VarChar, 500);
            parm[1].Value = name;

            parm[2] = new SqlParameter("@add", SqlDbType.VarChar, 500);
            parm[2].Value = add;

            parm[3] = new SqlParameter("@tel", SqlDbType.VarChar, 500);
            parm[3].Value = tel;

            parm[4] = new SqlParameter("@sup", SqlDbType.VarChar, 500);
            parm[4].Value = sup;

            parm[5] = new SqlParameter("@ty", SqlDbType.Int);
            parm[5].Value = ty;

            parm[6] = new SqlParameter("@sts", SqlDbType.Int);
            parm[6].Value = sts;

            parm[7] = new SqlParameter("@action", SqlDbType.NVarChar,20);
            parm[7].Value = action;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("stoors_SP", parm);
            return dt;
        }

        public void add_sett_ditails(string p_id,double o_qu, double n_qu, double d_qu, int id,string Pat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@p_id", SqlDbType.VarChar ,150);
            parm[0].Value = p_id;

            parm[1] = new SqlParameter("@o_qut", SqlDbType.Float);
            parm[1].Value = o_qu;

            parm[2] = new SqlParameter("@n_qut", SqlDbType.Float);
            parm[2].Value = n_qu;

            parm[3] = new SqlParameter("@d_qut", SqlDbType.Float);
            parm[3].Value = d_qu;

            parm[4] = new SqlParameter("@id", SqlDbType.Int);
            parm[4].Value = id;

            parm[5] = new SqlParameter("@Pat", SqlDbType.VarChar, 550);
            parm[5].Value = Pat;

            DAL.ExecuteCommand("add_sett_ditails", parm);
            DAL.close();
        }

        public void Add_sett(int id,string e_id,string note,string res )
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[4];

            parm[0] = new SqlParameter("@id", SqlDbType.Int);
            parm[0].Value = id;

            parm[1] = new SqlParameter("@e_id", SqlDbType.VarChar, 250);
            parm[1].Value = e_id;

            parm[2] = new SqlParameter("@note", SqlDbType.VarChar, 500);
            parm[2].Value = note;

            parm[3] = new SqlParameter("@res", SqlDbType.VarChar, 50);
            parm[3].Value = res;
            
            DAL.ExecuteCommand("Add_sett", parm);
            DAL.close();
        }

        public void UPDATE_PRODUCT(int ID_CAT, string LABEL_PRODUCT, string ID_PRODUCT, int QTE, string PRICE,string BPRICE, byte[] IMG,string mn,int p_ty)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[9];

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

            parm[7] = new SqlParameter("@mn", SqlDbType.NVarChar, 500);
            parm[7].Value = mn;

            parm[8] = new SqlParameter("@p_ty", SqlDbType.Int);
            parm[8].Value = p_ty;

            DAL.ExecuteCommand("UPDATE_PRODUCT", parm);
            DAL.close();
        }

        public void up_patch(string p_id,string pt_id,DateTime e_date,DateTime m_date,double s_price,double p_price)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[6];

            parm[0] = new SqlParameter("@p_id", SqlDbType.NVarChar,250);
            parm[0].Value = p_id;

            parm[1] = new SqlParameter("@pt_id", SqlDbType.VarChar, 250);
            parm[1].Value = pt_id;

            parm[2] = new SqlParameter("@e_date", SqlDbType.DateTime);
            parm[2].Value = e_date;

            parm[3] = new SqlParameter("@m_date", SqlDbType.DateTime);
            parm[3].Value = m_date;

            parm[4] = new SqlParameter("@s_price", SqlDbType.Float);
            parm[4].Value = s_price;

            parm[5] = new SqlParameter("@p_price", SqlDbType.Float);
            parm[5].Value = p_price;

            

            DAL.ExecuteCommand("up_patch", parm);
            DAL.close();
        }



        public void UPDATE_Stock(string ID_PRODUCT, int QTE,string pat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[3];

            parm[0] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,500);
            parm[0].Value = ID_PRODUCT;

            parm[1] = new SqlParameter("@QTE", SqlDbType.Int);
            parm[1].Value = QTE;

            parm[2] = new SqlParameter("@pat", SqlDbType.VarChar, 500);
            parm[2].Value = pat;

            DAL.ExecuteCommand("UPDATE_Stock", parm);
            DAL.close();
        }

        public void UP_price(int id_cat, double prc)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id_cat", SqlDbType.Int);
            parm[0].Value = id_cat;

            parm[1] = new SqlParameter("@prc", SqlDbType.Float);
            parm[1].Value = prc;

            DAL.ExecuteCommand("UP_price", parm);
            DAL.close();
        }

        public void UP_price2( double prc)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@prc", SqlDbType.Float);
            parm[0].Value = prc;

            DAL.ExecuteCommand("UP_price2", parm);
            DAL.close();
        }




        public DataTable get_l_s_id()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_l_s_id", null);
            return dt;
        }

        public DataTable get_main_GR()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_main_GR", null);
            return dt;
        }

        public DataTable get_main_GR2()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_main_GR2", null);
            return dt;
        }

        public DataTable get_main_GR3(string id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@id", SqlDbType.NVarChar, 500);
            parm[0].Value = id;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("get_main_GR3", parm);
            DAL.close();
            return dt;
        }



        public DataTable low_stock()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("low_stock", null);
            return dt;
        }

        public DataTable low_stock2()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("low_stock2", null);
            return dt;
        }

        public DataTable ex_list()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("ex_list", null);
            return dt;
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


        public DataTable GET_ALL_PRODUCTS2()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("GET_ALL_PRODUCTS2", null);
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

        public DataTable pro_TLS(int cat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@cat", SqlDbType.Int);
            parm[0].Value = cat;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("pro_TLS", parm);
            DAL.close();
            return dt;
        }

        public DataTable Patch_list(string ID,double prc)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;

            parm[1] = new SqlParameter("@prc", SqlDbType.Float);
            parm[1].Value = prc;

            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Patch_list", parm);
            DAL.close();
            return dt;
        }

        public DataTable Patch_list2(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Patch_list2", parm);
            DAL.close();
            return dt;
        }

        public DataTable Patch_list3(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("Patch_list3", parm);
            DAL.close();
            return dt;
        }



        public DataTable SearchProduct2(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] parm = new SqlParameter[1];
            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SearchProduct2", parm);
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

        public void stop_patch(string id_pro,string pat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id_pro", SqlDbType.VarChar, 50);
            parm[0].Value = id_pro;

            parm[1] = new SqlParameter("@pat", SqlDbType.VarChar, 50);
            parm[1].Value = pat;

            DAL.ExecuteCommand("stop_patch", parm);
            DAL.close();
        }

        public void stop_patch2(string id_pro, string pat)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@id_pro", SqlDbType.VarChar, 50);
            parm[0].Value = id_pro;

            parm[1] = new SqlParameter("@pat", SqlDbType.VarChar, 50);
            parm[1].Value = pat;

            DAL.ExecuteCommand("stop_patch2", parm);
            DAL.close();
        }



        public void DeleteProduct2(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.open();
            SqlParameter[] parm = new SqlParameter[1];

            parm[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            parm[0].Value = ID;
            DAL.ExecuteCommand("DeleteProduct2", parm);
            DAL.close();
        }

        internal void UPDATE_Stock()
        {
            throw new NotImplementedException();
        }
    }

}
