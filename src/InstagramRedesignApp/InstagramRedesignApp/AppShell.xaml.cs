using InstagramRedesignApp.Core;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : MySharedTransitionShell
    {
        public AppShell()
        {
            InitializeComponent();

            overlay.Items.Add(new ShellContent { Route = PagesEnum.HomePage.ToString(), ContentTemplate = new DataTemplate(typeof(HomePage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.SearchPage.ToString(), ContentTemplate = new DataTemplate(typeof(SearchPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.AddPage.ToString(), ContentTemplate = new DataTemplate(typeof(AddPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.ActivityPage.ToString(), ContentTemplate = new DataTemplate(typeof(ActivityPage)) });
            overlay.Items.Add(new ShellContent { Route = PagesEnum.ProfilePage.ToString(), ContentTemplate = new DataTemplate(typeof(ProfilePage)) });

            Routing.RegisterRoute(PagesEnum.ImageDetailPage.ToString(), typeof(ImageDetailPage));
        }

        protected override async void OnNavigating(ShellNavigatingEventArgs e)
        {
            base.OnNavigating(e);

            switch (e.Source)
            {
                case ShellNavigationSource.Pop:
                case ShellNavigationSource.PopToRoot:
                    Page page = Shell.Current.CurrentPage;

                    await Task.Delay(5000);

                    if (page is not null)
                    {
                        if (page.BindingContext is IBasePageViewModel viewModel)
                            viewModel.Dispose();

                        page.BindingContext = null;
                    }
                    break;
            }
        }
    }
}