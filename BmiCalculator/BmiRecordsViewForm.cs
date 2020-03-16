using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BmiCalculator
{
    public partial class BmiRecordsViewForm : Form
    {
        private readonly string _bmiRecordsFileName;

        public BmiRecordsViewForm(string bmiRecordsFileName)
        {
            _bmiRecordsFileName = bmiRecordsFileName;

            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            Visible = false;

            var records = LoadRecords();
            recordsListBox.Items.AddRange(records.ToArray());

            Visible = true;
        }


        private List<Human> LoadRecords()
        {
            try
            {
                string[] lines = File.ReadAllLines(_bmiRecordsFileName);

                var result = new List<Human>();
                result.Capacity = lines.Length;
                foreach (string line in lines)
                {
                    if (line.Length == 0)
                        continue;

                    result.Add(JsonSerializer.Deserialize<Human>(line));
                }

                return result;
            }
            catch(Exception)
            {
                ShowError("Не удалось корректно загрузить записи");
            }

            return new List<Human>();
        }

        private void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
