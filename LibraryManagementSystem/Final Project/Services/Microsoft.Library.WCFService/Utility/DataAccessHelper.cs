using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security;
using System.Security.Principal;
using System.Security.Authentication;
using System.Security.Permissions;

namespace Microsoft.LibraryService.Utility
{
    /// <summary>
    /// The DataAccess class provides exception-safe wrappers around the ADO.NET reader/dataset interface.
    /// This does not mean that method don't throw exceptions; it simply means that even in the face of an
    /// exception, resources are handled correctly. For example, any open database connection will be closed
    /// even under exceptions. It is the responsibility of the caller to catch the exception that is
    /// propagated/thrown by methods within this class.
    /// </summary>
    public sealed class DataAccessHelper
    {

        private DataAccessHelper()
        { }

        #region Private Types
        /// <summary>
        /// Execute type for the Command Object
        /// </summary>
        private enum ExecuteType
        {
            ExecuteReader,
            ExecuteScalar,
            ExecuteNonQuery
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Appends to a pre-build array of SqlParameter objects given a set of name/type/value triplet for
        /// each argument. It is crucial that each argument be specified using the triplet. A check is made
        /// very early in the method to ensure that the number of arguments provided is evenly divisible
        /// by three, failing which an exception is thrown.
        /// This method is typically invoked after invoking the BuildSqlParameterArray() method.
        /// </summary>
        /// <param name="args">Pre-build array of SqlParameter objects</param>
        /// <param name="nameTypeValue">A comma-separated list of name/type/value (one per parameter)</param>
        /// <returns>array of SqlParameter objects</returns>
        public static SqlParameter[] AppendToSqlParameterArray(SqlParameter[] args, params object[] nameTypeValue)
        {
            if ((nameTypeValue.Length % 3) != 0)
            {
                throw new CustomExceptionHandler("Name/Type/Value is unbalanced");
            }

            int originalArgCount = args.Length;
            int argCount = originalArgCount + (nameTypeValue.Length / 3);
            SqlParameter[] temp = new SqlParameter[argCount];
            args.CopyTo(temp, 0);
            args = temp;

            for (int arg = originalArgCount, ntv = 0; arg < argCount; ++arg, ntv += 3)
            {
                args[arg] = new SqlParameter((string)nameTypeValue[ntv], (SqlDbType)nameTypeValue[ntv + 1]);
                args[arg].Value = nameTypeValue[ntv + 2];
            }
            return args;
        }

        /// <summary>
        /// This method builds an array of SqlParameter objects given a set of name/type/value triplet for
        /// each argument. It is crucial that each argument be specified using the triplet. A check is made
        /// very early in the method to ensure that the number of arguments provided is evenly divisible
        /// by three, failing which an exception is thrown.
        /// 
        /// An example invocation may looks liks this:
        /// SqlParameter[] args = BuildSqlParameterArray("@firstName", SqlDbType.Varchar, "Abc");
        /// 
        /// </summary>
        /// <param name="nameTypeValue">A comma-separated list of name/type/value (one per parameter)</param>
        /// <returns>An array of initialized SqlParameter objects</returns>
        public static SqlParameter[] BuildSqlParameterArray(params object[] nameTypeValue)
        {
            if ((nameTypeValue.Length % 3) != 0)
            {
                throw new CustomExceptionHandler("Name/Type/Value is unbalanced");
            }

            int argCount = nameTypeValue.Length / 3;
            SqlParameter[] args = new SqlParameter[argCount];
            for (int arg = 0, ntv = 0; arg < argCount; ++arg, ntv += 3)
            {
                args[arg] = new SqlParameter((string)nameTypeValue[ntv], (SqlDbType)nameTypeValue[ntv + 1]);
                args[arg].Value = nameTypeValue[ntv + 2];
            }

            return args;
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void ExecuteNonQuery(string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            Execute(ExecuteType.ExecuteNonQuery, connectionString, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void ExecuteNonQuery(SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            Execute(ExecuteType.ExecuteNonQuery, connection, null, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="transaction">Transaction associated with the open connection</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string storedProcedureName, params SqlParameter[] args)
        {
            Execute(ExecuteType.ExecuteNonQuery, connection, transaction, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            return (SqlDataReader)Execute(ExecuteType.ExecuteReader, connectionString, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            return (SqlDataReader)Execute(ExecuteType.ExecuteReader, connection, null, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="transaction">Transaction associated with the open connection</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(SqlConnection connection, SqlTransaction transaction, string storedProcedureName, params SqlParameter[] args)
        {
            return (SqlDataReader)Execute(ExecuteType.ExecuteReader, connection, transaction, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            return Execute(ExecuteType.ExecuteScalar, connectionString, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            return Execute(ExecuteType.ExecuteScalar, connection, null, storedProcedureName, args);
        }

        /// <summary>
        /// Simple wrapper around like-named ADO.NET method.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="transaction">Transaction associated with the open connection</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(SqlConnection connection, SqlTransaction transaction, string storedProcedureName, params SqlParameter[] args)
        {
            return Execute(ExecuteType.ExecuteScalar, connection, transaction, storedProcedureName, args);
        }

        /// <summary>
        /// This method flushes the procedure cache maintained by SQL Server. A potential use of this method is in the
        /// context of gathering timing information for stored procedures and we don't want that data to be skewed by
        /// any existing cache contents.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        public static void FlushProcedureCache(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                FlushProcedureCache(connection);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// This method flushes the procedure cache maintained by SQL Server. A potential use of this method is in the
        /// context of gathering timing information for stored procedures and we don't want that data to be skewed by
        /// any existing cache contents.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        public static void FlushProcedureCache(SqlConnection connection)
        {
            (new SqlCommand("dbcc freeproccache", connection)).ExecuteNonQuery();
        }

        /// <summary>
        /// Return a DataSet populated by executing the specified stored procedure.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return GetDataSet(connection, storedProcedureName, args);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Return a DataSet populated by executing the specified stored procedure.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            return GetDataSet(connection, null, storedProcedureName, args);
        }

        /// <summary>
        /// Return a DataSet populated by executing the specified stored procedure.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="transaction">Transaction (if any) associated with the open connection</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(SqlConnection connection, SqlTransaction transaction, string storedProcedureName, params SqlParameter[] args)
        {

            Exception exc = null;

            DataSet ds = new DataSet();

            if (connection.State != ConnectionState.Open)
            {
                throw new CustomExceptionHandler("Connection is not open");
            }

            connection.FireInfoMessageEventOnUserErrors = true;

            //since this method is a static method, we need to find a way to share the exc object back to this function.
            //Previosly a a global static object was used but it cause cross talk between the threads as the static
            //objects are share across the threads. By using anonymous delegates we can share the exc variable which is
            //a stack variable above and when the delegate executes it is dealing with a local stack variable and which
            //is going to be different for every thread.
            SqlInfoMessageEventHandler evtHandler = delegate(object sender, SqlInfoMessageEventArgs e)
            {
                if (Convert.ToInt32(e.Errors[0].Class) != 0)
                {
                    exc = new CustomExceptionHandler(e.Message);
                }
            };

            connection.InfoMessage += evtHandler;

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            command.CommandTimeout = 10020;

            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if ((args != null) && (args.Length > 0))
            {
                foreach (SqlParameter p in args)
                {
                    command.Parameters.Add(p);
                }
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            if (exc != null)
            {
                throw exc;
            }

            return ds;
        }

        /// <summary>
        /// Return a loaded DataTable by executing the specified stored procedure.
        /// </summary>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>Loaded DataTable</returns>
        public static DataTable GetDataTable(string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return GetDataTable(connection, storedProcedureName, args);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Return a loaded DataTable by executing the specified stored procedure.
        /// </summary>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>Loaded DataTable</returns>
        public static DataTable GetDataTable(SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            if (connection.State != ConnectionState.Open)
            {
                throw new CustomExceptionHandler("Connection is not open");
            }

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;
                if ((args != null) && (args.Length > 0))
                {
                    foreach (SqlParameter p in args)
                    {
                        command.Parameters.Add(p);
                    }
                }

                DataTable dt = new DataTable();
                (new SqlDataAdapter(command)).Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e; //new Exception(String.Format("Failed to execute {0}", storedProcedureName), e);
            }
        }

        /// <summary>
        /// Load the specified DataSet by executing the specified stored procedure. Note that the load occurs
        /// within the DataTable whose name is specified. This is useful in loading a single DataSet with
        /// multiple DataTables.
        /// </summary>
        /// <param name="ds">Instance of the DataSet to load</param>
        /// <param name="tableName">Name of the DataTable within the DataSet to load into</param>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void LoadDataSet(DataSet ds, string tableName, string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                LoadDataSet(ds, tableName, connection, storedProcedureName, args);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Load the specified DataSet by executing the specified stored procedure. Note that the load occurs
        /// within the DataTable whose name is specified. This is useful in loading a single DataSet with
        /// multiple DataTables.
        /// </summary>
        /// <param name="ds">Instance of the DataSet to load</param>
        /// <param name="tableName">Name of the DataTable within the DataSet to load into</param>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void LoadDataSet(DataSet ds, string tableName, SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            if (connection.State != ConnectionState.Open)
            {
                throw new CustomExceptionHandler("Connection is not open");
            }

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;
                if ((args != null) && (args.Length > 0))
                {
                    foreach (SqlParameter p in args)
                    {
                        command.Parameters.Add(p);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                if (tableName != null)
                {
                    adapter.Fill(ds, tableName);
                }
                else
                {
                    adapter.Fill(ds);
                }
            }
            catch (Exception e)
            {
                throw e; //new Exception(String.Format("Failed to execute {0}", storedProcedureName), e);
            }
        }

        /// <summary>
        /// Load the specified DataTable by executing the specified stored procedure.
        /// </summary>
        /// <param name="dt">DataTable to load</param>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void LoadDataTable(DataTable dt, string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                LoadDataTable(dt, connection, storedProcedureName, args);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Load the specified DataTable by executing the specified stored procedure.
        /// </summary>
        /// <param name="dt">DataTable to load</param>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        public static void LoadDataTable(DataTable dt, SqlConnection connection, string storedProcedureName, params SqlParameter[] args)
        {
            if (connection.State != ConnectionState.Open)
            {
                throw new CustomExceptionHandler("Connection is not open");
            }

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                if ((args != null) && (args.Length > 0))
                {
                    foreach (SqlParameter p in args)
                    {
                        command.Parameters.Add(p);
                    }
                }

                (new SqlDataAdapter(command)).Fill(dt);
            }
            catch (Exception e)
            {
                throw e; //new Exception(String.Format("Failed to execute {0}", storedProcedureName), e);
            }
        }

        /// <summary>
        /// This methods normalizes the specified connection string for acceptance by the SQL data provider.
        /// The connection string for the SQL data provider MUST NOT specify the "Provider" property
        /// (since it is always going to be SQL).
        /// </summary>
        /// <param name="connectionString">Original connection string</param>
        /// <returns>Normalized connection string</returns>
        public static string NormalizeConnectionString(string connectionString)
        {
            return Regex.Replace(connectionString, @"Provider=[^;]+;", "", RegexOptions.IgnoreCase);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Helper method that handles the Execute* class of ADO.NET methods. Since the bulk of that logic
        /// is identical, it has been factored into this single method.
        /// </summary>
        /// <param name="type">One of ExecuteReader, ExecuteScalar, ExecuteNonQuery</param>
        /// <param name="connectionString">Connection parameters specific to the data provider</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>object</returns>
        private static object Execute(ExecuteType type, string connectionString, string storedProcedureName, params SqlParameter[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return Execute(type, connection, null, storedProcedureName, args);
            }
            catch (Exception e)
            {
                throw e; //new Exception(String.Format("Failed to execute {0}", storedProcedureName), e);
            }
            finally
            {
                // We should not close the connection if we are returning a reader! If we did, then the reader
                // would be invalid (and useless to the caller).

                if ((type != ExecuteType.ExecuteReader) && (connection.State != ConnectionState.Closed))
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Helper method that handles the Execute* class of ADO.NET methods. Since the bulk of that logic
        /// is identical, it has been factored into this single method.
        /// </summary>
        /// <param name="type">One of ExecuteReader, ExecuteScalar, ExecuteNonQuery</param>
        /// <param name="connection">An open instance of the SqlConnection object</param>
        /// <param name="transaction">Transaction (if any) associated with the open connection</param>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="args">Optional list of parameters to be passed to the stored procedure</param>
        /// <returns>object</returns>
        private static object Execute(ExecuteType type, SqlConnection connection, SqlTransaction transaction,
        string storedProcedureName, params SqlParameter[] args)
        {
            Exception exc = null;

            if (connection.State != ConnectionState.Open)
            {
                throw new CustomExceptionHandler("Connection is not open");
            }

            connection.FireInfoMessageEventOnUserErrors = true;

            //since this method is a static method, we need to find a way to share the exc object back to this function.
            //Previosly a a global static object was used but it cause cross talk between the threads as the static
            //objects are share across the threads. By using anonymous delegates we can share the exc variable which is
            //a stack variable above and when the delegate executes it is dealing with a local stack variable and which
            //is going to be different for every thread.
            SqlInfoMessageEventHandler evtHandler = delegate(object sender, SqlInfoMessageEventArgs e)
            {
                if (Convert.ToInt32(e.Errors[0].Class) != 0)
                {
                    exc = new CustomExceptionHandler(e.Message);
                }
            };

            connection.InfoMessage += evtHandler;

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            // command.CommandTimeout = Settings.GetKeyValue("Database.CommandTimeout", 0);
            command.CommandTimeout = 10020;
            if (transaction != null)
            {
                command.Transaction = transaction;
            }

            if ((args != null) && (args.Length > 0))
            {
                foreach (SqlParameter p in args)
                {
                    command.Parameters.Add(p);
                }
            }

            switch (type)
            {
                case

                    ExecuteType.ExecuteNonQuery:
                    object o = command.ExecuteNonQuery();

                    if (exc != null)
                    {
                        throw exc;
                    }
                    return o;

                case ExecuteType.ExecuteReader:
                    return command.ExecuteReader(CommandBehavior.CloseConnection);

                case ExecuteType.ExecuteScalar:
                    return command.ExecuteScalar();
            }

            throw new CustomExceptionHandler(String.Format("Unsupported ExecuteType '{0}'", type));
        }

        #endregion

        #region Extra Methods
        //private DataSet getDataSet(string ProcedureName, SqlParameter[] sqlparams)
        //{
        //    SqlDatabase db = new SqlDatabase(WebConfigurationManager.ConnectionStrings[1].ConnectionString);
        //    SqlCommand command = new SqlCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = ProcedureName;
        //    command.Parameters.AddRange(sqlparams);
        //    command.CommandTimeout = 30;
        //    DataSet ds = new DataSet();
        //    db.LoadDataSet(command, ds, "Profiles");
        //    return ds;
        //}
        #endregion
    }
}
