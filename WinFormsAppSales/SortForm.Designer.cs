namespace WinFormsAppSales
{
    partial class SortForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortForm));
            label_SortDirection = new Label();
            comboBox_SortDirection = new ComboBox();
            label_SortingColumn = new Label();
            comboBox_SortingColumn = new ComboBox();
            button_DataProcessing = new Button();
            button_Return = new Button();
            SuspendLayout();
            // 
            // label_SortDirection
            // 
            label_SortDirection.Anchor = AnchorStyles.None;
            label_SortDirection.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_SortDirection.Location = new Point(32, 188);
            label_SortDirection.Margin = new Padding(4, 0, 4, 0);
            label_SortDirection.Name = "label_SortDirection";
            label_SortDirection.Size = new Size(557, 45);
            label_SortDirection.TabIndex = 32;
            label_SortDirection.Text = "Выберите направление сортировки";
            label_SortDirection.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_SortDirection
            // 
            comboBox_SortDirection.Anchor = AnchorStyles.None;
            comboBox_SortDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_SortDirection.FormattingEnabled = true;
            comboBox_SortDirection.Items.AddRange(new object[] { "Возрастание", "Убывание" });
            comboBox_SortDirection.Location = new Point(87, 248);
            comboBox_SortDirection.Margin = new Padding(4, 2, 4, 2);
            comboBox_SortDirection.Name = "comboBox_SortDirection";
            comboBox_SortDirection.Size = new Size(435, 40);
            comboBox_SortDirection.TabIndex = 31;
            // 
            // label_SortingColumn
            // 
            label_SortingColumn.Anchor = AnchorStyles.None;
            label_SortingColumn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_SortingColumn.Location = new Point(48, 60);
            label_SortingColumn.Margin = new Padding(4, 0, 4, 0);
            label_SortingColumn.Name = "label_SortingColumn";
            label_SortingColumn.Size = new Size(541, 45);
            label_SortingColumn.TabIndex = 30;
            label_SortingColumn.Text = "Выберите столбец для сортировки";
            label_SortingColumn.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_SortingColumn
            // 
            comboBox_SortingColumn.Anchor = AnchorStyles.None;
            comboBox_SortingColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_SortingColumn.ForeColor = Color.Black;
            comboBox_SortingColumn.FormattingEnabled = true;
            comboBox_SortingColumn.Location = new Point(87, 127);
            comboBox_SortingColumn.Margin = new Padding(4, 2, 4, 2);
            comboBox_SortingColumn.Name = "comboBox_SortingColumn";
            comboBox_SortingColumn.Size = new Size(435, 40);
            comboBox_SortingColumn.TabIndex = 29;
            // 
            // button_DataProcessing
            // 
            button_DataProcessing.AutoSize = true;
            button_DataProcessing.BackColor = Color.Transparent;
            button_DataProcessing.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_DataProcessing.Location = new Point(59, 357);
            button_DataProcessing.Margin = new Padding(4, 2, 4, 2);
            button_DataProcessing.Name = "button_DataProcessing";
            button_DataProcessing.Size = new Size(479, 84);
            button_DataProcessing.TabIndex = 33;
            button_DataProcessing.Text = "Применить";
            button_DataProcessing.UseVisualStyleBackColor = false;
            button_DataProcessing.Click += button_DataProcessing_Click;
            // 
            // button_Return
            // 
            button_Return.AutoSize = true;
            button_Return.BackColor = Color.Transparent;
            button_Return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Return.Location = new Point(59, 466);
            button_Return.Margin = new Padding(4, 2, 4, 2);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(479, 84);
            button_Return.TabIndex = 34;
            button_Return.Text = "Назад";
            button_Return.UseVisualStyleBackColor = false;
            button_Return.Click += button_Return_Click;
            // 
            // SortForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(625, 561);
            Controls.Add(button_Return);
            Controls.Add(button_DataProcessing);
            Controls.Add(label_SortDirection);
            Controls.Add(comboBox_SortDirection);
            Controls.Add(label_SortingColumn);
            Controls.Add(comboBox_SortingColumn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SortForm";
            Text = "Сортировка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_SortDirection;
        private ComboBox comboBox_SortDirection;
        private Label label_SortingColumn;
        private ComboBox comboBox_SortingColumn;
        private Button button_DataProcessing;
        private Button button_Return;
    }
}