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
        private DataTable mainTable = new DataTable();
        private OleDbDataAdapter currentAdapter = new OleDbDataAdapter();
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
            form.SetConnectionStirng(selectedBasePath);
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
        private void RightsSettings(string userRightsIndex)
        {
            int userRightsInt = Convert.ToInt32(userRightsIndex);
            if(userRightsInt > 1)
            {
                comboBox_ChooseTable.Items.Remove("Пользователи");
                comboBox_ChooseTable.Items.Remove("ПраваПользователей");
                if(userRightsInt > 2)
                {
                    if(userRightsInt > 3)
                    {
                        button_RemakeData.Visible = false;
                    }
                }
            }
        }
        private void button_LoadBase_Click(object sender, EventArgs e)
        {
            if (!DatabaseHelper.IsAceOleDb12Installed())
            {
                MessageBox.Show(
                    "Драйвер Microsoft.ACE.OLEDB.12.0 не установлен.\n" +
                    "Для работы приложения требуется установить Microsoft Access Database Engine 2010/2016.\n" +
                    "Загрузите его с официального сайта Microsoft."
                );
                return;
            }
            ChooseDatabase();
            FillNamesComboBox();
            ShowAuthentication();
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
            panel_ChooseTable.Visible = true;
        }
        private void button_ExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentAdapter != null)
            {
                currentAdapter.Dispose();
                currentAdapter = null;
            }
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
                remakeForm.SetData(mainTable, selectedBasePath, comboBox_ChooseTable.Text);
                this.Hide();
                remakeForm.ShowDialog();
                if (remakeForm.DialogResult == DialogResult.Cancel) 
                {
                    DataTable dt = remakeForm.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
                    remakeForm.Close();
                    this.Show();
                }

            }

        }
        private void button_Report_Click(object sender, EventArgs e)
        {
            if (CheckAvailability())
            {
                if (mainTable != null)
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
            dataGridView_Sales.DataSource = mainTable;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();

        }

        private void comboBox_ChooseTable_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadTable();
            if (mainTable != null)
            {
                FillTable();
            }

        }
        private void LoadTable()
        {
            string query = $"SELECT * FROM {comboBox_ChooseTable.SelectedItem}";
            var (table, adapter) = DatabaseHelper.ReadData(selectedBasePath, query);
            mainTable = table;
            if (currentAdapter != null)
            {
                currentAdapter.Dispose();
            }
            currentAdapter = adapter;
        }
        private void FillTable()
        {
            dataGridView_Sales.DataSource = mainTable;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }



        private void button_Remove_Click(object sender, EventArgs e)
        {

            DataTable dt = mainTable.Copy();
            dataGridView_Sales.DataSource = dt;
            label_StatInfoNum.Text = dataGridView_Sales.Rows.Count.ToString();
        }
        private void button_Sort_Click(object sender, EventArgs e)
        {
            if (comboBox_ChooseTable.Text != "")
            {
                SortForm sort = new SortForm();
                DataTable table = mainTable.Copy();
                sort.SetDataTable(table);
                this.Hide();
                sort.ShowDialog();
                if (sort.DialogResult == DialogResult.OK)
                {
                    DataTable dt = sort.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
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
                DataTable table = mainTable.Copy();
                find.SetDataTable(table);
                this.Hide();
                find.ShowDialog();
                if (find.DialogResult == DialogResult.OK)
                {
                    DataTable dt = find.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
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
                 DataTable table = mainTable.Copy();
                group.SetDataTable(table);
                this.Hide();
                group.ShowDialog();
                if (group.DialogResult == DialogResult.OK)
                {
                    DataTable dt = group.GetDataTable();
                    dataGridView_Sales.DataSource = dt;
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
    }
}