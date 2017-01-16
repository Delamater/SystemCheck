using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;

namespace SystemCheck
{
    /// <summary>
    /// Acts as Data Access Layer for SQL Server
    /// </summary>
    public class DataAccessLayer
    {
        //"Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=DummyDatabase;Data Source=.;Connect Timeout=200;"
        private static ErrorHandler _err = new ErrorHandler();
        private static string _SqlConnectionString = "";
        private static string _LoginName = "";
        public static string MinimumDatabaseVersionNotMet
        {
            get
            {
                return "The minimum database version has not been met. Your connection has not been established";
            }
        }

        public static string SqlConnectionString
        {
            get
            {
                return _SqlConnectionString;
            }
            set
            {
                _SqlConnectionString = value;
            }
        }

        public static string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }

        //your connection string I place mine for illustration.. DON'T HARDLY WRITE IT, pass it as argument or add it in application configuration 
        /// <summary>
        /// Replaces every parameter with its value from 2D array
        /// </summary>
        /// <param name="query">Query</param>
        /// <param name="parameters">Query parameters</param>
        /// <returns>Query with parameters value to be executed against SQL Server Database</returns>
        private static string SetParametersValue(string query, string[,] parameters)
        {
            for (int i = 0; i < parameters.Length / 2; i++)
            {
                if (!string.IsNullOrEmpty(parameters[i, 0]))
                    query = query.Replace(parameters[i, 0], "'" + parameters[i, 1] + "'");
            }
            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sp, CommandType commandType)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(sp, con);
            com.CommandTimeout = con.ConnectionTimeout;
            object result = null;

            com.CommandType = commandType;

            try
            {
                con.Open();
                result = com.ExecuteScalar();
                con.Close();
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
            return result;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sp, string[,] parameters, CommandType commandType)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(SetParametersValue(sp, parameters), con);
            com.CommandTimeout = con.ConnectionTimeout;
            object result = null;


            com.CommandType = commandType;

            for (int i = 0; i < parameters.Length / 2; i++)
            {
                com.Parameters.AddWithValue(parameters[i, 0], parameters[i, 1]);
            }

            try
            {
                con.Open();
                result = com.ExecuteScalar();
                con.Close();
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteQuery(string sp, CommandType commandType, Decimal decMinSQLVersion)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(sp, con);
            com.CommandTimeout = con.ConnectionTimeout;
            string strGetSqlVersion =
                @"DECLARE @ProductVersion VARCHAR(50)"
                + "SET @ProductVersion  = (SELECT CONVERT(VARCHAR(50),SERVERPROPERTY('PRODUCTVERSION')))"
                + "SELECT CONVERT(DECIMAL(18,2),SUBSTRING(@ProductVersion,0,CHARINDEX('.',@ProductVersion,CHARINDEX('.',@ProductVersion)+1))) ProductVersion";
            SqlCommand comVersionCheck = new SqlCommand(strGetSqlVersion, con);
            SqlDataReader reader = null;
            SqlDataReader sdrVersionCheck = null;

            com.CommandType = commandType;

            try
            {
                con.Open();
                sdrVersionCheck = comVersionCheck.ExecuteReader(CommandBehavior.SingleRow);
                sdrVersionCheck.Read();

                //Perform a version compatibility check first
                if (decMinSQLVersion > Convert.ToDecimal(sdrVersionCheck["ProductVersion"].ToString()))
                {
                    throw new ApplicationException(
                        MinimumDatabaseVersionNotMet
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Min version: " 
                        + decMinSQLVersion 
                        + Environment.NewLine 
                        + "Your version: " 
                        + sdrVersionCheck["ProductVersion"].ToString());
                }

                con.Close();
                con.Open();

                //Run the TSQL Code
                reader = com.ExecuteReader(CommandBehavior.CloseConnection);
                
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
            return reader;
        }

        public static DataTable GetDataTable(string sp, CommandType commandType, string tableName, Decimal decMinSQLVersion)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(sp, con);
            com.CommandTimeout = con.ConnectionTimeout;
            DataTable dt = new DataTable(tableName);
            com.CommandType = commandType;

            string strGetSqlVersion =
                @"DECLARE @ProductVersion VARCHAR(50)"
                + "SET @ProductVersion  = (SELECT CONVERT(VARCHAR(50),SERVERPROPERTY('PRODUCTVERSION')))"
                + "SELECT CONVERT(DECIMAL(18,2),SUBSTRING(@ProductVersion,0,CHARINDEX('.',@ProductVersion,CHARINDEX('.',@ProductVersion)+1))) ProductVersion";
            SqlCommand comVersionCheck = new SqlCommand(strGetSqlVersion, con);
            SqlDataReader sdrVersionCheck = null;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = com;
            

            try
            {
                con.Open();

                sdrVersionCheck = comVersionCheck.ExecuteReader(CommandBehavior.SingleRow);
                sdrVersionCheck.Read();

                //Perform a version compatibility check first
                if (decMinSQLVersion > Convert.ToDecimal(sdrVersionCheck["ProductVersion"].ToString()))
                {
                    _err.WriteToErrorLog(new ApplicationException(
                        MinimumDatabaseVersionNotMet
                        + Environment.NewLine
                        + Environment.NewLine
                        + "Min version: "
                        + decMinSQLVersion
                        + Environment.NewLine
                        + "Your version: "
                        + sdrVersionCheck["ProductVersion"].ToString()));

                    DataTable tempDataTable = new DataTable(tableName);
                    return tempDataTable;
                }

                con.Close();
                con.Open();

                //Fill the dataset
                da.Fill(dt);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// FOR SQL
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteQuery(string sp, string[,] parameters, CommandType commandType)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(SetParametersValue(sp, parameters), con);
            SqlDataReader reader = null;


            com.CommandType = commandType;

            for (int i = 0; i < parameters.Length / 2; i++)
            {
                com.Parameters.AddWithValue(parameters[i, 0], parameters[i, 1]);
            }

            try
            {
                con.Open();
                reader = com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
            return reader;
        }

        /// <summary>
        /// FOR SQL
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static void ExecuteNonQuery(string sp, CommandType commandType)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(sp, con);


            com.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
        }

        /// <summary>
        /// FOR SQL
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static void ExecuteNonQuery(string sp, string[,] parameters, CommandType commandType)
        {
            SqlConnection con = new SqlConnection(SqlConnectionString);
            SqlCommand com = new SqlCommand(SetParametersValue(sp, parameters), con);


            com.CommandType = commandType;

            for (int i = 0; i < parameters.Length / 2; i++)
            {
                com.Parameters.AddWithValue(parameters[i, 0], parameters[i, 1]);
            }

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (System.Exception ex)
            {
                //log the exception
                throw ex;
            }
        }

        public static DataTable GetDataTable(string xmlFullPathName, string strTableName)
        {
            try
            {

                DataTable dt = new DataTable(strTableName);
                dt.ReadXml(xmlFullPathName);
                
                return dt;
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
