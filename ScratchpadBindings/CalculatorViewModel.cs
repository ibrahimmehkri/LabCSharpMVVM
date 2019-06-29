using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms; 

namespace ScratchpadBindings
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; set; }
        public ICommand SubtractCommand { get; set; }
        public ICommand DivideCommand { get; set; }
        public ICommand MultiplyCommand { get; set; }
        public ICommand EqualsToCommand { get; set; }
        public ICommand EnterNumberCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand AddCharCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        bool isOpCmdActive = false;
        bool isFirstEntry = true;
        int numberInMemory;
        string currentOp;

        string displayText = "";
        public string DisplayText
        {
            get { return displayText; }
            set
            {
                if(displayText != value)
                {
                    displayText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DisplayText"));
                }
            }
        }

        public CalculatorViewModel()
        {
            ResetCommand = new Command(delegate () {
                DisplayText = "";
                isOpCmdActive = false;
                isFirstEntry = true;
                numberInMemory = default(int);
            });

            AddCharCommand = new Command<string>(delegate (string key) {
                if (isOpCmdActive)
                {
                    numberInMemory = int.Parse(DisplayText);
                    isFirstEntry = false;
                    DisplayText = "";
                    isOpCmdActive = false;
                }
                DisplayText += key;
            });

            AddCommand = new Command(delegate () {
                OperationCmdActive();
                currentOp = "+";
                if (!isFirstEntry)
                {
                    DisplayText = Calculate(numberInMemory, int.Parse(DisplayText), currentOp).ToString();
                }
            });

            SubtractCommand = new Command(delegate () {
                OperationCmdActive();
                currentOp = "-";
                if (!isFirstEntry)
                {
                    DisplayText = Calculate(numberInMemory, int.Parse(DisplayText), currentOp).ToString();
                }
            });

            MultiplyCommand = new Command(delegate () {
                OperationCmdActive();
                currentOp = "*";
                if (!isFirstEntry)
                {
                    DisplayText = Calculate(numberInMemory, int.Parse(DisplayText), currentOp).ToString();
                }
            });

            DivideCommand = new Command(delegate () {
                OperationCmdActive();
                currentOp = "/";
                if (!isFirstEntry)
                {
                    DisplayText = Calculate(numberInMemory, int.Parse(DisplayText), currentOp).ToString();
                }
            });

            EqualsToCommand = new Command(delegate () {
                DisplayText = Calculate(numberInMemory, int.Parse(DisplayText), currentOp).ToString();
                numberInMemory = default(int);
                isFirstEntry = true;
            });
        }

        int Calculate(int x, int y, string operation)
        {
            switch (operation)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
                case "/":
                    return x / y;
                case "*":
                    return x * y;
                default:
                    return -1;
            }
        }

        void OperationCmdActive()
        {
            isOpCmdActive = true;
        }

        
    }
}
