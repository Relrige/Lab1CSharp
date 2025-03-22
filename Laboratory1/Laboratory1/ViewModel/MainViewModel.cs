using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Laboratory1.Helper;
using Laboratory1.Model;

namespace Laboratory1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region fieldsAndProperties
        private Person _person = new Person { DateOfBirth = DateTime.Today };
        private RelayCommand<object> _relayComand;

        public int Age
        {
            get => _person.Age;
            private set
            {
                _person.Age = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                if (_person.DateOfBirth != value)
                {
                    _person.DateOfBirth = value;
                    //DateChanged();
                    OnPropertyChanged();
                }
            }
        }
        public ZodiacSigns WesternZodiac
        {
            get => _person.WesternZodiac;
            private set
            {
                _person.WesternZodiac = value;
                OnPropertyChanged();
            }
        }
        public ChineseZodiacSigns ChineseZodiac
        {
            get => _person.ChineseZodiac;
            private set
            {
                _person.ChineseZodiac = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region calculate
        private void DateChanged()
        {
            Age = DateHelper.CalculateAge(DateOfBirth);
            if (!ValidateAge(Age))
            {
                MessageBox.Show("Invalid age. Please enter a valid date of birth.");
                return;
            }
            if (_person.IsBirthdayToday())
                MessageBox.Show("Happy birthday!");
            WesternZodiac = DateHelper.GetWesternZodiac(DateOfBirth);
            ChineseZodiac = DateHelper.GetChineseZodiac(DateOfBirth);
        }
        private bool ValidateAge(int age)
        {
            return age is >= 0 and < 135;
        }
        #endregion

        public RelayCommand<object> CalculateCommand =>
          _relayComand ??= new RelayCommand<object>(_ => DateChanged());

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}