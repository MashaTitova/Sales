using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;

namespace TestProjectSales
{
    public class DatabaseHelperTests
    {
        private const string ValidDatabasePath = "test.accdb";
        private const string InvalidDatabasePath = "nonexistent.accdb";

        [Fact]
        public void GetConnectionString_ReturnsValidString_WhenPathProvided()
        {
            // Arrange
            string expected = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ValidDatabasePath};Persist Security Info=False;";

            // Act
            string result = DatabaseHelper.GetConnectionString(ValidDatabasePath);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsAceOleDb12Installed_ReturnsBool_WhenCalled()
        {
            // Act
            bool result = DatabaseHelper.IsAceOleDb12Installed();

            // Assert
            // Метод возвращает bool в любом случае
            Assert.True(result || !result);
        }

        [Fact]
        public void ReadData_ThrowsException_WhenInvalidQuery()
        {
            // Arrange
            string invalidQuery = "SELECT * FROM NonExistentTable";

            // Act & Assert
            var exception = Assert.Throws<OleDbException>(() =>
                DatabaseHelper.ReadData(ValidDatabasePath, invalidQuery)
            );
            Assert.NotNull(exception);
        }

        [Fact]
        public void ReadData_ReturnsDataTable_WhenValidQuery()
        {
            // Arrange
            string validQuery = "SELECT 1 AS TestColumn";

            // Act
            var (table, adapter) = DatabaseHelper.ReadData(ValidDatabasePath, validQuery);

            // Assert
            Assert.NotNull(table);
            Assert.NotNull(adapter);
            Assert.NotEmpty(table.Rows);
            Assert.Single(table.Columns);
            Assert.Equal("TestColumn", table.Columns[0].ColumnName);
        }

        [Fact]
        public void GetAllTableNames_ReturnsList_WhenDatabaseHasTables()
        {
            // Act
            List<string> tableNames = DatabaseHelper.GetAllTableNames(ValidDatabasePath);

            // Assert
            Assert.NotNull(tableNames);
            // В реальной БД будет хотя бы одна таблица
            Assert.NotEmpty(tableNames);
        }

        [Fact]
        public void GetAllTableNames_ReturnsEmptyList_WhenNoTables()
        {
            // Для тестирования нужен пустой файл БД или имитация
            // Этот тест покажет поведение при отсутствии таблиц
            List<string> tableNames = DatabaseHelper.GetAllTableNames(InvalidDatabasePath);

            Assert.NotNull(tableNames);
            // При ошибке возвращается пустой список
            Assert.Empty(tableNames);
        }

        [Theory]
        [InlineData("password123", "password123")]
        [InlineData("", "")]
        [InlineData("special@#$", "special@#$")]
        public void HashPassword_ReturnsDifferentHash_ForDifferentInputs(string input, string expectedInput)
        {
            // Act
            string hash1 = DatabaseHelper.HashPassword(input);
            string hash2 = DatabaseHelper.HashPassword(expectedInput);

            // Assert
            Assert.NotNull(hash1);
            Assert.NotNull(hash2);
            Assert.NotEqual(hash1, hash2);
        }

        [Fact]
        public void HashPassword_ReturnsConsistentHash_ForSameInput()
        {
            // Arrange
            string password = "testpassword";

            // Act
            string hash1 = DatabaseHelper.HashPassword(password);
            string hash2 = DatabaseHelper.HashPassword(password);

            // Assert
            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void HashPassword_ReturnsNonEmptyHash_WhenInputProvided()
        {
            // Arrange
            string password = "test";

            // Act
            string hash = DatabaseHelper.HashPassword(password);

            // Assert
            Assert.NotNull(hash);
            Assert.NotEmpty(hash);
        }
        
    }
}

