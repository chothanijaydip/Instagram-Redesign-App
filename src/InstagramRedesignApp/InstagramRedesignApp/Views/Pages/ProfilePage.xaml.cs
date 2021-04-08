using InstagramRedesignApp.Core;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        double tabsGridDefaultTranslation;
        double verticalOffset = 0;
        IProfilePageViewModel viewModel;

        public double ImageHeight { get; set; }

        public ProfilePage()
        {
            InitializeComponent();

            viewModel = this.InitializeViewModel<IProfilePageViewModel>(PagesEnum.ProfilePage);

            headerGrid.SizeChanged += ProfilePageSizeChanged;
            VisualStateManager.GoToState(postsPath, "Selected");
        }

        private void ProfilePageSizeChanged(object sender, EventArgs e)
        {
            tabsGridDefaultTranslation = -(mainCollectionView.Height - headerGrid.Height - 2) - verticalOffset;

            ImageHeight = (mainCollectionView.Width - (3 * 4)) / 3d;
            OnPropertyChanged(nameof(ImageHeight));

            tabsGrid.TranslationY = tabsGridDefaultTranslation;
        }

        private void PostsScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            verticalOffset = e.VerticalOffset;

            headerGrid.TranslationY = verticalOffset;
            tabsGrid.TranslationY = tabsGridDefaultTranslation - verticalOffset;
        }

        private void PostsTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(postsPath, "Selected");
        }

        private void ClipTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(clipPath, "Selected");
        }

        private void TvTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(tvPath, "Selected");
        }

        private void UserTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(userPath, "Selected");
        }

        private void LinkTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(linkPath, "Selected");
        }

        private void BookmarkTapped(object sender, EventArgs e)
        {
            ResetAllTabs();
            VisualStateManager.GoToState(bookmarkPath, "Selected");
        }

        private void ResetAllTabs()
        {
            mainCollectionView.ScrollTo(0);

            VisualStateManager.GoToState(postsPath, "Normal");
            VisualStateManager.GoToState(clipPath, "Normal");
            VisualStateManager.GoToState(tvPath, "Normal");
            VisualStateManager.GoToState(userPath, "Normal");
            VisualStateManager.GoToState(linkPath, "Normal");
            VisualStateManager.GoToState(bookmarkPath, "Normal");
        }
    }
}