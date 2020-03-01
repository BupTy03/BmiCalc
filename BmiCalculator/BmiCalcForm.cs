using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace BmiCalculator
{
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

        private struct GetIntFromTextResult
        {
            public GetIntFromTextResult(int value, bool isValid, string errorMessage)
            {
                IsValid = isValid;
                Value = value;
                ErrorMessage = errorMessage;
            }

            public bool IsValid { get; }
            public int Value { get; }
            public string ErrorMessage { get; }
        }

        private static GetIntFromTextResult GetIntFromText(string text, int minVal, int maxVal)
        {
            if (text.Length == 0)
                return new GetIntFromTextResult(0, false, "Введите значение");

            int value = 0;
            if (!Int32.TryParse(text, out value))
                return new GetIntFromTextResult(0, false, "Некорректное значение");

            if (!(value >= minVal && value <= maxVal))
                return new GetIntFromTextResult(0, false, 
                    String.Format("Значение должно быть в пределах от {0} до {1}", minVal, maxVal));

            return new GetIntFromTextResult(value, true, "");
        }

        private static bool InRange(char value, char minValue, char maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        private static bool ValidateTextBox(TextBox txtBox, ErrorProvider errProvider, int minVal, int maxVal)
        {
            string text = txtBox.Text;
            if (text.Length > 0)
            {
                int prevLastIndex = text.Length - 1;
                if (!InRange(text[prevLastIndex], '0', '9'))
                {
                    txtBox.Text = text.Remove(prevLastIndex, 1);
                }
            }

            var result = GetIntFromText(text, minVal, maxVal);
            if (!result.IsValid)
                errProvider.SetError(txtBox, result.ErrorMessage);
            else
                errProvider.Clear();

            return result.IsValid;
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            calcButton.Enabled =
                ValidateTextBox(ageTextBox, ageErrorProvider, MinAge, MaxAge) &&
                ValidateTextBox(heightTextBox, ageErrorProvider, MinHeight, MaxHeight) &&
                ValidateTextBox(weightTextBox, ageErrorProvider, MinWeight, MaxWeight);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

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
