using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsAppSales
{
    public partial class FindForm : Form
    {
        private DataTable _dt = new DataTable();
        private string _name;
        private LogicLayer _logicLayer;
        private bool _wasProcess = false;
        public FindForm()
        {
            InitializeComponent();
            toolTip_Question.SetToolTip(label_ChooseFind, "Пример для числового поиска:\n" +
            "СтоимостьЕдиницы >= 5000\n" +
            "Пример для строкового поиска (точное совпадение):\n" +
            "Модель = A01\n" +
            "ВНИМАНИЕ\n" +
            "Для составления выражений строкового поиска из представленных операторов сравнения выбирайте \"=\"\n");
        }
        public void SetData(string nameOfTable, LogicLayer logicLayer, List<string> columnNames, DataTable table)
        {
            _dt = table;
            _name = nameOfTable;
            _logicLayer = logicLayer;
            FillComboBox(columnNames);
        }
        public DataTable GetDataTable()
        {
            return _dt;
        }
        private void FillComboBox(List<string> columnNames)
        {
            comboBox_ChooseFindParam.Items.Clear();
            foreach (string name in columnNames)
            {
                comboBox_ChooseFindParam.Items.Add(name);
            }
        }
        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetFind();
            if (_wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            
        }
        private void GetFind()
        {
            if (comboBox_ChooseFindParam.Text != "" && comboBox_FindRatio.Text != "" && textBox_ChooseFind.Text != "" && (radioButton_NumFind.Checked || radioButton_StringFind.Checked))
            {
                if (radioButton_StringFind.Checked)
                {
                    if(comboBox_FindRatio.Text == "=")
                    {
                        try
                        {
                            _dt = _logicLayer.FilterString(_name, comboBox_ChooseFindParam.Text, textBox_ChooseFind.Text.Trim());
                            _wasProcess = true;
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
                    else
                    {
                        MessageBox.Show("Для числового поиска выберите знак =");
                    }
                }
                else
                {
                    if (radioButton_NumFind.Checked)
                    {
                        // Проверка: введено ли число или дата
                        if (!CheckNumInput(textBox_ChooseFind.Text.Trim()))
                        {
                            MessageBox.Show("Значение для поиска должно быть числом или датой", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Проверка: является ли выбранный столбец числовым или датой
                        if (!IsNumericOrDateTimeColumn(_dt, comboBox_ChooseFindParam.Text))
                        {
                            MessageBox.Show($"Столбец '{comboBox_ChooseFindParam.Text}' не является числовым или датой. Числовой поиск невозможен.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Проверка: можно ли преобразовать введённое значение к типу столбца
                        object convertedValue;
                        if (!IsValidValueForColumn(_dt, comboBox_ChooseFindParam.Text, textBox_ChooseFind.Text.Trim(), out convertedValue))
                        {
                            MessageBox.Show($"Введённое значение '{textBox_ChooseFind.Text}' несовместимо с типом столбца '{comboBox_ChooseFindParam.Text}'.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        try
                        {
                            _dt = _logicLayer.FilterNum(_name, comboBox_ChooseFindParam.Text, comboBox_FindRatio.Text, textBox_ChooseFind.Text.Trim());
                            _wasProcess = true;
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
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        private bool IsValidValueForColumn(DataTable table, string columnName, string inputValue, out object convertedValue)
        {
            convertedValue = null;
            DataColumn column = table.Columns[columnName];
            Type columnType = column.DataType;

            try
            {
                if (columnType == typeof(DateTime))
                {
                    if (DateTime.TryParse(inputValue, out DateTime dateValue))
                    {
                        convertedValue = dateValue;
                        return true;
                    }
                }
                else if (columnType == typeof(int))
                {
                    if (int.TryParse(inputValue, out int intValue))
                    {
                        convertedValue = intValue;
                        return true;
                    }
                }
                else if (columnType == typeof(double))
                {
                    if (double.TryParse(inputValue, out double doubleValue))
                    {
                        convertedValue = doubleValue;
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }
        private bool CheckNumInput(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
                return false;

            return int.TryParse(input, out _) || double.TryParse(input, out _) || DateTime.TryParse(input, out _);
        }
        private bool IsNumericOrDateTimeColumn(DataTable table, string columnName)
        {
            DataColumn column = table.Columns[columnName];
            Type columnType = column.DataType;

            return columnType == typeof(int) ||
                   columnType == typeof(double) ||
                   columnType == typeof(DateTime);
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
