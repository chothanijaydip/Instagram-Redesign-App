using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class CollectionToLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection enumerable = value as ICollection;

            return enumerable.Count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
