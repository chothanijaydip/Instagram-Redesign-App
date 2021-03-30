using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class SettingsViewModel : BaseViewModel, ISettingsViewModel
    {
        private bool darkTheme;
        private readonly IAppThemeService appThemeService;

        public bool DarkTheme
        {
            get => darkTheme;
            set
            {
                darkTheme = value;

                if (value)
                    appThemeService.SetAppTheme(AppThemesEnum.Dark);
                else
                    appThemeService.SetAppTheme(AppThemesEnum.Light);
            }
        }


        public SettingsViewModel(IAppThemeService appThemeService)
        {
            this.appThemeService = appThemeService;
        }


        public override async Task OnPageAppearing()
        {
            UpdateAppTheme(appThemeService.CurrentAppTheme);
            await base.OnPageAppearing();
        }

        private void UpdateAppTheme(AppThemesEnum appTheme)
        {
            DarkTheme = appTheme == AppThemesEnum.Dark;
            OnPropertyChanged(nameof(DarkTheme));
        }
    }
}
