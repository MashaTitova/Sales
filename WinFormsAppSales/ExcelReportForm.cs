using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ExcelReportForm : Form
    {
        private DataTable _data;
        private string _nameOfBase;
        private byte[] _excelData;
        private bool _hasExcelReport;
        public ExcelReportForm()
        {
            InitializeComponent();
        }
        public void SetData(DataTable dt, string name)
        {
            _data = dt;
            _nameOfBase = name;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_ReporGenegation_Click(object sender, EventArgs e)
        {
            try
            {
                if (_data == null)
                {
                    MessageBox.Show("Нет данных для генерации");
                    return;
                }
                _excelData = GenerateExcelData();
                _hasExcelReport = true;
                MessageBox.Show("Отчёт в формате Excel успешно сгенерирован");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации Excel: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] GenerateExcelData()
        {
            using (var workbook = new XSSFWorkbook())
            {
                var sheet = workbook.CreateSheet("Отчёт");

                // Стили
                var numericStyle = workbook.CreateCellStyle();
                
                var font = workbook.CreateFont();
                font.IsBold = true;                 

                var cellStyle = workbook.CreateCellStyle();
                // Перенос текста
                cellStyle.WrapText = true;

                // Заголовки
                var headerRow = sheet.CreateRow(0);
                for (int i = 0; i < _data.Columns.Count; i++)
                {
                    var cell = headerRow.CreateCell(i);
                    cell.SetCellValue(_data.Columns[i].ColumnName);
                }

                // Данные
                for (int r = 0; r < _data.Rows.Count; r++)
                {
                    var row = sheet.CreateRow(r + 1);
                    for (int c = 0; c < _data.Columns.Count; c++)
                    {
                        var cell = row.CreateCell(c);
                        var value = _data.Rows[r][c];

                        if (value is IConvertible convertible &&
                            double.TryParse(convertible.ToString(), out double numericValue))
                        {
                            cell.SetCellValue(numericValue);
                            cell.CellStyle = numericStyle;
                        }
                        else
                        {
                            cell.SetCellValue(value?.ToString() ?? string.Empty);
                            cell.CellStyle = cellStyle;
                        }
                    }
                }
                // Автоширина
                for (int i = 0; i < _data.Columns.Count; i++)
                    sheet.AutoSizeColumn(i);

                using (var ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    return ms.ToArray();
                }
            }
        }
        private void button_ViewExcel_Click(object sender, EventArgs e)
        {
            if (!_hasExcelReport)
            {
                MessageBox.Show("Сначала сгенерируйте отчёт в Excel");
                return;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), $"Report_Excel_{Guid.NewGuid()}.xlsx");
            try
            {
                File.WriteAllBytes(tempPath, _excelData);
                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true }); // Открытие в приложении Excel
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл для просмотра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExcelReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
