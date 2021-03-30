using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class HomePageViewModel : BaseViewModel, IHomePageViewModel
    {
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;
        private readonly IAppThemeService appThemeService;
        private IList<Post> posts;
        private IList<User> followedUsers;

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
        

        public HomePageViewModel(IUsersService usersService, IPostsService postsService)
        {
            this.usersService = usersService;
            this.postsService = postsService;
        }


        public override async Task OnCreated(params object[] parameters)
        {
            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
            FollowedUsers = usersService.GetUsersByIds(usersService.CurrentUser.FollowedUsersIds);

            await base.OnCreated(parameters);
        }
    }
}
