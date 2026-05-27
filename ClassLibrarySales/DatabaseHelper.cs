using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;

namespace ClassLibrarySales
{
    public class DatabaseHelper
    {
        public static string GetConnectionString(string databasePath)
        {
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }

        public static (DataTable table, OleDbDataAdapter adapter) ReadData(string databasePath, string query)
        {
            DataTable result = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(databasePath)))
            {
                try
                {
                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);

                        // Создаём CommandBuilder для автоматического создания команд UPDATE/INSERT/DELETE
                        OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);
                        adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
                        adapter.InsertCommand = commandBuilder.GetInsertCommand();
                        adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

                        adapter.Fill(result);

                        return (result, adapter);
                    }
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine($"SQL ошибка: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Общая ошибка: {ex.Message}");
                    throw;
                }
            }
        }

        public static void SaveChanges(OleDbDataAdapter adapter, DataTable dataTable, string databasePath)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(GetConnectionString(databasePath)))
                {
                    if (adapter.SelectCommand != null)
                    {
                        adapter.SelectCommand.Connection = connection;
                    }

                    connection.Open();
                    adapter.Update(dataTable);
                    connection.Close();
                    Console.WriteLine("Изменения успешно сохранены в базе данных.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении: {ex.Message}");
                throw;
            }
        }

        public static List<string> GetAllTableNames(string databasePath)
        {
            List<string> tableNames = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(databasePath)))
            {
                try
                {
                    connection.Open();

                    DataTable schemaTable = connection.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Tables,
                        new object[] { null, null, null, "TABLE" });

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        tableNames.Add(row["TABLE_NAME"].ToString());
                    }
                }
                catch (OleDbException ex)
                {
                    Console.WriteLine($"Ошибка при получении списка таблиц: {ex.Message}");
                }
            }

            return tableNames;
        }
    }
}
