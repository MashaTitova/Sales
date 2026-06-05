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
    /// <summary>
    /// Форма аутентификации пользователя
    /// </summary>
    public partial class AuthenticationForm : Form
    {
        private string _userRightsIndex;
        private LogicLayer _logicLayer;
        public AuthenticationForm()
        {
            InitializeComponent();
            // Использование системного символа для сокрытия пароля
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
        public void SetLogicLayer(LogicLayer logicLayer)
        {
            _logicLayer = logicLayer;
        }
        public string GetUserRights()
        {
            return _userRightsIndex;
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
            try
            {
                string message = "";
                string index = _logicLayer.GetAuthentication(enteredPassword, enteredLogin, out message);
                MessageBox.Show(message);
                if(index != null)
                {
                    _userRightsIndex = index;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }

        }


        private void button_Regestration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm form = new RegistrationForm();
            form.SetLogicLayer(_logicLayer);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                form.Close();
                _userRightsIndex = "4";
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                form.Close();
                this.Show();
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
