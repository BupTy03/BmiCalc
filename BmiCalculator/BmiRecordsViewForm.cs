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
    /// <summary>
    /// Отображает список записей(запись представлена объектом типа Human).
    /// </summary>
    public partial class BmiRecordsViewForm : Form
    {
        public BmiRecordsViewForm(List<Human> records)
        {
            InitializeComponent();
            recordsListBox.Items.AddRange(records.ToArray());
        }
    }
}
