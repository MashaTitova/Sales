using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Transactions;
using System.Windows.Forms;

namespace ClassLibrarySales
{
    /// <summary>
    /// Связь с базой данных
    /// </summary>
    public class DatabaseHelper
    {
        public static string GetConnectionString(string databasePath)
        {
            // Если драйвер есть — формируем строку подключения
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }
        public static bool IsAceOleDb12Installed()
        {
            try
            {
                var enumerator = new System.Data.OleDb.OleDbEnumerator();
                var dataTable = enumerator.GetElements();

                foreach (System.Data.DataRow row in dataTable.Rows)
                {
                    string providerName = row["SOURCES_NAME"]?.ToString();
                    // Проверяем наличие нужного драйвера
                    if (providerName == "Microsoft.ACE.OLEDB.12.0")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false; 
            }
        }
        /// <summary>
        /// Получение данных по запросу
        /// </summary>
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

        /// <summary>
        /// Получение заголовков всех таблиц в бд
        /// </summary>
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
        /// <summary>
        /// Хеширование паролей
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

    }
}

