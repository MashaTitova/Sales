using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace ClassLibrarySales
{
    /// <summary>
    /// Класс бизнес-логики приложения для работы с данными о продажах
    /// Инкапсулирует операции 
    /// </summary>
    public class LogicLayer
    {
        // Экземпляр слоя доступа к данным
        private DataAccess _dataAccess;
        /// <summary>
        /// Конструктор класса LogicLayer
        /// Инициализирует экземпляр DataAccess с указанным путём к файлу базы данных
        /// </summary>
        /// <param name="basePath">Путь к файлу базы данных Access</param>
        public LogicLayer(string basePath)
        {
            _dataAccess = new DataAccess(basePath);
        }
        /// <summary>
        /// Проверяет наличие установленного драйвера Microsoft.ACE.OLEDB.12.0.
        /// </summary>
        /// <returns>True, если драйвер установлен; иначе — false.</returns>
        public bool OleDb12Installed()
        {
            return _dataAccess.IsAceOleDb12Installed() ? true : false;
        }
        /// <summary>
        /// Получение всех данных из таблицы
        /// </summary>
        /// <param name="tableName">Имя таблицы в БД Access.</param>
        /// <returns>DataTable, содержащий все строки и столбцы запрошенной таблицы.</returns>
        public DataTable Read(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return _dataAccess.GetData(query);
        }
        /// <summary>
        /// Получение заголовков всех таблиц в бд
        /// </summary>
        /// <returns>Список строк с именами таблиц.</returns>
        public List<string> GetTableNames()
        {
            return _dataAccess.GetAllTableNames();
        }
        /// <summary>
        /// Аутентификация пользователя по логину и паролю
        /// </summary>
        /// <param name="enteredPassword">Введённый пользователем пароль (в открытом виде)</param>
        /// <param name="entredLogin">Введённый пользователем логин</param>
        /// <param name="message">Выходной параметр: сообщение об успехе/ошибке аутентификации</param>
        /// <returns>Строковое представление индекса прав пользователя при успешной аутентификации; иначе — пустая строка.</returns>
        public string GetAuthentication(string enteredPassword, string entredLogin, out string message)
        {
            // Хешируем введённый пароль
            string hashedEnteredPassword = _dataAccess.HashPassword(enteredPassword);

            string query = "SELECT Пользователи.ИмяПользователя, Пользователи.Пароль, Пользователи.КодПравПользователя, ПраваПользователей.ПраваПользователя " +
                          "FROM Пользователи " +
                          "INNER JOIN ПраваПользователей ON Пользователи.КодПравПользователя = ПраваПользователей.КодПравПользователя " +
                          "WHERE Пользователи.ИмяПользователя = @Login";

                string userRigtsIndex = _dataAccess.Authentication(query, entredLogin, hashedEnteredPassword, out message);
                return userRigtsIndex;
        }
        /// <summary>
        /// Проверяет существование пользователя с указанным логином в таблице Пользователи.
        /// </summary>
        /// <param name="login">Проверяемый логин.</param>
        /// <returns>True, если пользователь с таким логином существует; иначе — false.</returns>
        public bool UserExistance(string login)
        {
            string checkUserQuery = "SELECT COUNT(*) FROM Пользователи WHERE ИмяПользователя = @Login";
            return _dataAccess.IsUserExists(login, checkUserQuery);
        }
        /// <summary>
        /// Регистрирует нового пользователя в системе
        /// Сохраняет логин и хешированный пароль в таблице Пользователи с правами по умолчанию
        /// </summary>
        /// <param name="newLogin">Новый логин</param>
        /// <param name="newPassword">Новый пароль (в открытом виде)</param>
        /// <param name="message">Выходной параметр: сообщение о результате операции</param>
        public void UserReg(string newLogin, string newPassword, out string message)
        {
            // Хеширование пароля
            string hashedPassword = _dataAccess.HashPassword(newPassword);
            // Добавление нового пользователя в таблицу Пользователи
            string insertUserQuery =
            "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) " +
            "VALUES (?, ?, ?)";
            _dataAccess.Registration(insertUserQuery, newLogin, hashedPassword, out message);
        }
        /// <summary>
        /// Получает текстовое название уровня доступа по его индексу из таблицы ПраваПользователей
        /// </summary>
        /// <returns>Строка с названием прав</returns>
        public string ShowUserRights()
        {
            return _dataAccess.GetNameFromIndex();
        }
        /// <summary>
        /// Сохраняет изменения из DataTable в соответствующую таблицу базы данных Access
        /// </summary>
        /// <param name="data">DataTable с изменёнными данными</param>
        /// <param name="nameOfTable">Имя целевой таблицы в БД</param>
        public void SaveToAccess(DataTable data, string nameOfTable)
        {
            string query = $"SELECT * FROM [{nameOfTable}]";
            _dataAccess.SaveToAccess(data, query);
        }
        /// <summary>
        /// Хеширование введенного пароля
        /// </summary>
        /// <param name="password">Исходный пароль в открытом виде</param>
        /// <returns>Хешированная строка пароля</returns>
        public string HashUserInput(string password)
        {
            return _dataAccess.HashPassword(password);
        }
        /// <summary>
        /// Выполняет сортировку данных указанной таблицы по заданному столбцу и направлению
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="columnName">Имя столбца для сортировки</param>
        /// <param name="direction">Направление сортировки: "Возрастание" или "Убывание"</param>
        /// <returns>DataTable с отсортированными данными</returns>
        public DataTable SortData(string tableName, string columnName, string direction)
        {
            string sortDirection = direction == "Возрастание" ? "ASC" : "DESC";
            string query = $"SELECT * FROM [{tableName}] ORDER BY [{columnName}]{sortDirection}";
            return _dataAccess.GetData(query);
           
        }
        /// <summary>
        /// Фильтрует данные таблицы по строковому значению в заданном столбце
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="columnName">Имя столбца для фильтрации</param>
        /// <param name="value">Искомое значение</param>
        /// <returns>DataTable с отфильтрованными данными</returns>
        public DataTable FilterString(string tableName, string columnName, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE [{columnName}] LIKE ?";
            return _dataAccess.Filter(query, value);
        }

        /// <summary>
        /// Фильтрует данные таблицы по числовому значению с использованием заданного оператора сравнения
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="columnName">Имя столбца для фильтрации</param>
        /// <param name="ratio">Оператор сравнения (например, ">", "<=", "=")</param>
        /// <param name="value">Значение для сравнения</param>
        /// <returns>DataTable с отфильтрованными данными</returns>
        public DataTable FilterNum(string tableName, string columnName, string ratio, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE [{columnName}] {ratio} @value";
            return _dataAccess.Filter(query, value);
        }
        /// <summary>
        /// Выполняет группировку данных таблицы по указанному столбцу с подсчётом количества записей в каждой группе
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="columnName">Имя столбца для группировки</param>
        /// <returns>DataTable с результатами группировки (столбец группировки и столбец количества записей)</returns>
        public DataTable GroupData(string tableName, string columnName)
        {
            string query = $"SELECT [{columnName}], COUNT(*) AS {tableName}Количество " +
                $"FROM [{tableName}]" +
                $"GROUP BY [{columnName}]";
            return _dataAccess.GetData(query);
        }
    }
}
