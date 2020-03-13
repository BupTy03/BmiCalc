﻿using System;
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
    [Serializable]
    public class Human : ISerializable
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


        protected Human(SerializationInfo info, StreamingContext context)
        {
            Age = info.GetInt32(nameof(Age));
            HeightInCentimeters = info.GetInt32(nameof(HeightInCentimeters));
            WeightInKilograms = info.GetInt32(nameof(WeightInKilograms));
            Gender = (HumanGender)info.GetValue(nameof(Gender), typeof(HumanGender));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Age), Age);
            info.AddValue(nameof(HeightInCentimeters), HeightInCentimeters);
            info.AddValue(nameof(WeightInKilograms), WeightInKilograms);
            info.AddValue(nameof(Gender), Gender);
            info.AddValue(nameof(Bmi), Bmi);
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

        public double HeightInMeters => _heightCm / (double)CentimetersInMeter;

        public int WeightInKilograms
        {
            get { return _weightKg; }
            set
            {
                CheckWeight(value);
                _weightKg = value;
            }
        }

        public HumanGender Gender { get; set; }

        public double Bmi => WeightInKilograms / Math.Pow(HeightInMeters, 2.0);

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
