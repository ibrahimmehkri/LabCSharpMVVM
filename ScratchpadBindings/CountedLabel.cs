using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ScratchpadBindings
{
    public class CountedLabel : Label
    {
        static readonly BindablePropertyKey WordCountKey = BindableProperty.CreateReadOnly("WordCount", typeof(int), typeof(CountedLabel), 0);
        public static readonly BindableProperty WordCountProperty = WordCountKey.BindableProperty; 
        public int WordCount
        {
            get
            {
                return (int)GetValue(CountedLabel.WordCountProperty);
            }
            private set
            {
                SetValue(WordCountKey, value);
            }
        }

        public CountedLabel()
        {
            Debug.WriteLine("Hello World");

            PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                if(e.PropertyName == "Text")
                {
                    if (!string.IsNullOrEmpty(Text))
                    {
                        WordCount = Text.Length;
                        Debug.WriteLine("Word count value: " + WordCount);
                    }
                    Debug.WriteLine("Prop changed: " + e.PropertyName); 
                }
            };

        }

    }
}
