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
        public BmiResultForm()
        {
            InitializeComponent();
            bmiPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            bmiPictureBox.Image = Image.FromFile(@"D:\\USER\\Downloads\\55c601160d671.jpg");
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
