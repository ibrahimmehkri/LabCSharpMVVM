using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ScratchpadBindings
{
    public class ClockViewModel : INotifyPropertyChanged
    {
        public ClockViewModel()
        {
            DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), UpdateClock);
        }

        DateTime dateTime;
        public DateTime DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                if(dateTime != value)
                {
                    dateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime")); 
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool UpdateClock()
        {
            DateTime = DateTime.Now;
            return true;
        }
    }
}
