using ClassLibrarySales;
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
        int _page = 1;
        LogicLayer _logicLayer;
        public RemakeDataForm()
        {
            InitializeComponent();
        }
        public void SetData(DataTable dt, string name, LogicLayer logicLayer)
        {
            _data = dt;
            _nameOfTable = name;
            _logicLayer = logicLayer;
            CreatingFields();
            ShowPage();
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

                TextBox textBox = new TextBox();
                textBox.Height = 43;
                textBox.Width = 315;
                textBox.Name = $"textBox_{column.ColumnName}";
                textBox.Location = new System.Drawing.Point(470, y);
                this.Controls.Add(textBox);

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

            y += 110;

            Button buttonDelete = new Button();
            buttonDelete.Height = 100;
            buttonDelete.Width = 300;
            buttonDelete.Text = "Удалить запись";
            buttonDelete.Name = $"button_Delete";
            buttonDelete.Location = new System.Drawing.Point(255, y);
            buttonDelete.Click += button_Delete_Click;
            this.Controls.Add(buttonDelete);

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

        private void ShowPage()
        {
            // Проверяем, что страница существует
            if (_page <= 0 || _page > _data.Rows.Count) return;

            DataRow currentRow = _data.Rows[_page - 1];
            if (currentRow.RowState == DataRowState.Deleted)
            {
                return;
            }

            foreach (DataColumn column in _data.Columns)
            {
                string textBoxName = $"textBox_{column.ColumnName}";

                // Находим элемент управления по имени
                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                if (textBox != null)
                {
                    if (currentRow.RowState == DataRowState.Deleted)
                        continue;
                    // Берем значение из текущей строки и текущего столбца
                    textBox.Text = currentRow[column].ToString();
                }
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            string text = "";
            if (_page <= 0 || _page > _data.Rows.Count) return;


            string errorMessage;
            if (!ValidateFormData(out errorMessage))
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow currentRow = _data.Rows[_page - 1];
            // Проверка: если строка удалена, не сохраняем
            if (currentRow.RowState == DataRowState.Deleted)
            {
                MessageBox.Show("Невозможно сохранить изменения: текущая запись была удалена.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataColumn column in _data.Columns)
            {
                string textBoxName = $"textBox_{column.ColumnName}";
                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                if (textBox != null && textBox.Text != null)
                {
                    if (_nameOfTable == "Пользователи" && textBoxName == "textBox_Пароль")
                    {
                        text = _logicLayer.HashUserInput(textBox.Text);
                    }
                    else
                    {
                        text = textBox.Text;
                    }
                    // Записываем изменения в DataTable
                    currentRow[column] = text;
                }
            }
            MessageBox.Show("Текущие изменения успешно сохранены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private bool ValidateFormData(out string errorMessage)
        {
            errorMessage = "";

            // Собираем значения из TextBox в словарь 
            var formValues = new Dictionary<DataColumn, string>();
            for (int i = 0; i < _data.Columns.Count; i++)
            {
                if (i == 0 && _nameOfTable != "Пользователи")
                {
                    continue;
                }
                DataColumn column = _data.Columns[i];
                string textBoxName = $"textBox_{column.ColumnName}";
                TextBox textBox = this.Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    formValues[column] = textBox.Text;
                }
            }

            for (int i = 1; i < _data.Columns.Count; i++)
            {
                if (i == 0 && _nameOfTable != "Пользователи")
                {
                    continue;
                }
                DataColumn column = _data.Columns[i];
                string value = formValues[column];

                // Проверка типа данных
                if (!string.IsNullOrWhiteSpace(value))
                {
                    try
                    {
                        Convert.ChangeType(value, column.DataType);
                    }
                    catch (Exception)
                    {
                        errorMessage = $"В поле \"{column.ColumnName}\" введено некорректное значение. Ожидается тип: {column.DataType.Name}";
                        return false;
                    }
                }

                // Проверка длины строк
                if (column.DataType == typeof(string))
                {
                    int maxLength = column.MaxLength;
                    if (maxLength > 0 && !string.IsNullOrWhiteSpace(value))
                    {
                        if (value.Length > maxLength)
                        {
                            errorMessage = $"Длина значения в поле \"{column.ColumnName}\" превышает допустимую ({maxLength} символов).";
                            return false;
                        }
                    }
                }
            }
            errorMessage = "";
            return true;
        }
        private void button_Add_Click(object sender, EventArgs e)
        {
            DataRow newRow = _data.NewRow();
            _data.Rows.Add(newRow);

            // Переключаемся на новую запись
            _page = _data.Rows.Count;
            ShowPage();
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (_page <= 0 || _page > _data.Rows.Count) return;

            DataRow currentRow = _data.Rows[_page - 1];
            DialogResult result = MessageBox.Show(
                "Вы действительно хотите удалить запись?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            currentRow.Delete();
            if (result == DialogResult.Yes)
            {
                // Обновляем отображение страницы
                ShowPage();
                MessageBox.Show("Данные успешно удалены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private bool SaveToAccess()
        {
            try
            {
                _logicLayer.SaveToAccess(_data, _nameOfTable);
                MessageBox.Show("Данные успешно сохранены в базу данных", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                $"Ошибка при сохранении в базу данных:\n{ex.Message}\n\n" +
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
    }
}
