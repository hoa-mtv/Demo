using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
namespace System
{
    public class Help
    {
        public static string stringConn = "Data Source=10.120.104.124,1433;initial catalog=DemoUnityRepository;Uid=sa;Pwd=12345678;max pool size=1";
       // public static string stringConn = "Data Source=QV-ASSY1-NPC24\\SQLEXPRESS;initial catalog=Mottainai;Uid=sa;Pwd=******";
       
        public static SqlConnection open()
        {
            return new SqlConnection(stringConn);
        }
        public static DataTable DataTable_Sql(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(stringConn))
                {
                    using (SqlDataAdapter dap = new SqlDataAdapter(sql, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            dap.Fill(ds);
                            conn.Close();
                            conn.Dispose();
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable Querry(string strSQL, SqlParameter[] prs, CommandType cmtype)
        {
            DataTable dt = new DataTable();
            SqlDataReader reader = null;
            SqlConnection sqlCon = new SqlConnection(stringConn);
            SqlCommand sqlCmd = null;

            try
            {
                sqlCon.Open();
                dt = new DataTable();
                sqlCmd = sqlCon.CreateCommand();

                sqlCmd.CommandType = cmtype;
                sqlCmd.CommandText = strSQL;
                if (prs != null)
                {
                    sqlCmd.Parameters.AddRange(prs);
                }
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw e;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                sqlCon.Close();
            }
            return dt;
        }
        public static DataTable exe_table(string sql, SqlParameter[] prs, CommandType cmtype)
        {
            SqlDataReader reader = null;
            DataTable dt = new DataTable();
            SqlConnection sqlcon = new SqlConnection(stringConn);
            try
            {
                sqlcon.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = sqlcon.CreateCommand();
                    cmd.CommandType = cmtype;
                    cmd.CommandText = sql;
                    if (prs != null)
                    {
                        cmd.Parameters.AddRange(prs);
                    }
                    reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    sqlcon.Dispose();
                    sqlcon.Close();
                    return dt;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
       
        public static int none_query(string sql, SqlParameter[] prs, CommandType cmtype)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = 0;
            conn.Open();

            cmd.CommandType = cmtype;
            cmd.CommandText = sql;
            if (prs != null)
            {
                cmd.Parameters.AddRange(prs);
            }
            row = cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
            return row;
        }
        public static int exe_NoneSql(string sql)
        {
            SqlConnection conn = new SqlConnection(stringConn);
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = 0;
            conn.Open();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            row = cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
            return row;
        }
        /**
         * thangngueyn
         * Check exists record
         */
        public static bool CheckExist(string sql)
        {
            DataTable dtb = new DataTable();
            dtb = DataTable_Sql(sql);
            if (dtb.Rows.Count > 0) return true;
            return false;
        }

        public static string image(string code)
        {

            return "http://localhost/image?code=" + code;
        }

         public static DataTable GetPagedTable (DataTable dt, int PageIndex=0 , int PageSize=0)
            {
             
                if (PageIndex == 0)
                return dt;
                DataTable newdt = dt.Copy ();
                newdt.Clear ();
                 int rowbegin = (PageIndex - 1 ) * PageSize;
                int rowend = PageIndex * PageSize;
                if (rowbegin >= dt.Rows.Count)
                return newdt;
                if (rowend> dt.Rows.Count)
                rowend = dt.Rows.Count;
                for (int i = rowbegin; i <= rowend - 1 ; i++)
                {
                    DataRow newdr = newdt.NewRow ();
                    DataRow dr = dt.Rows [i];
                    foreach (DataColumn column in dt.Columns)
                    {
                    newdr [column.ColumnName] = dr [column.ColumnName];
                    }
                    newdt.Rows.Add (newdr);
                }
                return newdt;
            }
    }
}