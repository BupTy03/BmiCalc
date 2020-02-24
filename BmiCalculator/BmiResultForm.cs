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
    public partial class BmiResultForm : Form
    {
        public BmiResultForm(Image bmiImage, string message, Color messageColor)
        {
            InitializeComponent();
            bmiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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
