using ClassLibrarySales;
using FastReport;
using System.Data;
using System.Data.OleDb;
using FastReport.Preview;

namespace WinFormsAppSales
{

    /// <summary>
    ///Главная форма приложения для работы с данными о продажах
    /// Обеспечивает навигацию между модулями, управление отображением данных,
    /// интеграцию с модулем аутентификации, формирование отчётов и применение обработки
    /// (сортировка, поиск, группировка) к данным из подключённой БД Access
    /// </summary>
    public partial class Form_Sales : Form
    {
        // Путь к выбранной базе данных Access
        private string _selectedBasePath = "";
        // DataTable с данными выбранной таблицы из БД
        private DataTable _mainTable = new DataTable();
        // Экземпляр слоя бизнес-логики
        private LogicLayer _logicLayer;
        // Список названий столбцов выбранной таблицы
        private List<string> _columnNames = new List<string>();
        // Экземпляр класса для изменения данных
        private int _rightsIndex;

        public Form_Sales()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Взаимодействие с формой аутентификации
        /// </summary>
        private void ShowAuthentication()
        {
            AuthenticationForm form = new AuthenticationForm();
            form.SetLogicLayer(_logicLayer);
            this.Hide();
            form.ShowDialog();
            string userRightsIndex = form.GetUserRights();
            RightsSettings(userRightsIndex);
            if (form.DialogResult == DialogResult.OK)
            {
                this.Show();
            }
            else { Application.Exit(); }


        }
        /// <summary>
        /// Настройка доступа к функционалу в соответствии с правами пользователя
        /// </summary>
        /// <param name="userRightsIndex">Строковое представление индекса прав пользователя.</param>
        private void RightsSettings(string userRightsIndex)
        {
            int userRightsInt = Convert.ToInt32(userRightsIndex);
            _rightsIndex = userRightsInt;
            if (userRightsInt > 1)
            {
                // Если права пользователя ниже "Администратора"
                comboBox_ChooseTable.Items.Remove("Пользователи");
                if (userRightsInt > 3)
                {
                    // Если права пользователя "Чтение"
                    button_RemakeData.Visible = false;
                }
            }
        }
        /// <summary>
        /// Обработчик клика по кнопке загрузки базы данных
        /// </summary>
        private void button_LoadBase_Click(object sender, EventArgs e)
        {
            ChooseDatabase();
            // Проверка наличия нужного драйвера
            if (!_logicLayer.OleDb12Installed())
            {
                MessageBox.Show(
                    "Драйвер Microsoft.ACE.OLEDB.12.0 не установлен.\n" +
                    "Для работы приложения требуется установить Microsoft Access Database Engine 2010/2016.\n" +
                    "Загрузите его с официального сайта Microsoft."
                );
                return;
            }
            FillNamesComboBox();
            ShowAuthentication();
        }
        /// <summary>
        /// Выбор базы данных
        /// </summary>
        private void ChooseDatabase()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Настройка диалогового окна
            openFileDialog.Title = "Выберите базу данных";
            openFileDialog.Filter = "(*.accdb)|*.accdb";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Запоминаем путь к файлу
                _selectedBasePath = openFileDialog.FileName;
                if (string.IsNullOrEmpty(_selectedBasePath))
                {
                    MessageBox.Show(
                    "База данных не найдена",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                // Инициализация слоя логики выбранным путем
                _logicLayer = new LogicLayer(_selectedBasePath);
            }
            else { Application.Exit(); }
        }
        /// <summary>
        /// Формирование списка для выбора таблиц
        /// </summary>
        private void FillNamesComboBox()
        {
            comboBox_ChooseTable.Items.Clear();
            List<string> tableNames = new List<string>();
            try
            {
                // Получаем список имен таблиц выбранной бд
                tableNames = _logicLayer.GetTableNames();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (string tableName in tableNames)
            {
                comboBox_ChooseTable.Items.Add(tableName);
            }
            comboBox_ChooseTable.Items.Remove("ПраваПользователей");
            panel_ChooseTable.Visible = true;
        }

        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Вы действительно хотите закрыть приложение?",
               "Подтверждение",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Information
           );
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void Form_Sales_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                panel_Processing.Visible = true;
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
                OpenRemakeForm();

            }

        }
        private void button_Report_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                if (_mainTable != null)
                {
                    ReportForm form = new ReportForm();
                    form.SetData(_mainTable, comboBox_ChooseTable.Text);
                    DialogResult result = form.ShowDialog();
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
        /// <summary>
        /// Проверяет, загружена ли база данных и выбрана ли таблица
        /// </summary>
        private bool CheckAvailability()
        {
            if (comboBox_ChooseTable.Items.Count == 0 || comboBox_ChooseTable.Text == "")
            {
                MessageBox.Show(
                "Загрузите базу данных и выберите таблицу с данными",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Переключает элементы интерфейса в режим просмотра/обработки таблицы
        /// </summary>
        private void ViewTable()
        {
            button_Return.Visible = true;
            button_Info.Visible = false;
            panel_StatInfo.Visible = true;
            panel_Base.Visible = true;
            flowLayoutPanel_HomeButtons.Visible = false;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        /// <summary>
        /// Обработчик клика по кнопке «Назад»
        /// Восстанавливает исходное состояние интерфейса
        /// </summary>
        private void button_Return_Click(object sender, EventArgs e)
        {
            button_Return.Visible = false;
            button_Info.Visible = true;
            panel_StatInfo.Visible = false;
            panel_Base.Visible = false;
            flowLayoutPanel_HomeButtons.Visible = true;
            label_Name.Text = "Данные о продажах";
            if (panel_Processing.Visible == true)
            {
                panel_Processing.Visible = false;
            }
            dataGridView_Sales.DataSource = _mainTable;
            if (comboBox_ChooseTable.Text != "Пользователи")
                dataGridView_Sales.Columns[0].Visible = false;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();

        }

        private void comboBox_ChooseTable_SelectedValueChanged(object sender, EventArgs e)
        {
            _columnNames.Clear();
            // Получение выбранных данных
            LoadTable();
            if (_mainTable != null)
            {
                // Заполнение DataGridView
                FillTable();
            }

        }
        /// <summary>
        /// Загружает данные выбранной таблицы из БД через слой логики
        /// </summary>
        private void LoadTable()
        {
            if (comboBox_ChooseTable.Text == "")
            {
                return;
            }
            try
            {
                var table = _logicLayer.Read(comboBox_ChooseTable.Text);
                _mainTable = table;
                FillColumnsNames();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"SQL ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Общая ошибка: {ex.Message}");
            }
        }
        private void FillColumnsNames()
        {
            foreach (DataColumn column in _mainTable.Columns)
            {
                _columnNames.Add(column.ColumnName);
            }
        }
        private void FillTable()
        {
            dataGridView_Sales.DataSource = _mainTable;
            if (comboBox_ChooseTable.Text != "Пользователи")
                dataGridView_Sales.Columns[0].Visible = false;
            foreach (DataGridViewColumn column in dataGridView_Sales.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        /// <summary>
        /// Сброс изменений в таблице
        /// </summary>
        private void button_Remove_Click(object sender, EventArgs e)
        {

            DataTable dt = _mainTable.Copy();
            dataGridView_Sales.DataSource = dt;
            if (comboBox_ChooseTable.Text != "Пользователи")
                dataGridView_Sales.Columns[0].Visible = false;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        private void button_Sort_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseTable.Text != "")
            {
                SortForm sort = new SortForm();
                DataTable table = _mainTable.Copy();
                if (comboBox_ChooseTable.Text != "Пользователи")
                dataGridView_Sales.Columns[0].Visible = false;
                sort.SetData(comboBox_ChooseTable.Text, _logicLayer, _columnNames);
                sort.ShowDialog();
                if (sort.DialogResult == DialogResult.OK)
                {
                    DataTable dt = sort.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if (comboBox_ChooseTable.Text != "Пользователи")
                        dataGridView_Sales.Columns[0].Visible = false;
                    sort.Close();
                }

            }
        }

        private void button_Find_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseTable.Text != "")
            {
                FindForm find = new FindForm();
                DataTable table = _mainTable.Copy();
                find.SetData(comboBox_ChooseTable.Text, _logicLayer, _columnNames, table);
                find.ShowDialog();
                if (find.DialogResult == DialogResult.OK)
                {
                    DataTable dt = find.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if (comboBox_ChooseTable.Text != "Пользователи")
                        dataGridView_Sales.Columns[0].Visible = false;
                    find.Close();
                }
                label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();

            }
        }

        private void button_Group_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseTable.Text != "")
            {
                GroupForm group = new GroupForm();
                DataTable table = _mainTable.Copy();
                group.SetData(comboBox_ChooseTable.Text, _logicLayer, _columnNames);
                group.ShowDialog();
                if (group.DialogResult == DialogResult.OK)
                {
                    DataTable dt = group.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    dataGridView_Sales.Refresh();
                    group.Close();
                }
                label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();

            }
        }

        private void button_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("   Данное приложение предназначено для работы с данными о продажах. \n" +
                "   Для начала работы необходимо загрузить базу данных в формате (*.accdb). \n" +
                "   После прохождения аутентификации или регистрации вы получите доступ к определенным функциям в соответствии с уровнем доступа. \n" +
                "   При регистрации вы получаете уровень доступа только для чтения.\n" +
                "   Перед этим необходимо выбрать таблицу с данными.\n" +
                "   При успешном выполнении описанных действий вы получите возможность:\n" +
                "   1. Просматривать выбранные данные\n" +
                "   2. Применять к данным сортировку, группировку или поиск по значению\n" +
                "   3. При соответствующем уровне доступа добавлять, изменять или удалять данные\n" +
                "   4. Создавать отчеты по данные, которые можно сохранить или распечатать", "Справка пользователя",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void button_ChangeUser_Click(object sender, EventArgs e)
        {
            ShowAuthentication();
        }

        private void dataGridView_Sales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(panel_Processing.Visible == true)
            {
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }
            var selectedRowIndex = e.RowIndex;
            OpenRemakeForm(selectedRowIndex);
        }
        private void OpenRemakeForm(int selectedRowIndex = 0)
        {
            RemakeDataForm form = new RemakeDataForm();
            form.SetPage(selectedRowIndex);
            form.SetDeleteRights(_rightsIndex <= 2);
            form.SetData(_mainTable, comboBox_ChooseTable.Text, _logicLayer);

            this.Hide();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.Cancel)
            {
                DataTable dt = form.GetDataTable();
                dataGridView_Sales.DataSource = dt;
                if (comboBox_ChooseTable.Text != "Пользователи")
                    dataGridView_Sales.Columns[0].Visible = false;
                form.Close();
                this.Show();
            }
        }
    }
}