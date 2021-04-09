using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace TaskAPI.Config
{
    public class Connection
    {
        public SqlConnection ConnectionString()
        {
            return new SqlConnection("Data Source=DESKTOP-EVFTCMO\\MSSQLSERVER01;Initial Catalog=efectura;Integrated Security=True");
        }

        public int Execute(string query)
        {
            var connection = ConnectionString();
            var command = new SqlCommand(query, connection);
            command.Connection.Open();
            var affectedRow = 0;
            try { affectedRow = command.ExecuteNonQuery(); }
            catch {/**/}
            finally { command.Connection.Close(); connection.Dispose(); GC.SuppressFinalize(connection); command.Dispose(); GC.SuppressFinalize(command); }
            return affectedRow;
        }

        public DataTable GetDataTable(string query)
        {
            var connection = ConnectionString();
            connection.Open();
            var adapter = new SqlDataAdapter(query, connection);
            var dataTable = new DataTable();
            try { adapter.Fill(dataTable); }
            catch {/**/}
            finally { connection.Close(); connection.Dispose(); GC.SuppressFinalize(connection); adapter.Dispose(); GC.SuppressFinalize(adapter); }
            return dataTable;
        }


        public List<T> DataTableToModelList<T>(DataTable dataTable) where T : class, new()
        {
            if (dataTable == null) return null;
            var modelList = new List<T>();
            foreach (var row in dataTable.AsEnumerable())
            {
                var model = new T();
                foreach (var prop in model.GetType().GetProperties())
                {
                    var propertyInfo = model.GetType().GetProperty(prop.Name);
                    propertyInfo.SetValue(model, Convert.ChangeType((row[prop.Name] == DBNull.Value) ? string.Empty : row[prop.Name], propertyInfo.PropertyType), null);
                }
                modelList.Add(model);
            }
            return modelList;
        }

    }
}