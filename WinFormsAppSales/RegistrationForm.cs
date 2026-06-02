using ClassLibrarySales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace WinFormsAppSales
{
    /// <summary>
    /// Форма регистрации нового пользователя в системе.
    /// Позволяет создать учётную запись с указанием логина и пароля,
    /// автоматически назначает базовый уровень доступа (код 4).
    /// </summary>
    public partial class RegistrationForm : Form
    {
        private string connectionString;

        public RegistrationForm()
        {
            InitializeComponent();
        }
        public void SetConnectionStirng(string conString)
        {
            connectionString = conString;
        }
        /// <summary>
        /// Проверка на существование пользователя с таким же логином
        /// </summary>
        private bool IsUserExists(string login)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string checkUserQuery = "SELECT COUNT(*) FROM Пользователи WHERE ИмяПользователя = @Login";

                    using (OleDbCommand command = new OleDbCommand(checkUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        // Получение количества пользователей с заданным логином
                        int userCount = (int)command.ExecuteScalar();
                        return userCount > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при проверке существования пользователя: {ex.Message}");
                    return false;
                }
            }
        }
        private void button_AddUser_Click(object sender, EventArgs e)
        {

            string newLogin = textBox_Login.Text.Trim();
            string newPassword = textBox_Password.Text.Trim();
            string repeatNewPassword = textBox_RepeatPassword.Text.Trim();

            // Валидация ввода
            if (string.IsNullOrEmpty(newLogin) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(repeatNewPassword))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (!string.Equals(newPassword, repeatNewPassword))
            {
                MessageBox.Show("Проверьте правильность ввода пароля");
                return;
            }
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов");
                return;
            }
            if (IsUserExists(newLogin))
            {
                MessageBox.Show("Пользователь с таким логином уже существует. Выберите другой логин.");
                return;
            }
            // Хеширование пароля
            string hashedPassword = DatabaseHelper.HashPassword(newPassword);

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OleDbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Добавление нового пользователя в таблицу Пользователи
                            string insertUserQuery =
                                "INSERT INTO Пользователи (ИмяПользователя, Пароль, КодПравПользователя) " +
                                "VALUES (@Login, @Password, @RightsCode)";

                            using (OleDbCommand userCommand = new OleDbCommand(insertUserQuery, connection, transaction))
                            {
                                userCommand.Parameters.AddWithValue("@Login", newLogin);
                                userCommand.Parameters.AddWithValue("@Password", hashedPassword);
                                userCommand.Parameters.AddWithValue("@RightsCode", 4);
                            }

                            transaction.Commit();
                            MessageBox.Show("Пользователь успешно зарегистрирован");
                            string userRightsName = GetNameFromIndex(connection, transaction);
                            if (userRightsName != "")
                            {
                                MessageBox.Show($"Уровень доступа пользователя - {userRightsName}");
                            }

                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Ошибка регистрации: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения: {ex.Message}");
                }
            }
        }
        /// <summary>
        /// Получение уровня доступа по индексу
        /// </summary>
        private string GetNameFromIndex(OleDbConnection connection, OleDbTransaction transaction)
        {
            string getRightsQuery = "SELECT ПраваПользователя FROM ПраваПользователей WHERE КодПравПользователя = @RightsCode";
            string userRightsName = "";

            using (OleDbCommand rightsCommand = new OleDbCommand(getRightsQuery, connection, transaction))
            {
                rightsCommand.Parameters.AddWithValue("@RightsCode", 4);
                object result = rightsCommand.ExecuteScalar();

                if (result != null)
                {
                    userRightsName = result.ToString();
                }
                return userRightsName;
            }
        }
        private void button_Return_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 
            }
        }
    }
}
