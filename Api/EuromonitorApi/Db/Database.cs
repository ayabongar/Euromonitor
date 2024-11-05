using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EuromonitorApi.Db
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("EuromonitorConnection");
        }

        public DataTable ExecuteStoredProcedure(string storedProcName, SqlParameter[] parameters = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(storedProcName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public List<T> ConvertDataTable<T>(DataTable dt) where T : new()
        {
            var data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (dt.Columns.Contains(prop.Name) && !DBNull.Value.Equals(row[prop.Name]))
                    {
                        prop.SetValue(item, row[prop.Name]);
                    }
                }
                data.Add(item);
            }
            return data;
        }

    }
}
