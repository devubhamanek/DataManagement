using Dm.Common.AppConfig;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
public static class SqlHelper
{
    public static AppConfiguration appConfiguration;

    static SqlHelper()
    {
        appConfiguration = new AppConfiguration();
    }
    

    public static string ExecuteProcedureReturnString(string procName,
        params SqlParameter[] paramters)
    {        
        string result = "";
        using (var sqlConnection = new SqlConnection(appConfiguration.ConnectionString.ToString()))
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = procName;
                if (paramters != null)
                {
                    command.Parameters.AddRange(paramters);
                }
                sqlConnection.Open();
                var ret = command.ExecuteScalar();
                if (ret != null)
                    result = Convert.ToString(ret);
            }
        }
        return result;
    }

    public static TData ExtecuteProcedureReturnData<TData>(string procName,
        Func<SqlDataReader, TData> translator,
        params SqlParameter[] parameters)
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        using (var sqlConnection = new SqlConnection(appConfiguration.ConnectionString.ToString()))
        {
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = procName;
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlConnection.Open();
                using (var reader = sqlCommand.ExecuteReader())
                {
                    TData elements;
                    try
                    {


                        elements = translator(reader);
                    }
                    finally
                    {
                        while (reader.NextResult())
                        { }
                    }
                    return elements;
                }
            }
        }
    }


    ///Methods to get values of 
    ///individual columns from sql data reader
    #region Get Values from Sql Data Reader
    public static string GetNullableString(SqlDataReader reader, string colName)
    {
        return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
    }

    public static int GetNullableInt32(SqlDataReader reader, string colName)
    {
        return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
    }

    public static bool GetBoolean(SqlDataReader reader, string colName)
    {
        return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
    }

    //this method is to check wheater column exists or not in data reader
    public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName)
    {
        try
        {
            return (dr.GetOrdinal(colName) >= 0);
        }
        catch (Exception)
        {
            return false;
        }
    }


    #region "FILL DATA TABLE"

    public static void Fill(DataTable dataTable, string procedureName)
    {
        SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataManagement"].ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        SqlDataAdapter oAdapter = new SqlDataAdapter
        {
            SelectCommand = oCommand
        };
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oAdapter.SelectCommand.Transaction = oTransaction;
                oAdapter.Fill(dataTable);
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oAdapter.Dispose();
            }
        }
    }
    public static void Fill(DataTable dataTable, string procedureName, SqlParameter[] parameters)
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        if (parameters != null)
        {
            oCommand.Parameters.AddRange(parameters);
        }

        SqlDataAdapter oAdapter = new SqlDataAdapter
        {
            SelectCommand = oCommand
        };
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oAdapter.SelectCommand.Transaction = oTransaction;
                oAdapter.Fill(dataTable);
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oAdapter.Dispose();
            }
        }
    }

    #endregion

    #region "FILL DATASET"

    public static void Fill(DataSet dataSet, string procedureName)
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());

        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        SqlDataAdapter oAdapter = new SqlDataAdapter
        {
            SelectCommand = oCommand
        };
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oAdapter.SelectCommand.Transaction = oTransaction;
                oAdapter.Fill(dataSet);
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oAdapter.Dispose();
            }
        }
    }

    public static void Fill(DataSet dataSet, string procedureName, SqlParameter[] parameters)
    {
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };

        if (parameters != null)
        {
            oCommand.Parameters.AddRange(parameters);
        }

        SqlDataAdapter oAdapter = new SqlDataAdapter
        {
            SelectCommand = oCommand
        };
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oAdapter.SelectCommand.Transaction = oTransaction;
                oAdapter.Fill(dataSet);
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oAdapter.Dispose();
            }
        }
    }

    #endregion

    #region "EXECUTE SCALAR"

    public static object ExecuteScalar(string procedureName)
    {
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        object oReturnValue;
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oCommand.Transaction = oTransaction;
                oReturnValue = oCommand.ExecuteScalar();
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oCommand.Dispose();
            }
        }
        return oReturnValue;
    }

    public static object ExecuteScalar(string procedureName, SqlParameter[] parameters)
    {
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        object oReturnValue;
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                if (parameters != null)
                {
                    oCommand.Parameters.AddRange(parameters);
                }

                oCommand.Transaction = oTransaction;
                oReturnValue = oCommand.ExecuteScalar();
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oCommand.Dispose();
            }
        }
        return oReturnValue;
    }

    #endregion

    #region "EXECUTE NON QUERY"

    public static int Fill(string procedureName)
    {

        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        int iReturnValue;
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                oCommand.Transaction = oTransaction;
                iReturnValue = oCommand.ExecuteNonQuery();
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oCommand.Dispose();
            }
        }
        return iReturnValue;
    }

    public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
    {
        SqlConnection oConnection = new SqlConnection(appConfiguration.ConnectionString.ToString());
        SqlCommand oCommand = new SqlCommand(procedureName, oConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        int iReturnValue;
        oConnection.Open();
        using (SqlTransaction oTransaction = oConnection.BeginTransaction())
        {
            try
            {
                if (parameters != null)
                {
                    oCommand.Parameters.AddRange(parameters);
                }

                oCommand.Transaction = oTransaction;
                iReturnValue = oCommand.ExecuteNonQuery();
                oTransaction.Commit();
            }
            catch (Exception ex)
            {

                oTransaction.Rollback();
                throw;
            }
            finally
            {
                if (oConnection.State == ConnectionState.Open)
                {
                    oConnection.Close();
                }

                oConnection.Dispose();
                oCommand.Dispose();
            }
        }
        return iReturnValue;
    }

    #endregion












}
#endregion
