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
        private LogicLayer _logicLayer;

        public RegistrationForm()
        {
            InitializeComponent();
        }
        public void SetLogicLayer(LogicLayer logicLayer)
        {
            _logicLayer = logicLayer;
        }
        /// <summary>
        /// Проверка на существование пользователя с таким же логином
        /// </summary>
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
            try
            {
                if (_logicLayer.UserExistance(newLogin))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует. Выберите другой логин.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке существования пользователя: {ex.Message}");
                return;
            }
            try
            {
                string message;
                _logicLayer.UserReg(newLogin, newPassword, out message);
                MessageBox.Show(message);
                ShowUserRights();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }
       private void ShowUserRights()
       {
            string userRightsName = _logicLayer.ShowUserRights();
            if (!string.IsNullOrEmpty(userRightsName))
            {
                MessageBox.Show($"Уровень доступа пользователя - {userRightsName}");
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
