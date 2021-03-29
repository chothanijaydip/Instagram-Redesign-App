using System;

namespace InstagramRedesignApp.Core
{
    public interface IAppThemeService
    {
        AppThemesEnum CurrentAppTheme { get; }

        void SetAppTheme(AppThemesEnum appTheme);
        void Initialize();

        event Action<AppThemesEnum> ThemeChanged;
    }
}
