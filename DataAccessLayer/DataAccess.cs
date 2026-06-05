using System.Data;
using System.Data.OleDb;
using System.Transactions;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ClassLibrarySales
{
    /// <summary>
    /// Слой работы с данными
    /// </summary>
    public class DataAccess
    {
        private string _connectionString;
        public DataAccess(string basePath)
        {
            _connectionString = GetConnectionString(basePath);
        }
        private string GetConnectionString(string databasePath)
        {
            // Если драйвер есть — формируем строку подключения
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }

        /// <summary>
        /// Проверка наличия нужного драйвера
        /// </summary>
        public bool IsAceOleDb12Installed()
        {
            try
            {
                var enumerator = new System.Data.OleDb.OleDbEnumerator();
                // Получение списка провайдеров
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
        public DataTable GetData(string query)
        {
            DataTable result = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }

        /// <summary>
        /// Получение заголовков всех таблиц в бд
        /// </summary>
        public List<string> GetAllTableNames()
        {
            List<string> tableNames = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });

                if (schemaTable != null)
                {
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        tableNames.Add(row["TABLE_NAME"].ToString());
                    }
                }
            }

            return tableNames;
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        public string Authentication(string query, string enteredLogin, string hashedEnteredPassword, out string message)
        {
            message = "";
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", enteredLogin);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Сравниваем хеш из базы с введённым
                            string storedHash = reader["Пароль"].ToString();

                            if (storedHash == hashedEnteredPassword)
                            {
                                // Получаем права из связанной таблицы
                                string userRightsIndex = reader["КодПравПользователя"].ToString();
                                string userRights = reader["ПраваПользователя"].ToString();
                                message = "Вход выполнен успешно \n" +
                                    $"Ваш уровень доступа - {userRights}";
                                return userRightsIndex;
                            }
                            else
                            {
                                message =  "Неверный пароль";
                                return null;
                            }
                        }
                        else
                        {
                            message = "Пользователь не найден";
                            return null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Проверка на существование пользователя с таким же логином
        /// </summary>
        public bool IsUserExists(string login, string checkUserQuery)
        {
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(checkUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    // Получение количества пользователей с заданным логином
                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        public void Regicration(string insertUserQuery, string newLogin, string hashedPassword, out string message)
        {
            message = "";
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (OleDbCommand userCommand = new OleDbCommand(insertUserQuery, connection, transaction))
                        {
                            // Добавление данных в базу
                            userCommand.Parameters.AddWithValue("?", newLogin);
                            userCommand.Parameters.AddWithValue("?", hashedPassword);
                            userCommand.Parameters.AddWithValue("?", 4); 
                            int rowsAffected = userCommand.ExecuteNonQuery();
                            if (rowsAffected == 0)
                            {
                                throw new Exception("Не удалось добавить пользователя");
                            }
                        }

                        transaction.Commit();
                        message = "Пользователь успешно зарегистрирован\n";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        message = $"Ошибка при регистрации: {ex.Message}";
                    }
                }
            }
        }
        /// <summary>
        /// Получение названия уровня доступа по индексу
        /// </summary>
        public string GetNameFromIndex()
        {
            string getRightsQuery = "SELECT ПраваПользователя FROM ПраваПользователей WHERE КодПравПользователя = @RightsCode";
            string userRightsName = "";
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();
                using (OleDbTransaction transaction = connection.BeginTransaction())
                {
                    using (OleDbCommand rightsCommand = new OleDbCommand(getRightsQuery, connection, transaction))
                    {
                        rightsCommand.Parameters.AddWithValue("@RightsCode", 4); //4 - номер прав пользователя по умолчанию
                        object result = rightsCommand.ExecuteScalar();

                        if (result != null)
                        {
                            userRightsName = result.ToString();
                        }
                        return userRightsName;
                    }
                }
            }
        }
        /// <summary>
        /// Сохранение в базу данных
        /// </summary>
        public void SaveToAccess(DataTable data, string query)
        {
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                // Обновляем команды адаптера
                adapter.InsertCommand = builder.GetInsertCommand();
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.DeleteCommand = builder.GetDeleteCommand();

                adapter.Update(data);
            }
        }
        /// <summary>
        /// Фильтрация данных
        /// </summary>
        public DataTable Filter(string query, string value)
        {
            DataTable result = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", value);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }
        /// <summary>
        /// Хеширование паролей
        /// </summary>
        public string HashPassword(string password)
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

