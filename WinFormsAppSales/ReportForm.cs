using FastReport;
using System.Data;
using FastReport.Preview;

namespace WinFormsAppSales
{
    public partial class ReportForm : Form
    {
        DataTable data;
        Report report;
        public ReportForm()
        {
            InitializeComponent();
        }

        private void button_ReporGenegation_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаём новый отчёт
                report = new Report();

                // Добавляем страницу
                ReportPage page = new ReportPage();
                report.Pages.Add(page);

                // Добавляем бэнд «Данные»
                DataBand dataBand = new DataBand();
                page.Bands.Add(dataBand);

                // Настраиваем источник данных
                DataColumnCollection columns = data.Columns;
                foreach (DataColumn column in columns)
                {
                    // Создаём текст‑объект для каждого столбца
                    TextObject textObj = new TextObject();
                    textObj.Bounds = new System.Drawing.RectangleF(
                        (column.Ordinal * 100), 0, 100, 20);
                    textObj.Text = $"[{column.ColumnName}]";
                    dataBand.Objects.Add(textObj);
                }

                // Регистрируем данные
                report.RegisterData(data, "MyData");
                report.GetDataSource("MyData").Enabled = true;

                MessageBox.Show("Отчет успешно сгенерирован");
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при генерации");
            }
        }
        public void SetData(DataTable dt)
        {
            this.data = dt;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_ViewReport_Click(object sender, EventArgs e)
        {
            // Подготавливаем отчёт
            report.Prepare();

        }
    }
}
