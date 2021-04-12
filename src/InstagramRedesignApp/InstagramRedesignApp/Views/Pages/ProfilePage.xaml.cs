using InstagramRedesignApp.Core;
using System;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        readonly double headerGridHeight = 350;
        int oldPosition = 0;
        double tabsGridDefaultTranslation;
        double verticalOffset = 0;
        IProfilePageViewModel viewModel;

        public double ImageHeight { get; set; }

        public ProfilePage()
        {
            viewModel = this.InitializeViewModel<IProfilePageViewModel>(PagesEnum.ProfilePage);

            InitializeComponent();

            tabView.SizeChanged += ProfilePageSizeChanged;
            VisualStateManager.GoToState(postsPath, "Selected");
        }

        private void ProfilePageSizeChanged(object sender, EventArgs e)
        {
            tabsGridDefaultTranslation = -(tabView.Height - headerGridHeight - 2) - verticalOffset;

            ImageHeight = (tabView.Width - (3 * 4)) / 3d;
            OnPropertyChanged(nameof(ImageHeight));

            tabsGrid.TranslationY = tabsGridDefaultTranslation;
        }

        private void PostsScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            verticalOffset = e.VerticalOffset;

            tabsGrid.TranslationY = tabsGridDefaultTranslation - verticalOffset;
            headerFrame.HeightRequest = headerGridHeight - verticalOffset;
        }

        private void PostsTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Posts;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(postsPath, "Selected");
        }

        private void ClipTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Clips;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(clipPath, "Selected");
        }

        private void TvTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Tv;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(tvPath, "Selected");
        }

        private void UserTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Users;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(userPath, "Selected");
        }

        private void LinkTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Links;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(linkPath, "Selected");
        }

        private void BookmarkTapped(object sender, EventArgs e)
        {
            tabView.SelectedIndex = (int)TabsEnum.Bookmarks;
            _ = TabViewSelectionChangedAsync(tabView.SelectedIndex);

            ResetAllTabs();
            VisualStateManager.GoToState(bookmarkPath, "Selected");
        }

        private void ResetAllTabs()
        {
            VisualStateManager.GoToState(postsPath, "Normal");
            VisualStateManager.GoToState(clipPath, "Normal");
            VisualStateManager.GoToState(tvPath, "Normal");
            VisualStateManager.GoToState(userPath, "Normal");
            VisualStateManager.GoToState(linkPath, "Normal");
            VisualStateManager.GoToState(bookmarkPath, "Normal");
        }

        private async void TabViewSelectionChanged(object sender, TabSelectionChangedEventArgs e)
        {
            await TabViewSelectionChangedAsync(e.NewPosition);
        }

        private async Task TabViewSelectionChangedAsync(int newPosition)
        {
            if (tabView.TabItems[newPosition].Content is LazyView<ProfilePostsView> newProfilePostsLazyView)
            {
                var collectionView = newProfilePostsLazyView.Content.FindByName<CollectionView>("collectionView");
                collectionView.Scrolled -= PostsScrolled;
                collectionView.Scrolled += PostsScrolled;
            }

            if (newPosition != (int)TabsEnum.Posts && tabView.TabItems[oldPosition].Content is LazyView<ProfilePostsView> oldProfilePostsLazyView)
            {
                var collectionView = oldProfilePostsLazyView.Content.FindByName<CollectionView>("collectionView");
                collectionView.Scrolled -= PostsScrolled;
                collectionView.ScrollTo(0);

                Animation animation = new Animation();

                animation.Add(0, 1, new Animation(v => headerFrame.HeightRequest = v, headerFrame.Height, headerGridHeight));
                animation.Add(0, 1, new Animation(v => tabsGrid.TranslationY = v, tabsGrid.TranslationY, tabsGridDefaultTranslation));

                animation.Commit(this, "Animation");

                await Task.Delay(250);
            }

            oldPosition = newPosition;
        }
    }

    public enum TabsEnum
    {
        Posts, Clips, Tv, Users, Links, Bookmarks
    }
}