using InstagramRedesignApp.Core;
using Plugin.SharedTransitions;
using System;
using System.Linq;
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
        IPostDetailPageViewModel viewModel;
        double lastVelocity;

        public double ImageHeight { get; set; }


        public PostDetailPage()
        {
            InitializeComponent();

            viewModel = this.InitializeViewModel<IPostDetailPageViewModel>(PagesEnum.PostDetailPage);

            SizeChanged += PostDetailPageSizeChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AppShell shell = Shell.Current as AppShell;

            shell.TransitionEnded += PostDetailPageTransitionEnded;
            shell.TransitionStarted += PostDetailPageTransitionStarted;
            shell.Navigating += PostDetailPageNavigating; ;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            AppShell shell = Shell.Current as AppShell;

            shell.TransitionEnded -= PostDetailPageTransitionEnded;
            shell.TransitionStarted -= PostDetailPageTransitionStarted;
            shell.Navigating -= PostDetailPageNavigating; ;
        }

        private void PostDetailPageTransitionStarted(object sender, SharedTransitionEventArgs e)
        {
            if (e.PageTo is PostDetailPage)
            {
                carouselView.Opacity = 0;
                image.Opacity = 1;
            }
        }

        private async void PostDetailPageTransitionEnded(object sender, SharedTransitionEventArgs e)
        {
            carouselView.Opacity = 1;
            await Task.Delay(400);
            image.Opacity = 0;
        }

        private async void PostDetailPageNavigating(object sender, ShellNavigatingEventArgs e)
        {
            if (e.Current is null)
                return;

            PagesEnum currentPage = (PagesEnum)Enum.Parse(typeof(PagesEnum), e.Current.Location.OriginalString.Split('/').Last());

            if (currentPage == PagesEnum.PostDetailPage)
            {
                var deferral = e.GetDeferral();

                carouselView.ScrollTo(0);

                await Task.Delay(200);

                deferral.Complete();

                carouselView.Opacity = 0;
                image.Opacity = 1;
            }
        }

        private void PostDetailPageSizeChanged(object sender, EventArgs e)
        {
            carouselView.HeightRequest = ImageHeight = DeviceDisplay.MainDisplayInfo.Width / 3d * 4 / density;
            _ = HideComments();
            commentsGrid.HeightRequest = this.Height - AppBar.AppBarPadding.VerticalThickness;

            OnPropertyChanged(nameof(ImageHeight));
        }

        private void CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            int index = Array.IndexOf(viewModel.CurrentPost.Images, e.CurrentItem);
            indicatorView.MoveTo(index);
        }

        private async Task ShowComments()
        {
            commentsOverlayBoxView.InputTransparent = true;
            await commentsGrid.TranslateTo(commentsGrid.X, 0);
        }

        private async Task HideComments()
        {
            commentsOverlayBoxView.InputTransparent = false;
            await commentsGrid.TranslateTo(commentsGrid.X, ImageHeight);
        }

        private async void ArrowTapped(object sender, EventArgs e)
        {
            await ShowComments();
        }

        private async void CommentsPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    lastVelocity = e.TotalY;
                    System.Diagnostics.Debug.WriteLine(e.TotalY);
                    await commentsGrid.TranslateTo(0, Math.Min(Math.Max(commentsGrid.TranslationY + lastVelocity, 0), ImageHeight), length: 50);
                    break;
                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    if (lastVelocity < -20)
                        await ShowComments();
                    else
                        await HideComments();
                    break;
            }
        }
    }
}