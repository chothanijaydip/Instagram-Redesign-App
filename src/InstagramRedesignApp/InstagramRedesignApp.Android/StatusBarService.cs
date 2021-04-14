using Android.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(InstagramRedesignApp.Droid.StatusBarService))]
namespace InstagramRedesignApp.Droid
{
    public class StatusBarService : IStatusBar
    {
        Window window => Platform.CurrentActivity.Window;

        public int GetHeight()
        {
            int statusBarHeight = -1;
            int resourceId = Platform.CurrentActivity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = Platform.CurrentActivity.Resources.GetDimensionPixelSize(resourceId);
            }
            return statusBarHeight;
        }

        public void SetFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                (Platform.CurrentActivity as MainActivity)?.HideSoftwareMenuBars();
                window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            }
            else
            {
                window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                (Platform.CurrentActivity as MainActivity)?.ShowSoftwareMenuBars();
                window.AddFlags(WindowManagerFlags.TranslucentStatus);
                window.ClearFlags(WindowManagerFlags.LayoutNoLimits);
            }
        }

        public void SetLightStatusBar(bool light)
        {
            int uiOptions = (int)window.DecorView.SystemUiVisibility;

            if (light)
                uiOptions |= (int)SystemUiFlags.LightStatusBar;
            else
                uiOptions &= ~(int)SystemUiFlags.LightStatusBar;

            window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}