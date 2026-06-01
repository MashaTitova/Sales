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
    public partial class SortForm : Form
    {
        private DataTable dt = new DataTable();
        private bool wasProcess = false;
        public SortForm()
        {
            InitializeComponent();
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
        private void button_Return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetSort()
        {
            if (comboBox_SortingColumn.Text != "" && comboBox_SortDirection.Text != "")
            {
                DataProcessing.CustomSort(dt, comboBox_SortDirection.Text, comboBox_SortingColumn.Text);
                wasProcess = true;
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetSort();
            if(wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            
        }
        private void FillComboBox()
        {
            comboBox_SortingColumn.Items.Clear();
            foreach (DataColumn column in dt.Columns)
            {
                comboBox_SortingColumn.Items.Add(column.ColumnName);
            }
        }
    }
}
