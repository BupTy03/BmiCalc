using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace BmiCalculator
{
    /// <summary>
    /// Форма, отображающая результаты вычислений BMI.
    /// </summary>
    public partial class BmiResultForm : Form
    {
        private const string SerializedObjectsFileName = "bmi.json";

        private readonly Human _human;

        public BmiResultForm(BmiCalculator.CalculationResults calculationResult, Human human)
        {
            InitializeComponent();

            _human = human;

            bmiPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            bmiPictureBox.Image = calculationResult.BmiImage;
            bmiResultLabel.Text = calculationResult.BmiText;
            bmiResultLabel.ForeColor = calculationResult.BmiTextColor;
        }

        /// <summary>
        /// Обработка события нажатия на кнопку "OK".
        /// </summary>
        private void OkButtonClicked(object sender, EventArgs e) => Close();

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        private async Task SaveHumanToFile()
        {
            saveButton.Enabled = false;

            FileStream fileStream = null;
            try
            {
                byte[] separator = new UTF8Encoding(true).GetBytes("\n");
                fileStream = new FileStream(SerializedObjectsFileName, FileMode.Append | FileMode.Create);
                await JsonSerializer.SerializeAsync(fileStream, _human);
                fileStream.Write(separator, 0, separator.Length);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось сохранить результаты ):", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                fileStream.Close();
                saveButton.Enabled = true;
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Сохранить".
        /// </summary>
        private void SaveButtonClicked(object sender, EventArgs e) => SaveHumanToFile();
    }
}
