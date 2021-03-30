using InstagramRedesignApp.Core;
using System;
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

        private void PostDetailPageSizeChanged(object sender, EventArgs e)
        {
            image.HeightRequest = ImageHeight = DeviceDisplay.MainDisplayInfo.Width / 3d * 4 / density;

            OnPropertyChanged(nameof(ImageHeight));
        }
    }
}