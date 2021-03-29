using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public static class StatusBar
    {
        public static double Height
        {
            get
            {
                IStatusBar statusBar = DependencyService.Get<IStatusBar>();
                double height = 0;

                if (statusBar is not null)
                    height = statusBar.GetHeight() / Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

                return height;
            }
        }

        public static Thickness Padding => new Thickness(0, Height, 0, 0);

        public static void SetLightStatusBar(bool light)
        {
            IStatusBar statusBar = DependencyService.Get<IStatusBar>();

            if (statusBar is not null)
                statusBar.SetLightStatusBar(light);
        }
    }
}
