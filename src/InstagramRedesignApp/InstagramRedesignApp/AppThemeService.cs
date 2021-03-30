using InstagramRedesignApp.Core;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class AppThemeService : IAppThemeService
    {
        public AppThemesEnum CurrentAppTheme => ConvertOsAppTheme(Application.Current.UserAppTheme);

        public void Initialize()
        {
            SetAppTheme(ConvertOsAppTheme(Application.Current.UserAppTheme));
        }

        public void SetAppTheme(AppThemesEnum appTheme)
        {
            switch (appTheme)
            {
                case AppThemesEnum.Default:
                    Application.Current.UserAppTheme = AppInfo.RequestedTheme == AppTheme.Dark ? OSAppTheme.Dark : OSAppTheme.Light;
                    break;
                case AppThemesEnum.Dark:
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                case AppThemesEnum.Light:
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
            }

            switch(Application.Current.UserAppTheme)
            {
                case OSAppTheme.Light:
                    StatusBar.SetLightStatusBar(true);
                    break;
                case OSAppTheme.Dark:
                    StatusBar.SetLightStatusBar(false);
                    break;
            }
        }

        private AppThemesEnum ConvertOsAppTheme(OSAppTheme osAppTheme)
        {
            AppThemesEnum appThemesEnum = AppThemesEnum.Default;

            switch (osAppTheme)
            {
                case OSAppTheme.Light:
                    appThemesEnum = AppThemesEnum.Light;
                    break;
                case OSAppTheme.Dark:
                    appThemesEnum = AppThemesEnum.Dark;
                    break;
                case OSAppTheme.Unspecified:
                    appThemesEnum = AppThemesEnum.Default;
                    break;
            }

            return appThemesEnum;
        }
    }
}
