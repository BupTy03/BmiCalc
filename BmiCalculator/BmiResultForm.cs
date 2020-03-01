using System;
using System.Drawing;
using System.Windows.Forms;


namespace BmiCalculator
{
    public partial class BmiResultForm : Form
    {
        public BmiResultForm(Image bmiImage, string message, Color messageColor)
        {
            InitializeComponent();
            bmiPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            bmiPictureBox.Image = bmiImage;
            bmiResultLabel.Text = message;
            bmiResultLabel.ForeColor = messageColor;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
