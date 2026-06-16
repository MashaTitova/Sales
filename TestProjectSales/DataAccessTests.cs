using System.Data;
using System.Data.OleDb;

namespace ClassLibrarySales.Tests
{
    public class DataAccessTests
    {
        private const string TestDatabasePath = "test.accdb";

        private void CleanUpTestDatabase()
        {
            try
            {
                using var connection = new OleDbConnection(
                    $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={TestDatabasePath};");
                connection.Open();

                using var command = new OleDbCommand(
                    "DELETE FROM Пользователи WHERE ИмяПользователя = 'newtestuser'", connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка очистки БД: {ex.Message}");
            }
        }

        [Fact]
        public void Constructor_ShouldCreateConnectionString()
        {
            var dataAccess = new DataAccess(TestDatabasePath);
            var connectionString = dataAccess.GetType()
                .GetField("_connectionString",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance)
                ?.GetValue(dataAccess)?.ToString();

            Assert.Contains(TestDatabasePath, connectionString);
        }

        [Fact]
        public void IsAceOleDb12Installed_ShouldReturnBool()
        {
            var dataAccess = new DataAccess(TestDatabasePath);

            bool result = dataAccess.IsAceOleDb12Installed();
            Assert.True(result);
        }

        [Fact]
        public void GetData_WithValidQuery_ShouldReturnDataTable()
        {
            var dataAccess = new DataAccess(TestDatabasePath);

            string query = "SELECT * FROM Пользователи WHERE 1=0";
            DataTable result = dataAccess.GetData(query);

            Assert.NotNull(result);
            Assert.IsType<DataTable>(result);
        }

        [Fact]
        public void GetAllTableNames_ShouldReturnListOfStrings()
        {
            var dataAccess = new DataAccess(TestDatabasePath);

            List<string> tableNames = dataAccess.GetAllTableNames();

            Assert.NotNull(tableNames);
            Assert.IsType<List<string>>(tableNames);
        }

        [Theory]
        [InlineData("testUser", "correctHash", "Администратор", "1")]
        [InlineData("nonexistent", "wrongHash", "", "")]
        public void Authentication_WithValidCredentials_ShouldAuthenticate(
            string login, string passwordHash, string expectedRights, string expectedIndex)
        {
            var dataAccess = new DataAccess(TestDatabasePath);

            string query = "SELECT Пароль, КодПравПользователя, ПраваПользователя FROM Пользователи WHERE ИмяПользователя = @Login";
            string message;

            string result = dataAccess.Authentication(query, login, passwordHash, out message);

            if (!string.IsNullOrEmpty(expectedIndex))
            {
                Assert.Equal(expectedIndex, result);
                Assert.Contains("Вход выполнен успешно", message);
                Assert.Contains($"Ваш уровень доступа - {expectedRights}", message);
            }
            else
            {
                Assert.Null(result);
                Assert.Contains("Пользователь не найден", message);
            }
        }

        [Fact]
        public void IsUserExists_WithExistingUser_ShouldReturnTrue()
        {
            CleanUpTestDatabase();

            var dataAccess = new DataAccess(TestDatabasePath);

            string existingLogin = "testUser";
            string checkUserQuery = "SELECT COUNT(*) FROM Пользователи WHERE ИмяПользователя = @Login";

            bool exists = dataAccess.IsUserExists(existingLogin, checkUserQuery);
            Assert.True(exists);
        }

        [Fact]
        public void Registration_WithValidData_ShouldAddUser()
        {
            CleanUpTestDatabase();

            var dataAccess = new DataAccess(TestDatabasePath);

            string insertUserQuery = "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) VALUES (?, ?, ?)";
            string newLogin = "newtestuser";
            string hashedPassword = "hashedpassword123";
            string message;

            dataAccess.Registration(insertUserQuery, newLogin, hashedPassword, out message);
            Assert.Contains("Пользователь успешно зарегистрирован", message);
        }

        [Fact]
        public void Registration_WithDuplicateLogin_ShouldFail()
        {
            CleanUpTestDatabase();

            var dataAccess = new DataAccess(TestDatabasePath);
            string insertUserQuery = "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) VALUES (?, ?, ?)";
            string duplicateLogin = "existingUser";
            string hashedPassword = "hashedpassword123";
            string message;

            dataAccess.Registration(insertUserQuery, duplicateLogin, hashedPassword, out message);
            Assert.Contains("Ошибка при регистрации", message);
        }

        [Fact]
        public void HashPassword_ShouldReturnValidHash()
        {
            var dataAccess = new DataAccess(TestDatabasePath);
            string password = "testpassword";
            string hash = dataAccess.HashPassword(password);

            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
            Assert.NotEqual(password, hash);
            Assert.Equal(44, hash.Length);
        }

        [Fact]
        public void Filter_WithValidParameters_ShouldReturnFilteredData()
        {

            var dataAccess = new DataAccess(TestDatabasePath);
            string query = "SELECT * FROM Пользователи WHERE ИмяПользователя LIKE @value";
            string filterValue = "testUser";

            DataTable result = dataAccess.Filter(query, filterValue);
            Assert.NotNull(result);
            Assert.IsType<DataTable>(result);
        }
    }
}
