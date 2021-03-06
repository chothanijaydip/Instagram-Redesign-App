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
            services.AddSingleton<IActivitiesService, ActivitiesService>();
            services.AddSingleton<IAppThemeService, AppThemeService>();
            services.AddSingleton<IBrowser, Browser>();
            services.AddTransient<ISettingsViewModel, SettingsViewModel>();
            services.AddTransient<IHomePageViewModel, HomePageViewModel>();
            services.AddTransient<IPostDetailPageViewModel, PostDetailPageViewModel>();
            services.AddTransient<IProfilePageViewModel, ProfilePageViewModel>();
            services.AddTransient<IActivityPageViewModel, ActivityPageViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            ServiceProvider.GetRequiredService<IAppThemeService>().Initialize();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            if (Shell.Current.CurrentPage is PostDetailPage postDetailPage)
                postDetailPage.UnfocuseEntry();
        }

        protected override void OnResume()
        {
        }
    }
}
