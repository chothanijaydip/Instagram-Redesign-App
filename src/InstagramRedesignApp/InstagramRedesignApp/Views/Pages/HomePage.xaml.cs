using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IHomePageViewModel>();
        }

        private void LightClicked(object sender, EventArgs e)
        {
            Application.Current.UserAppTheme = OSAppTheme.Light;
        }

        private void DarkClicked(object sender, EventArgs e)
        {
            Application.Current.UserAppTheme = OSAppTheme.Dark;
        }
    }
}
