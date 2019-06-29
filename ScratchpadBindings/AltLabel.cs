using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ScratchpadBindings
{
    public class AltLabel : Label
    {
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create("PointSize", typeof(double), typeof(AltLabel), 8.0, propertyChanged: OnPointSizePropChanged);

        public double PointSize
        {
            get
            {
                return (double)GetValue(AltLabel.PointSizeProperty);
            }
            set
            {
                SetValue(AltLabel.PointSizeProperty, value);
            }
        }

        public AltLabel()
        {
        }

        static void OnPointSizePropChanged(BindableObject bindable, object oldValue, object newValue)
        {
            AltLabel label = (AltLabel)bindable;
            label.FontSize = 160 * (double)newValue / 72;
        }

    }
}
