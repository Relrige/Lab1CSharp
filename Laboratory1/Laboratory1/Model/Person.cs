using Laboratory1.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory1.Model
{
    public class Person
    {
        #region Fields

        private int _age;
        private DateTime _dob = DateTime.Today;
        private ZodiacSigns _zodiac;
        private ChineseZodiacSigns _chineseZodiac;

        #endregion

        #region Properties
        public int Age
        {
            get => _age;
            set => _age = value;
        }
        public DateTime DateOfBirth
        {
            get => _dob;
            set => _dob = value;
        }
        public ZodiacSigns WesternZodiac
        {
            get => _zodiac;
            set => _zodiac = value;
        }
        public ChineseZodiacSigns ChineseZodiac
        {
            get => _chineseZodiac;
            set => _chineseZodiac = value;
        }
        #endregion
        public bool IsBirthdayToday()
        {
            return DateOfBirth.Day == DateTime.Today.Day && DateOfBirth.Month == DateTime.Today.Month;
        }
    }
}
