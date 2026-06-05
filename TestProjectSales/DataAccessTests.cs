using System.Data;
using System.Data.OleDb;

namespace ClassLibrarySales.Tests
{
    public class DataAccessTests
    {
        private const string TestDatabasePath = "test.accdb";
        private DataAccess _dataAccess;

        public DataAccessTests()
        {
            _dataAccess = new DataAccess(TestDatabasePath);
        }

        [Fact]
        public void Constructor_ShouldCreateConnectionString()
        {
            var dataAccess = new DataAccess(TestDatabasePath);

            Assert.Contains(TestDatabasePath, dataAccess.GetType()
                .GetField("_connectionString", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.GetValue(dataAccess)?.ToString());
        }

        [Fact]
        public void IsAceOleDb12Installed_ShouldReturnBool()
        {
            bool result = _dataAccess.IsAceOleDb12Installed();

            Assert.True(result); 
        }

        [Fact]
        public void GetData_WithValidQuery_ShouldReturnDataTable()
        {
            string query = "SELECT * FROM Пользователи WHERE 1=0"; 

            DataTable result = _dataAccess.GetData(query);

            Assert.NotNull(result);
            Assert.IsType<DataTable>(result);
        }

        [Fact]
        public void GetAllTableNames_ShouldReturnListOfStrings()
        {
            List<string> tableNames = _dataAccess.GetAllTableNames();

            Assert.NotNull(tableNames);
            Assert.IsType<List<string>>(tableNames);
        }

        [Theory]
        [InlineData("testUser", "correctHash", "Администратор", "1")]
        [InlineData("nonexistent", "wrongHash", "", "")]
        public void Authentication_WithValidCredentials_ShouldAuthenticate(
            string login, string passwordHash, string expectedRights, string expectedIndex)
        {
            string query = "SELECT Пароль, КодПравПользователя, ПраваПользователя FROM Пользователи WHERE ИмяПользователя = @Login";
            string message;

            string result = _dataAccess.Authentication(query, login, passwordHash, out message);

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

            var testDataAccess = new DataAccess(TestDatabasePath);

            string existingLogin = "testUser";
            string checkUserQuery = "SELECT COUNT(*) FROM Пользователи WHERE ИмяПользователя = @Login";

            bool exists = testDataAccess.IsUserExists(existingLogin, checkUserQuery);

            Assert.True(exists);
        }

        [Fact]
        public void Regicration_WithValidData_ShouldAddUser()
        {
            string insertUserQuery = "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) VALUES (?, ?, ?)";
            string newLogin = "newtestuser";
            string hashedPassword = "hashedpassword123";
            string message;

            _dataAccess.Regicration(insertUserQuery, newLogin, hashedPassword, out message);

            Assert.Contains("Пользователь успешно зарегистрирован", message);
        }

        [Fact]
        public void Regicration_WithDuplicateLogin_ShouldFail()
        {
            string insertUserQuery = "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) VALUES (?, ?, ?)";
            string duplicateLogin = "existingUser"; 
            string hashedPassword = "hashedpassword123";
            string message;

            _dataAccess.Regicration(insertUserQuery, duplicateLogin, hashedPassword, out message);

            Assert.Contains("Ошибка при регистрации", message);
        }

        [Fact]
        public void HashPassword_ShouldReturnValidHash()
        {
            string password = "testpassword";

            string hash = _dataAccess.HashPassword(password);

            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
            Assert.NotEqual(password, hash); 
            Assert.Equal(44, hash.Length); 
        }

        [Fact]
        public void Filter_WithValidParameters_ShouldReturnFilteredData()
        {
            string query = "SELECT * FROM Пользователи WHERE ИмяПользователя LIKE @value";
            string filterValue = "testUser";

            DataTable result = _dataAccess.Filter(query, filterValue);

            Assert.NotNull(result);
            Assert.IsType<DataTable>(result);
        }

 

    }
}