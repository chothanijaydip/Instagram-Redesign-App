using InstagramRedesignApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityPage : ContentPage
    {
        IActivityPageViewModel viewModel;

        public ActivityPage()
        {
            viewModel = this.InitializeViewModel<IActivityPageViewModel>(PagesEnum.ActivityPage);

            InitializeComponent();
        }
    }
}