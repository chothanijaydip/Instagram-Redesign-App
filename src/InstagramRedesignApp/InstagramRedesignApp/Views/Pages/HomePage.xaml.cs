using InstagramRedesignApp.Core;
using Plugin.SharedTransitions;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public partial class HomePage : ContentPage
    {
        readonly double density = DeviceDisplay.MainDisplayInfo.Density;
        readonly double cornerRadius = 45;
        IHomePageViewModel viewModel;

        public double ImageHeight { get; set; }
        public double PostHeight { get; set; }
        public Thickness PreviousImageMargin { get; set; }

        public HomePage()
        {
            InitializeComponent();

            viewModel = this.InitializeViewModel<IHomePageViewModel>(PagesEnum.HomePage);
            SizeChanged += HomePageSizeChanged;
        }

        private void HomePageSizeChanged(object sender, EventArgs e)
        {
            ImageHeight = DeviceDisplay.MainDisplayInfo.Width / 3d * 4 / density;
            PostHeight = ImageHeight - cornerRadius;
            PreviousImageMargin = new Thickness(0, -PostHeight, 0,0);

            OnPropertyChanged(nameof(ImageHeight));
            OnPropertyChanged(nameof(PostHeight));
            OnPropertyChanged(nameof(PreviousImageMargin));
        }

        private void PostTapped(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;

            if (grid is not null)
            {
                Post post = grid.BindingContext as Post;

                SharedTransitionShell.SetTransitionSelectedGroup(this, post.AuthorId);
            }
        }
    }
}
