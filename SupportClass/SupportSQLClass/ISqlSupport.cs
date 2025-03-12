using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.SupportClass.SupportSQLClass
{
    //Uses interface incase for the integration of System if my code is still required but another class is needed
    public interface ISqlSupport
    {
        /// <inheritdoc/>
        public bool _isDebugShow { get; set; }
        /// <inheritdoc/>
        public Task<DataTable> ExecuteQueryAsync(string query);
        /// <inheritdoc/>
        public DataTable ExecuteQuery(string query);
        /// <inheritdoc/>
        public Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, params SqlParameter[] parameters);
        /// <inheritdoc/>
        public Task BulkInsertAsync(DataTable dataTable, string destinationTable);
        /// <inheritdoc/>
        public Task<bool> ExecuteTransactionAsync(params string[] queries);
        /// <inheritdoc/>
        public Task<bool> TestConnectionWithRetryAsync(int maxAttempts = 3);
        /// <inheritdoc/>
        public Task<int> ExecuteNonQueryWithLoggingAsync(string query);
        /// <inheritdoc/>
        public Task<int> ExecuteNonQuerySafeAsync(string query, params SqlParameter[] parameters);
        /// <inheritdoc/>
        public Task<bool> InsertDataAsync(string tableName, Dictionary<string, object> data);
        /// <inheritdoc/>
        public bool InsertData(string tableName, Dictionary<string, object> data);
        /// <inheritdoc/>
        public int InsertDataAndGetId(string tableName, Dictionary<string, object> data, string idColumn = "id");
    }
}
