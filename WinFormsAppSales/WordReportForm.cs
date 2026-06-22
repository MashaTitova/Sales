using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public partial class WordReportForm : Form
    {
        private DataTable _data;
        private string _nameOfBase;
        private byte[] _wordData;
        private bool _hasWordReport;
        public WordReportForm()
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
                _wordData = GenerateWordData();
                _hasWordReport = true;
                MessageBox.Show("Отчёт в формате Word успешно сгенерирован");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации Word: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] GenerateWordData()
        {
            using (var ms = new MemoryStream())
            {
                using (var doc = WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document))
                {
                    var mainPart = doc.AddMainDocumentPart();
                    var body = new Body();
                    mainPart.Document = new Document(body);

                    // Заголовок
                    var paragraph = new Paragraph(
                        new Run(new Text($"Отчёт по данным: {_nameOfBase}")),
                        new ParagraphProperties(new Justification { Val = JustificationValues.Center }) // Выравнивание по центру
                    );
                    body.AppendChild(paragraph); // Пустая строка
                    body.AppendChild(new Paragraph(new Run()));

                    // Таблица
                    var table = new Table();
                    var tableProperties = new TableProperties(
                        new TableBorders(
                            new TopBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) },
                            new BottomBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) },
                            new LeftBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) },
                            new RightBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) },
                            new InsideHorizontalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) },
                            new InsideVerticalBorder { Val = new EnumValue<BorderValues>(BorderValues.Single) }
                        )
                    );
                    table.AppendChild(tableProperties);

                    // Заголовки
                    var headerRow = new TableRow();
                    for (int i = 0; i < _data.Columns.Count; i++)
                    {
                        var cell = new TableCell(new Paragraph(new Run(new Text(_data.Columns[i].ColumnName))));
                        headerRow.AppendChild(cell);
                    }
                    table.AppendChild(headerRow);

                    // Данные
                    for (int r = 0; r < _data.Rows.Count; r++)
                    {
                        var row = new TableRow();
                        for (int c = 0; c < _data.Columns.Count; c++)
                        {
                            var value = _data.Rows[r][c];
                            var cell = new TableCell(new Paragraph(new Run(new Text(value?.ToString() ?? string.Empty))));
                            row.AppendChild(cell);
                        }
                        table.AppendChild(row);
                    }

                    body.AppendChild(table);
                }
                return ms.ToArray();
            }
        }
        private void button_ViewWord_Click(object sender, EventArgs e)
        {
            if (!_hasWordReport)
            {
                MessageBox.Show("Сначала сгенерируйте отчёт в Word.");
                return;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), $"Report_Word_{Guid.NewGuid()}.docx");
            try
            {
                File.WriteAllBytes(tempPath, _wordData);
                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть файл для просмотра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WordReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
