using FastReport;
using FastReport.Preview;
using System.Data;
using System.Drawing.Printing;
using System.Text;

namespace WinFormsAppSales
{
    public partial class ReportForm : Form
    {
        DataTable data;
        String reportText;
        String nameOfBase;
        bool hasReport;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void button_ReporGenegation_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateTextReport();
                MessageBox.Show("Отчет успешно сгенерирован");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при генерации");
            }
        }
        private void GenerateTextReport()
        {
            var report = new StringBuilder();
            int columnWidth = 20;

            report.AppendLine("ОТЧЁТ ПО ДАННЫМ");
            report.AppendLine(new string('=', data.Columns.Count * columnWidth));

            // Заголовки
            foreach (DataColumn column in data.Columns)
            {
                report.Append(string.Format("{0,-" + columnWidth + "}", column.ColumnName));
            }
            report.AppendLine();

            // Разделитель
            report.AppendLine(new string('-', data.Columns.Count * columnWidth));

            // Данные
            foreach (DataRow row in data.Rows)
            {
                foreach (object cell in row.ItemArray)
                {
                    report.Append(string.Format("{0,-" + columnWidth + "}", cell));
                }
                report.AppendLine();
            }

            reportText = report.ToString();
            hasReport = true;
        }
        public void SetData(DataTable dt, string name)
        {
            data = dt;
            nameOfBase = name;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_ViewReport_Click(object sender, EventArgs e)
        {
            if (!hasReport)
            {
                MessageBox.Show("Для совершения данного действия сгенерируйте отчет");
                return;
            }
            Form previewForm = new Form();
            previewForm.Text = "Предварительный просмотр отчёта";
            previewForm.Size = CalculateWindowSize();
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Font = new Font("Courier New", 9);
            textBox.Text = reportText;
            textBox.TabStop = false;

            previewForm.Controls.Add(textBox);
            previewForm.Show();
        }
        private Size CalculateWindowSize()
        {
            string[] lines = reportText.Split('\n');
            int maxLineLength = lines.Max(line => line.Length);

            using (Graphics g = this.CreateGraphics())
            {
                Font font = new Font("Courier New", 9);
                float charWidth = g.MeasureString("M", font).Width;
                float lineHeight = font.GetHeight(g);

                // Учитываем границы формы и полосу прокрутки
                int border = 40;
                int scrollBarWidth = 20;
                int heightIndent = 30;

                int calculatedWidth = (int)(maxLineLength * charWidth) + border + scrollBarWidth;
                int calculatedHeight = (int)(lines.Length * lineHeight) + border + heightIndent;

                font.Dispose();

                // Ограничиваем размеры, чтобы окно помещалось на экране
                Screen screen = Screen.FromPoint(this.Location);
                int maxWidth = screen.WorkingArea.Width - 100;
                int maxHeight = screen.WorkingArea.Height - 100;

                return new Size
                {
                    Width = Math.Min(calculatedWidth, maxWidth),
                    Height = Math.Min(calculatedHeight, maxHeight)
                };
            }
        }
        private void button_SaveReport_Click(object sender, EventArgs e)
        {
            if (!hasReport)
            {
                MessageBox.Show("Для совершения данного действия сгенерируйте отчет");
                return;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveDialog.FileName = $"Отчет о продажах. {nameOfBase}";
            saveDialog.Title = "Сохранить отчёт";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveDialog.FileName, reportText, Encoding.UTF8);
                    MessageBox.Show("Отчёт успешно сохранён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_PrintReport_Click(object sender, EventArgs e)
        {
            if (!hasReport)
            {
                MessageBox.Show("Для совершения данного действия сгенерируйте отчет");
                return;
            }
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = new PrintDocument();
            printDialog.Document.DocumentName = "Отчёт о продажах";

            // Обработчик печати
            printDialog.Document.PrintPage += (sender, e) =>
            {
                Font font = new Font("Courier New", 10);
                float yPos = 0;
                float leftMargin = e.MarginBounds.Left;
                float topMargin = e.MarginBounds.Top;
                StringFormat stringFormat = new StringFormat();

                // Разбиваем текст на строки
                string[] lines = reportText.Split('\n');

                foreach (string line in lines)
                {
                    if (yPos + font.GetHeight(e.Graphics) > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    e.Graphics.DrawString(line, font, Brushes.Black, leftMargin, topMargin + yPos, stringFormat);
                    yPos += font.GetHeight(e.Graphics);
                }

                e.HasMorePages = false;
            };

            // Показываем диалог печати
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document.Print();
            }
        }
    }
}