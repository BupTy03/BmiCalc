using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;


namespace BmiCalculator
{
    public enum AuthorizationResult
    {
        AuthorizedAsUser,
        AuthorizedAsAdministrator,
        NotAuthorized
    }

    /// <summary>
    /// Форма авторизации.
    /// </summary>
    public partial class AuthorizationForm : Form
    {
        private const string AdministratorLogin = "Admin";

        private AuthorizationResult _currentState = AuthorizationResult.NotAuthorized;
        private Dictionary<string, string> _loginsAndPasswords = new Dictionary<string, string>
        {
            [AdministratorLogin] = "123",
            ["Anton"] = "1234",
            ["Denis"] = "12345"
        };

        private AuthorizationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Авторизоваться.
        /// </summary>
        /// <returns>Результат авторизации.</returns>
        public static AuthorizationResult Authorize()
        {
            using (var form = new AuthorizationForm())
            {
                form.ShowDialog();
                return form._currentState;
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "OK".
        /// </summary>
        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            Debug.Assert(IsFormFilled());

            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if(!_loginsAndPasswords.ContainsKey(login))
            {
                loginTextBoxErrorProvider.SetError(loginTextBox, "Логин не найден");
                return;
            }

            if(_loginsAndPasswords[login] != password)
            {
                passwordTextBoxErrorProvider.SetError(passwordTextBox, "Неверный пароль");
                return;
            }

            if(login == AdministratorLogin)
            {
                _currentState = AuthorizationResult.AuthorizedAsAdministrator;
            }
            else
            {
                _currentState = AuthorizationResult.AuthorizedAsUser;
            }

            Close();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Выход".
        /// </summary>
        private void OnExitButtonClicked(object sender, EventArgs e) => Close();

        /// <summary>
        /// Обработка события изменения текста в любом из TextBox-ов.
        /// </summary>
        private void OnTextInInputsChanged(object sender, EventArgs e) => IsFormFilled();


        /// <summary>
        /// Проверка, заполнена ли форма или остались ещё пустые инпуты(TextBox-ы).
        /// </summary>
        /// <returns>true - если форма заполнена(все инпуты не пустые).</returns>
        private bool IsFormFilled()
        {
            bool result = true;
            if (loginTextBox.Text.Length == 0)
            {
                loginTextBoxErrorProvider.SetError(loginTextBox, "Введите логин");
                result = false;
            }
            else
            {
                loginTextBoxErrorProvider.Clear();
            }

            if (passwordTextBox.Text.Length == 0)
            {
                passwordTextBoxErrorProvider.SetError(passwordTextBox, "Введите пароль");
                result = false;
            }
            else
            {
                passwordTextBoxErrorProvider.Clear();
            }

            okButton.Enabled = result;
            return result;
        }
    }
}
