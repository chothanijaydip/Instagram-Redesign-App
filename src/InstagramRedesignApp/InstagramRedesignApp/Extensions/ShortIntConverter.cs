using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class ShortIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strNumber = value.ToString();
            string shortNumber = strNumber;

            if (strNumber.Length > 3 && strNumber.Length < 7)
            {
                shortNumber = string.Concat(strNumber.Take(strNumber.Length - 2));
                shortNumber = shortNumber.Insert(shortNumber.Length - 1, ",");
                shortNumber += "k";
            }
            else if (strNumber.Length > 6)
            {
                shortNumber = string.Concat(strNumber.Take(strNumber.Length - 5));
                shortNumber = shortNumber.Insert(shortNumber.Length - 1, ",");
                shortNumber += "m";
            }

            return shortNumber;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
