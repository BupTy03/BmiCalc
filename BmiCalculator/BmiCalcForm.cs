using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmiCalculator
{
    public partial class BmiCalcForm : Form
    {
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
                return new GetIntFromTextResult(0, false, String.Format("Значение должно быть в пределах от {0} до {1}", minVal, maxVal));

            return new GetIntFromTextResult(value, true, "");
        }

        private static bool InRange(char value, char minValue, char maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        private static void ValidateTextBox(TextBox txtBox, ErrorProvider errProvider, int minVal, int maxVal)
        {
            string text = txtBox.Text;
            if (text.Length > 0)
            {
                int prevLastIndex = text.Length - 1;
                if (!InRange(text[prevLastIndex], '0', '9'))
                {
                    txtBox.Text = text.Remove(prevLastIndex, 1);
                    return;
                }
            }

            var result = GetIntFromText(text, minVal, maxVal);
            if (!result.IsValid)
                errProvider.SetError(txtBox, result.ErrorMessage);
            else
                errProvider.Clear();
        }

        // Event handlers
        private void ageTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBox((TextBox)sender, ageErrorProvider, 2, 100);
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBox((TextBox)sender, heightErrorProvider, 30, 240);
        }

        private void weightTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextBox((TextBox)sender, weightErrorProvider, 2, 250);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            var age = GetIntFromText(ageTextBox.Text, 18, 100);
            var height = GetIntFromText(heightTextBox.Text, 30, 240);
            var weight = GetIntFromText(weightTextBox.Text, 2, 250);

            if (!(age.IsValid && height.IsValid && weight.IsValid))
                return;

            var calcResult = BmiCalculator.Calculate(age.Value, height.Value, weight.Value, manRadioButton.Checked);
            var resultForm = new BmiResultForm(calcResult.BmiImage, calcResult.BmiText, calcResult.BmiTextColor);
            resultForm.ShowDialog();
        }
    }
}
