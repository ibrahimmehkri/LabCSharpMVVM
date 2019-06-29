using System;
using System.ComponentModel; 
using Xamarin.Forms;

namespace ScratchpadBindings
{

    class HslViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public HslViewModel()
        {
            Hue = Saturation = Luminosity = 0.5;
        }

        double hue;
        public double Hue
        {
            get
            {
                return hue;
            }
            set
            {
                if(hue != value)
                {
                    hue = value;
                    SetColor();
                    OnPropertyChanged("Hue");
                }
            }
        }

        double saturation;
        public double Saturation
        {
            get
            {
                return saturation;
            }
            set
            {
                if(saturation != value)
                {
                    saturation = value;
                    SetColor();
                    OnPropertyChanged("Saturation"); 
                }
            }
        }

        double luminosity;
        public double Luminosity
        {
            get
            {
                return luminosity;
            }
            set
            {
                if(luminosity != value)
                {
                    luminosity = value;
                    SetColor();
                    OnPropertyChanged("Luminosity");
                }
            }
        }

        Color color;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if(color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        public void SetColor()
        {
            Color = Color.FromHsla(Hue, Saturation, Luminosity); 
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}