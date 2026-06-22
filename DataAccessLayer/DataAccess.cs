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
        /// <summary>
        /// Формирует строку подключения к базе данных Microsoft Access с использованием провайдера ACE OLE DB 12.0
        /// </summary>
        /// <param name="databasePath">Путь к файлу базы данных</param>
        /// <returns>Строка подключения</returns>
        private string GetConnectionString(string databasePath)
        {
            // Если драйвер есть — формируем строку подключения
            return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }

        /// <summary>
        /// Проверка наличия нужного драйвера
        /// </summary>
        /// <returns>
        /// true<, если провайдер "Microsoft.ACE.OLEDB.12.0" найден в списке доступных OLE DB провайдеров; иначе false.
        /// </returns>
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
        /// <param name="query">SQL‑запрос</param>
        /// <returns>DataTable, заполненный результатами запроса.</returns>
        /// <exception cref="OleDbException">Выбрасывается при ошибке соединения или выполнения запроса.</exception>
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
        /// <returns>Список строк, содержащих имена таблиц</returns>
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
        /// Выполняет аутентификацию пользователя по логину и хешу пароля
        /// </summary>
        /// <param name="query">SQL‑запрос для поиска пользователя по логину</param>
        /// <param name="enteredLogin">Введённый пользователем логин</param>
        /// <param name="hashedEnteredPassword">Хеш введённого пароля</param>
        /// <param name="message">Выходной параметр: сообщение о результате операции</param>
        /// <returns>
        /// Индекс прав пользователя при успешной аутентификаци, иначе null
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
        public List<string> FindTablesWithColumn(string columnName)
        {
            var tableNames = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                // Получаем список всех таблиц
                DataTable tablesSchema = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });

                if (tablesSchema == null) return tableNames;

                foreach (DataRow tableRow in tablesSchema.Rows)
                {
                    string tableName = tableRow["TABLE_NAME"].ToString();

                    // Получаем схему столбцов для текущей таблицы
                    DataTable columnsSchema = connection.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Columns,
                        new object[] { null, null, tableName, null });

                    if (columnsSchema == null) continue;

                    foreach (DataRow colRow in columnsSchema.Rows)
                    {
                        string colName = colRow["COLUMN_NAME"].ToString();
                        if (colName.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            tableNames.Add(tableName);
                            break; 
                        }
                    }
                }
            }

            return tableNames;
        }
        public List<string> GetCodeAndFullNamePairsByIndex(string tableName, int codeColumnIndex, int fullNameColumnIndex)
        {
            var result = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                DataTable columnsSchema = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Columns,
                    new object[] { null, null, tableName, null });

                if (columnsSchema == null || columnsSchema.Rows.Count == 0)
                    return result;

                string codeColumnName = columnsSchema.Rows[codeColumnIndex]["COLUMN_NAME"].ToString();
                string fullNameColumnName = columnsSchema.Rows[fullNameColumnIndex]["COLUMN_NAME"].ToString();

                string query = $"SELECT [{codeColumnName}], [{fullNameColumnName}] " +
                               $"FROM [{tableName}] " +
                               $"WHERE [{codeColumnName}] IS NOT NULL AND [{fullNameColumnName}] IS NOT NULL " +
                               $"ORDER BY [{codeColumnName}]";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string code = reader.GetValue(0).ToString().Trim();
                        string fullName = reader.GetValue(1).ToString().Trim();
                        result.Add($"{code} - {fullName}");
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Проверка на существование пользователя с таким же логином
        /// </summary>
        /// <param name="login">Логин пользователя для проверки</param>
        /// <param name="checkUserQuery">SQL‑запрос, возвращающий количество пользователей с заданным логином</param>
        /// <returns>true, если пользователь с таким логином существует, иначе false</returns>
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
        /// <param name="insertUserQuery">SQL‑запрос INSERT для добавления пользователя (использует позиционные параметры "?")</param>
        /// <param name="newLogin">Логин нового пользователя</param>
        /// <param name="hashedPassword">Хеш пароля нового пользователя</param>
        /// <param name="message">Выходной параметр: сообщение о результате операции</param>
        public void Registration(string insertUserQuery, string newLogin, string hashedPassword, out string message)
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
        /// <returns>Название уровня доступа для индекса 4; пустая строка</returns>
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
        /// Сохранение таблицы в базу данных
        /// </summary>
        /// <param name="data">DataTable, содержащий изменённые данные</param>
        /// <param name="query">SELECT‑запрос</param>
        /// <exception cref="OleDbException">Выбрасывается при ошибке сохранения</exception>
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
        /// Выполняет фильтрацию данных по заданному значению с использованием оператора LIKE
        /// </summary>
        /// <param name="query">SQL‑запрос с позиционным параметром "?" для подстановки значения фильтрации</param>
        /// <param name="value">Значение для поиска (частичное совпадение)</param>
        /// <returns>DataTable, содержащий отфильтрованные результаты.</returns>
        public DataTable Filter(string query, string value)
        {
            DataTable result = new DataTable();

            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                connection.Open();

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", "%" + value + "%");
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }
     
        /// <summary>
        /// Создаёт хеш пароля с использованием алгоритма SHA‑256
        /// </summary>
        /// <param name="password">Исходный пароль в виде строки</param>
        /// <returns>Строка в формате Base64, представляющая хеш пароля</returns>
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

