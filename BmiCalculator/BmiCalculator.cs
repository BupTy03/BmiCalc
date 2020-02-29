using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BmiCalculator
{
    using BMIList = SegmentsList.SegmentsList<double, string>;
    using AgesBMIList = SegmentsList.SegmentsList<int, SegmentsList.SegmentsList<double, string>>;

    class BmiCalculator
    {
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

        public static BmiCalculationResult Calculate(int age, int height, int weight, bool gender)
        {
            InitData();

            double heightInMeters = height * 0.01;
            double bmiValue = weight / Math.Pow(heightInMeters, 2.0);

            string message = m_bmiByAgesList[age][bmiValue];
            return new BmiCalculationResult(
                gender ? m_mensBmiImages[message] : m_womensBmibmiImages[message], 
                String.Format("Ваш BMI: {0:f1}. ", bmiValue) + message,
                message == "Норма" ? Color.ForestGreen : Color.Red);
        }


        private static void InitData()
        {
            if (m_bmiByAgesList != null)
                return;

            // Заполняю таблицу в соответствии с: https://simpledoc.ru/indeks-massy-tela/#start

            const string imagePathPrefix = "..\\..\\img\\";

            m_mensBmiImages = new Dictionary<string, Image>
            { 
                ["Дефицит массы тела"] = Image.FromFile(imagePathPrefix + "m1.jpg"),
                ["Норма"] = Image.FromFile(imagePathPrefix + "m2.jpg"),
                ["Избыток массы тела"] = Image.FromFile(imagePathPrefix + "m3.jpg"),
                ["Ожирение 1 степени"] = Image.FromFile(imagePathPrefix + "m4.jpg"),
                ["Ожирение 2 степени"] = Image.FromFile(imagePathPrefix + "m5.jpg"),
                ["Ожирение 3 степени"] = Image.FromFile(imagePathPrefix + "m5.jpg"),
                ["Ожирение 4 степени"] = Image.FromFile(imagePathPrefix + "m5.jpg")
            };

            m_womensBmibmiImages = new Dictionary<string, Image>
            {
                ["Дефицит массы тела"] = Image.FromFile(imagePathPrefix + "f1.jpg"),
                ["Норма"] = Image.FromFile(imagePathPrefix + "f2.jpg"),
                ["Избыток массы тела"] = Image.FromFile(imagePathPrefix + "f3.jpg"),
                ["Ожирение 1 степени"] = Image.FromFile(imagePathPrefix + "f4.jpg"),
                ["Ожирение 2 степени"] = Image.FromFile(imagePathPrefix + "f5.jpg"),
                ["Ожирение 3 степени"] = Image.FromFile(imagePathPrefix + "f5.jpg"),
                ["Ожирение 4 степени"] = Image.FromFile(imagePathPrefix + "f5.jpg")
            };

            // средний возраст
            BMIList middleAge = new BMIList();
            middleAge.Add(0, "Дефицит массы тела");
            middleAge.Add(19.5, "Норма");
            middleAge.Add(23, "Избыток массы тела");
            middleAge.Add(27.5, "Ожирение 1 степени");
            middleAge.Add(30, "Ожирение 2 степени");
            middleAge.Add(35, "Ожирение 3 степени");
            middleAge.Add(40, "Ожирение 4 степени");

            // старший возраст
            BMIList oldAge = new BMIList();
            oldAge.Add(0, "Дефицит массы тела");
            oldAge.Add(20, "Норма");
            oldAge.Add(26, "Избыток массы тела");
            oldAge.Add(28, "Ожирение 1 степени");
            oldAge.Add(31, "Ожирение 2 степени");
            oldAge.Add(36, "Ожирение 3 степени");
            oldAge.Add(41, "Ожирение 4 степени");

            // таблица возрастов
            m_bmiByAgesList = new AgesBMIList();
            m_bmiByAgesList.Add(18, middleAge);
            m_bmiByAgesList.Add(30, oldAge);
        }

        private static AgesBMIList m_bmiByAgesList = null;
        private static Dictionary<string, Image> m_mensBmiImages = null;
        private static Dictionary<string, Image> m_womensBmibmiImages = null;
    }
}
