using System;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;

namespace ScratchpadBindings
{
    public class CreateAccountViewModel : INotifyPropertyChanged
    {
        string name; 
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    UpdateInfo();
                }
            }
        }

        string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber; 
            }
            set
            {
                if(phoneNumber != value)
                {
                    phoneNumber = value;
                    UpdateInfo();
                }
            }
        }

        string email;
        public string EmailAddress
        {
            get
            {
                return email;
            }
            set
            {
                if(email != value)
                {
                    email = value;
                    UpdateInfo();
                }
            }
        }

        string age; 
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                if(age != value)
                {
                    age = value;
                    UpdateInfo();
                }
            }
        }

        string info;
        public string Info
        {
            get
            {
                return info;
            }
            set
            {
                if(info != value)
                {
                    info = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Info"));
                }
            }
        }

        public CreateAccountViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateInfo()
        {
            Info = $"Name: {Name}\nPhone number: {PhoneNumber}\nEmail address: {EmailAddress}\nAge: {Age}";
        }
    }

    class StringToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
