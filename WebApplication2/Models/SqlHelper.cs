using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class SqlHelper
    {
        string Constr_ = @"Data Source=127.0.0.1;Initial Catalog=SOTWO;Persist Security Info=True;Pooling=True; User ID=sa;Password=e62541301!";
        public DataTable SqlQuery(string quString, List<SqlParameter> sqlParameters)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Constr_);
                conn.Open();
                string Sqlstr = quString;

                SqlDataAdapter da = new SqlDataAdapter(Sqlstr, conn);


                foreach (SqlParameter parameter in sqlParameters)
                {
                    da.SelectCommand.Parameters.Add(parameter);
                }

                DataTable ds = new DataTable();

                da.Fill(ds);
                da.SelectCommand.Parameters.Clear();
                conn.Close();
                conn.Dispose();

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SqlCommit(string quString, List<SqlParameter> sqlParameters)
        {
            try
            {
                SqlConnection conn = new SqlConnection(Constr_);
                conn.Open();

                SqlCommand cmd = new SqlCommand(quString, conn);
                cmd.Parameters.Clear();
                foreach (SqlParameter parameter in sqlParameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                int ReturnQuantity = cmd.ExecuteNonQuery();
                if (ReturnQuantity == 0)
                    throw new Exception("Insert quantity equal zero");
                else
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDataSet(string sconn, string cmd)
        {
            try
            {
                System.Data.DataSet ds = new System.Data.DataSet();
                using (SqlConnection sqlConn = new SqlConnection(sconn))
                {
                    sqlConn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandTimeout = 3000;
                    sqlComm.CommandText = cmd;

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                    adapter.Fill(ds, "temp");
                    return ds;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        public DataTable GetDataTable(string sconn, string cmd)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlConn = new SqlConnection(sconn))
                {
                    sqlConn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandTimeout = 3000;
                    sqlComm.CommandText = cmd;

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlComm);
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        public string GetScalar(string sconn, string cmd)
        {
            try
            {
                object obj;
                using (SqlConnection sqlConn = new SqlConnection(sconn))
                {
                    sqlConn.Open();
                    SqlCommand sqlComm = new SqlCommand();
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandTimeout = 3000;
                    sqlComm.CommandText = cmd;
                    obj = sqlComm.ExecuteScalar();
                    if (obj == null)
                        obj = "";
                    return obj.ToString();

                }
            }
            catch (SqlException e)
            {
                return "";
            }
        }

    }
}