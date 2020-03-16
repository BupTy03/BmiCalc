using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public partial class AuthorizationForm : Form
    {
        private const string AdministratorLogin = "Admin";

        private AuthorizationResult _currentState = AuthorizationResult.NotAuthorized;
        private Dictionary<string, string> _loginsAndPassword = new Dictionary<string, string>
        {
            [AdministratorLogin] = "123",
            ["Anton"] = "1234",
            ["Denis"] = "12345"
        };

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        public static AuthorizationResult Authorize()
        {
            using (var form = new AuthorizationForm())
            {
                form.ShowDialog();
                return form._currentState;
            }
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            Debug.Assert(CheckEmptyInputs());

            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if(!_loginsAndPassword.ContainsKey(login))
            {
                loginTextBoxErrorProvider.SetError(loginTextBox, "Логин не найден");
                return;
            }

            if(_loginsAndPassword[login] != password)
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

        private bool CheckEmptyInputs()
        {
            bool result = true;
            if(loginTextBox.Text.Length == 0)
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

        private void OnTextInInputsChanged(object sender, EventArgs e) => CheckEmptyInputs();

        private void OnExitButtonClicked(object sender, EventArgs e) => Close();
    }
}
