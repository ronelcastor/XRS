using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.UI.WebControls;

namespace DataLayer
{
    public class DataAccess
    {

        SqlCommand sqlcmd = new SqlCommand();
        public string Message { get; set; }


        protected string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["TWDConnectionString"].ToString();
        }

        //public DataSet FillDataSet(string commandtext)
        //{
        //    DataSet ds = new DataSet();
        //    SqlConnection connection = new SqlConnection(ConnectionString());
        //    ds.Clear();
        //    connection.Open();
        //    SqlDataAdapter adapter = new SqlDataAdapter(commandtext, connection);
        //    adapter.Fill(ds);

        //    if (connection != null)
        //        ((IDisposable)connection).Dispose();

        //    return ds;
        //}

        public DataSet FillDataSet(string commandtext, CommandType commandtype)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString());
            ds.Clear();
            sqlcmd.Connection = connection;
            sqlcmd.CommandType = commandtype;
            sqlcmd.CommandText = commandtext;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
            adapter.Fill(ds);
            sqlcmd.Dispose();

            if (connection != null)
                ((IDisposable)connection).Dispose();

            return ds;
        }

        public DataRow FillDataRow(string commandtext, CommandType commandtype)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString());
            ds.Clear();
            try
            {
                connection.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter(commandtext, connection);
                //adapter.Fill(ds);
                sqlcmd.Connection = connection;
                sqlcmd.CommandType = commandtype;
                sqlcmd.CommandText = commandtext;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcmd.Dispose();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                throw;
            }
            finally
            {
                if (connection != null)
                    ((IDisposable)connection).Dispose();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable FillDataTable(string commandtext, CommandType commandtype)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(ConnectionString());
            ds.Clear();
            try
            {
                connection.Open();
                //SqlDataAdapter adapter = new SqlDataAdapter(commandtext, connection);
                //adapter.Fill(ds);
                sqlcmd.Connection = connection;
                sqlcmd.CommandType = commandtype;
                sqlcmd.CommandText = commandtext;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
                adapter.Fill(ds);
                sqlcmd.Dispose();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                throw;
            }
            finally
            {
                if (connection != null)
                    ((IDisposable)connection).Dispose();
            }

            return ds.Tables[0];

        }

        public SqlDataReader FillReader(string commandtext)
        {
            SqlDataReader datareader = null;
            SqlConnection connection = new SqlConnection(ConnectionString());
            try
            {
                using (SqlCommand command = new SqlCommand(commandtext, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    datareader = command.ExecuteReader();
                    return datareader;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
            finally
            {
                if (connection != null)
                    ((IDisposable)connection).Dispose();
            }
            return datareader;
        }

        public bool ExecuteActionQuery(string querystatement, CommandType commandtype)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString()))
                {
                    sqlcmd.Connection = connection;
                    sqlcmd.CommandType = commandtype;
                    sqlcmd.CommandText = querystatement;
                    connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();
                }
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }
        }

        public int ExecuteActionQuery(string querystatement, CommandType commandtype, out int identityno)
        {
            identityno = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString()))
                {
                    sqlcmd.Connection = connection;
                    sqlcmd.CommandType = commandtype;
                    sqlcmd.CommandText = querystatement;
                    connection.Open();
                    sqlcmd.ExecuteNonQuery();
                    identityno = int.Parse(sqlcmd.Parameters["@Employee_No_Temp"].Value.ToString());
                    sqlcmd.Dispose();
                }
                return identityno;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return identityno;
            }
        }


        public void ClearParameter()
        {
            if (sqlcmd.Parameters.Count > 0)
            {
                sqlcmd.Parameters.Clear();
                sqlcmd.Dispose();
            }
        }
        #region Parameter Addition

        // Add byte parameter
        public void AddParameter(string parameterName, byte parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Byte;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add short parameter
        public void AddParameter(string parameterName, short parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Int16;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add int parameter
        public void AddParameter(string parameterName, int parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Int32;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        public void AddParameterOut(string parameterName, int parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Int32;
                param.Direction = ParameterDirection.Output;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }


        // Add long parameter
        public void AddParameter(string parameterName, long parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Int64;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add decimal parameter
        public void AddParameter(string parameterName, decimal parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Currency;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add float parameter
        public void AddParameter(string parameterName, float parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Single;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add double parameter
        public void AddParameter(string parameterName, double parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Double;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add boolean parameter
        public void AddParameter(string parameterName, bool parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Boolean;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add DateTime parameter
        public void AddParameter(string parameterName, DateTime parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.DateTime;
                param.Direction = ParameterDirection.Input;
                param.Value = parameterValue;
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                sqlcmd.Parameters[parameterName].Value = parameterValue;
            }
        }

        // Add string parameter
        public void AddParameter(string parameterName, string parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.String;
                param.Direction = ParameterDirection.Input;
                if (parameterValue != null)
                {
                    if (parameterValue.Length > 0)
                    {
                        param.Size = parameterValue.Length;
                        param.Value = parameterValue;
                    }
                    else
                    {
                        param.Size = 1;
                        param.Value = System.DBNull.Value;
                    }
                }
                else
                {
                    param.Size = 1;
                    param.Value = System.DBNull.Value;
                }
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                if (parameterValue != null)
                {
                    sqlcmd.Parameters[parameterName].Value = parameterValue;
                }
                else
                {
                    sqlcmd.Parameters[parameterName].Value = System.DBNull.Value;
                }
            }
        }

        // Add object parameter
        public void AddParameter(string parameterName, object parameterValue)
        {
            if (sqlcmd.Parameters.IndexOf(parameterName).Equals(-1))
            {
                SqlParameter param = sqlcmd.CreateParameter();
                param.ParameterName = parameterName;
                param.DbType = DbType.Object;
                param.Direction = ParameterDirection.Input;
                if (parameterValue != null)
                {
                    param.Value = parameterValue;
                }
                else
                {
                    param.Value = System.DBNull.Value;
                }
                sqlcmd.Parameters.Add(param);
            }
            else
            {
                if (parameterValue != null)
                {
                    sqlcmd.Parameters[parameterName].Value = parameterValue;
                }
                else
                {
                    sqlcmd.Parameters[parameterName].Value = System.DBNull.Value;
                }
            }
        }

        #endregion


    }
}
