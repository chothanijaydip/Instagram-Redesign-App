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
        IHomePageViewModel viewModel;
        double lastScrollPosition = 0;

        public double ImageHeight { get; set; }

        public HomePage()
        {
            InitializeComponent();

            viewModel = this.InitializeViewModel<IHomePageViewModel>(PagesEnum.HomePage);
            SizeChanged += HomePageSizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnPageAppearing();

            AppShell shell = Shell.Current as AppShell;

            if (lastScrollPosition > headerCollecionView.Height)
                shell.ShowHomePageCorners();
            else
                shell.HideHomePageCorners();
        }

        private void HomePageSizeChanged(object sender, EventArgs e)
        {
            ImageHeight = DeviceDisplay.MainDisplayInfo.Width / 3d * 4 / density;

            OnPropertyChanged(nameof(ImageHeight));
        }

        private void PostTapped(object sender, EventArgs e)
        {
            Grid grid = sender as Grid;

            if (grid is not null)
            {
                Post post = grid.BindingContext as Post;

                if(post is not null)
                    SharedTransitionShell.SetTransitionSelectedGroup(this, post.AuthorId);
            }
        }

        private void CollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            lastScrollPosition = e.VerticalOffset;

            AppShell shell = Shell.Current as AppShell;

            if (lastScrollPosition > headerCollecionView.Height)
                shell.ShowHomePageCorners();
            else
                shell.HideHomePageCorners();
        }

        private async void LikeTapped(object sender, EventArgs e)
        {
            Grid mainGrid = sender as Grid;

            HeartView heartView = mainGrid.FindView<HeartView>();

            if (heartView is not null)
                await heartView.ShowHeart();
        }
    }
}
