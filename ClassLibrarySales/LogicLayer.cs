using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;

namespace ClassLibrarySales
{
    public class LogicLayer
    {
        /// <summary>
        /// Слой бмзнес-логики
        /// </summary>
        private DataAccess _dataAccess;
        public LogicLayer(string basePath)
        {
            _dataAccess = new DataAccess(basePath);
        }
        /// <summary>
        /// Проверка наличия нужного драйвера
        /// </summary>
        public bool OleDb12Installed()
        {
            return _dataAccess.IsAceOleDb12Installed() ? true : false;
        }
        /// <summary>
        /// Получение всех данных из таблицы
        /// </summary>
        public DataTable Read(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            return _dataAccess.GetData(query);
        }
        /// <summary>
        /// Получение заголовков всех таблиц в бд
        /// </summary>
        public List<string> GetTableNames()
        {
            return _dataAccess.GetAllTableNames();
        }
        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
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
        /// Проверка на существование пользователя с таким же логином
        /// </summary>
        public bool UserExistance(string login)
        {
            string checkUserQuery = "SELECT COUNT(*) FROM Пользователи WHERE ИмяПользователя = @Login";
            return _dataAccess.IsUserExists(login, checkUserQuery);
        }
        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        public void UserReg(string newLogin, string newPassword, out string message)
        {
            // Хеширование пароля
            string hashedPassword = _dataAccess.HashPassword(newPassword);
            // Добавление нового пользователя в таблицу Пользователи
            string insertUserQuery =
            "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) " +
            "VALUES (?, ?, ?)";
            _dataAccess.Regicration(insertUserQuery, newLogin, hashedPassword, out message);
        }
        /// <summary>
        /// Получение уровня названия доступа по индексу
        /// </summary>
        public string ShowUserRights()
        {
            return _dataAccess.GetNameFromIndex();
        }
        /// <summary>
        /// Сохранение в базу данных
        /// </summary>
        public void SaveToAccess(DataTable data, string nameOfTable)
        {
            string query = $"SELECT * FROM [{nameOfTable}]";
            _dataAccess.SaveToAccess(data, query);
        }
        /// <summary>
        /// Хеширование паролей
        /// </summary>
        public string HashUserInput(string password)
        {
            return _dataAccess.HashPassword(password);
        }
        /// <summary>
        /// Сортировка данных
        /// </summary>
        public DataTable SortData(string tableName, string columnName, string direction)
        {
            string sortDirection = direction == "Возрастание" ? "ASC" : "DESC";
            string query = $"SELECT * FROM [{tableName}] ORDER BY [{columnName}]{sortDirection}";
            return _dataAccess.GetData(query);
           
        }
        /// <summary>
        /// Фильтрация строковых данных
        /// </summary>
        public DataTable FilterString(string tableName, string columnName, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE [{columnName}] LIKE @value";
            return _dataAccess.Filter(query, value);
        }
        /// <summary>
        /// Фильтрация числовых данных
        /// </summary>
        public DataTable FilterNum(string tableName, string columnName, string ratio, string value)
        {
            string query = $"SELECT * FROM [{tableName}] WHERE [{columnName}] {ratio} @value";
            return _dataAccess.Filter(query, value);
        }
        /// <summary>
        /// Группировка данных
        /// </summary>
        public DataTable GroupData(string tableName, string columnName)
        {
            string query = $"SELECT [{columnName}], COUNT(*) AS {tableName}Количество " +
                $"FROM [{tableName}]" +
                $"GROUP BY [{columnName}]";
            return _dataAccess.GetData(query);
        }
    }
}
