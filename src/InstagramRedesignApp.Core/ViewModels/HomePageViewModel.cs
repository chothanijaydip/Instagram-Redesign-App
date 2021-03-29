using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
    {
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;
        private readonly IAppThemeService appThemeService;
        private IList<Post> posts;
        private IList<User> followedUsers;
        private bool darkTheme;

        public IList<Post> Posts
        {
            get => posts;
            set
            {
                posts = value;
                OnPropertyChanged(nameof(Posts));
            }
        }
        public IList<User> FollowedUsers
        {
            get => followedUsers;
            set
            {
                followedUsers = value;
                OnPropertyChanged(nameof(FollowedUsers));
            }
        }
        public bool DarkTheme
        {
            get => darkTheme;
            set
            {
                darkTheme = value;
                
                if (value)
                    appThemeService.SetAppTheme(AppThemesEnum.Dark);
                else
                    appThemeService.SetAppTheme(AppThemesEnum.Light);
            }
        }


        public HomePageViewModel(IUsersService usersService, IPostsService postsService, IAppThemeService appThemeService)
        {
            this.usersService = usersService;
            this.postsService = postsService;
        }


        public override async Task OnPageCreated(params object[] parameters)
        {
            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
            FollowedUsers = usersService.GetUsersByIds(usersService.CurrentUser.FollowedUsersIds);
            ChangeAppTheme(appThemeService.CurrentAppTheme);
            appThemeService.ThemeChanged += ThemeChanged;

            await base.OnPageCreated(parameters);
        }

        private void ThemeChanged(AppThemesEnum appTheme)
        {
            ChangeAppTheme(appTheme);
        }

        public override void Dispose()
        {
            base.Dispose();

            appThemeService.ThemeChanged -= ThemeChanged;
        }

        private void ChangeAppTheme(AppThemesEnum appTheme)
        {
            DarkTheme = appTheme == AppThemesEnum.Dark;
            OnPropertyChanged(nameof(DarkTheme));
        }
    }
}
