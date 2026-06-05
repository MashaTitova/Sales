using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppSales
{
    public partial class SortForm : Form
    {
        private DataTable _dt;
        private string _name;
        private LogicLayer _logicLayer;
        private bool _wasProcess = false;
        public SortForm()
        {
            InitializeComponent();
        }
        public void SetData(string nameOfTable, LogicLayer logicLayer, List<string> columnNames)
        {
            _name = nameOfTable;
            _logicLayer = logicLayer;
            FillComboBox(columnNames);
        }
        public DataTable GetDataTable()
        {
            return _dt;
        }
        private void button_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetSort()
        {
            if (comboBox_SortingColumn.Text != "" && comboBox_SortDirection.Text != "")
            {
                try
                {
                    _dt = _logicLayer.SortData(_name, comboBox_SortingColumn.Text, comboBox_SortDirection.Text);
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
                MessageBox.Show("Заполните все поля");
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetSort();
            if(_wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            
        }
        private void FillComboBox(List<string> columnNames)
        {
            comboBox_SortingColumn.Items.Clear();
            foreach (string name in columnNames)
            {
                comboBox_SortingColumn.Items.Add(name);
            }
        }
    }
}
