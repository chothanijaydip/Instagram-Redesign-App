using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InstagramRedesignApp;

namespace InstagramRedesignApp.Droid
{
    public class StatusBar : IStatusBar
    {
        public int GetHeight()
        {
            int statusBarHeight = -1;
            int resourceId = Xamarin.Essentials.Platform.CurrentActivity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                statusBarHeight = Xamarin.Essentials.Platform.CurrentActivity.Resources.GetDimensionPixelSize(resourceId);
            }
            return statusBarHeight;
        }

        public void SetLightStatusBar(bool light)
        {
            int uiOptions = (int)Xamarin.Essentials.Platform.CurrentActivity.Window.DecorView.SystemUiVisibility;

            if (light)
                uiOptions |= (int)SystemUiFlags.LightStatusBar;
            else
                uiOptions &= ~(int)SystemUiFlags.LightStatusBar;

            Xamarin.Essentials.Platform.CurrentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}