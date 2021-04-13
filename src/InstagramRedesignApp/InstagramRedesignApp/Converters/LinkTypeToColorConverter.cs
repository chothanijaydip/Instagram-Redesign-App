using InstagramRedesignApp.Core;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class LinkTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LinkTypesEnum linkType = (LinkTypesEnum)value;

            string hexColor = linkType switch
            {
                LinkTypesEnum.Website => "#35009D",
                LinkTypesEnum.Behance => "#0157FF",
                LinkTypesEnum.Dribbble => "#EA4C89",
                LinkTypesEnum.Twitch => "#9147FF",
                LinkTypesEnum.TikTok => "#0B0B12",
                LinkTypesEnum.SnapChat => "#ffffff",
                LinkTypesEnum.Unsplash => "#D7F2FC",
                LinkTypesEnum.Discord => "#7289D9",
                LinkTypesEnum.YouTube => "#ffffff",
                LinkTypesEnum.GitHub => "#0B0B12",
                _ => "",
            };

            return Color.FromHex(hexColor);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
