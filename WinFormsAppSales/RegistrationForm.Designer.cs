namespace WinFormsAppSales
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            button_AddUser = new Button();
            button_Return = new Button();
            label_Password = new Label();
            textBox_Password = new TextBox();
            label_Login = new Label();
            textBox_Login = new TextBox();
            label_RepeatPassword = new Label();
            textBox_RepeatPassword = new TextBox();
            SuspendLayout();
            // 
            // button_AddUser
            // 
            button_AddUser.AutoSize = true;
            button_AddUser.BackColor = Color.Transparent;
            button_AddUser.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_AddUser.Location = new Point(236, 509);
            button_AddUser.Margin = new Padding(4, 2, 4, 2);
            button_AddUser.Name = "button_AddUser";
            button_AddUser.Size = new Size(370, 80);
            button_AddUser.TabIndex = 39;
            button_AddUser.Text = "Добавить пользователя";
            button_AddUser.UseVisualStyleBackColor = false;
            button_AddUser.Click += button_AddUser_Click;
            // 
            // button_Return
            // 
            button_Return.AutoSize = true;
            button_Return.BackColor = Color.Transparent;
            button_Return.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button_Return.Location = new Point(246, 630);
            button_Return.Margin = new Padding(4, 2, 4, 2);
            button_Return.Name = "button_Return";
            button_Return.Size = new Size(346, 80);
            button_Return.TabIndex = 38;
            button_Return.Text = "Назад";
            button_Return.UseVisualStyleBackColor = false;
            button_Return.Click += button_Return_Click;
            // 
            // label_Password
            // 
            label_Password.Anchor = AnchorStyles.None;
            label_Password.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_Password.Location = new Point(201, 196);
            label_Password.Margin = new Padding(4, 0, 4, 0);
            label_Password.Name = "label_Password";
            label_Password.Size = new Size(435, 45);
            label_Password.TabIndex = 36;
            label_Password.Text = "Введите пароль";
            label_Password.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Password
            // 
            textBox_Password.Anchor = AnchorStyles.None;
            textBox_Password.Location = new Point(201, 260);
            textBox_Password.Margin = new Padding(4, 2, 4, 2);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.Size = new Size(435, 39);
            textBox_Password.TabIndex = 37;
            // 
            // label_Login
            // 
            label_Login.Anchor = AnchorStyles.None;
            label_Login.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_Login.Location = new Point(201, 47);
            label_Login.Margin = new Padding(4, 0, 4, 0);
            label_Login.Name = "label_Login";
            label_Login.Size = new Size(435, 45);
            label_Login.TabIndex = 34;
            label_Login.Text = "Введите логин";
            label_Login.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_Login
            // 
            textBox_Login.Anchor = AnchorStyles.None;
            textBox_Login.Location = new Point(201, 111);
            textBox_Login.Margin = new Padding(4, 2, 4, 2);
            textBox_Login.Name = "textBox_Login";
            textBox_Login.Size = new Size(435, 39);
            textBox_Login.TabIndex = 35;
            // 
            // label_RepeatPassword
            // 
            label_RepeatPassword.Anchor = AnchorStyles.None;
            label_RepeatPassword.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_RepeatPassword.Location = new Point(201, 342);
            label_RepeatPassword.Margin = new Padding(4, 0, 4, 0);
            label_RepeatPassword.Name = "label_RepeatPassword";
            label_RepeatPassword.Size = new Size(435, 45);
            label_RepeatPassword.TabIndex = 40;
            label_RepeatPassword.Text = "Повторите пароль";
            label_RepeatPassword.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox_RepeatPassword
            // 
            textBox_RepeatPassword.Anchor = AnchorStyles.None;
            textBox_RepeatPassword.Location = new Point(201, 406);
            textBox_RepeatPassword.Margin = new Padding(4, 2, 4, 2);
            textBox_RepeatPassword.Name = "textBox_RepeatPassword";
            textBox_RepeatPassword.Size = new Size(435, 39);
            textBox_RepeatPassword.TabIndex = 41;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(839, 772);
            Controls.Add(label_RepeatPassword);
            Controls.Add(textBox_RepeatPassword);
            Controls.Add(button_AddUser);
            Controls.Add(button_Return);
            Controls.Add(label_Password);
            Controls.Add(textBox_Password);
            Controls.Add(label_Login);
            Controls.Add(textBox_Login);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RegistrationForm";
            Text = "Регестрация";
            FormClosing += RegistrationForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_AddUser;
        private Button button_Return;
        private Label label_Password;
        private TextBox textBox_Password;
        private Label label_Login;
        private TextBox textBox_Login;
        private Label label_RepeatPassword;
        private TextBox textBox_RepeatPassword;
    }
}