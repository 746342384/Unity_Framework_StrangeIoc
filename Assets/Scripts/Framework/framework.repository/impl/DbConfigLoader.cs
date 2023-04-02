using System;
using System.Collections.Generic;
using System.Data;
using Cysharp.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Framework.framework.repository
{
    public class DbConfigLoader : IConfigLoader
    {
        public string BasePath { get; set; }

        public async UniTask<List<T>> LoadConfigData<T>(string tableName)
        {
            var query = $"SELECT * FROM {tableName}";
            var dataTable = await ExecuteQueryAsync(query);

            if (dataTable != null)
            {
                var configDataList = new List<T>();

                foreach (DataRow row in dataTable.Rows)
                {
                    var configData = Activator.CreateInstance<T>();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        var property = typeof(T).GetProperty(column.ColumnName);
                        if (property != null && row[column] != DBNull.Value)
                        {
                            property.SetValue(configData, Convert.ChangeType(row[column], property.PropertyType));
                        }
                    }

                    configDataList.Add(configData);
                }

                return configDataList;
            }


            return new List<T>();
        }

        private async UniTask<DataTable> ExecuteQueryAsync(string query)
        {
            var dataTable = new DataTable();

            await using var connection = new MySqlConnection(BasePath);
            await connection.OpenAsync();

            await using (var command = new MySqlCommand(query, connection))
            {
                await using (var reader = (MySqlDataReader)await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
            }

            await connection.CloseAsync();

            return dataTable;
        }
    }
}