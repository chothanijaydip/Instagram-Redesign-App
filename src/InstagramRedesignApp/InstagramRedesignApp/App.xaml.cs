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

            var services = new ServiceCollection();

            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IHomePageViewModel, HomePageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

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
