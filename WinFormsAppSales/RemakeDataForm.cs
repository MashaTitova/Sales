using ClassLibrarySales;
using FastReport.Table;
using System.Data;
using System.Data.OleDb;

namespace WinFormsAppSales
{
    /// <summary>
    /// Форма для добавления, изменения или удаления данных
    /// </summary>
    public partial class RemakeDataForm : Form
    {
        private DataTable _data;
        private string _nameOfTable;
        private int _page = 1;
        private LogicLayer _logicLayer;
        private bool _deleteRights;
        public RemakeDataForm()
        {
            InitializeComponent();
           
        }
        public void SetData(DataTable dt, string name, LogicLayer logicLayer)
        {
            _data = dt;
            _nameOfTable = name;
            _logicLayer = logicLayer;
            _page = 1;
            CreatingFields();
            ShowPage();
        }
        
        public void SetDeleteRights(bool rights)
        {
            _deleteRights = rights;
        }
        public DataTable GetDataTable()
        {
            return _data;
        }

        
        /// <summary>
        /// Динамическое создание интерфейса формы
        /// </summary>
        private void CreatingFields()
        {
            int y = 65;
            for (int i = 0; i < _data.Columns.Count; i++)
            {
                if ((i == 0 && _nameOfTable != "Пользователи") && (i == 0 && _nameOfTable != "ПраваПользователей"))
                {
                    continue;
                }
                DataColumn column = _data.Columns[i];
                Label label = new Label();
                label.Height = 43;
                label.Width = 315;
                label.Text = column.ColumnName;
                label.Name = $"label_{column.ColumnName}";
                label.Location = new System.Drawing.Point(55, y);
                this.Controls.Add(label);
                if (column.ColumnName.Contains("Код") && !column.ColumnName.Equals("КодПравПользователя") || column.ColumnName.Equals("СерийныйНомер"))
                {
                    ComboBox comboBox = new ComboBox();
                    comboBox.Height = 43;
                    comboBox.Width = 315;
                    comboBox.Name = $"comboBox_{column.ColumnName}";
                    comboBox.Location = new System.Drawing.Point(470, y);
                    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (column.ColumnName == "СерийныйНомер")
                    {
                        var items = _logicLayer.GetSerialAndModelPairs();
                        comboBox.Items.AddRange(items.ToArray());
                    }
                    else
                    {
                        var items = _logicLayer.GetAllValuesFromColumn(column.ColumnName, _nameOfTable);
                        comboBox.Items.AddRange(items.ToArray());
                    }
                    this.Controls.Add(comboBox);
                }
                else
                {
                    TextBox textBox = new TextBox();
                    textBox.Height = 43;
                    textBox.Width = 315;
                    textBox.Name = $"textBox_{column.ColumnName}";
                    textBox.Location = new System.Drawing.Point(470, y);
                    this.Controls.Add(textBox);


                }
                y += 53;
            }
            Button buttonLast = new Button();
            buttonLast.Height = 50;
            buttonLast.Width = 50;
            buttonLast.Text = "<-";
            buttonLast.Name = $"button_Last";
            buttonLast.Location = new System.Drawing.Point(155, y);
            buttonLast.Click += button_Last_Click;
            this.Controls.Add(buttonLast);

            Button buttonNext = new Button();
            buttonNext.Height = 50;
            buttonNext.Width = 50;
            buttonNext.Text = "->";
            buttonNext.Name = $"button_Next";
            buttonNext.Location = new System.Drawing.Point(603, y);
            buttonNext.Click += button_Next_Click;
            this.Controls.Add(buttonNext);

            y += 60;

            Button buttonAdd = new Button();
            buttonAdd.Height = 100;
            buttonAdd.Width = 300;
            buttonAdd.Text = "Добавить запись";
            buttonAdd.Name = $"button_Add";
            buttonAdd.Location = new System.Drawing.Point(255, y);
            buttonAdd.Click += button_Add_Click;
            this.Controls.Add(buttonAdd);

            y += 110;

            Button buttonSave = new Button();
            buttonSave.Height = 100;
            buttonSave.Width = 300;
            buttonSave.Text = "Сохранить изменения в записи";
            buttonSave.Name = $"button_Save";
            buttonSave.Location = new System.Drawing.Point(255, y);
            buttonSave.Click += button_Save_Click;
            this.Controls.Add(buttonSave);

            if (_deleteRights)
            {
                y += 110;

                Button buttonDelete = new Button();
                buttonDelete.Height = 100;
                buttonDelete.Width = 300;
                buttonDelete.Text = "Удалить запись";
                buttonDelete.Name = $"button_Delete";
                buttonDelete.Location = new System.Drawing.Point(255, y);
                buttonDelete.Click += button_Delete_Click;
                this.Controls.Add(buttonDelete);
            }
            y += 110;

            Button buttonReturn = new Button();
            buttonReturn.Height = 100;
            buttonReturn.Width = 300;
            buttonReturn.Text = "Сохранить в базу данных и выйти";
            buttonReturn.Name = $"button_Return";
            buttonReturn.Location = new System.Drawing.Point(255, y);
            buttonReturn.Click += button_Return_Click;
            this.Controls.Add(buttonReturn);

            y += 200;

            this.Height = y;
        }

        private void button_Next_Click(object sender, EventArgs e)
        {
            if (_page < _data.Rows.Count)
            {
                _page++;
                ShowPage();
            }
        }
        private void button_Last_Click(object sender, EventArgs e)
        {
            if (_page > 1)
            {
                _page--;
                ShowPage();
            }
        }
        private void button_Return_Click(object sender, EventArgs e)
        {
            if (SaveToAccess()) this.Close();
        }
        /// <summary>
        /// Отображение записи
        /// </summary>
        private void ShowPage()
        {
            if (_page <= 0 || _page > _data.Rows.Count) return;

            DataRow currentRow = _data.Rows[_page - 1];
            if (currentRow.RowState == DataRowState.Deleted) return;

            bool isNewRow = (currentRow.RowState == DataRowState.Added);

            FillTextBoxes(currentRow);
            FillComboBoxes(currentRow);
            SetUpAccess(currentRow);
            SetUpAccessUserRights(currentRow);
        }
        private void FillTextBoxes(DataRow currentRow)
        {
            foreach (DataColumn column in _data.Columns)
            {
                string textBoxName = $"textBox_{column.ColumnName}";
                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    object value = currentRow[column];
                    textBox.Text = value != DBNull.Value ? value.ToString() : "";
                }
            }
        }
        private void FillComboBoxes(DataRow currentRow)
        {
            foreach (DataColumn column in _data.Columns)
            {
                string comboBoxName = $"comboBox_{column.ColumnName}";
                ComboBox comboBox = this.Controls.Find(comboBoxName, true).FirstOrDefault() as ComboBox;

                if (comboBox == null) continue;

                object currentValue = currentRow[column];
                if (currentValue == DBNull.Value)
                {
                    comboBox.SelectedIndex = -1;
                    continue;
                }

                string currentValueStr = currentValue.ToString().Trim();

                int index = -1;
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    string item = comboBox.Items[i].ToString();
                    if (item.StartsWith(currentValueStr + " - "))
                    {
                        index = i;
                        break;
                    }
                }

                comboBox.SelectedIndex = index;
            }
        }
        public void SetUpAccessUserRights(DataRow currentRow)
        {
            if (_nameOfTable == "ПраваПользователей")
            {
                isAvailableUserRights(false);
            }
            else
            {
                isAvailableUserRights(true);
            }
        }
        private void SetUpAccess(DataRow currentRow)
        {
            Button buttonSave = this.Controls["button_Save"] as Button;
            if (_nameOfTable == "Пользователи" && Convert.ToInt32(currentRow["КодПравПользователя"]) == 1)
            {   
                IsAvailableUsers(false);

                if (buttonSave != null)
                {
                    buttonSave.Enabled = false;
                }
            }
            else
            {
                IsAvailableUsers(true);
                buttonSave.Enabled = true;
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                MessageBox.Show("Текущие изменения успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// Сохранение изменений в таблицу
        /// </summary>
        private bool Save()
        {
            if (!IsValidPage())
                return false;

            string errorMessage;
            if (!ValidateFormData(out errorMessage))
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DataRow currentRow = _data.Rows[_page - 1];
            if (IsRowDeleted(currentRow))
                return false;
                
            UpdateRowData(currentRow);
            return true;
        }
        private void isAvailableUserRights(bool available = true)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox tb && tb.Name == "textBox_КодПравПользователя")
                {
                    tb.Enabled = available;
                }
            }
        }
        private void IsAvailableUsers(bool available = true)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox tb)
                {
                    tb.Enabled = available;
                }
                else if (ctl is ComboBox cb)
                {
                    cb.Enabled = available;
                }
            }
        }
        private bool IsValidPage()
        {
            if (_page <= 0 || _page > _data.Rows.Count)
            {
                MessageBox.Show("Некорректный номер страницы.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsRowDeleted(DataRow row)
        {
            if (row.RowState == DataRowState.Deleted)
            {
                MessageBox.Show("Невозможно сохранить изменения: текущая запись была удалена.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void UpdateRowData(DataRow currentRow)
        {
            foreach (DataColumn column in _data.Columns)
            {
                string textBoxName = $"textBox_{column.ColumnName}";
                string comboBoxName = $"comboBox_{column.ColumnName}";

                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;
                ComboBox comboBox = this.Controls.Find(comboBoxName, true).FirstOrDefault() as ComboBox;



                if (comboBox != null && comboBox.Visible && comboBox.SelectedItem != null)
                {
                    string selected = comboBox.SelectedItem.ToString();
                    string[] parts = selected.Split(" - ", 2);
                    if (parts.Length >= 1)
                    {
                        currentRow[column] = Convert.ToInt32(parts[0]);
                    }
                }
                
                else if (textBox != null && textBox.Text != null)
                {
                    string text = GetTextBoxValue(textBox);
                    if (!string.IsNullOrEmpty(text))
                    {
                        currentRow[column] = text;
                    }
                }
            }
        }
        /// <summary>
        /// Получение значения из TextBox с учетом условия
        /// </summary>
        private string GetTextBoxValue(TextBox textBox)
        {
            if (_nameOfTable == "Пользователи" && textBox.Name == "textBox_Пароль")
            {
                return _logicLayer.HashUserInput(textBox.Text);
            }
            return textBox.Text;
        }
        /// <summary>
        /// Валидация добавленных значений
        /// </summary>
        private bool ValidateFormData(out string errorMessage)
        {
            errorMessage = "";

            var formValues = CollectFormValues();

            foreach (var kvp in formValues)
            {
                DataColumn column = kvp.Key;
                string value = kvp.Value;
                if(string.IsNullOrEmpty(value)) continue;

                if (!ValidateDataType(column, value, out errorMessage))
                    return false;

                if (column.DataType == typeof(string) && !ValidateStringLength(column, value, out errorMessage))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Собираем значения в словарь по столбцу
        /// </summary>
        private Dictionary<DataColumn, string> CollectFormValues()
        {
            var formValues = new Dictionary<DataColumn, string>();

            for (int i = 0; i < _data.Columns.Count; i++)
            {
                DataColumn column = _data.Columns[i];

                if (i == 0 && (_nameOfTable != "Пользователи" && _nameOfTable != "ПраваПользователей"))
                    continue;

                string textBoxName = $"textBox_{column.ColumnName}";
                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    formValues[column] = textBox.Text;
                }
            }
            return formValues;
        }
        /// <summary>
        /// Проверка типа значения
        /// </summary>
        private bool ValidateDataType(DataColumn column, string value, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Convert.ChangeType(value, column.DataType);
            }
            catch (Exception)
            {
                errorMessage = $"В поле \"{column.ColumnName}\" введено некорректное значение. Ожидается тип: {column.DataType.Name}";
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на соответствие допустимой длине строки
        /// </summary>
        private bool ValidateStringLength(DataColumn column, string value, out string errorMessage)
        {
            errorMessage = "";
            int maxLength = column.MaxLength;
            if (maxLength > 0 && value.Length > maxLength)
            {
                errorMessage = $"Длина значения в поле \"{column.ColumnName}\" превышает допустимую ({maxLength} символов).";
                return false;
            }
            return true;
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            DataRow newRow = _data.NewRow();
            _data.Rows.Add(newRow);
            _page = _data.Rows.Count; 
            ShowPage();
        }
       
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (_page <= 0 || _page > _data.Rows.Count) return;
           
            DataRow currentRow = _data.Rows[_page - 1];
            if (_nameOfTable == "Пользователи" && Convert.ToInt32(currentRow["КодПравПользователя"]) == 1)
            {
                MessageBox.Show("Невозможно удалить пользователя с правом доступа \"Администратор\"");
                return;
            }
            DialogResult result = MessageBox.Show(
            "Вы действительно хотите удалить запись?",
            "Подтверждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentRow.Delete();
                ShowPage();
                MessageBox.Show("Данные успешно удалены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private bool SaveToAccess()
        {
            if (!Save())
            {
                return false;
            }
            try
            {
                _logicLayer.SaveToAccess(_data, _nameOfTable);
                MessageBox.Show("Данные успешно сохранены в базу данных", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                $"Ошибка при сохранении в базу данных:\n" +
                $"{ex.Message}\n" +
                "Проверьте корректность данных и соединение с базой.",
                "Ошибка базы данных",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                $"Неизвестная ошибка при сохранении:\n{ex.Message}",
                "Критическая ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }
        }

        private void RemakeDataForm_Load(object sender, EventArgs e)
        {

        }
    }
}
