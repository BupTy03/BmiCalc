using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;

using SegmentsList;


namespace BmiCalculator
{
    /// <summary>
    /// Синглтон, инкапсулирующий расчёт BMI.
    /// </summary>
    public sealed class BmiCalculator
    {
        private static readonly BmiCalculator _instance = new BmiCalculator();
        public static BmiCalculator Instance => _instance;

        private readonly SegmentsList<int, SegmentsList<double, FatLevel>> _bmiByAgesList;
        private readonly Dictionary<FatLevel, FatLevelEntry> _fatLevelEntries;

        static BmiCalculator()
        {
        }

        /// <summary>
        /// Уровень ожирения.
        /// </summary>
        private enum FatLevel
        {
            Underweight,
            Normal,
            Owerweight,
            FirstGradeObesity,
            SecondGradeObesity,
            ThirdGradeObesity,
            FourthGradeObesity
        }

        /// <summary>
        /// Запись, соответствующая определённому уровню жирности.
        /// Хранит картинки(для мужчин и для женщин соответственно), сообщение и цвет текста.
        /// </summary>
        private struct FatLevelEntry
        {
            public FatLevelEntry(Image menImage, Image womenImage, string message, Color textColor)
            {
                Debug.Assert(menImage != null);
                Debug.Assert(womenImage != null);
                Debug.Assert(message != null);
                Debug.Assert(textColor != null);

                MenImage = menImage;
                WomenImage = womenImage;
                Message = message;
                TextColor = textColor;
            }

            public Image MenImage { get; }
            public Image WomenImage { get; }
            public string Message { get; }
            public Color TextColor { get; }
        }

        /// <summary>
        /// Хранит результат вычислений, произведённых методом Calculate.
        /// Содержит картинку, сообщение и цвет текста сообщения.
        /// </summary>
        public struct CalculationResults
        {
            public CalculationResults(Image bmiImage, string bmiText, Color bmiTextColor)
            {
                Debug.Assert(bmiImage != null);
                Debug.Assert(bmiText != null);
                Debug.Assert(bmiTextColor != null);

                BmiImage = bmiImage;
                BmiText = bmiText;
                BmiTextColor = bmiTextColor;
            }

            public Image BmiImage { get; }
            public string BmiText { get; }
            public Color BmiTextColor { get; }
        }

        private BmiCalculator()
        {
            _fatLevelEntries = LoadEntries();


            // Таблица заполнена в соответствии с: https://simpledoc.ru/indeks-massy-tela/#start

            var littleAge = new SegmentsList<double, FatLevel>();
            littleAge.Add(0,    FatLevel.Underweight);
            littleAge.Add(15.3, FatLevel.Normal);
            littleAge.Add(17,   FatLevel.Owerweight);
            littleAge.Add(18.3, FatLevel.FirstGradeObesity);
            littleAge.Add(20.3, FatLevel.SecondGradeObesity);
            littleAge.Add(25,   FatLevel.ThirdGradeObesity);
            littleAge.Add(35,   FatLevel.FourthGradeObesity);

            var middleAge = new SegmentsList<double, FatLevel>();
            middleAge.Add(0,    FatLevel.Underweight);
            middleAge.Add(19.5, FatLevel.Normal);
            middleAge.Add(23,   FatLevel.Owerweight);
            middleAge.Add(27.5, FatLevel.FirstGradeObesity);
            middleAge.Add(30,   FatLevel.SecondGradeObesity);
            middleAge.Add(35,   FatLevel.ThirdGradeObesity);
            middleAge.Add(40,   FatLevel.FourthGradeObesity);

            var oldAge = new SegmentsList<double, FatLevel>();
            oldAge.Add(0,  FatLevel.Underweight);
            oldAge.Add(20, FatLevel.Normal);
            oldAge.Add(26, FatLevel.Owerweight);
            oldAge.Add(28, FatLevel.FirstGradeObesity);
            oldAge.Add(31, FatLevel.SecondGradeObesity);
            oldAge.Add(36, FatLevel.ThirdGradeObesity);
            oldAge.Add(41, FatLevel.FourthGradeObesity);


            _bmiByAgesList = new SegmentsList<int, SegmentsList<double, FatLevel>>();
            _bmiByAgesList.Add(0, littleAge);
            _bmiByAgesList.Add(18, middleAge);
            _bmiByAgesList.Add(30, oldAge);
        }

        /// <summary>
        /// Производит вычисление BMI и возвращает результат BmiCalculationResult.
        /// </summary>
        /// <param name="human">Человек.</param>
        /// <returns>Результаты вычисления BMI.</returns>
        public CalculationResults Calculate(Human human)
        {
            Debug.Assert(human != null);

            FatLevelEntry entry = _fatLevelEntries[_bmiByAgesList[human.Age][human.Bmi]];

            return new CalculationResults(
                human.Gender == HumanGender.Male ? entry.MenImage : entry.WomenImage, 
                String.Format("Ваш BMI: {0:f1}. ", human.Bmi) + entry.Message,
                entry.TextColor);
        }

        /// <summary>
        /// Заполняет словарь записей FatLevelEntry, соответствующих определённым уровням жирности.
        /// </summary>
        /// <returns>Словарь с записями FatLevelEntry.</returns>
        private static Dictionary<FatLevel, FatLevelEntry> LoadEntries()
        {
            var menImages = new Dictionary<FatLevel, Image> 
            {
                [FatLevel.Underweight]          = Properties.Resources.m1,
                [FatLevel.Normal]               = Properties.Resources.m2,
                [FatLevel.Owerweight]           = Properties.Resources.m3,
                [FatLevel.FirstGradeObesity]    = Properties.Resources.m4,
                [FatLevel.SecondGradeObesity]   = Properties.Resources.m5,
                [FatLevel.ThirdGradeObesity]    = Properties.Resources.m5,
                [FatLevel.FourthGradeObesity]   = Properties.Resources.m5
            };

            var womenImages = new Dictionary<FatLevel, Image>
            {
                [FatLevel.Underweight]          = Properties.Resources.f1,
                [FatLevel.Normal]               = Properties.Resources.f2,
                [FatLevel.Owerweight]           = Properties.Resources.f3,
                [FatLevel.FirstGradeObesity]    = Properties.Resources.f4,
                [FatLevel.SecondGradeObesity]   = Properties.Resources.f5,
                [FatLevel.ThirdGradeObesity]    = Properties.Resources.f5,
                [FatLevel.FourthGradeObesity]   = Properties.Resources.f5
            };

            var messages = new Dictionary<FatLevel, string>
            {
                [FatLevel.Underweight]          = "Дефицит массы тела",
                [FatLevel.Normal]               = "Норма",
                [FatLevel.Owerweight]           = "Избыток массы тела",
                [FatLevel.FirstGradeObesity]    = "Ожирение 1 степени",
                [FatLevel.SecondGradeObesity]   = "Ожирение 2 степени",
                [FatLevel.ThirdGradeObesity]    = "Ожирение 3 степени",
                [FatLevel.FourthGradeObesity]   = "Ожирение 4 степени"
            };

            var colors = new Dictionary<FatLevel, Color>
            {
                [FatLevel.Underweight]          = Color.FromArgb(149, 188, 221),
                [FatLevel.Normal]               = Color.FromArgb(125, 195, 159),
                [FatLevel.Owerweight]           = Color.FromArgb(253, 216, 20),
                [FatLevel.FirstGradeObesity]    = Color.FromArgb(244, 160, 70),
                [FatLevel.SecondGradeObesity]   = Color.FromArgb(231, 55, 65),
                [FatLevel.ThirdGradeObesity]    = Color.FromArgb(231, 55, 65),
                [FatLevel.FourthGradeObesity]   = Color.FromArgb(231, 55, 65)
            };

            var result = new Dictionary<FatLevel, FatLevelEntry>();
            foreach (FatLevel level in Enum.GetValues(typeof(FatLevel)))
            {
                result.Add(level, new FatLevelEntry(
                    menImages[level],
                    womenImages[level],
                    messages[level],
                    colors[level]
                ));
            }

            return result;
        }
    }
}
