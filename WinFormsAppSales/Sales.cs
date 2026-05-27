using ClassLibrarySales;
using FastReport;
using System.Data;
using System.Data.OleDb;
using FastReport.Preview;

namespace WinFormsAppSales
{
    public partial class Form_Sales : Form
    {
        private string selectedBasePath = "";
        private DataTable mainTable;
        private OleDbDataAdapter currentAdapter;
        public Form_Sales()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dataGridView_Sales.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            toolTip_Find.SetToolTip(panel_Find, "Пример для числового поиска:\n" +
            "СтоимостьЕдиницы >= 5000\n" +
            "Пример для строкового поиска:\n" +
            "Модель = A01\n" +
            "ВНИМАНИЕ\n" +
            "Для составления выражений строкового поиска из представленных операторов сравнения выбирайте \"=\"\n");
        }

        private void button_LoadBase_Click(object sender, EventArgs e)
        {
            ChooseDatabase();
            FillNamesComboBox();
        }
        private void ChooseDatabase()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройка диалогового окна
            openFileDialog.Title = "Выберите базу данных";
            openFileDialog.Filter = "(*.accdb)|*.accdb|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedBasePath = openFileDialog.FileName;
                if (string.IsNullOrEmpty(selectedBasePath))
                {
                    MessageBox.Show(
                    "База данных не найдена",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void FillNamesComboBox()
        {
            comboBox_ChooseTable.Items.Clear();
            List<string> tableNames = DatabaseHelper.GetAllTableNames(selectedBasePath);
            foreach (string tableName in tableNames)
            {
                comboBox_ChooseTable.Items.Add(tableName);
            }

        }
        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Вы уверены, что хотите закрыть приложение?",
            "Подтверждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                panel_Processing.Visible = true;
                button_Apply.Visible = true;
                button_Apply.Text = "Применить обработку";
                button_Remove.Visible = true;
                button_Remove.Text = "Снять обработку";
                ViewTable();
                label_Name.Text = "Обработка данных";
            }
        }

        private void button_DataViewing_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                label_Name.Text = "Просмотр данных";
                ViewTable();
            }
        }
        private void button_RemakeData_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                label_Name.Text = "Изменение данных";
                button_Apply.Visible = true;
                button_Apply.Text = "Сохранить изменения";
                button_Remove.Visible = true;
                button_Remove.Text = "Отменить изменения";
                ViewTable();
            }
            
        }
        private void button_Report_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                if(mainTable != null)
                {
                    ReportForm form = new ReportForm();
                    form.SetData(mainTable);
                    this.Hide();
                    DialogResult result = form.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show(
                    "Для создания отчета необходимо в одном из подразделов (\"Просмотр данных\", \"Обработка данных\", \"Изменение данных\") выбрать таблицу с данными",
                    "Выберите таблицу",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                
            }
        }
        private bool CheckAvailability()
        {
            if (comboBox_ChooseTable.Items.Count == 0)
            {
                MessageBox.Show(
                "Данные не найдены",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void ViewTable()
        {
            button_Return.Visible = true;
            panel_ChooseTable.Visible = true;
            button_Info.Visible = false;
            panel_StatInfo.Visible = true;
            panel_Base.Visible = true;
            flowLayoutPanel_HomeButtons.Visible = false;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            button_Return.Visible = false;
            panel_ChooseTable.Visible = false;
            button_Info.Visible = true;
            panel_StatInfo.Visible = false;
            panel_Base.Visible = false;
            flowLayoutPanel_HomeButtons.Visible = true;
            label_Name.Text = "Данные о продажах";
            if (panel_Processing.Visible == true)
            {
                panel_Processing.Visible = false;
                button_Apply.Visible = false;
                button_Remove.Visible = false;
            }
            dataGridView_Sales.DataSource = mainTable;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();

        }

        private void comboBox_ChooseTable_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTable();
            if (mainTable != null)
            {
                FillTable();
                FillComboBoxes();
            }
            if (label_Name.Text == "Изменение данных")
            {
                DataTable dt = mainTable.Copy();
                dataGridView_Sales.DataSource = dt;
            }

        }
        private void LoadTable()
        {
            string query = $"SELECT * FROM {comboBox_ChooseTable.SelectedItem}";
            var (table, adapter) = DatabaseHelper.ReadData(selectedBasePath, query);
            mainTable = table;
            currentAdapter = adapter;
        }
        private void FillTable()
        {
            dataGridView_Sales.DataSource = mainTable;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }

        private void FillComboBoxes()
        {
            comboBox_SortingColumn.Items.Clear();
            comboBox_ChooseFindParam.Items.Clear();
            comboBox_ChooseGroupParam.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView_Sales.Columns)
            {
                comboBox_SortingColumn.Items.Add(column.HeaderText);
                comboBox_ChooseFindParam.Items.Add(column.HeaderText);
                comboBox_ChooseGroupParam.Items.Add(column.HeaderText);
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            if (panel_Processing.Visible == true)
            {
                GetDataProcessing();
            }
            else
            {
                if (mainTable != null && currentAdapter != null)
                {
                    DatabaseHelper.SaveChanges(currentAdapter, mainTable, selectedBasePath);
                }
                mainTable = (DataTable)dataGridView_Sales.DataSource;
                label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
            }

        }

        private void GetDataProcessing()
        {
            DataTable dt = mainTable.Copy();
            if (comboBox_ChooseTable.Text != "")
            {
                GetSort(dt);
                GetFind(dt);
                GetGroup(dt);
            }
            dataGridView_Sales.DataSource = dt;
        }
        private void GetSort(DataTable dt)
        {
            if (comboBox_SortingColumn.Text != "" && comboBox_SortDirection.Text != "")
            {
                DataProcessing.CustomSort(dt, comboBox_SortDirection.Text, comboBox_SortingColumn.Text);
            }
        }
        private void GetFind(DataTable dt)
        {
            if (comboBox_ChooseFindParam.Text != "" && comboBox_FindRatio.Text != "" && textBox_ChooseFind.Text != "" && (radioButton_NumFind.Checked || radioButton_StringFind.Checked))
            {
                if (comboBox_FindRatio.Text == "=" && radioButton_StringFind.Checked)
                {
                    DataProcessing.FilterString(dt, textBox_ChooseFind.Text, comboBox_ChooseFindParam.Text);
                }
                else
                {
                    if (radioButton_NumFind.Checked)
                    {

                        // Проверка: введено ли число в поле поиска
                        if (!CheckIntInput(textBox_ChooseFind.Text.Trim(), "Значение для поиска должно быть целым числом"))
                        {
                            MessageBox.Show("Значение для поиска должно быть целым числом", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Проверка: содержит ли столбец только числа
                        if (!CheckColumnForNumbers(dt, comboBox_ChooseFindParam.Text))
                        {
                            MessageBox.Show($"Столбец '{comboBox_ChooseFindParam.Text}' содержит нечисловые значения. Числовой поиск невозможен.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Если все проверки пройдены — выполняем фильтрацию
                        DataProcessing.FilterNums(dt, textBox_ChooseFind.Text, comboBox_ChooseFindParam.Text, comboBox_FindRatio.Text.Trim());
                    }
                }
            }
        }
        private void GetGroup(DataTable dt)
        {
            if (comboBox_ChooseGroupParam.Text != "")
            {
                dt = DataProcessing.Group(dt, comboBox_ChooseGroupParam.Text);
            }
        }
        private bool CheckIntInput(string input, string errorMessage)
        {

            if (string.IsNullOrWhiteSpace(input))
                return false;

            return int.TryParse(input, out _);
        }
        private bool CheckColumnForNumbers(DataTable table, string columnName)
        {
            foreach (DataRow row in table.Rows)
            {
                object cellValue = row[columnName];

                if (!int.TryParse(cellValue.ToString(), out _))
                    return false;
            }

            return true;
        }
        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (panel_Processing.Visible == true)
            {
                comboBox_SortingColumn.SelectedItem = null;
                comboBox_SortDirection.SelectedItem = null;
                comboBox_ChooseFindParam.SelectedItem = null;
                comboBox_FindRatio.SelectedItem = null;
                textBox_ChooseFind.Text = "";
                comboBox_ChooseGroupParam.SelectedItem = null;
                dataGridView_Sales.DataSource = mainTable;
                radioButton_NumFind.Checked = false;
                radioButton_StringFind.Checked = false;
            }
            else
            {
                DataTable dt = mainTable.Copy();
                dataGridView_Sales.DataSource = null;
                dataGridView_Sales.DataSource = dt;
                label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
            }
        }

        private void radioButton_StringFind_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_StringFind.Checked)
            {
                radioButton_NumFind.Checked = false;
            }
        }

        private void radioButton_NumFind_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_NumFind.Checked)
            {
                radioButton_StringFind.Checked = false;
            }
        }

    }
}