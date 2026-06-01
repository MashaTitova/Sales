using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppSales
{
    public partial class FindForm : Form
    {
        private DataTable dt = new DataTable();
        private bool wasProcess = false;
        public FindForm()
        {
            InitializeComponent();
            toolTip_Question.SetToolTip(label_ChooseFind, "Пример для числового поиска:\n" +
            "СтоимостьЕдиницы >= 5000\n" +
            "Пример для строкового поиска:\n" +
            "Модель = A01\n" +
            "ВНИМАНИЕ\n" +
            "Для составления выражений строкового поиска из представленных операторов сравнения выбирайте \"=\"\n");
        }
        public void SetDataTable(DataTable table)
        {
            dt = table;
            FillComboBox();
        }
        public DataTable GetDataTable()
        {
            return dt;
        }
        private void FillComboBox()
        {
            comboBox_ChooseFindParam.Items.Clear();
            foreach (DataColumn column in dt.Columns)
            {
                comboBox_ChooseFindParam.Items.Add(column.ColumnName);
            }
        }
        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetFind();
            if (wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            
        }
        private void GetFind()
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
                wasProcess = true;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
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

        private void button_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
