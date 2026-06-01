namespace WinFormsAppSales
{
    partial class Form_Sales
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Sales));
            panel_Main = new Panel();
            button_Info = new Button();
            button_Return = new Button();
            flowLayoutPanel_HomeButtons = new FlowLayoutPanel();
            button_LoadBase = new Button();
            button_DataViewing = new Button();
            button_DataProcessing = new Button();
            button_RemakeData = new Button();
            button_Report = new Button();
            button_ExitApp = new Button();
            panel_Processing = new Panel();
            button_Group = new Button();
            button_Remove = new Button();
            button_Find = new Button();
            button_Sort = new Button();
            panel_ChooseTable = new Panel();
            label_ChooseTable = new Label();
            comboBox_ChooseTable = new ComboBox();
            panel_StatInfo = new Panel();
            label_StatInfo = new Label();
            label_StatInfoNum = new Label();
            panel_Base = new Panel();
            dataGridView_Sales = new DataGridView();
            label_Name = new Label();
            toolTip_Find = new ToolTip(components);
            toolTip1 = new ToolTip(components);
            panel_Main.SuspendLayout();
            flowLayoutPanel_HomeButtons.SuspendLayout();
            panel_Processing.SuspendLayout();
            panel_ChooseTable.SuspendLayout();
            panel_StatInfo.SuspendLayout();
            panel_Base.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Sales).BeginInit();
            SuspendLayout();
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.Transparent;
            panel_Main.Controls.Add(button_Info);
            panel_Main.Controls.Add(button_Return);
            panel_Main.Controls.Add(flowLayoutPanel_HomeButtons);
            panel_Main.Controls.Add(panel_Processing);
            panel_Main.Controls.Add(panel_ChooseTable);
            panel_Main.Controls.Add(panel_StatInfo);
            panel_Main.Controls.Add(panel_Base);
            panel_Main.Controls.Add(label_Name);
            panel_Main.Dock = DockStyle.Fill;
            panel_Main.Location = new Point(0, 0);
            panel_Main.Margin = new Padding(4, 2, 4, 2);
            panel_Main.Name = "panel_Main";
            panel_Main.Size = new Size(1622, 1164);
            panel_Main.TabIndex = 8;
            // 
            // button_Info
            // 
            button_Info.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Info.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Info.Location = new Point(6, 1067);
            button_Info.Name = "button_Info";
            button_Info.Size = new Size(187, 87);
            button_Info.TabIndex = 48;
            button_Info.Text = "Справка пользователя";
            button_Info.UseVisualStyleBackColor = true;
            // 
            // button_Return
            // 
            button_Return.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Return.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Return.Location = new Point(6, 1067);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(187, 87);
            button_Return.TabIndex = 47;
            button_Return.Text = "Возврат в главное меню";
            button_Return.UseVisualStyleBackColor = true;
            button_Return.Visible = false;
            button_Return.Click += button_Return_Click;
            // 
            // flowLayoutPanel_HomeButtons
            // 
            flowLayoutPanel_HomeButtons.Anchor = AnchorStyles.None;
            flowLayoutPanel_HomeButtons.AutoSize = true;
            flowLayoutPanel_HomeButtons.BackColor = Color.Transparent;
            flowLayoutPanel_HomeButtons.Controls.Add(button_LoadBase);
            flowLayoutPanel_HomeButtons.Controls.Add(button_DataViewing);
            flowLayoutPanel_HomeButtons.Controls.Add(button_DataProcessing);
            flowLayoutPanel_HomeButtons.Controls.Add(button_RemakeData);
            flowLayoutPanel_HomeButtons.Controls.Add(button_Report);
            flowLayoutPanel_HomeButtons.Controls.Add(button_ExitApp);
            flowLayoutPanel_HomeButtons.Location = new Point(528, 257);
            flowLayoutPanel_HomeButtons.Margin = new Padding(4, 2, 4, 2);
            flowLayoutPanel_HomeButtons.MaximumSize = new Size(700, 800);
            flowLayoutPanel_HomeButtons.MinimumSize = new Size(496, 582);
            flowLayoutPanel_HomeButtons.Name = "flowLayoutPanel_HomeButtons";
            flowLayoutPanel_HomeButtons.Size = new Size(598, 714);
            flowLayoutPanel_HomeButtons.TabIndex = 9;
            // 
            // button_LoadBase
            // 
            button_LoadBase.AutoSize = true;
            button_LoadBase.BackColor = Color.Transparent;
            button_LoadBase.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_LoadBase.Location = new Point(4, 2);
            button_LoadBase.Margin = new Padding(4, 2, 4, 2);
            button_LoadBase.Name = "button_LoadBase";
            button_LoadBase.Size = new Size(590, 114);
            button_LoadBase.TabIndex = 7;
            button_LoadBase.Text = "Загрузка базы данных";
            button_LoadBase.UseVisualStyleBackColor = false;
            button_LoadBase.Click += button_LoadBase_Click;
            // 
            // button_DataViewing
            // 
            button_DataViewing.AutoSize = true;
            button_DataViewing.BackColor = Color.Transparent;
            button_DataViewing.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_DataViewing.Location = new Point(4, 120);
            button_DataViewing.Margin = new Padding(4, 2, 4, 2);
            button_DataViewing.Name = "button_DataViewing";
            button_DataViewing.Size = new Size(590, 114);
            button_DataViewing.TabIndex = 12;
            button_DataViewing.Text = "Просмотр данных";
            button_DataViewing.UseVisualStyleBackColor = false;
            button_DataViewing.Click += button_DataViewing_Click;
            // 
            // button_DataProcessing
            // 
            button_DataProcessing.AutoSize = true;
            button_DataProcessing.BackColor = Color.Transparent;
            button_DataProcessing.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_DataProcessing.Location = new Point(4, 238);
            button_DataProcessing.Margin = new Padding(4, 2, 4, 2);
            button_DataProcessing.Name = "button_DataProcessing";
            button_DataProcessing.Size = new Size(590, 114);
            button_DataProcessing.TabIndex = 8;
            button_DataProcessing.Text = "Обработка данных";
            button_DataProcessing.UseVisualStyleBackColor = false;
            button_DataProcessing.Click += button_DataProcessing_Click;
            // 
            // button_RemakeData
            // 
            button_RemakeData.AutoSize = true;
            button_RemakeData.BackColor = Color.Transparent;
            button_RemakeData.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_RemakeData.Location = new Point(4, 356);
            button_RemakeData.Margin = new Padding(4, 2, 4, 2);
            button_RemakeData.Name = "button_RemakeData";
            button_RemakeData.Size = new Size(590, 114);
            button_RemakeData.TabIndex = 9;
            button_RemakeData.Text = "Изменение данных";
            button_RemakeData.UseVisualStyleBackColor = false;
            button_RemakeData.Click += button_RemakeData_Click;
            // 
            // button_Report
            // 
            button_Report.AutoSize = true;
            button_Report.BackColor = Color.Transparent;
            button_Report.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Report.Location = new Point(4, 474);
            button_Report.Margin = new Padding(4, 2, 4, 2);
            button_Report.Name = "button_Report";
            button_Report.Size = new Size(590, 114);
            button_Report.TabIndex = 10;
            button_Report.Text = "Создание отчета";
            button_Report.UseVisualStyleBackColor = false;
            button_Report.Click += button_Report_Click;
            // 
            // button_ExitApp
            // 
            button_ExitApp.AutoSize = true;
            button_ExitApp.BackColor = Color.Transparent;
            button_ExitApp.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_ExitApp.Location = new Point(4, 592);
            button_ExitApp.Margin = new Padding(4, 2, 4, 2);
            button_ExitApp.Name = "button_ExitApp";
            button_ExitApp.Size = new Size(590, 114);
            button_ExitApp.TabIndex = 11;
            button_ExitApp.Text = "Выход из приложения";
            button_ExitApp.UseVisualStyleBackColor = false;
            button_ExitApp.Click += button_ExitApp_Click;
            // 
            // panel_Processing
            // 
            panel_Processing.Controls.Add(button_Group);
            panel_Processing.Controls.Add(button_Remove);
            panel_Processing.Controls.Add(button_Find);
            panel_Processing.Controls.Add(button_Sort);
            panel_Processing.Location = new Point(3, 262);
            panel_Processing.Name = "panel_Processing";
            panel_Processing.Size = new Size(549, 799);
            panel_Processing.TabIndex = 28;
            panel_Processing.Visible = false;
            // 
            // button_Group
            // 
            button_Group.AutoSize = true;
            button_Group.BackColor = Color.Transparent;
            button_Group.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Group.Location = new Point(72, 351);
            button_Group.Margin = new Padding(4, 2, 4, 2);
            button_Group.Name = "button_Group";
            button_Group.Size = new Size(388, 94);
            button_Group.TabIndex = 15;
            button_Group.Text = "Группировка";
            button_Group.UseVisualStyleBackColor = false;
            button_Group.Click += button_Group_Click;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Remove.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Remove.Location = new Point(72, 489);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(388, 94);
            button_Remove.TabIndex = 46;
            button_Remove.Text = " Снять обработку";
            button_Remove.UseVisualStyleBackColor = true;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_Find
            // 
            button_Find.AutoSize = true;
            button_Find.BackColor = Color.Transparent;
            button_Find.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Find.Location = new Point(72, 213);
            button_Find.Margin = new Padding(4, 2, 4, 2);
            button_Find.Name = "button_Find";
            button_Find.Size = new Size(388, 94);
            button_Find.TabIndex = 14;
            button_Find.Text = "Поиск";
            button_Find.UseVisualStyleBackColor = false;
            button_Find.Click += button_Find_Click;
            // 
            // button_Sort
            // 
            button_Sort.AutoSize = true;
            button_Sort.BackColor = Color.Transparent;
            button_Sort.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Sort.Location = new Point(72, 77);
            button_Sort.Margin = new Padding(4, 2, 4, 2);
            button_Sort.Name = "button_Sort";
            button_Sort.Size = new Size(388, 94);
            button_Sort.TabIndex = 13;
            button_Sort.Text = "Сортировка";
            button_Sort.UseVisualStyleBackColor = false;
            button_Sort.Click += button_Sort_Click;
            // 
            // panel_ChooseTable
            // 
            panel_ChooseTable.Controls.Add(label_ChooseTable);
            panel_ChooseTable.Controls.Add(comboBox_ChooseTable);
            panel_ChooseTable.Location = new Point(3, 88);
            panel_ChooseTable.Name = "panel_ChooseTable";
            panel_ChooseTable.Size = new Size(549, 172);
            panel_ChooseTable.TabIndex = 36;
            panel_ChooseTable.Visible = false;
            // 
            // label_ChooseTable
            // 
            label_ChooseTable.Anchor = AnchorStyles.None;
            label_ChooseTable.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_ChooseTable.Location = new Point(62, 41);
            label_ChooseTable.Margin = new Padding(4, 0, 4, 0);
            label_ChooseTable.Name = "label_ChooseTable";
            label_ChooseTable.Size = new Size(427, 45);
            label_ChooseTable.TabIndex = 29;
            label_ChooseTable.Text = "Выберите таблицу для работы";
            label_ChooseTable.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_ChooseTable
            // 
            comboBox_ChooseTable.Anchor = AnchorStyles.None;
            comboBox_ChooseTable.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseTable.ForeColor = Color.Black;
            comboBox_ChooseTable.FormattingEnabled = true;
            comboBox_ChooseTable.Location = new Point(54, 98);
            comboBox_ChooseTable.Margin = new Padding(4, 2, 4, 2);
            comboBox_ChooseTable.Name = "comboBox_ChooseTable";
            comboBox_ChooseTable.Size = new Size(435, 40);
            comboBox_ChooseTable.TabIndex = 28;
            comboBox_ChooseTable.SelectedValueChanged += comboBox_ChooseTable_SelectedValueChanged;
            // 
            // panel_StatInfo
            // 
            panel_StatInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panel_StatInfo.AutoSize = true;
            panel_StatInfo.Controls.Add(label_StatInfo);
            panel_StatInfo.Controls.Add(label_StatInfoNum);
            panel_StatInfo.Location = new Point(1149, 1075);
            panel_StatInfo.Margin = new Padding(4, 2, 4, 2);
            panel_StatInfo.Name = "panel_StatInfo";
            panel_StatInfo.Size = new Size(445, 64);
            panel_StatInfo.TabIndex = 32;
            panel_StatInfo.Visible = false;
            // 
            // label_StatInfo
            // 
            label_StatInfo.Dock = DockStyle.Fill;
            label_StatInfo.Font = new Font("Segoe UI", 9F);
            label_StatInfo.ImageAlign = ContentAlignment.MiddleRight;
            label_StatInfo.Location = new Point(0, 0);
            label_StatInfo.Margin = new Padding(4, 0, 4, 0);
            label_StatInfo.Name = "label_StatInfo";
            label_StatInfo.Size = new Size(308, 64);
            label_StatInfo.TabIndex = 1;
            label_StatInfo.Text = "Количество записей:";
            label_StatInfo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_StatInfoNum
            // 
            label_StatInfoNum.Dock = DockStyle.Right;
            label_StatInfoNum.Font = new Font("Segoe UI", 9F);
            label_StatInfoNum.Location = new Point(308, 0);
            label_StatInfoNum.Margin = new Padding(4, 0, 4, 0);
            label_StatInfoNum.Name = "label_StatInfoNum";
            label_StatInfoNum.Size = new Size(137, 64);
            label_StatInfoNum.TabIndex = 0;
            label_StatInfoNum.Text = "0";
            label_StatInfoNum.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel_Base
            // 
            panel_Base.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_Base.AutoSize = true;
            panel_Base.BackColor = Color.Transparent;
            panel_Base.Controls.Add(dataGridView_Sales);
            panel_Base.Location = new Point(559, 88);
            panel_Base.Margin = new Padding(4, 2, 4, 2);
            panel_Base.Name = "panel_Base";
            panel_Base.Size = new Size(1059, 973);
            panel_Base.TabIndex = 34;
            panel_Base.Visible = false;
            // 
            // dataGridView_Sales
            // 
            dataGridView_Sales.AllowUserToAddRows = false;
            dataGridView_Sales.AllowUserToDeleteRows = false;
            dataGridView_Sales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Sales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Sales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Sales.Dock = DockStyle.Fill;
            dataGridView_Sales.Location = new Point(0, 0);
            dataGridView_Sales.Margin = new Padding(4, 2, 4, 2);
            dataGridView_Sales.Name = "dataGridView_Sales";
            dataGridView_Sales.ReadOnly = true;
            dataGridView_Sales.RowHeadersWidth = 82;
            dataGridView_Sales.Size = new Size(1059, 973);
            dataGridView_Sales.TabIndex = 8;
            // 
            // label_Name
            // 
            label_Name.BackColor = Color.Transparent;
            label_Name.Dock = DockStyle.Top;
            label_Name.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            label_Name.Location = new Point(0, 0);
            label_Name.Margin = new Padding(4, 0, 4, 0);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(1622, 91);
            label_Name.TabIndex = 0;
            label_Name.Text = "Данные о продажах";
            label_Name.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form_Sales
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1622, 1164);
            Controls.Add(panel_Main);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form_Sales";
            Text = "Sales";
            FormClosing += Form_Sales_FormClosing;
            panel_Main.ResumeLayout(false);
            panel_Main.PerformLayout();
            flowLayoutPanel_HomeButtons.ResumeLayout(false);
            flowLayoutPanel_HomeButtons.PerformLayout();
            panel_Processing.ResumeLayout(false);
            panel_Processing.PerformLayout();
            panel_ChooseTable.ResumeLayout(false);
            panel_StatInfo.ResumeLayout(false);
            panel_Base.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_Sales).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_Main;
        private FlowLayoutPanel flowLayoutPanel_HomeButtons;
        private Button button_LoadBase;
        private Panel panel_StatInfo;
        private Label label_StatInfo;
        private Label label_StatInfoNum;
        private Label label_Name;
        private Button button_DataProcessing;
        private Button button_RemakeData;
        private Button button_Report;
        private Button button_ExitApp;
        private Panel panel_Base;
        private DataGridView dataGridView_Sales;
        private Panel panel_WorkWithBase;
        private Panel panel_ChooseTable;
        private Label label_ChooseTable;
        private ComboBox comboBox_ChooseTable;
        private Button button_DataViewing;
        private ToolTip toolTip_Find;
        private ToolTip toolTip1;
        private Button button_Info;
        private Button button_Return;
        private Panel panel_Processing;
        private Button button_Group;
        private Button button_Remove;
        private Button button_Find;
        private Button button_Sort;
    }
}
