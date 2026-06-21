namespace WinFormsAppSales
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            label_Name = new Label();
            flowLayoutPanel_HomeButtons = new FlowLayoutPanel();
            button_Txt = new Button();
            button_Excel = new Button();
            button_Word = new Button();
            button_return = new Button();
            flowLayoutPanel_HomeButtons.SuspendLayout();
            SuspendLayout();
            // 
            // label_Name
            // 
            label_Name.BackColor = Color.Transparent;
            label_Name.Dock = DockStyle.Top;
            label_Name.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            label_Name.Location = new Point(0, 0);
            label_Name.Margin = new Padding(4, 0, 4, 0);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(879, 91);
            label_Name.TabIndex = 11;
            label_Name.Text = "Выберите формат отчета";
            label_Name.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel_HomeButtons
            // 
            flowLayoutPanel_HomeButtons.Anchor = AnchorStyles.None;
            flowLayoutPanel_HomeButtons.AutoSize = true;
            flowLayoutPanel_HomeButtons.BackColor = Color.Transparent;
            flowLayoutPanel_HomeButtons.Controls.Add(button_Txt);
            flowLayoutPanel_HomeButtons.Controls.Add(button_Excel);
            flowLayoutPanel_HomeButtons.Controls.Add(button_Word);
            flowLayoutPanel_HomeButtons.Controls.Add(button_return);
            flowLayoutPanel_HomeButtons.Location = new Point(147, 155);
            flowLayoutPanel_HomeButtons.Margin = new Padding(4, 2, 4, 2);
            flowLayoutPanel_HomeButtons.MaximumSize = new Size(700, 800);
            flowLayoutPanel_HomeButtons.MinimumSize = new Size(496, 582);
            flowLayoutPanel_HomeButtons.Name = "flowLayoutPanel_HomeButtons";
            flowLayoutPanel_HomeButtons.Size = new Size(598, 582);
            flowLayoutPanel_HomeButtons.TabIndex = 10;
            // 
            // button_Txt
            // 
            button_Txt.AutoSize = true;
            button_Txt.BackColor = Color.Transparent;
            button_Txt.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Txt.Location = new Point(4, 2);
            button_Txt.Margin = new Padding(4, 2, 4, 2);
            button_Txt.Name = "button_Txt";
            button_Txt.Size = new Size(590, 114);
            button_Txt.TabIndex = 14;
            button_Txt.Text = "Txt";
            button_Txt.UseVisualStyleBackColor = false;
            button_Txt.Click += button_Txt_Click;
            // 
            // button_Excel
            // 
            button_Excel.AutoSize = true;
            button_Excel.BackColor = Color.Transparent;
            button_Excel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Excel.Location = new Point(4, 120);
            button_Excel.Margin = new Padding(4, 2, 4, 2);
            button_Excel.Name = "button_Excel";
            button_Excel.Size = new Size(590, 114);
            button_Excel.TabIndex = 15;
            button_Excel.Text = "Excel";
            button_Excel.UseVisualStyleBackColor = false;
            button_Excel.Click += button_Excel_Click;
            // 
            // button_Word
            // 
            button_Word.AutoSize = true;
            button_Word.BackColor = Color.Transparent;
            button_Word.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Word.Location = new Point(4, 238);
            button_Word.Margin = new Padding(4, 2, 4, 2);
            button_Word.Name = "button_Word";
            button_Word.Size = new Size(590, 114);
            button_Word.TabIndex = 16;
            button_Word.Text = "Word";
            button_Word.UseVisualStyleBackColor = false;
            button_Word.Click += button_Word_Click;
            // 
            // button_return
            // 
            button_return.AutoSize = true;
            button_return.BackColor = Color.Transparent;
            button_return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_return.Location = new Point(4, 356);
            button_return.Margin = new Padding(4, 2, 4, 2);
            button_return.Name = "button_return";
            button_return.Size = new Size(590, 114);
            button_return.TabIndex = 13;
            button_return.Text = "Вернуться на главный экран";
            button_return.UseVisualStyleBackColor = false;
            button_return.Click += button_Exit_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(879, 782);
            Controls.Add(label_Name);
            Controls.Add(flowLayoutPanel_HomeButtons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReportForm";
            Text = "Выбор формата";
            flowLayoutPanel_HomeButtons.ResumeLayout(false);
            flowLayoutPanel_HomeButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_Name;
        private FlowLayoutPanel flowLayoutPanel_HomeButtons;
        private Button button_return;
        private Button button_Txt;
        private Button button_Excel;
        private Button button_Word;
    }
}