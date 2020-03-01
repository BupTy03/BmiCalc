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
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="bmiImage">Картинка, отображающая степень ожирения.</param>
        /// <param name="message">Сообщение, отображающее степень ожирения.</param>
        /// <param name="messageColor">Цвет сообщения.</param>
        public BmiResultForm(Image bmiImage, string message, Color messageColor)
        {
            InitializeComponent();
            bmiPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            bmiPictureBox.Image = bmiImage;
            bmiResultLabel.Text = message;
            bmiResultLabel.ForeColor = messageColor;
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "OK".
        /// </summary>
        private void okButton_Click(object sender, EventArgs e) => Close();
    }
}
