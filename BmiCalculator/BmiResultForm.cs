using System;
using System.Drawing;
using System.Windows.Forms;


namespace BmiCalculator
{
    /// <summary>
    /// Форма, отображающая результаты вычислений BMI.
    /// </summary>
    public partial class BmiResultForm : Form
    {
        public BmiResultForm(BmiCalculator.CalculationResult calculationResult)
        {
            InitializeComponent();
            bmiPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            bmiPictureBox.Image = calculationResult.BmiImage;
            bmiResultLabel.Text = calculationResult.BmiText;
            bmiResultLabel.ForeColor = calculationResult.BmiTextColor;
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "OK".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e) => Close();
    }
}
