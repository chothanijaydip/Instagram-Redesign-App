using System;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    public class PathGeometryExtension : IMarkupExtension<Geometry>
    {
        PathGeometryConverter PathGeometryConverter = new PathGeometryConverter();

        public string Path { get; set; }

        public Geometry ProvideValue(IServiceProvider serviceProvider)
        {
            var path = PathGeometryConverter.ConvertFromInvariantString(Path) as Geometry;

            return path;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Geometry>).ProvideValue(serviceProvider);
        }
    }
}
