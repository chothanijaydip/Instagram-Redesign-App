using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;

namespace InstagramRedesignApp.Droid
{
    [Activity(Label = "Instagram Redesign", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.Portrait )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
            //Window.SetSoftInputMode(SoftInput.AdjustPan);

            base.OnCreate(savedInstanceState);

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnWindowFocusChanged(bool hasFocus)
        {
            base.OnWindowFocusChanged(hasFocus);
            if (hasFocus)
                HideSoftwareMenuBars();
        }

        public void HideSoftwareMenuBars()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                Window.SetDecorFitsSystemWindows(true);
                Window.InsetsController.Hide(WindowInsets.Type.NavigationBars());
                Window.InsetsController.SystemBarsBehavior = (int)WindowInsetsControllerBehavior.ShowBarsBySwipe;

                return;
            }

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        public void ShowSoftwareMenuBars()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                Window.SetDecorFitsSystemWindows(true);
                Window.InsetsController.Show(WindowInsets.Type.NavigationBars());

                return;
            }

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions &= ~(int)SystemUiFlags.LayoutHideNavigation;
            uiOptions &= ~(int)SystemUiFlags.HideNavigation;
            uiOptions &= ~(int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }
    }
}