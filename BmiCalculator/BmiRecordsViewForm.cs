using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;


namespace BmiCalculator
{
    /// <summary>
    /// Отображает список записей(запись представлена объектом типа Human).
    /// </summary>
    public partial class BmiRecordsViewForm : Form
    {
        public BmiRecordsViewForm(IEnumerable<Human> records)
        {
            Debug.Assert(records != null);

            InitializeComponent();
            recordsListBox.Items.AddRange(records.ToArray());
        }
    }
}
