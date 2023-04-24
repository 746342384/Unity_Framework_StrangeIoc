using System;
using System.Collections.Generic;
using System.Data;
using Cysharp.Threading.Tasks;
using Framework.framework.log;
using LitJson;
using MySql.Data.MySqlClient;

namespace Framework.framework.repository
{
    public class DbConfigLoader : IConfigLoader
    {
        private readonly ILog _log;

        public DbConfigLoader(ILog log)
        {
            _log = log;
        }

        public string BasePath { get; set; }

        public async UniTask<List<T>> LoadConfigData<T>(string tableName)
        {
            var query = $"SELECT * FROM `{tableName}`";
            var dataTable = await ExecuteQuery(query);

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

                    var json = JsonMapper.ToJson(configData);
                    _log.Debug($"LoadConfigData:{json}");
                    configDataList.Add(configData);
                }

                return configDataList;
            }


            return new List<T>();
        }

        private async UniTask<DataTable> ExecuteQuery(string query)
        {
            await using var connection = new MySqlConnection(BasePath);
            await connection.OpenAsync();
            var dataTable = new DataTable();
            await using (var command = new MySqlCommand(query, connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    dataTable.Load(reader);
                }
            }

            await connection.CloseAsync();

            return dataTable;
        }
    }
}