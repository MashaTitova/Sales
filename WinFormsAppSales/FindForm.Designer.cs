namespace WinFormsAppSales
{
    partial class FindForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindForm));
            radioButton_NumFind = new RadioButton();
            radioButton_StringFind = new RadioButton();
            label_ChooseFormat = new Label();
            label_ChooseFind = new Label();
            comboBox_FindRatio = new ComboBox();
            comboBox_ChooseFindParam = new ComboBox();
            textBox_ChooseFind = new TextBox();
            button_Return = new Button();
            button_DataProcessing = new Button();
            toolTip_Question = new ToolTip(components);
            SuspendLayout();
            // 
            // radioButton_NumFind
            // 
            radioButton_NumFind.AutoSize = true;
            radioButton_NumFind.Location = new Point(125, 152);
            radioButton_NumFind.Name = "radioButton_NumFind";
            radioButton_NumFind.Size = new Size(233, 36);
            radioButton_NumFind.TabIndex = 35;
            radioButton_NumFind.TabStop = true;
            radioButton_NumFind.Text = "Числовой поиск ";
            radioButton_NumFind.UseVisualStyleBackColor = true;
            radioButton_NumFind.CheckedChanged += radioButton_NumFind_CheckedChanged;
            // 
            // radioButton_StringFind
            // 
            radioButton_StringFind.AutoSize = true;
            radioButton_StringFind.Location = new Point(125, 100);
            radioButton_StringFind.Name = "radioButton_StringFind";
            radioButton_StringFind.Size = new Size(478, 36);
            radioButton_StringFind.TabIndex = 34;
            radioButton_StringFind.TabStop = true;
            radioButton_StringFind.Text = "Строковый поиск (точное совпадение)";
            radioButton_StringFind.UseVisualStyleBackColor = true;
            radioButton_StringFind.CheckedChanged += radioButton_StringFind_CheckedChanged;
            // 
            // label_ChooseFormat
            // 
            label_ChooseFormat.Anchor = AnchorStyles.None;
            label_ChooseFormat.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_ChooseFormat.Location = new Point(91, 31);
            label_ChooseFormat.Margin = new Padding(4, 0, 4, 0);
            label_ChooseFormat.Name = "label_ChooseFormat";
            label_ChooseFormat.Size = new Size(435, 45);
            label_ChooseFormat.TabIndex = 33;
            label_ChooseFormat.Text = "Выберите формат поиска";
            label_ChooseFormat.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_ChooseFind
            // 
            label_ChooseFind.Anchor = AnchorStyles.None;
            label_ChooseFind.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_ChooseFind.Location = new Point(91, 228);
            label_ChooseFind.Margin = new Padding(4, 0, 4, 0);
            label_ChooseFind.Name = "label_ChooseFind";
            label_ChooseFind.Size = new Size(435, 45);
            label_ChooseFind.TabIndex = 29;
            label_ChooseFind.Text = "Введите запрос для поиска";
            label_ChooseFind.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_FindRatio
            // 
            comboBox_FindRatio.Anchor = AnchorStyles.None;
            comboBox_FindRatio.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_FindRatio.FormattingEnabled = true;
            comboBox_FindRatio.Items.AddRange(new object[] { "=", ">", ">=", "<", "<=" });
            comboBox_FindRatio.Location = new Point(432, 288);
            comboBox_FindRatio.Margin = new Padding(4, 2, 4, 2);
            comboBox_FindRatio.Name = "comboBox_FindRatio";
            comboBox_FindRatio.Size = new Size(94, 40);
            comboBox_FindRatio.TabIndex = 31;
            // 
            // comboBox_ChooseFindParam
            // 
            comboBox_ChooseFindParam.Anchor = AnchorStyles.None;
            comboBox_ChooseFindParam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseFindParam.FormattingEnabled = true;
            comboBox_ChooseFindParam.Location = new Point(91, 288);
            comboBox_ChooseFindParam.Margin = new Padding(4, 2, 4, 2);
            comboBox_ChooseFindParam.Name = "comboBox_ChooseFindParam";
            comboBox_ChooseFindParam.Size = new Size(312, 40);
            comboBox_ChooseFindParam.TabIndex = 30;
            // 
            // textBox_ChooseFind
            // 
            textBox_ChooseFind.Anchor = AnchorStyles.None;
            textBox_ChooseFind.Location = new Point(91, 353);
            textBox_ChooseFind.Margin = new Padding(4, 2, 4, 2);
            textBox_ChooseFind.Name = "textBox_ChooseFind";
            textBox_ChooseFind.Size = new Size(435, 39);
            textBox_ChooseFind.TabIndex = 32;
            // 
            // button_Return
            // 
            button_Return.AutoSize = true;
            button_Return.BackColor = Color.Transparent;
            button_Return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Return.Location = new Point(76, 549);
            button_Return.Margin = new Padding(4, 2, 4, 2);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(479, 84);
            button_Return.TabIndex = 37;
            button_Return.Text = "Назад";
            button_Return.UseVisualStyleBackColor = false;
            button_Return.Click += button_Return_Click;
            // 
            // button_DataProcessing
            // 
            button_DataProcessing.AutoSize = true;
            button_DataProcessing.BackColor = Color.Transparent;
            button_DataProcessing.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_DataProcessing.Location = new Point(76, 452);
            button_DataProcessing.Margin = new Padding(4, 2, 4, 2);
            button_DataProcessing.Name = "button_DataProcessing";
            button_DataProcessing.Size = new Size(479, 84);
            button_DataProcessing.TabIndex = 36;
            button_DataProcessing.Text = "Применить";
            button_DataProcessing.UseVisualStyleBackColor = false;
            button_DataProcessing.Click += button_DataProcessing_Click;
            // 
            // FindForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(625, 686);
            Controls.Add(button_Return);
            Controls.Add(button_DataProcessing);
            Controls.Add(radioButton_NumFind);
            Controls.Add(radioButton_StringFind);
            Controls.Add(label_ChooseFormat);
            Controls.Add(label_ChooseFind);
            Controls.Add(comboBox_FindRatio);
            Controls.Add(comboBox_ChooseFindParam);
            Controls.Add(textBox_ChooseFind);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FindForm";
            Text = "Поиск";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton_NumFind;
        private RadioButton radioButton_StringFind;
        private Label label_ChooseFormat;
        private Label label_ChooseFind;
        private ComboBox comboBox_FindRatio;
        private ComboBox comboBox_ChooseFindParam;
        private TextBox textBox_ChooseFind;
        private Button button_Return;
        private Button button_DataProcessing;
        private ToolTip toolTip_Question;
    }
}