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
        private readonly Human _human;
        private readonly string _bmiRecordsFileName;

        public BmiResultForm(string bmiRecordsFileName, BmiCalculator.CalculationResults calculationResult, Human human)
        {
            InitializeComponent();

            _bmiRecordsFileName = bmiRecordsFileName;
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
        /// Обработка нажатия кнопки "Сохранить".
        /// </summary>
        private void SaveButtonClicked(object sender, EventArgs e) => SaveHumanToFileAsync();


        /// <summary>
        /// Сохранение данных(асинхронно).
        /// </summary>
        private async Task SaveHumanToFileAsync()
        {
            saveButton.Enabled = false;

            FileStream fileStream = null;
            try
            {
                byte[] separator = new UTF8Encoding(true).GetBytes("\n");
                fileStream = new FileStream(_bmiRecordsFileName, FileMode.Append | FileMode.Create);
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
    }
}
