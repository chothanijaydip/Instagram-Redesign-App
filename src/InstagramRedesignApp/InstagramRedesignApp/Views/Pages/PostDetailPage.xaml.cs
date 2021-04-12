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
        readonly double commentsGridShowedPosition = 40;
        double lastVelocity;
        IPostDetailPageViewModel viewModel;

        public double ImageHeight { get; set; }


        public PostDetailPage()
        {
            viewModel = this.InitializeViewModel<IPostDetailPageViewModel>(PagesEnum.PostDetailPage);

            InitializeComponent();

            SizeChanged += PostDetailPageSizeChanged;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            AppShell shell = Shell.Current as AppShell;

            shell.TransitionEnded += PostDetailPageTransitionEnded;
            shell.TransitionStarted += PostDetailPageTransitionStarted;
            shell.Navigating += PostDetailPageNavigating;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            AppShell shell = Shell.Current as AppShell;

            shell.TransitionEnded -= PostDetailPageTransitionEnded;
            shell.TransitionStarted -= PostDetailPageTransitionStarted;
            shell.Navigating -= PostDetailPageNavigating;
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
                _ = HideComments(200);

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
            commentsGrid.HeightRequest = this.Height - AppBar.AppBarPadding.VerticalThickness - commentsGridShowedPosition - downArrowGrid.Height + 5;

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
            downArrowGrid.InputTransparent = false;
            await Task.WhenAll(
                commentsGrid.TranslateTo(commentsGrid.X, commentsGridShowedPosition),
                upArrowPath.FadeTo(0),
                downArrowGrid.FadeTo(1)
                );
        }

        private async Task HideComments(uint length = 250)
        {
            commentsOverlayBoxView.InputTransparent = false;
            downArrowGrid.InputTransparent = true;
            await Task.WhenAll(
                commentsGrid.TranslateTo(commentsGrid.X, ImageHeight),
                upArrowPath.FadeTo(1, length),
                downArrowGrid.FadeTo(0, length)
                );
        }

        private async void UpArrowTapped(object sender, EventArgs e)
        {
            await ShowComments();
        }

        private async void DownArrowTapped(object sender, EventArgs e)
        {
            await HideComments();
        }

        private async void UpCommentsPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    lastVelocity = commentsGrid.TranslationY + e.TotalY;
                    await commentsGrid.TranslateTo(0, Math.Min(Math.Max(lastVelocity, commentsGridShowedPosition), ImageHeight), length: 50);
                    break;
                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    if (lastVelocity < ImageHeight  - 40)
                        await ShowComments();
                    else
                        await HideComments();
                    break;
            }
        }

        private async void DownCommentsPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    lastVelocity = e.TotalY;
                    await commentsGrid.TranslateTo(0, Math.Min(Math.Max(lastVelocity, commentsGridShowedPosition), ImageHeight), length: 50);
                    break;
                case GestureStatus.Canceled:
                case GestureStatus.Completed:
                    if (lastVelocity > 40)
                        await HideComments();
                    else
                        await ShowComments();
                    break;
            }
        }
    }
}