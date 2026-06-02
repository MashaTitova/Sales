namespace WinFormsAppSales
{
    partial class AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            label_Login = new Label();
            textBox_Login = new TextBox();
            label_Password = new Label();
            textBox_Password = new TextBox();
            button_End = new Button();
            button_Regestration = new Button();
            button_Entry = new Button();
            button_TogglePassword = new Button();
            SuspendLayout();
            // 
            // label_Login
            // 
            label_Login.Anchor = AnchorStyles.None;
            label_Login.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_Login.Location = new Point(182, 42);
            label_Login.Margin = new Padding(4, 0, 4, 0);
            label_Login.Name = "label_Login";
            label_Login.Size = new Size(435, 45);
            label_Login.TabIndex = 25;
            label_Login.Text = "Введите логин";
            label_Login.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Login
            // 
            textBox_Login.Anchor = AnchorStyles.None;
            textBox_Login.Location = new Point(182, 108);
            textBox_Login.Margin = new Padding(4, 2, 4, 2);
            textBox_Login.Name = "textBox_Login";
            textBox_Login.Size = new Size(399, 39);
            textBox_Login.TabIndex = 28;
            textBox_Login.Text = "User";
            // 
            // label_Password
            // 
            label_Password.Anchor = AnchorStyles.None;
            label_Password.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_Password.Location = new Point(182, 205);
            label_Password.Margin = new Padding(4, 0, 4, 0);
            label_Password.Name = "label_Password";
            label_Password.Size = new Size(435, 45);
            label_Password.TabIndex = 29;
            label_Password.Text = "Введите пароль";
            label_Password.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Password
            // 
            textBox_Password.Anchor = AnchorStyles.None;
            textBox_Password.Location = new Point(182, 269);
            textBox_Password.Margin = new Padding(4, 2, 4, 2);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(399, 39);
            textBox_Password.TabIndex = 30;
            textBox_Password.Text = "1234567";
            // 
            // button_End
            // 
            button_End.AutoSize = true;
            button_End.BackColor = Color.Transparent;
            button_End.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_End.Location = new Point(235, 577);
            button_End.Margin = new Padding(4, 2, 4, 2);
            button_End.Name = "button_End";
            button_End.Size = new Size(346, 80);
            button_End.TabIndex = 32;
            button_End.Text = "Выйти из приложения";
            button_End.UseVisualStyleBackColor = false;
            button_End.Click += button_End_Click;
            // 
            // button_Regestration
            // 
            button_Regestration.AutoSize = true;
            button_Regestration.BackColor = Color.Transparent;
            button_Regestration.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Regestration.Location = new Point(235, 464);
            button_Regestration.Margin = new Padding(4, 2, 4, 2);
            button_Regestration.Name = "button_Regestration";
            button_Regestration.Size = new Size(346, 80);
            button_Regestration.TabIndex = 33;
            button_Regestration.Text = "Регистрация";
            button_Regestration.UseVisualStyleBackColor = false;
            button_Regestration.Click += button_Regestration_Click;
            // 
            // button_Entry
            // 
            button_Entry.AutoSize = true;
            button_Entry.BackColor = Color.Transparent;
            button_Entry.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Entry.Location = new Point(235, 356);
            button_Entry.Margin = new Padding(4, 2, 4, 2);
            button_Entry.Name = "button_Entry";
            button_Entry.Size = new Size(346, 80);
            button_Entry.TabIndex = 34;
            button_Entry.Text = "Вход";
            button_Entry.UseVisualStyleBackColor = false;
            button_Entry.Click += button_Entry_Click;
            // 
            // button_TogglePassword
            // 
            button_TogglePassword.AutoSize = true;
            button_TogglePassword.BackColor = Color.Transparent;
            button_TogglePassword.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_TogglePassword.Location = new Point(577, 265);
            button_TogglePassword.Margin = new Padding(4, 2, 4, 2);
            button_TogglePassword.Name = "button_TogglePassword";
            button_TogglePassword.Size = new Size(70, 51);
            button_TogglePassword.TabIndex = 35;
            button_TogglePassword.Tag = "false";
            button_TogglePassword.Text = "👁";
            button_TogglePassword.UseVisualStyleBackColor = false;
            button_TogglePassword.Click += buttonTogglePassword_Click;
            // 
            // AuthenticationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(821, 690);
            Controls.Add(button_TogglePassword);
            Controls.Add(button_Entry);
            Controls.Add(button_Regestration);
            Controls.Add(button_End);
            Controls.Add(label_Password);
            Controls.Add(textBox_Password);
            Controls.Add(label_Login);
            Controls.Add(textBox_Login);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AuthenticationForm";
            Text = "Аутентификация";
            FormClosing += AuthenticationForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Login;
        private TextBox textBox_Login;
        private Label label_Password;
        private TextBox textBox_Password;
        private Button button_End;
        private Button button_Regestration;
        private Button button_Entry;
        private Button button_TogglePassword;
    }
}