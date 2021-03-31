using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [ContentProperty(nameof(Value))]
    public class ToNativeUnitsExtension : IMarkupExtension
    {
        static double density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

        public double Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value * density;
        }
    }
}
