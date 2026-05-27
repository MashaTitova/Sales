using System.ComponentModel;
using System.Data;

namespace ClassLibrarySales
{
    public class DataProcessing
    {
        private static DataColumn ChooseColumn(DataTable table, string choisenColumnName)
        {
            DataColumn column = table.Columns.Cast<DataColumn>().FirstOrDefault(c => c.ColumnName == choisenColumnName);
            return column;
        }
        public static void CustomSort(DataTable table, string sortDirect, string choisenColumnName)
        {
            String sortDirection =
                sortDirect == "Возрастание"
                    ? "ASC"
                    : "DESC";
            DataColumn column = ChooseColumn(table, choisenColumnName);
            if (column == null) return;

            table.DefaultView.Sort = $"{column.ColumnName} {sortDirection}";
        }
        public static void FilterString(DataTable table, string searchValue, string choisenColumnName)
        {
            DataColumn column = ChooseColumn(table, choisenColumnName);
            if (column == null)
                return;

            // Формируем фильтр
            string filter = $"[{column.ColumnName}] LIKE '%{searchValue}%'";

            // Применяем фильтр
            table.DefaultView.RowFilter = filter;
        }
        public static void FilterNums(DataTable table, string searchValue, string choisenColumnName, string ratio)
        {
            DataColumn column = ChooseColumn(table, choisenColumnName);
            if (column == null)
                return;

            // Формируем фильтр
            string filter = $"Convert([{column.ColumnName}], 'System.Double') {ratio} {Convert.ToDouble(searchValue)}";

            // Применяем фильтр
            table.DefaultView.RowFilter = filter;
        }
        public static DataTable Group(DataTable table, string choisenColumnName)
        {
            // Создаём новую таблицу для результата
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("GroupKey", typeof(object));
            resultTable.Columns.Add("Count", typeof(int));
            try
            {
                // Выполняем группировку
                var groups = table.AsEnumerable()
                .GroupBy(row => row.Field<object>(choisenColumnName));
                // Заполняем результирующую таблицу
                foreach (var group in groups)
                {
                    resultTable.Rows.Add(group.Key, group.Count());
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Ошибка: {ex}");
            }
            return resultTable;
        }
    }
}
