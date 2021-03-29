using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarView : ContentView
    {
        INavigationService navigationService;

        public TabBarView()
        {
            InitializeComponent();

            navigationService = ((App)App.Current).ServiceProvider.GetRequiredService<INavigationService>();
        }
    }
}