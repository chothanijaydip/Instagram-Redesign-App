using InstagramRedesignApp.Core;
using Plugin.SharedTransitions;
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

            tabBar.Items.Add(new ShellContent { Route = PagesEnum.HomePage.ToString(), ContentTemplate = new DataTemplate(typeof(HomePage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.SearchPage.ToString(), ContentTemplate = new DataTemplate(typeof(SearchPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.AddPage.ToString(), ContentTemplate = new DataTemplate(typeof(AddPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.ActivityPage.ToString(), ContentTemplate = new DataTemplate(typeof(ActivityPage)) });
            tabBar.Items.Add(new ShellContent { Route = PagesEnum.ProfilePage.ToString(), ContentTemplate = new DataTemplate(typeof(ProfilePage)) });

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
                        page.BindingContext = null;
                    break;
            }
        }
    }
}