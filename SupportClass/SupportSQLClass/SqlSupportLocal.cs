using Microsoft.Win32;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using MyWinFormsApp.SupportClass.SupportSQLClass;
using Microsoft.Data.Sql;

namespace SQLSupportLibrary
    {
        class Sqlsupportlocal : ISqlSupport
        {
            private readonly string? _connection_server;
            /// <summary>
            /// If set to 'true', allows method to send a debug messages through Console.
            /// </summary>
            public bool _isDebugShow { get; set; }



        public Sqlsupportlocal(string database)
        {
            try
            {
                    _connection_server = $"Server={GetSQLServerInstance};Database={database};Integrated Security=True;TrustServerCertificate=True;";
            }
            catch (Exception e)
            {
                if (_isDebugShow) Console.WriteLine($"\n\n//ERROR: " + e.Message);
            }
        }


        /// <summary>
        /// SQLSupport class allows you to easily connect into your own Database. Automatically finds the Server instance of the SQLEXPRESS
        /// </summary>
        /// <param name="database"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public Sqlsupportlocal(string database, string user = null, string password = null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    {
                        _connection_server = $"Server={GetSQLServerInstance};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";
                    }
                    else
                    {
                        _connection_server = $"Server={GetSQLServerInstance};Database={database};Integrated Security=True;TrustServerCertificate=True;";
                    }
                }
                catch (Exception e)
                {
                    if (_isDebugShow) Console.WriteLine($"\n\n//ERROR: " + e.Message);
                }
            }


            /// <summary>
            /// SQLSupport class allows you to easily connect into your own Database. 
            /// - SSMS is the only known compatible for this class
            /// </summary>
            /// <param name="server">a name of a server string which you can get on SSMS Server tag</param>
            /// <param name="database">a string name of your Database</param>
            /// <param name="user">If has no User Hierarchy, leave it null</param>
            /// <param name="password">If has no User Hierarchy and password, leave it null</param>


            public Sqlsupportlocal(string server, string database, string user = null, string password = null)
            {
                try
                {
                    if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
                    {
                        _connection_server = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";
                    }
                    else
                    {
                        _connection_server = $"Server={server};Database={database};Integrated Security=True;TrustServerCertificate=True;";
                    }
                }
                catch (Exception e)
                {
                    if (_isDebugShow) Console.WriteLine($"\n\n//ERROR: " + e.Message);
                }
            }


        /// <summary>
        /// Return a server Instance of SQLEXPRESS
        /// </summary>
        /// <returns></returns>
#pragma warning disable CA1416
        private string GetSQLServerInstance()
        {
            var dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in dt.Rows)
            {
                if (row["InstanceName"] != DBNull.Value && row["InstanceName"].ToString() == "SQLEXPRESS")
                {
                    return $"{row["ServerName"]}\\SQLEXPRESS";
                }
            }
            return $"{Environment.MachineName}\\SQLEXPRESS"; // Default fallback
        }



        /// <summary>
        /// Executes a SQL query asynchronously and returns the result as a DataTable.
        /// </summary>
        public async Task<DataTable> ExecuteQueryAsync(string query)
            {
                if (_isDebugShow) Console.WriteLine($"Executing Query: {query}");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            await Task.Run(() => adapter.Fill(dt));
                            return dt;
                        }
                    }
                }
            }


            /// <summary>
            /// Execute a command Query
            /// </summary>
            /// <param name="query"></param>
            /// <returns>Returns a DataTable</returns>
            public DataTable ExecuteQuery(string query)
            {
                if (_isDebugShow) Console.WriteLine($"Executing Query: {query}");

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey; // Ensures schema is fully loaded
                            adapter.Fill(dt);
                        }
                    }
                }
                Console.WriteLine($"DEBUG// Rows Retrieved: {dt.Rows.Count}");
                return dt;
            }



            /// <summary>
            /// Executes a stored procedure asynchronously and returns the result as a DataTable.
            /// </summary>
            public async Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, params SqlParameter[] parameters)
            {
                if (_isDebugShow) Console.WriteLine($"Executing Stored Procedure: {procedureName}");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            await Task.Run(() => adapter.Fill(dt));
                            return dt;
                        }
                    }
                }
            }


            /// <summary>
            /// Performs bulk insertion of a DataTable into a specified SQL table asynchronously.
            /// </summary>
            public async Task BulkInsertAsync(DataTable dataTable, string destinationTable)
            {
                if (_isDebugShow) Console.WriteLine($"Performing Bulk Insert into {destinationTable}");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = destinationTable;
                        await bulkCopy.WriteToServerAsync(dataTable);
                    }
                }
            }


            /// <summary>
            /// Executes multiple queries within a single transaction asynchronously.
            /// </summary>
            public async Task<bool> ExecuteTransactionAsync(params string[] queries)
            {
                if (_isDebugShow) Console.WriteLine("Executing Transaction");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (string query in queries)
                            {
                                using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                                {
                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }
                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }


            /// <summary>
            /// Tests the database connection with multiple retry attempts.
            /// </summary>
            public async Task<bool> TestConnectionWithRetryAsync(int maxAttempts = 3)
            {
                int attempt = 0;
                while (attempt < maxAttempts)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(_connection_server))
                        {
                            await conn.OpenAsync();
                            if (_isDebugShow) Console.WriteLine("Database Connection Successful");
                            return true;
                        }
                    }
                    catch
                    {
                        attempt++;
                        if (_isDebugShow) Console.WriteLine($"Database Connection Attempt {attempt} Failed");
                        await Task.Delay(1000);
                    }
                }
                return false;
            }


            /// <summary>
            /// Executes a SQL query asynchronously and logs the query.
            /// </summary>
            public async Task<int> ExecuteNonQueryWithLoggingAsync(string query)
            {
                if (_isDebugShow) Console.WriteLine($"Executing Non-Query with Logging: {query}");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        await LogQueryAsync(query);
                        return rowsAffected;
                    }
                }
            }


            /// <summary>
            /// Executes a SQL query safely with parameters asynchronously.
            /// </summary>
            public async Task<int> ExecuteNonQuerySafeAsync(string query, params SqlParameter[] parameters)
            {
                if (_isDebugShow) Console.WriteLine($"Executing Safe Non-Query: {query}");
                using (SqlConnection conn = new SqlConnection(_connection_server))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        return await cmd.ExecuteNonQueryAsync();
                    }
                }
            }


            /// <summary>
            /// Inserts data into a specified SQL table safely using parameters with Async Keyword that uses await keyword.
            /// </summary>
            public async Task<bool> InsertDataAsync(string tableName, Dictionary<string, object> data)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connection_server))
                    {
                        await conn.OpenAsync();

                        string columns = string.Join(", ", data.Keys);
                        string parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
                        string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                        if (_isDebugShow)
                        {
                            Console.WriteLine($"Executing Query: {query}");
                            foreach (var item in data)
                            {
                                Console.WriteLine($"Param {item.Key}: {item.Value}");
                            }
                        }

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            foreach (var item in data)
                            {
                                cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                            }

                            int rowsAffected = await cmd.ExecuteNonQueryAsync();

                            if (_isDebugShow) Console.WriteLine($"Rows Affected: {rowsAffected}");

                            return rowsAffected > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_isDebugShow) Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
            }


            /// <summary>
            /// Inserts data into a specified SQL table safely using parameters.
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="data"></param>
            /// <returns></returns>
            public bool InsertData(string tableName, Dictionary<string, object> data)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connection_server))
                    {
                        conn.Open();

                        string columns = string.Join(", ", data.Keys);
                        string parameters = string.Join(", ", data.Keys.Select(k => "@" + k));
                        string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";

                        if (_isDebugShow) // Debugging Enabled
                        {
                            Console.WriteLine($"Executing Query: {query}");
                            foreach (var item in data)
                            {
                                Console.WriteLine($"Param {item.Key}: {item.Value}");
                            }
                        }
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            foreach (var item in data)
                            {
                                cmd.Parameters.AddWithValue("@" + item.Key, item.Value ?? DBNull.Value);
                            }
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (_isDebugShow) Console.WriteLine($"Rows Affected: {rowsAffected}");
                            return rowsAffected > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_isDebugShow) System.Diagnostics.Debug.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
            }
        
        public bool InsertData(string tableName, List<object> value)//INCOMPLETE
        {
            try
            {
                string query = $"INSERT INTO {tableName} VALUES ";
                string _value = "";
                foreach (object item in value)
                {
                    if (item is string str)
                    {

                    }
                    else
                    {
                        
                    }
                }
                return true;
            }catch(Exception ex)
            {
                if (_isDebugShow) Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
        }


            /// <summary>
            /// Insert data through uses of Dictionary enum and returns the last increment id
            /// </summary>
            /// <param name="tableName"></param>
            /// <param name="data"></param>
            /// <param name="idColumn"></param>
            /// <returns></returns>
            public int InsertDataAndGetId(string tableName, Dictionary<string, object> data, string idColumn = "id")
            {
                try
                {
                string values = string.Join(", ", data.Values.Select(v =>
                    v is string ? $"'{v}'" :
                    v is DateTime dt ? $"'{dt:yyyy-MM-dd HH:mm:ss}'" : // Correct date format for SQL
                    v is bool b ? (b ? "1" : "0") : // Convert bool to 1/0 for SQL compatibility
                    v != null ? v.ToString() : "NULL" // Handle null values
                ));

                string query = $"INSERT INTO {tableName} ({string.Join(", ", data.Keys)}) " +
                                   $"VALUES ({values}); " +
                                   $"SELECT {idColumn} FROM {tableName} WHERE {idColumn} = SCOPE_IDENTITY();";

                    DataTable dt = ExecuteQuery(query);
                    int id = Convert.ToInt32(dt.Rows[0][0]);
                    if (dt.Rows.Count > 0)
                    {
                        return id; // Get the first row, first column
                    }
                    else
                    {
                        Console.WriteLine("No data returned.");
                        return -1; // Indicate failure
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"SQL Error: {ex.Message}");
                    return -1; // Indicate failure
                }
            }


            /// <summary>
            /// Removes any harmful keyword or character that will be inserted in Database.
            /// - Uses on user input.
            /// </summary>
            /// <param name="input">User original input</param>
            /// <returns>Filtered user input as string</returns>
            public string FilterQuery(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return string.Empty;

                // Escape single quotes by doubling them (' becomes '')
                string filtered = input.Replace("'", "''");

                // Remove dangerous SQL keywords (basic protection)
                string[] blacklist = ["DROP", "DELETE", "INSERT", "UPDATE", "--", ";", "xp_cmdshell", "EXEC", "UNION", "ALTER"];

                foreach (string word in blacklist)
                {
                    filtered = Regex.Replace(filtered, @"\b" + word + @"\b", "", RegexOptions.IgnoreCase);
                }

                return filtered.Trim();
            }

        public bool DoesDataExist(string table_name, string column_name, object data_to_be_check)
        {
            if (data_to_be_check == null) return false; // Handle null cases early

            string query = $"SELECT COUNT(*) AS Count FROM {table_name} WHERE {column_name} = '{data_to_be_check}' AND is_deleted = 0;";
            DataTable result = ExecuteQuery(query);
            return result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0]["Count"]) > 0;
        }



#pragma warning disable CS1998
        private async Task LogQueryAsync(string query)
            {
                throw new NotImplementedException();
            }


        }
    }

