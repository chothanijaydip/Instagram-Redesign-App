using InstagramRedesignApp.Core;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class LinkTypeToGeometryBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LinkTypesEnum linkType = (LinkTypesEnum)value;

            string hexColor = linkType switch
            {
                LinkTypesEnum.SnapChat => "#000000",
                LinkTypesEnum.Unsplash => "#000000",
                LinkTypesEnum.YouTube => "#000000",
                _ => "#ffffff",
            };

            return new SolidColorBrush(Color.FromHex(hexColor));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
