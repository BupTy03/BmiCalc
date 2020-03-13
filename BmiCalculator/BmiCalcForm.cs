using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace BmiCalculator
{
    /// <summary>
    /// Форма главного окна калькулятора BMI.
    /// </summary>
    public partial class BmiCalcForm : Form
    {
        public BmiCalcForm()
        {
            InitializeComponent();
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
                errProvider.SetError(txtBox, "Введите значение!");
                return false;
            }

            if (!Int32.TryParse(text, out int value))
            {
                errProvider.SetError(txtBox, "Некорректное значение!");
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
        /// Проверяет введённые в форму данные.
        /// </summary>
        /// <returns>true если форма правильно обработана</returns>
        private bool ValidateForm()
        {
            return
                ValidateTextBoxAndSetErrorToProvider(ageTextBox, ageErrorProvider, Human.MinAge, Human.MaxAge) &&
                ValidateTextBoxAndSetErrorToProvider(heightTextBox, heightErrorProvider, Human.MinHeight, Human.MaxHeight) &&
                ValidateTextBoxAndSetErrorToProvider(weightTextBox, weightErrorProvider, Human.MinWeight, Human.MaxWeight);
        }

        /// <summary>
        /// Обрабатывает события изменения текста в TextBox-ах.
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            calcButton.Enabled = ValidateForm();
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Выход".
        /// </summary>
        private void ExitButtonClicked(object sender, EventArgs e) => Close();

        /// <summary>
        /// Показать ошибку.
        /// </summary>
        /// <param name="errorMessage">Сообщение об ошибке</param>
        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "Рассчитать".
        /// </summary>
        private void CalculateButtonClicked(object sender, EventArgs e)
        {
            if(!ValidateForm())
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
            catch(FileNotFoundException exception)
            {
                ShowError(String.Format("Файл изображения \"{0}\" не найден!", exception.FileName));
                return;
            }
            catch(Exception)
            {
                ShowError("Упс, кажется что-то пошло не так :(");
                return;
            }

            using (var resultForm = new BmiResultForm(calcResult, human))
            {
                resultForm.ShowDialog();
            }
        }
    }
}
