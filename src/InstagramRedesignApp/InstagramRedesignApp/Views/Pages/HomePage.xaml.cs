using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
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
    }
}
