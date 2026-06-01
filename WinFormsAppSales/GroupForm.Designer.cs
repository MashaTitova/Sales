namespace WinFormsAppSales
{
    partial class GroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupForm));
            label_ChooseGroup = new Label();
            comboBox_ChooseGroupParam = new ComboBox();
            button_Return = new Button();
            button_DataProcessing = new Button();
            SuspendLayout();
            // 
            // label_ChooseGroup
            // 
            label_ChooseGroup.Anchor = AnchorStyles.None;
            label_ChooseGroup.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_ChooseGroup.Location = new Point(30, 32);
            label_ChooseGroup.Margin = new Padding(4, 0, 4, 0);
            label_ChooseGroup.Name = "label_ChooseGroup";
            label_ChooseGroup.Size = new Size(560, 44);
            label_ChooseGroup.TabIndex = 21;
            label_ChooseGroup.Text = "Выберите столбец для группировки";
            label_ChooseGroup.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBox_ChooseGroupParam
            // 
            comboBox_ChooseGroupParam.Anchor = AnchorStyles.None;
            comboBox_ChooseGroupParam.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_ChooseGroupParam.FormattingEnabled = true;
            comboBox_ChooseGroupParam.Location = new Point(88, 108);
            comboBox_ChooseGroupParam.Margin = new Padding(4, 2, 4, 2);
            comboBox_ChooseGroupParam.Name = "comboBox_ChooseGroupParam";
            comboBox_ChooseGroupParam.Size = new Size(435, 40);
            comboBox_ChooseGroupParam.TabIndex = 22;
            // 
            // button_Return
            // 
            button_Return.AutoSize = true;
            button_Return.BackColor = Color.Transparent;
            button_Return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Return.Location = new Point(68, 345);
            button_Return.Margin = new Padding(4, 2, 4, 2);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(479, 84);
            button_Return.TabIndex = 36;
            button_Return.Text = "Назад";
            button_Return.UseVisualStyleBackColor = false;
            button_Return.Click += button_Return_Click;
            // 
            // button_DataProcessing
            // 
            button_DataProcessing.AutoSize = true;
            button_DataProcessing.BackColor = Color.Transparent;
            button_DataProcessing.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_DataProcessing.Location = new Point(68, 236);
            button_DataProcessing.Margin = new Padding(4, 2, 4, 2);
            button_DataProcessing.Name = "button_DataProcessing";
            button_DataProcessing.Size = new Size(479, 84);
            button_DataProcessing.TabIndex = 35;
            button_DataProcessing.Text = "Применить";
            button_DataProcessing.UseVisualStyleBackColor = false;
            button_DataProcessing.Click += button_DataProcessing_Click;
            // 
            // GroupForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(625, 561);
            Controls.Add(button_Return);
            Controls.Add(button_DataProcessing);
            Controls.Add(label_ChooseGroup);
            Controls.Add(comboBox_ChooseGroupParam);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GroupForm";
            Text = "Группировка";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_ChooseGroup;
        private ComboBox comboBox_ChooseGroupParam;
        private Button button_Return;
        private Button button_DataProcessing;
    }
}