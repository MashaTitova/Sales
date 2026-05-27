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
            flowLayoutPanel_HomeButtons = new FlowLayoutPanel();
            button_LoadBase = new Button();
            button_DataViewing = new Button();
            button_DataProcessing = new Button();
            button_RemakeData = new Button();
            button_Report = new Button();
            button_ExitApp = new Button();
            button_Info = new Button();
            panel_Processing = new Panel();
            panel_Find = new Panel();
            radioButton_NumFind = new RadioButton();
            radioButton_StringFind = new RadioButton();
            label1 = new Label();
            label_ChooseFind = new Label();
            comboBox_FindRatio = new ComboBox();
            comboBox_ChooseFindParam = new ComboBox();
            label_Find = new Label();
            textBox_ChooseFind = new TextBox();
            label_SortDirection = new Label();
            comboBox_SortDirection = new ComboBox();
            label_SortingColumn = new Label();
            label_Sort = new Label();
            label_Group = new Label();
            label_ChooseGroup = new Label();
            comboBox_ChooseGroupParam = new ComboBox();
            comboBox_SortingColumn = new ComboBox();
            button_Return = new Button();
            button_Remove = new Button();
            button_Apply = new Button();
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
            panel_Find.SuspendLayout();
            panel_ChooseTable.SuspendLayout();
            panel_StatInfo.SuspendLayout();
            panel_Base.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Sales).BeginInit();
            SuspendLayout();
            // 
            // panel_Main
            // 
            panel_Main.BackColor = Color.Transparent;
            panel_Main.Controls.Add(flowLayoutPanel_HomeButtons);
            panel_Main.Controls.Add(button_Info);
            panel_Main.Controls.Add(panel_Processing);
            panel_Main.Controls.Add(button_Return);
            panel_Main.Controls.Add(button_Remove);
            panel_Main.Controls.Add(button_Apply);
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
            // button_Info
            // 
            button_Info.Anchor = AnchorStyles.None;
            button_Info.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Info.Location = new Point(12, 1074);
            button_Info.Name = "button_Info";
            button_Info.Size = new Size(187, 87);
            button_Info.TabIndex = 40;
            button_Info.Text = "Справка пользователя";
            button_Info.UseVisualStyleBackColor = true;
            // 
            // panel_Processing
            // 
            panel_Processing.Controls.Add(panel_Find);
            panel_Processing.Controls.Add(label_SortDirection);
            panel_Processing.Controls.Add(comboBox_SortDirection);
            panel_Processing.Controls.Add(label_SortingColumn);
            panel_Processing.Controls.Add(label_Sort);
            panel_Processing.Controls.Add(label_Group);
            panel_Processing.Controls.Add(label_ChooseGroup);
            panel_Processing.Controls.Add(comboBox_ChooseGroupParam);
            panel_Processing.Controls.Add(comboBox_SortingColumn);
            panel_Processing.Location = new Point(3, 262);
            panel_Processing.Name = "panel_Processing";
            panel_Processing.Size = new Size(549, 799);
            panel_Processing.TabIndex = 28;
            panel_Processing.Visible = false;
            // 
            // panel_Find
            // 
            panel_Find.Controls.Add(radioButton_NumFind);
            panel_Find.Controls.Add(radioButton_StringFind);
            panel_Find.Controls.Add(label1);
            panel_Find.Controls.Add(label_ChooseFind);
            panel_Find.Controls.Add(comboBox_FindRatio);
            panel_Find.Controls.Add(comboBox_ChooseFindParam);
            panel_Find.Controls.Add(label_Find);
            panel_Find.Controls.Add(textBox_ChooseFind);
            panel_Find.Location = new Point(43, 262);
            panel_Find.Name = "panel_Find";
            panel_Find.Size = new Size(456, 382);
            panel_Find.TabIndex = 41;
            // 
            // radioButton_NumFind
            // 
            radioButton_NumFind.AutoSize = true;
            radioButton_NumFind.Location = new Point(129, 162);
            radioButton_NumFind.Name = "radioButton_NumFind";
            radioButton_NumFind.Size = new Size(226, 36);
            radioButton_NumFind.TabIndex = 27;
            radioButton_NumFind.TabStop = true;
            radioButton_NumFind.Text = "Числовой поиск";
            radioButton_NumFind.UseVisualStyleBackColor = true;
            radioButton_NumFind.CheckedChanged += radioButton_NumFind_CheckedChanged;
            // 
            // radioButton_StringFind
            // 
            radioButton_StringFind.AutoSize = true;
            radioButton_StringFind.Location = new Point(132, 103);
            radioButton_StringFind.Name = "radioButton_StringFind";
            radioButton_StringFind.Size = new Size(240, 36);
            radioButton_StringFind.TabIndex = 26;
            radioButton_StringFind.TabStop = true;
            radioButton_StringFind.Text = "Строковый поиск";
            radioButton_StringFind.UseVisualStyleBackColor = true;
            radioButton_StringFind.CheckedChanged += radioButton_StringFind_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label1.Location = new Point(11, 55);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(435, 45);
            label1.TabIndex = 25;
            label1.Text = "Выберите формат поиска";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_ChooseFind
            // 
            label_ChooseFind.Anchor = AnchorStyles.None;
            label_ChooseFind.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_ChooseFind.Location = new Point(4, 201);
            label_ChooseFind.Margin = new Padding(4, 0, 4, 0);
            label_ChooseFind.Name = "label_ChooseFind";
            label_ChooseFind.Size = new Size(435, 45);
            label_ChooseFind.TabIndex = 13;
            label_ChooseFind.Text = "Введите запрос для поиска";
            label_ChooseFind.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_FindRatio
            // 
            comboBox_FindRatio.Anchor = AnchorStyles.None;
            comboBox_FindRatio.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FindRatio.FormattingEnabled = true;
            comboBox_FindRatio.Items.AddRange(new object[] { "=", ">", ">=", "<", "<=" });
            comboBox_FindRatio.Location = new Point(345, 261);
            comboBox_FindRatio.Margin = new Padding(4, 2, 4, 2);
            comboBox_FindRatio.Name = "comboBox_FindRatio";
            comboBox_FindRatio.Size = new Size(94, 40);
            comboBox_FindRatio.TabIndex = 17;
            // 
            // comboBox_ChooseFindParam
            // 
            comboBox_ChooseFindParam.Anchor = AnchorStyles.None;
            comboBox_ChooseFindParam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseFindParam.FormattingEnabled = true;
            comboBox_ChooseFindParam.Location = new Point(4, 261);
            comboBox_ChooseFindParam.Margin = new Padding(4, 2, 4, 2);
            comboBox_ChooseFindParam.Name = "comboBox_ChooseFindParam";
            comboBox_ChooseFindParam.Size = new Size(312, 40);
            comboBox_ChooseFindParam.TabIndex = 16;
            // 
            // label_Find
            // 
            label_Find.Anchor = AnchorStyles.None;
            label_Find.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_Find.Location = new Point(8, 14);
            label_Find.Margin = new Padding(4, 0, 4, 0);
            label_Find.Name = "label_Find";
            label_Find.Size = new Size(435, 41);
            label_Find.TabIndex = 11;
            label_Find.Text = "Поиск";
            label_Find.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_ChooseFind
            // 
            textBox_ChooseFind.Anchor = AnchorStyles.None;
            textBox_ChooseFind.Location = new Point(4, 326);
            textBox_ChooseFind.Margin = new Padding(4, 2, 4, 2);
            textBox_ChooseFind.Name = "textBox_ChooseFind";
            textBox_ChooseFind.Size = new Size(435, 39);
            textBox_ChooseFind.TabIndex = 24;
            // 
            // label_SortDirection
            // 
            label_SortDirection.Anchor = AnchorStyles.None;
            label_SortDirection.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_SortDirection.Location = new Point(51, 170);
            label_SortDirection.Margin = new Padding(4, 0, 4, 0);
            label_SortDirection.Name = "label_SortDirection";
            label_SortDirection.Size = new Size(435, 45);
            label_SortDirection.TabIndex = 27;
            label_SortDirection.Text = "Выберите направление сортировки";
            label_SortDirection.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_SortDirection
            // 
            comboBox_SortDirection.Anchor = AnchorStyles.None;
            comboBox_SortDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_SortDirection.FormattingEnabled = true;
            comboBox_SortDirection.Items.AddRange(new object[] { "Возрастание", "Убывание" });
            comboBox_SortDirection.Location = new Point(51, 217);
            comboBox_SortDirection.Margin = new Padding(4, 2, 4, 2);
            comboBox_SortDirection.Name = "comboBox_SortDirection";
            comboBox_SortDirection.Size = new Size(435, 40);
            comboBox_SortDirection.TabIndex = 26;
            // 
            // label_SortingColumn
            // 
            label_SortingColumn.Anchor = AnchorStyles.None;
            label_SortingColumn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_SortingColumn.Location = new Point(59, 54);
            label_SortingColumn.Margin = new Padding(4, 0, 4, 0);
            label_SortingColumn.Name = "label_SortingColumn";
            label_SortingColumn.Size = new Size(427, 45);
            label_SortingColumn.TabIndex = 25;
            label_SortingColumn.Text = "Выберите столбец для сортировки";
            label_SortingColumn.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_Sort
            // 
            label_Sort.Anchor = AnchorStyles.None;
            label_Sort.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_Sort.Location = new Point(51, 1);
            label_Sort.Margin = new Padding(4, 0, 4, 0);
            label_Sort.Name = "label_Sort";
            label_Sort.Size = new Size(435, 45);
            label_Sort.TabIndex = 9;
            label_Sort.Text = "Сортировка";
            label_Sort.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_Group
            // 
            label_Group.Anchor = AnchorStyles.None;
            label_Group.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_Group.Location = new Point(59, 647);
            label_Group.Margin = new Padding(4, 0, 4, 0);
            label_Group.Name = "label_Group";
            label_Group.Size = new Size(427, 38);
            label_Group.TabIndex = 10;
            label_Group.Text = "Группировка";
            label_Group.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_ChooseGroup
            // 
            label_ChooseGroup.Anchor = AnchorStyles.None;
            label_ChooseGroup.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label_ChooseGroup.Location = new Point(51, 694);
            label_ChooseGroup.Margin = new Padding(4, 0, 4, 0);
            label_ChooseGroup.Name = "label_ChooseGroup";
            label_ChooseGroup.Size = new Size(435, 44);
            label_ChooseGroup.TabIndex = 14;
            label_ChooseGroup.Text = "Выберите столбец для группировки";
            label_ChooseGroup.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_ChooseGroupParam
            // 
            comboBox_ChooseGroupParam.Anchor = AnchorStyles.None;
            comboBox_ChooseGroupParam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseGroupParam.FormattingEnabled = true;
            comboBox_ChooseGroupParam.Location = new Point(51, 750);
            comboBox_ChooseGroupParam.Margin = new Padding(4, 2, 4, 2);
            comboBox_ChooseGroupParam.Name = "comboBox_ChooseGroupParam";
            comboBox_ChooseGroupParam.Size = new Size(435, 40);
            comboBox_ChooseGroupParam.TabIndex = 19;
            // 
            // comboBox_SortingColumn
            // 
            comboBox_SortingColumn.Anchor = AnchorStyles.None;
            comboBox_SortingColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_SortingColumn.ForeColor = Color.Black;
            comboBox_SortingColumn.FormattingEnabled = true;
            comboBox_SortingColumn.Location = new Point(51, 111);
            comboBox_SortingColumn.Margin = new Padding(4, 2, 4, 2);
            comboBox_SortingColumn.Name = "comboBox_SortingColumn";
            comboBox_SortingColumn.Size = new Size(435, 40);
            comboBox_SortingColumn.TabIndex = 15;
            // 
            // button_Return
            // 
            button_Return.Anchor = AnchorStyles.None;
            button_Return.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Return.Location = new Point(12, 1074);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(187, 87);
            button_Return.TabIndex = 39;
            button_Return.Text = "Возврат в главное меню";
            button_Return.UseVisualStyleBackColor = true;
            button_Return.Visible = false;
            button_Return.Click += button_Return_Click;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.None;
            button_Remove.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Remove.Location = new Point(398, 1075);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(187, 87);
            button_Remove.TabIndex = 38;
            button_Remove.Text = " Снять обработку";
            button_Remove.UseVisualStyleBackColor = true;
            button_Remove.Visible = false;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_Apply
            // 
            button_Apply.Anchor = AnchorStyles.None;
            button_Apply.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            button_Apply.Location = new Point(205, 1074);
            button_Apply.Name = "button_Apply";
            button_Apply.Size = new Size(187, 87);
            button_Apply.TabIndex = 37;
            button_Apply.Text = "Применить обработку";
            button_Apply.UseVisualStyleBackColor = true;
            button_Apply.Visible = false;
            button_Apply.Click += button_Apply_Click;
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
            dataGridView_Sales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Sales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView_Sales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Sales.Dock = DockStyle.Fill;
            dataGridView_Sales.Location = new Point(0, 0);
            dataGridView_Sales.Margin = new Padding(4, 2, 4, 2);
            dataGridView_Sales.Name = "dataGridView_Sales";
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
            panel_Find.ResumeLayout(false);
            panel_Find.PerformLayout();
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
        private Label label_SortDirection;
        private ComboBox comboBox_SortDirection;
        private TextBox textBox_ChooseFind;
        private Label label_SortingColumn;
        private Label label_Sort;
        private Label label_Group;
        private Label label_Find;
        private Label label_ChooseFind;
        private Label label_ChooseGroup;
        private ComboBox comboBox_ChooseGroupParam;
        private ComboBox comboBox_SortingColumn;
        private ComboBox comboBox_FindRatio;
        private ComboBox comboBox_ChooseFindParam;
        private Panel panel_ChooseTable;
        private Label label_ChooseTable;
        private ComboBox comboBox_ChooseTable;
        private Button button_Return;
        private Button button_Remove;
        private Button button_Apply;
        private Panel panel_Processing;
        private Button button_Info;
        private Button button_DataViewing;
        private Panel panel_Find;
        private ToolTip toolTip_Find;
        private ToolTip toolTip1;
        private RadioButton radioButton_StringFind;
        private Label label1;
        private RadioButton radioButton_NumFind;
    }
}
