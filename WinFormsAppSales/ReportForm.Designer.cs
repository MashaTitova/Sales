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
            flowLayoutPanel_HomeButtons = new FlowLayoutPanel();
            button_ReporGenegation = new Button();
            button_ViewReport = new Button();
            button_SaveReport = new Button();
            button_PrintReport = new Button();
            button_return = new Button();
            label_Name = new Label();
            flowLayoutPanel_HomeButtons.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel_HomeButtons
            // 
            flowLayoutPanel_HomeButtons.Anchor = AnchorStyles.None;
            flowLayoutPanel_HomeButtons.AutoSize = true;
            flowLayoutPanel_HomeButtons.BackColor = Color.Transparent;
            flowLayoutPanel_HomeButtons.Controls.Add(button_ReporGenegation);
            flowLayoutPanel_HomeButtons.Controls.Add(button_ViewReport);
            flowLayoutPanel_HomeButtons.Controls.Add(button_SaveReport);
            flowLayoutPanel_HomeButtons.Controls.Add(button_PrintReport);
            flowLayoutPanel_HomeButtons.Controls.Add(button_return);
            flowLayoutPanel_HomeButtons.Location = new Point(231, 207);
            flowLayoutPanel_HomeButtons.Margin = new Padding(4, 2, 4, 2);
            flowLayoutPanel_HomeButtons.MaximumSize = new Size(700, 800);
            flowLayoutPanel_HomeButtons.MinimumSize = new Size(496, 582);
            flowLayoutPanel_HomeButtons.Name = "flowLayoutPanel_HomeButtons";
            flowLayoutPanel_HomeButtons.Size = new Size(598, 590);
            flowLayoutPanel_HomeButtons.TabIndex = 10;
            // 
            // button_ReporGenegation
            // 
            button_ReporGenegation.AutoSize = true;
            button_ReporGenegation.BackColor = Color.Transparent;
            button_ReporGenegation.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_ReporGenegation.Location = new Point(4, 2);
            button_ReporGenegation.Margin = new Padding(4, 2, 4, 2);
            button_ReporGenegation.Name = "button_ReporGenegation";
            button_ReporGenegation.Size = new Size(590, 114);
            button_ReporGenegation.TabIndex = 10;
            button_ReporGenegation.Text = "Сгенерировать отчет";
            button_ReporGenegation.UseVisualStyleBackColor = false;
            button_ReporGenegation.Click += button_ReporGenegation_Click;
            // 
            // button_ViewReport
            // 
            button_ViewReport.AutoSize = true;
            button_ViewReport.BackColor = Color.Transparent;
            button_ViewReport.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_ViewReport.Location = new Point(4, 120);
            button_ViewReport.Margin = new Padding(4, 2, 4, 2);
            button_ViewReport.Name = "button_ViewReport";
            button_ViewReport.Size = new Size(590, 114);
            button_ViewReport.TabIndex = 11;
            button_ViewReport.Text = "Предварительный просмотр";
            button_ViewReport.UseVisualStyleBackColor = false;
            button_ViewReport.Click += button_ViewReport_Click;
            // 
            // button_SaveReport
            // 
            button_SaveReport.AutoSize = true;
            button_SaveReport.BackColor = Color.Transparent;
            button_SaveReport.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_SaveReport.Location = new Point(4, 238);
            button_SaveReport.Margin = new Padding(4, 2, 4, 2);
            button_SaveReport.Name = "button_SaveReport";
            button_SaveReport.Size = new Size(590, 114);
            button_SaveReport.TabIndex = 7;
            button_SaveReport.Text = "Сохранение отчета";
            button_SaveReport.UseVisualStyleBackColor = false;
            button_SaveReport.Click += button_SaveReport_Click;
            // 
            // button_PrintReport
            // 
            button_PrintReport.AutoSize = true;
            button_PrintReport.BackColor = Color.Transparent;
            button_PrintReport.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_PrintReport.Location = new Point(4, 356);
            button_PrintReport.Margin = new Padding(4, 2, 4, 2);
            button_PrintReport.Name = "button_PrintReport";
            button_PrintReport.Size = new Size(590, 114);
            button_PrintReport.TabIndex = 12;
            button_PrintReport.Text = "Печать отчета";
            button_PrintReport.UseVisualStyleBackColor = false;
            button_PrintReport.Click += button_PrintReport_Click;
            // 
            // button_return
            // 
            button_return.AutoSize = true;
            button_return.BackColor = Color.Transparent;
            button_return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_return.Location = new Point(4, 474);
            button_return.Margin = new Padding(4, 2, 4, 2);
            button_return.Name = "button_return";
            button_return.Size = new Size(590, 114);
            button_return.TabIndex = 13;
            button_return.Text = "Вернуться на главный экран";
            button_return.UseVisualStyleBackColor = false;
            button_return.Click += button_Exit_Click;
            // 
            // label_Name
            // 
            label_Name.BackColor = Color.Transparent;
            label_Name.Dock = DockStyle.Top;
            label_Name.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold);
            label_Name.Location = new Point(0, 0);
            label_Name.Margin = new Padding(4, 0, 4, 0);
            label_Name.Name = "label_Name";
            label_Name.Size = new Size(1058, 91);
            label_Name.TabIndex = 11;
            label_Name.Text = "Выберите действие";
            label_Name.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1058, 951);
            Controls.Add(label_Name);
            Controls.Add(flowLayoutPanel_HomeButtons);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ReportForm";
            Text = "Создание отчета";
            flowLayoutPanel_HomeButtons.ResumeLayout(false);
            flowLayoutPanel_HomeButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel_HomeButtons;
        private Button button_ReporGenegation;
        private Button button_ViewReport;
        private Button button_SaveReport;
        private Button button_PrintReport;
        private Button button_return;
        private Label label_Name;
    }
}