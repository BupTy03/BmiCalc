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

            // TODO: сделать чтобы gender(пол) на что-то влиял
            double heightInMeters = height * 0.01;
            double bmiValue = weight / Math.Pow(heightInMeters, 2.0);

            string message = m_bmiByAgesList[age][bmiValue];
            return new BmiCalculationResult(
                m_bmiImages[message], 
                String.Format("Ваш BMI: {0:f1}. ", bmiValue) + message,
                message == "Норма" ? Color.ForestGreen : Color.Red);
        }


        private static void InitData()
        {
            if (m_bmiByAgesList != null)
                return;

            // Заполняю таблицу в соответствие с: https://simpledoc.ru/indeks-massy-tela/#start

            m_bmiImages = new Dictionary<string, Image>{ 
                ["Дефицит массы тела"] = Image.FromFile(@"..\\..\\img\\skelet.jpg"),
                ["Норма"] = Image.FromFile(@"..\\..\\img\\norma.jpg"),
                ["Избыток массы тела"] = Image.FromFile(@"..\\..\\img\\train.jpg"),
                ["Ожирение 1 степени"] = Image.FromFile(@"..\\..\\img\\train.jpg"),
                ["Ожирение 2 степени"] = Image.FromFile(@"..\\..\\img\\train.jpg"),
                ["Ожирение 3 степени"] = Image.FromFile(@"..\\..\\img\\train.jpg"),
                ["Ожирение 4 степени"] = Image.FromFile(@"..\\..\\img\\train.jpg")
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
        private static Dictionary<string, Image> m_bmiImages = null;
    }
}
