using FFImageLoading.Forms;
using InstagramRedesignApp.Core;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class LinkTypeToFFImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LinkTypesEnum linkType = (LinkTypesEnum)value;

            string imageName = linkType switch
            {
                LinkTypesEnum.Website => "website.png",
                LinkTypesEnum.Behance => "behance.png",
                LinkTypesEnum.Dribbble => "dribbble.png",
                LinkTypesEnum.Twitch => "twitch.png",
                LinkTypesEnum.TikTok => "tiktok.png",
                LinkTypesEnum.SnapChat => "snapchat.png",
                LinkTypesEnum.Unsplash => "unsplash.png",
                LinkTypesEnum.Discord => "discord.png",
                LinkTypesEnum.YouTube => "youtube.png",
                LinkTypesEnum.GitHub => "github.png",
                _ => "",
            };

            return new EmbeddedResourceImageSource("InstagramRedesignApp.Images.Links." + imageName, typeof(LinkTypeToFFImageSourceConverter).Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
