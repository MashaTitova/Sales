using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsAppSales
{
    public partial class AuthenticationForm : Form
    {
        private string userRightsIndex;
        private string connectionString;
        public AuthenticationForm()
        {
            InitializeComponent();
            textBox_Password.UseSystemPasswordChar = true;
        }
        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            bool isVisible = Convert.ToBoolean(button_TogglePassword.Tag);

            if (!isVisible)
            {
                textBox_Password.UseSystemPasswordChar = false;
                textBox_Password.PasswordChar = '\0';
                button_TogglePassword.Text = "🔒";
                button_TogglePassword.Tag = true;
            }
            else
            {
                textBox_Password.UseSystemPasswordChar = true;
                button_TogglePassword.Text = "👁";
                button_TogglePassword.Tag = false;
            }
        }
        public void SetConnectionStirng(string basePath)
        {
            string conString = DatabaseHelper.GetConnectionString(basePath);
            connectionString = conString;
        }
        public string GetUserRights()
        {
            return userRightsIndex;
        }
        private void button_Entry_Click(object sender, EventArgs e)
        {
            string enteredLogin = textBox_Login.Text.Trim();
            string enteredPassword = textBox_Password.Text.Trim();

            if (string.IsNullOrEmpty(enteredLogin) || string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }

            // Хешируем введённый пароль
            string hashedEnteredPassword = DatabaseHelper.HashPassword(enteredPassword);

            string query = "SELECT Пользователи.ИмяПользователя, Пользователи.Пароль, Пользователи.КодПравПользователя, ПраваПользователей.ПраваПользователя " +
                          "FROM Пользователи " +
                          "INNER JOIN ПраваПользователей ON Пользователи.КодПравПользователя = ПраваПользователей.КодПравПользователя " +
                          "WHERE Пользователи.ИмяПользователя = @Login";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Login", enteredLogin);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Сравниваем хеш из базы с введённым
                                string storedHash = reader["Пароль"].ToString();

                                if (storedHash == hashedEnteredPassword)
                                {
                                    // Получаем права из связанной таблицы
                                    userRightsIndex = reader["КодПравПользователя"].ToString();
                                    string userRights = reader["ПраваПользователя"].ToString();
                                    MessageBox.Show("Вход выполнен успешно \n" +
                                        $"Ваш уровень доступа - {userRights}");
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Пользователь не найден");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при входе: {ex.Message}");
                }
            }

        }


        private void button_Regestration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm form = new RegistrationForm();
            form.SetConnectionStirng(connectionString);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                userRightsIndex = "4";
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button_End_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AuthenticationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
