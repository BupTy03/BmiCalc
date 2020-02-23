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

        private static void CheckHeight(Control ctrl, int minVal, int maxVal, ErrorProvider errProvider)
        {
            int height = 0;
            if (String.IsNullOrEmpty(ctrl.Text))
            {
                errProvider.SetError(ctrl, "Не указан рост!");
            }
            else if (!Int32.TryParse(ctrl.Text, out height))
            {
                errProvider.SetError(ctrl, "Некорректное число!");
            }
            else if(!(height >= minVal && height <= maxVal))
            {
                errProvider.SetError(ctrl, String.Format("Значение роста должно быть в пределах от {0} до {1} !", minVal, maxVal));
            }
            else
            {
                errProvider.Clear();
            }
        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox heightTxtBox = (TextBox)sender;
            CheckHeight(heightTxtBox, 0, 200, heightErrorProvider);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
