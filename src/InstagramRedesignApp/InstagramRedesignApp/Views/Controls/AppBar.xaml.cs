using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppBar : ContentView
    {
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
    }
}