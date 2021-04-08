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
        }

        private void ProfilePageSizeChanged(object sender, EventArgs e)
        {
            tabsGridDefaultTranslation = -(Height - headerGrid.Height - tabsGrid.Height - headerGrid.RowSpacing - 4) - verticalOffset;

            ImageHeight = (postsCollectionView.Width - (3 * 4)) / 3d;
            OnPropertyChanged(nameof(ImageHeight));

            tabsGrid.TranslationY = tabsGridDefaultTranslation;
        }

        private void PostsScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            verticalOffset = e.VerticalOffset;

            headerGrid.TranslationY = verticalOffset;
            tabsGrid.TranslationY = tabsGridDefaultTranslation - verticalOffset;
        }
    }
}