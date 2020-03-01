using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using SegmentsList;


namespace BmiCalculator
{
    public sealed class BmiCalculator
    {
        private static readonly BmiCalculator m_instance = new BmiCalculator();
        public static BmiCalculator Instance => m_instance;

        static BmiCalculator()
        {
        }

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

        private struct FatLevelEntry
        {
            public FatLevelEntry(Image menImage, Image womenImage, string message, Color textColor)
            {
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

        public struct BmiCalculationResult
        {
            public BmiCalculationResult(Image bmiImage, string bmiText, Color bmiTextColor)
            {
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
            m_fatLevelEntries = LoadEntries();


            // Таблица заполнена в соответствии с: https://simpledoc.ru/indeks-massy-tela/#start

            // мелкий возраст
            var littleAge = new SegmentsList<double, FatLevel>();
            littleAge.Add(0, FatLevel.Underweight);
            littleAge.Add(15.3, FatLevel.Normal);
            littleAge.Add(17, FatLevel.Owerweight);
            littleAge.Add(18.3, FatLevel.FirstGradeObesity);
            littleAge.Add(20.3, FatLevel.SecondGradeObesity);
            littleAge.Add(25, FatLevel.ThirdGradeObesity);
            littleAge.Add(35, FatLevel.FourthGradeObesity);

            // средний возраст
            var middleAge = new SegmentsList<double, FatLevel>();
            middleAge.Add(0,    FatLevel.Underweight);
            middleAge.Add(19.5, FatLevel.Normal);
            middleAge.Add(23,   FatLevel.Owerweight);
            middleAge.Add(27.5, FatLevel.FirstGradeObesity);
            middleAge.Add(30,   FatLevel.SecondGradeObesity);
            middleAge.Add(35,   FatLevel.ThirdGradeObesity);
            middleAge.Add(40,   FatLevel.FourthGradeObesity);

            // старший возраст
            var oldAge = new SegmentsList<double, FatLevel>();
            oldAge.Add(0,  FatLevel.Underweight);
            oldAge.Add(20, FatLevel.Normal);
            oldAge.Add(26, FatLevel.Owerweight);
            oldAge.Add(28, FatLevel.FirstGradeObesity);
            oldAge.Add(31, FatLevel.SecondGradeObesity);
            oldAge.Add(36, FatLevel.ThirdGradeObesity);
            oldAge.Add(41, FatLevel.FourthGradeObesity);

            // таблица возрастов
            m_bmiByAgesList = new SegmentsList<int, SegmentsList<double, FatLevel>>();
            m_bmiByAgesList.Add(0, littleAge);
            m_bmiByAgesList.Add(18, middleAge);
            m_bmiByAgesList.Add(30, oldAge);
        }

        public BmiCalculationResult Calculate(int age, int height, int weight, bool gender)
        {
            Debug.Assert(age >= 0);
            Debug.Assert(height > 0);
            Debug.Assert(weight > 0);

            const double centimetersInMeters = 100.0;
            double heightInMeters = height / centimetersInMeters;
            double bmiValue = weight / (heightInMeters * heightInMeters);

            FatLevelEntry entry = m_fatLevelEntries[m_bmiByAgesList[age][bmiValue]];
            return new BmiCalculationResult(
                gender ? entry.MenImage : entry.WomenImage, 
                String.Format("Ваш BMI: {0:f1}. ", bmiValue) + entry.Message,
                entry.TextColor);
        }


        private static Dictionary<FatLevel, FatLevelEntry> LoadEntries()
        {
            var mens = new Dictionary<FatLevel, string> 
            {
                [FatLevel.Underweight]          = "m1.jpg",
                [FatLevel.Normal]               = "m2.jpg",
                [FatLevel.Owerweight]           = "m3.jpg",
                [FatLevel.FirstGradeObesity]    = "m4.jpg",
                [FatLevel.SecondGradeObesity]   = "m5.jpg",
                [FatLevel.ThirdGradeObesity]    = "m5.jpg",
                [FatLevel.FourthGradeObesity]   = "m5.jpg"
            };

            var womens = new Dictionary<FatLevel, string>
            {
                [FatLevel.Underweight]          = "f1.jpg",
                [FatLevel.Normal]               = "f2.jpg",
                [FatLevel.Owerweight]           = "f3.jpg",
                [FatLevel.FirstGradeObesity]    = "f4.jpg",
                [FatLevel.SecondGradeObesity]   = "f5.jpg",
                [FatLevel.ThirdGradeObesity]    = "f5.jpg",
                [FatLevel.FourthGradeObesity]   = "f5.jpg"
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


            string imagePathPrefix = new string[] {
                @"img\", @"..\img\", @"..\..\img\"
            }.FirstOrDefault(prefix => Directory.Exists(prefix));

            var result = new Dictionary<FatLevel, FatLevelEntry>();
            foreach (FatLevel level in Enum.GetValues(typeof(FatLevel)))
            {
                result.Add(level, new FatLevelEntry(
                    Image.FromFile(imagePathPrefix + mens[level]),
                    Image.FromFile(imagePathPrefix + womens[level]),
                    messages[level],
                    colors[level]
                ));
            }

            return result;
        }

        private readonly SegmentsList<int, SegmentsList<double, FatLevel>> m_bmiByAgesList;
        private readonly Dictionary<FatLevel, FatLevelEntry> m_fatLevelEntries;
    }
}
