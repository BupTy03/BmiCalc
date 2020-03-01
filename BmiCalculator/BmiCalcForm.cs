using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace BmiCalculator
{
    /// <summary>
    /// Форма главного окна калькулятора BMI.
    /// </summary>
    public partial class BmiCalcForm : Form
    {
        private const int MinAge = 0;
        private const int MaxAge = 100;

        private const int MinHeight = 30;
        private const int MaxHeight = 240;

        private const int MinWeight = 2;
        private const int MaxWeight = 250;

        public BmiCalcForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Результат, возвращаемый функцией GetIntFromText.
        /// Хранит в себе состояние значения (валидное/невалидное), значение, 
        /// сообщение об ошибке, если состояние оказалось невалидным.
        /// </summary>
        private struct GetIntFromTextResult
        {
            /// <summary>
            /// Конструктор для инициализации полей.
            /// </summary>
            /// <param name="value">Значение.</param>
            /// <param name="isValid">Валидность значения.</param>
            /// <param name="errorMessage">Сообщение об ошибке. (Пустое, если значение валидно)</param>
            public GetIntFromTextResult(int value, bool isValid, string errorMessage)
            {
                m_value = value;
                IsValid = isValid;
                ErrorMessage = errorMessage;
            }

            private int m_value;
            public bool IsValid { get; }

            /// <summary>
            /// Свойство Value кидает исключение при попытке 
            /// обратиться к невалидному значению.
            /// </summary>
            public int Value
            {
                get
                {
                    if (!IsValid)
                        throw new InvalidDataException("Value was in invalid state!");

                    return m_value;
                }
            }
            public string ErrorMessage { get; }
        }

        /// <summary>
        /// Перевести строку в целое число.
        /// </summary>
        /// <param name="text">Строка теста.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns></returns>
        private static GetIntFromTextResult GetIntFromText(string text, int minValue, int maxValue)
        {
            if (text.Length == 0)
                return new GetIntFromTextResult(0, false, "Введите значение");

            if (!Int32.TryParse(text, out int value))
                return new GetIntFromTextResult(0, false, "Некорректное значение");

            if (!(value >= minValue && value <= maxValue))
                return new GetIntFromTextResult(0, false, 
                    String.Format("Значение должно быть в пределах от {0} до {1}", minValue, maxValue));

            return new GetIntFromTextResult(value, true, "");
        }

        /// <summary>
        /// Проверяет корректность ввода в TextBox.
        /// </summary>
        /// <param name="txtBox">Инпут.</param>
        /// <param name="errProvider">Провайдер ошибок.</param>
        /// <param name="minValue">Минимальное значение.</param>
        /// <param name="maxValue">Максимальное значение.</param>
        /// <returns>true если проверка прошла успешно.</returns>
        private static bool ValidateTextBox(TextBox txtBox, ErrorProvider errProvider, int minValue, int maxValue)
        {
            string text = txtBox.Text;
            if (text.Length > 0 && !Char.IsDigit(text.Last()))
                txtBox.Text = text.Remove(text.Length - 1, 1);

            var result = GetIntFromText(text, minValue, maxValue);
            if (!result.IsValid)
                errProvider.SetError(txtBox, result.ErrorMessage);
            else
                errProvider.Clear();

            return result.IsValid;
        }

        /// <summary>
        /// Обрабатывает события изменения текста в TextBox-ах.
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            calcButton.Enabled =
                ValidateTextBox(ageTextBox, ageErrorProvider, MinAge, MaxAge) &&
                ValidateTextBox(heightTextBox, heightErrorProvider, MinHeight, MaxHeight) &&
                ValidateTextBox(weightTextBox, weightErrorProvider, MinWeight, MaxWeight);
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Выход".
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e) => Close();

        /// <summary>
        /// Обработка события нажатия на кнопку "Рассчитать".
        /// </summary>
        private void calcButton_Click(object sender, EventArgs e)
        {
            var age = GetIntFromText(ageTextBox.Text, MinAge, MaxAge);
            var height = GetIntFromText(heightTextBox.Text, MinHeight, MaxHeight);
            var weight = GetIntFromText(weightTextBox.Text, MinWeight, MaxWeight);

            Debug.Assert(age.IsValid && height.IsValid && weight.IsValid);

            BmiCalculator.BmiCalculationResult calcResult;
            try
            {
                calcResult = BmiCalculator.Instance.Calculate(age.Value, height.Value, weight.Value, manRadioButton.Checked);
            }
            catch(FileNotFoundException exception)
            {
                MessageBox.Show(String.Format("Файл изображения \"{0}\" не найден!", exception.FileName), 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch(Exception)
            {
                MessageBox.Show("Упс, кажется что-то пошло не так :(", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var resultForm = new BmiResultForm(calcResult.BmiImage, calcResult.BmiText, calcResult.BmiTextColor);
            resultForm.ShowDialog();
        }
    }
}
