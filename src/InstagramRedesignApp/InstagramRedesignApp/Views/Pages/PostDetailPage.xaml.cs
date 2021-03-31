using InstagramRedesignApp.Core;
using Plugin.SharedTransitions;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        readonly double density = DeviceDisplay.MainDisplayInfo.Density;

        public double ImageHeight { get; set; }


        public PostDetailPage()
        {
            InitializeComponent();

            this.InitializeViewModel<IPostDetailPageViewModel>(PagesEnum.PostDetailPage);

            SizeChanged += PostDetailPageSizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            carouselView.Opacity = 0;
            image.Opacity = 1;
            (Shell.Current as AppShell).TransitionEnded += PostDetailPageTransitionEnded;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            carouselView.Opacity = 0;
            image.Opacity = 1;
            (Shell.Current as AppShell).TransitionEnded -= PostDetailPageTransitionEnded;
        }

        private async void PostDetailPageTransitionEnded(object sender, SharedTransitionEventArgs e)
        {
            carouselView.Opacity = 1;
            await Task.Delay(200);
            image.Opacity = 0;
        }

        private void PostDetailPageSizeChanged(object sender, EventArgs e)
        {
            carouselView.HeightRequest = ImageHeight = DeviceDisplay.MainDisplayInfo.Width / 3d * 4 / density;

            OnPropertyChanged(nameof(ImageHeight));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopToRootAsync();
        }
    }
}