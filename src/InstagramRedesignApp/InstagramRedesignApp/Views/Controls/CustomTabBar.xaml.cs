using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTabBar : ContentView
    {
        INavigationService navigationService;

        public CustomTabBar()
        {
            InitializeComponent();

            navigationService = ((App)App.Current).ServiceProvider.GetRequiredService<INavigationService>();

            VisualStateManager.GoToState(homePath, "Selected");
        }

        private void HomeTapped(object sender, EventArgs e)
        {
            navigationService.PushPageAsync(PagesEnum.HomePage, false);
            UnselectAllTabs();
            VisualStateManager.GoToState(homePath, "Selected");
        }
        private void SearchTapped(object sender, EventArgs e)
        {
            navigationService.PushPageAsync(PagesEnum.SearchPage, false);
            UnselectAllTabs();
            VisualStateManager.GoToState(searchPath, "Selected");
        }
        private void AddTapped(object sender, EventArgs e)
        {
            navigationService.PushPageAsync(PagesEnum.AddPage, false);
            UnselectAllTabs();
            VisualStateManager.GoToState(addPath, "Selected");
        }
        private void ActivityTapped(object sender, EventArgs e)
        {
            navigationService.PushPageAsync(PagesEnum.ActivityPage, false);
            UnselectAllTabs();
            VisualStateManager.GoToState(activityPath, "Selected");
        }
        private void ProfileTapped(object sender, EventArgs e)
        {
            navigationService.PushPageAsync(PagesEnum.ProfilePage, false);
            UnselectAllTabs();
            VisualStateManager.GoToState(profilepath, "Selected");
        }

        private void UnselectAllTabs()
        {
            VisualStateManager.GoToState(homePath, "Normal"); 
            VisualStateManager.GoToState(searchPath, "Normal"); 
            VisualStateManager.GoToState(addPath, "Normal");
            VisualStateManager.GoToState(activityPath, "Normal");
            VisualStateManager.GoToState(profilepath, "Normal");
        }
    }
}