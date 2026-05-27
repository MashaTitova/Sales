using ClassLibrarySales;
using System.Data;
using System.Xml;

namespace TestProjectSales
{
    public class DataProcessingTests
    {
        private DataTable testTable;

        public DataProcessingTests()
        {
            testTable = CreateTestDataTable();
        }

        private DataTable CreateTestDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Model", typeof(string));
            table.Columns.Add("Price", typeof(double));
            table.Columns.Add("Quantity", typeof(int));

            // Добавляем тестовые данные
            table.Rows.Add(1, "A01", 300.0, 5);
            table.Rows.Add(2, "A02", 200.0, 3);
            table.Rows.Add(3, "A01", 500.0, 8);
            table.Rows.Add(4, "B01", 400.0, 2);
            table.Rows.Add(5, "B02", 150.0, 6);

            return table;
        }
        [Fact]
        public void CustomSort_Ascending_SortsCorrectly()
        {
            DataProcessing.CustomSort(testTable, "Возрастание", "Price");

            var sortedRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(150.0, sortedRows[0]["Price"]);
            Assert.Equal(200.0, sortedRows[1]["Price"]);
            Assert.Equal(300.0, sortedRows[2]["Price"]);
        }

        [Fact]
        public void CustomSort_Descending_SortsCorrectly()
        {
            DataProcessing.CustomSort(testTable, "Убывание", "Price");

            var sortedRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(500.0, sortedRows[0]["Price"]);
            Assert.Equal(400.0, sortedRows[1]["Price"]);
            Assert.Equal(300.0, sortedRows[2]["Price"]);
        }
        [Fact]
        public void FilterString_FindsMatchingStrings()
        {
            DataProcessing.FilterString(testTable, "A0", "Model");

            var filteredRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(3, filteredRows.Count); 
            Assert.Contains("A01", filteredRows[0]["Model"].ToString());
        }

        [Fact]
        public void FilterString_NoMatches_ReturnsEmpty()
        {
            DataProcessing.FilterString(testTable, "XYZ", "Model");

            var filteredRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(0, filteredRows.Count);
        }
        [Fact]
        public void FilterNums_GreaterThan_FiltersCorrectly()
        {
            DataProcessing.FilterNums(testTable, "250", "Price", ">");

            var filteredRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(3, filteredRows.Count);
            foreach (DataRow row in filteredRows)
            {
                double price = Convert.ToDouble(row["Price"]);
                Assert.True(price > 250);
            }
        }

        [Fact]
        public void FilterNums_LessThan_FiltersCorrectly()
        {
            DataProcessing.FilterNums(testTable, "350", "Price", "<");

            var filteredRows = testTable.DefaultView.ToTable().Rows;
            Assert.Equal(3, filteredRows.Count);
            foreach (DataRow row in filteredRows)
            {
                double price = Convert.ToDouble(row["Price"]);
                Assert.True(price < 350);
            }
        }

        [Fact]
        public void FilterNums_InvalidNumber_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() =>
                DataProcessing.FilterNums(testTable, "abc", "Price", ">"));
        }
        [Fact]
        public void Group_GroupsByColumn_CorrectCounts()
        {
            DataTable result = DataProcessing.Group(testTable, "Model");

            Assert.Equal(4, result.Rows.Count); 

            DataRow a01Row = result.AsEnumerable()
                .FirstOrDefault(r => r.Field<object>("GroupKey").ToString() == "A01");
            Assert.NotNull(a01Row);
            Assert.Equal(2, a01Row.Field<int>("Count"));

            DataRow b01Row = result.AsEnumerable()
                .FirstOrDefault(r => r.Field<object>("GroupKey").ToString() == "B01");
            Assert.NotNull(b01Row);
            Assert.Equal(1, b01Row.Field<int>("Count"));

            DataRow a02Row = result.AsEnumerable()
                .FirstOrDefault(r => r.Field<object>("GroupKey").ToString() == "A02");
            Assert.NotNull(a02Row);
            Assert.Equal(1, a02Row.Field<int>("Count"));

            DataRow b02Row = result.AsEnumerable()
                .FirstOrDefault(r => r.Field<object>("GroupKey").ToString() == "B02");
            Assert.NotNull(b02Row);
            Assert.Equal(1, b02Row.Field<int>("Count"));
        }

        [Fact]
        public void Group_InvalidColumn_ReturnsEmptyTable()
        {
            Assert.Throws<Exception>(() =>
                DataProcessing.Group(testTable, ""));
        }

    }

}
