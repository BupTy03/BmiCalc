using System;
using System.Runtime.Serialization;


namespace BmiCalculator
{
    public enum HumanGender
    {
        Male,
        Female
    }

    /// <summary>
    /// Класс, представляющий человека.
    /// </summary>
    public class Human
    {
        public const int MinAge = 0;
        public const int MaxAge = 100;

        public const int MinHeight = 30;
        public const int MaxHeight = 240;

        public const int MinWeight = 2;
        public const int MaxWeight = 250;

        private const int CentimetersInMeter = 100;


        private int _age = MinAge;
        private int _heightCm = MinHeight;
        private int _weightKg = MinWeight;
        private HumanGender _gender = HumanGender.Male;


        public Human()
        {
        }

        public Human(int age, int heightInCentimeters, int weightInKilograms, HumanGender gender)
        {
            CheckAge(age);
            CheckHeight(heightInCentimeters);
            CheckWeight(weightInKilograms);

            _age = age;
            _heightCm = heightInCentimeters;
            _weightKg = weightInKilograms;
            _gender = gender;
        }


        public int Age 
        { 
            get { return _age; }
            set
            {
                CheckAge(value);
                _age = value;
            }
        }

        public int HeightInCentimeters
        {
            get { return _heightCm; }
            set
            {
                CheckHeight(value);
                _heightCm = value;
            }
        }

        public int WeightInKilograms
        {
            get { return _weightKg; }
            set
            {
                CheckWeight(value);
                _weightKg = value;
            }
        }

        public HumanGender Gender { get { return _gender; } set { _gender = value; } }

        public double Bmi => WeightInKilograms / Math.Pow(_heightCm / (double)CentimetersInMeter, 2.0);

        public override string ToString()
        {
            return String.Format("Рост: {0} см, Вес: {1} кг, Возраст: {2} лет, Пол: {3}, BMI: {4:f2}",
                HeightInCentimeters,
                WeightInKilograms,
                Age,
                Gender == HumanGender.Male ? "мужской" : "женский",
                Bmi);
        }


        private static void CheckAge(int age)
        {
            if (!(age >= MinAge && age <= MaxAge))
            {
                throw new ArgumentException(String.Format("age must be in range[{0};{1}]", MinAge, MaxAge));
            }
        }

        private static void CheckHeight(int heightCm)
        {
            if (!(heightCm >= MinHeight && heightCm <= MaxHeight))
            {
                throw new ArgumentException(String.Format("height must be in range[{0};{1}]", MinHeight, MaxHeight));
            }
        }

        private static void CheckWeight(int weightKg)
        {
            if (!(weightKg >= MinWeight && weightKg <= MaxWeight))
            {
                throw new ArgumentException(String.Format("weight must be in range[{0};{1}]", MinWeight, MaxWeight));
            }
        }
    }
}
