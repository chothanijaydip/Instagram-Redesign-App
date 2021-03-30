using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentView
    {
        ISettingsViewModel viewModel;

        public SettingsView()
        {
            InitializeComponent();

            BindingContext = viewModel = ((App)App.Current).ServiceProvider.GetRequiredService<ISettingsViewModel>();
            viewModel.OnCreated();
        }

        public async Task Show()
        {
            grid.TranslationY = -grid.HeightRequest;
            await viewModel.OnPageAppearing();

            IsVisible = true;

            await grid.TranslateTo(grid.TranslationX, -30);
        }

        public async Task Hide()
        {
            await viewModel.OnPageDisappearing();

            await grid.TranslateTo(grid.TranslationX, -grid.Height);

            IsVisible = false;
        }

        private void GridSizeChanged(object sender, EventArgs e)
        {
            grid.TranslationY = -grid.HeightRequest;
            frame.Padding = new Thickness(0, StatusBar.Height + 30, 0, 0);
        }

        private async void CloseTapped(object sender, EventArgs e)
        {
            await Hide();
        }
    }
}