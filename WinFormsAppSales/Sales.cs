using ClassLibrarySales;
using FastReport;
using System.Data;
using System.Data.OleDb;
using FastReport.Preview;

namespace WinFormsAppSales
{

    /// <summary>
    /// Главная форма приложения.
    /// Служит для перемещений между остальными формами
    /// </summary>
    public partial class Form_Sales : Form
    {
        // Путь к выбранной базе данных
        private string _selectedBasePath = "";
        // DataTable с выбранными данными
        private DataTable _mainTable = new DataTable();
        private LogicLayer _logicLayer;
        private List<string> _columnNames = new List<string>();


        public Form_Sales()
        {
            InitializeComponent();

            foreach (DataGridViewColumn column in dataGridView_Sales.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
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
        /// Определение доступного функционала в соответствии с правами пользователя
        /// </summary>
        private void RightsSettings(string userRightsIndex)
        {
            int userRightsInt = Convert.ToInt32(userRightsIndex);
            if (userRightsInt > 1)
            {
                comboBox_ChooseTable.Items.Remove("Пользователи");
                comboBox_ChooseTable.Items.Remove("ПраваПользователей");
                if (userRightsInt > 2)
                {
                    if (userRightsInt > 3)
                    {
                        button_RemakeData.Visible = false;
                    }
                }
            }
        }
        /// <summary>
        /// Проверка на наличие нужного драйвера
        /// </summary>
        private void button_LoadBase_Click(object sender, EventArgs e)
        {
            ChooseDatabase();
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
                _logicLayer = new LogicLayer(_selectedBasePath);
            }
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
                tableNames = _logicLayer.GetTableNames();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (string tableName in tableNames)
            {
                comboBox_ChooseTable.Items.Add(tableName);
            }
            panel_ChooseTable.Visible = true;
        }
        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Sales_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Приложение будет закрыто",
                "Закрытие приложения",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
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
                RemakeDataForm remakeForm = new RemakeDataForm();
                remakeForm.SetData(_mainTable, comboBox_ChooseTable.Text, _logicLayer);
                this.Hide();
                remakeForm.ShowDialog();
                if (remakeForm.DialogResult == DialogResult.Cancel)
                {
                    DataTable dt = remakeForm.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                        dataGridView_Sales.Columns[0].Visible = false;
                    remakeForm.Close();
                    this.Show();
                }

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
        /// <summary>
        /// Проверка на получение необходимых данных
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
        private void ViewTable()
        {
            button_Return.Visible = true;
            panel_ChooseTable.Visible = false;
            button_Info.Visible = false;
            panel_StatInfo.Visible = true;
            panel_Base.Visible = true;
            flowLayoutPanel_HomeButtons.Visible = false;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            button_Return.Visible = false;
            button_Info.Visible = true;
            panel_StatInfo.Visible = false;
            panel_Base.Visible = false;
            panel_ChooseTable.Visible = true;
            flowLayoutPanel_HomeButtons.Visible = true;
            label_Name.Text = "Данные о продажах";
            if (panel_Processing.Visible == true)
            {
                panel_Processing.Visible = false;
            }
            dataGridView_Sales.DataSource = _mainTable;
            if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
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
        private void LoadTable()
        {
            if(comboBox_ChooseTable.Text == "")
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
            if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                dataGridView_Sales.Columns[0].Visible = false;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        /// <summary>
        /// Отображение изначальных данных
        /// </summary>
        private void button_Remove_Click(object sender, EventArgs e)
        {

            DataTable dt = _mainTable.Copy();
            dataGridView_Sales.DataSource = dt;
            if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                dataGridView_Sales.Columns[0].Visible = false;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        private void button_Sort_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseTable.Text != "")
            {
                SortForm sort = new SortForm();
                DataTable table = _mainTable.Copy();
                sort.SetData(comboBox_ChooseTable.Text, _logicLayer, _columnNames);
                this.Hide();
                sort.ShowDialog();
                if (sort.DialogResult == DialogResult.OK)
                {
                    DataTable dt = sort.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if(comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                     dataGridView_Sales.Columns[0].Visible = false;
                    sort.Close();
                    this.Show();
                }
                else
                {
                    this.Show();
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
                this.Hide();
                find.ShowDialog();
                if (find.DialogResult == DialogResult.OK)
                {
                    DataTable dt = find.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                        dataGridView_Sales.Columns[0].Visible = false;
                    find.Close();
                    this.Show();
                }
                else
                {
                    this.Show();
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
                this.Hide();
                group.ShowDialog();
                if (group.DialogResult == DialogResult.OK)
                {
                    DataTable dt = group.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    if (comboBox_ChooseTable.Text != "Пользователи" && comboBox_ChooseTable.Text != "ПраваПользователей")
                        dataGridView_Sales.Columns[0].Visible = false;
                    dataGridView_Sales.Refresh();
                    group.Close();
                    this.Show();
                }
                else
                {
                    this.Show();
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
    }
}