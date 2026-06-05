using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WinFormsAppSales
{
    public partial class GroupForm : Form
    {
        private DataTable _dt = new DataTable();
        private string _name;
        private LogicLayer _logicLayer;
        private bool _wasProcess = false;
        public GroupForm()
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
        private void GetGroup()
        {
            if (comboBox_ChooseGroupParam.Text != "")
            {
                try
                {
                    _dt = _logicLayer.GroupData(_name, comboBox_ChooseGroupParam.Text);
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
                MessageBox.Show("Выберите столбец группировки");
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetGroup();
            if (_wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }
        private void FillComboBox(List<string> columnNames)
        {
            comboBox_ChooseGroupParam.Items.Clear();
            foreach (string name in columnNames)
            {
                comboBox_ChooseGroupParam.Items.Add(name);
            }
        }
    }
}
