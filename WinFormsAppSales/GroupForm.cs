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
    public partial class GroupForm : Form
    {
        private DataTable dt = new DataTable();
        private bool wasProcess = false;
        public GroupForm()
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
        private void GetGroup()
        {
            if (comboBox_ChooseGroupParam.Text != "")
            {
                dt = DataProcessing.Group(dt, comboBox_ChooseGroupParam.Text);
                wasProcess = true;
            }
            else
            {
                MessageBox.Show("Выберите столбец группировки");
            }
        }

        private void button_DataProcessing_Click(object sender, EventArgs e)
        {
            GetGroup();
            if (wasProcess)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }
        private void FillComboBox()
        {
            comboBox_ChooseGroupParam.Items.Clear();
            foreach (DataColumn column in dt.Columns)
            {
                comboBox_ChooseGroupParam.Items.Add(column.ColumnName);
            }
        }
    }
}
