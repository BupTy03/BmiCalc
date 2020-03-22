using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;


namespace BmiCalculator
{
    /// <summary>
    /// Форма главного окна калькулятора BMI.
    /// </summary>
    public partial class BmiCalcForm : Form
    {
        public const string BmiRecordsFileName = "bmi.json";

        public BmiCalcForm(AuthorizationResult auth)
        {
            InitializeComponent();
            ApplyAuthorizationResult(auth);
        }

        /// <summary>
        /// Применить результаты авторизации.
        /// </summary>
        private void ApplyAuthorizationResult(AuthorizationResult auth)
        {
            switch (auth)
            {
                case AuthorizationResult.AuthorizedAsUser:
                    break;
                case AuthorizationResult.AuthorizedAsAdministrator:
                    showRecordsButton.Visible = true;
                    break;
                default:
                    Debug.Assert(false, "User is not authorized");
                    break;
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Рассчитать".
        /// </summary>
        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            BmiCalculator.CalculationResults calcResult;
            Human human;
            try
            {
                int age = Int32.Parse(ageTextBox.Text);
                int heightCm = Int32.Parse(heightTextBox.Text);
                int weightKg = Int32.Parse(weightTextBox.Text);
                HumanGender gender = manRadioButton.Checked ? HumanGender.Male : HumanGender.Female;

                human = new Human(age, heightCm, weightKg, gender);
                calcResult = BmiCalculator.Instance.Calculate(human);
            }
            catch (FileNotFoundException exception)
            {
                ShowError(String.Format("Файл изображения \"{0}\" не найден!", exception.FileName));
                return;
            }
            catch (Exception)
            {
                ShowError("Упс, кажется что-то пошло не так :(");
                return;
            }

            using (var resultForm = new BmiResultForm(calcResult, human, BmiRecordsFileName))
            {
                resultForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Выход".
        /// </summary>
        private void OnExitButtonClicked(object sender, EventArgs e) => Close();

        /// <summary>
        /// Обработка события нажатия на кнопку "Показать".
        /// </summary>
        private void OnShowRecordsButtonClicked(object sender, EventArgs e) => LoadAndShowRecordsAsync();

        /// <summary>
        /// Обрабатывает события изменения текста в TextBox-ах.
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            calcButton.Enabled = ValidateForm();
        }


        /// <summary>
        /// Проверяет введённые в форму данные.
        /// </summary>
        /// <returns>true если форма правильно заполнена.</returns>
        private bool ValidateForm()
        {
            bool isValidAge = ValidateTextBoxAndSetErrorToProvider(ageTextBox, ageErrorProvider, Human.MinAge, Human.MaxAge);
            bool isValidHeight = ValidateTextBoxAndSetErrorToProvider(heightTextBox, heightErrorProvider, Human.MinHeight, Human.MaxHeight);
            bool isValidWeight = ValidateTextBoxAndSetErrorToProvider(weightTextBox, weightErrorProvider, Human.MinWeight, Human.MaxWeight);

            return isValidAge && isValidHeight && isValidWeight;
        }

        /// <summary>
        /// Проверяет корректность ввода в TextBox и устанавливает ошибку (если произошла ошибка).
        /// </summary>
        /// <param name="txtBox">Инпут.</param>
        /// <param name="errProvider">Провайдер ошибок.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>true если проверка прошла успешно.</returns>
        private static bool ValidateTextBoxAndSetErrorToProvider(TextBox txtBox, ErrorProvider errProvider, int minValue, int maxValue)
        {
            string text = txtBox.Text;
            if (text.Length > 0 && !Char.IsDigit(text.Last()))
            {
                txtBox.Text = text.Remove(text.Length - 1, 1);
            }

            if (text.Length == 0)
            {
                errProvider.SetError(txtBox, "Введите значение");
                return false;
            }

            if (!Int32.TryParse(text, out int value))
            {
                errProvider.SetError(txtBox, "Некорректное значение");
                return false;
            }

            if(!(value >= minValue && value <= maxValue))
            {
                errProvider.SetError(txtBox, String.Format("Значение должно быть в пределах от {0} до {1}", minValue, maxValue));
                return false;
            }

            errProvider.Clear();
            return true;
        }

        /// <summary>
        /// Асинхронно загрузить и отобразить в отдельном окне записи BMI.
        /// </summary>
        private async Task LoadAndShowRecordsAsync()
        {
            showRecordsButton.Enabled = false;
            using (var viewRecordsForm = new BmiRecordsViewForm(await Task.Run(LoadRecords)))
            {
                viewRecordsForm.ShowDialog();
            }
            showRecordsButton.Enabled = true;
        }

        /// <summary>
        /// Загрузить записи BMI.
        /// </summary>
        private List<Human> LoadRecords()
        {
            try
            {
                string[] lines = File.ReadAllLines(BmiRecordsFileName);

                var result = new List<Human>{ Capacity = lines.Length };
                foreach (string line in lines)
                {
                    if (line.Length == 0)
                        continue;

                    result.Add(JsonSerializer.Deserialize<Human>(line));
                }

                return result;
            }
            catch (Exception)
            {
                ShowError("Не удалось корректно загрузить записи");
            }

            return new List<Human>();
        }

        /// <summary>
        /// Показать ошибку.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке.</param>
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
