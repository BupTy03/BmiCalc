using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BmiCalculator
{
    public enum Gender
    {
        Male, 
        Female
    }

    /// <summary>
    /// Класс, представляющий человека.
    /// </summary>
    public class Human
    {
        private int _age = 0;
        private int _heightCm = 0;
        private int _weightKg = 0;
        private Gender _gender = Gender.Male;

        public const int MinAge = 0;
        public const int MaxAge = 100;

        public const int MinHeight = 30;
        public const int MaxHeight = 240;

        public const int MinWeight = 2;
        public const int MaxWeight = 250;

        private const int CentimetersInMeter = 100;


        public Human()
        {
        }

        public Human(int age, int heightInCentimeters, int weightInKilograms, Gender gender)
        {
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
                if(!(value >= MinAge && value <= MaxAge))
                {
                    throw new ArgumentException(String.Format("age must be in range[{0};{1}]", MinAge, MaxAge));
                }

                _age = value;
            }
        }

        public int HeightInCentimeters
        {
            get { return _heightCm; }
            set
            {
                if (!(value >= MinHeight && value <= MaxHeight))
                {
                    throw new ArgumentException(String.Format("height must be in range[{0};{1}]", MinHeight, MaxHeight));
                }

                _heightCm = value;
            }
        }

        public double HeightInMeters => _heightCm / (double)CentimetersInMeter;

        public int WeightInKilograms
        {
            get { return _weightKg; }
            set
            {
                if (!(value >= MinWeight && value <= MaxWeight))
                {
                    throw new ArgumentException(String.Format("weight must be in range[{0};{1}]", MinWeight, MaxWeight));
                }

                _weightKg = value;
            }
        }

        public Gender Gender { get; set; }
    }
}
