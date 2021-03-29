using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            InitializeComponent();

            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            var services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<ICommentsService, CommentsService>();
            services.AddSingleton<IPostsService, PostsService>();
            services.AddSingleton<IAppThemeService, AppThemeService>();
            services.AddTransient<IHomePageViewModel, HomePageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.GetRequiredService<IAppThemeService>().Initialize();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
