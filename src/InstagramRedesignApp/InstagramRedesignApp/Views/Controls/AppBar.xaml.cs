using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppBar : ContentView
    {
        public static Thickness AppBarPadding => new Thickness(0, StatusBar.Height + 50, 0, 0);

        public AppBar()
        {
            InitializeComponent();
        }

        private void SettingsTapped(object sender, EventArgs e)
        {
            if(Shell.Current.CurrentItem is ShellOverlay overlay)
            {
                var settingsView = (overlay.Content as Grid)?.FindView<SettingsView>();

                if (settingsView is not null)
                    _ = settingsView.Show();
            }
        }

        private void BackTapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        public void ChangeState(AppBarStates appBarState)
        {
            IsVisible = true;

            switch (appBarState)
            {
                case AppBarStates.Main:
                    settingsBoxView.IsVisible = true;
                    settingsPath.IsVisible = true;
                    messagesPath.IsVisible = true;
                    backPath.IsVisible = false;
                    backBoxView.IsVisible = false;
                    break;
                case AppBarStates.Detail:
                    settingsBoxView.IsVisible = false;
                    settingsPath.IsVisible = false;
                    messagesPath.IsVisible = false;
                    backPath.IsVisible = true;
                    backBoxView.IsVisible = true;
                    break;
                case AppBarStates.Hidden:
                    IsVisible = false;
                    break;
            }
        }
    }
}