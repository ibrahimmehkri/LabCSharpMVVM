using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms; 

namespace ScratchpadBindings
{
    public class KeypadViewModel : INotifyPropertyChanged
    {
        public KeypadViewModel()
        {
            AddCharCommand = new Command<string>(delegate (string key) { InputString += key; Debug.WriteLine(key); });

            DeleteCharCommand = new Command(
                delegate ()
                {
                    InputString = InputString.Substring(0, InputString.Length - 1);
                },
                delegate ()
                {
                    return InputString.Length > 0;

                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private char[] specialChars = { '*', '#' };

        string inputString = "";
        public string InputString
        {
            get
            {
                return inputString;
            }
            protected set
            {
                if(inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    DisplayText = FormatText(inputString);

                    Command dltCommand = (Command)DeleteCharCommand;
                    dltCommand.ChangeCanExecute();
                }
            }
        }

        string displayText = "";
        public string DisplayText
        {
            get
            {
                return displayText; 
            }
            protected set
            {
                if(displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
        }

        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(specialChars) != -1;
            string formatted = str;

            if (hasNonNumbers || str.Length < 4 || str.Length > 10)
            {
            }
            else if (str.Length < 8)
            {
                formatted = String.Format("{0}-{1}",
                                          str.Substring(0, 3),
                                          str.Substring(3));
            }
            else
            {
                formatted = String.Format("({0}) {1}-{2}",
                                          str.Substring(0, 3),
                                          str.Substring(3, 3),
                                          str.Substring(6));
            }

            return formatted; 
        }

        public ICommand AddCharCommand { protected set; get; }
        public ICommand DeleteCharCommand { protected set; get; }
        

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
