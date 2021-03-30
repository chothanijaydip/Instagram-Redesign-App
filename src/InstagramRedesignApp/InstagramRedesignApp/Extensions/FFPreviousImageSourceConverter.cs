using FFImageLoading.Forms;
using InstagramRedesignApp.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class FFPreviousImageSourceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string image = "";
            IList<Post> posts = values[0] as IList<Post>;
            Post post = values[1] as Post;

            if (posts is not null && post is not null)
            {
                int index = posts.IndexOf(post);

                if (index - 1 >= 0)
                    image = posts[index - 1].FirstImage;
            }

            return new EmbeddedResourceImageSource("InstagramRedesignApp.Images." + image?.ToString(), typeof(FFPreviousImageSourceConverter).GetTypeInfo().Assembly);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
