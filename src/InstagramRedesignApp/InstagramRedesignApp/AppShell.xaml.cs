using InstagramRedesignApp.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : MySharedTransitionShell
    {
        readonly double homePageCornerRadius = 38;

        public AppShell()
        {
            InitializeComponent();

            overlay.Items.Add(new ShellContent { Route = PagesEnum.HomePage.ToString(), ContentTemplate = new DataTemplate(typeof(HomePage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.SearchPage.ToString(), ContentTemplate = new DataTemplate(typeof(SearchPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.AddPage.ToString(), ContentTemplate = new DataTemplate(typeof(AddPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.ActivityPage.ToString(), ContentTemplate = new DataTemplate(typeof(ActivityPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.ProfilePage.ToString(), ContentTemplate = new DataTemplate(typeof(ProfilePage)) });

            Routing.RegisterRoute(PagesEnum.PostDetailPage.ToString(), typeof(PostDetailPage));

            SizeChanged += AppShellSizeChanged;
        }

        private void AppShellSizeChanged(object sender, EventArgs e)
        {
            homePageCornersPath.Data = new PathGeometry
            {
                Figures = new PathFigureCollection
                {
                    new PathFigure
                    {
                        StartPoint = new Point(0,0), IsClosed = true, IsFilled = true,
                        Segments = new PathSegmentCollection
                        {
                            new LineSegment(new Point(this.Width, 0)),
                            new LineSegment(new Point(this.Width, homePageCornerRadius)),
                            new ArcSegment(new Point(this.Width - homePageCornerRadius, 0), new Size(homePageCornerRadius, homePageCornerRadius), 90, SweepDirection.CounterClockwise, false),
                            new LineSegment(new Point(homePageCornerRadius, 0)),
                            new ArcSegment(new Point(0, homePageCornerRadius), new Size(homePageCornerRadius, homePageCornerRadius), 90, SweepDirection.CounterClockwise, false),
                        }
                    }
                }
            };
        }

        protected override void OnNavigated(ShellNavigatedEventArgs e)
        {
            PagesEnum targetPage = (PagesEnum)Enum.Parse(typeof(PagesEnum), e.Current.Location.OriginalString.Split('/').Last());

            if (targetPage == PagesEnum.PostDetailPage)
                _ = tabBar.TranslateTo(0, tabBar.Height);
            else
                _ = tabBar.TranslateTo(0, 0);

            if (targetPage == PagesEnum.PostDetailPage)
                appBar.ChangeState(AppBarStates.Detail);
            else
                appBar.ChangeState(AppBarStates.Main);

            if (targetPage != PagesEnum.HomePage && targetPage != PagesEnum.PostDetailPage)
                HideHomePageCorners();
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs e)
        {
            base.OnNavigating(e);

            _ = settingsView.Hide();

            switch (e.Source)
            {
                case ShellNavigationSource.Pop:
                case ShellNavigationSource.PopToRoot:
                    Page page = CurrentPage;

                    await Task.Delay(5000);

                    if (page is not null)
                    {
                        if (page.BindingContext is IBaseViewModel viewModel)
                            viewModel.Dispose();

                        page.BindingContext = null;
                    }
                    break;
            }
        }

        public void ShowHomePageCorners()
        {
            homePageCornersPath.IsVisible = true;
        }

        public void HideHomePageCorners()
        {
            homePageCornersPath.IsVisible = false;
        }
    }
}