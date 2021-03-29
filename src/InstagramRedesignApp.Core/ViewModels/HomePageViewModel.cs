using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
    {
        private readonly IUsersService usersService;
        private readonly IPostsService postsService;
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

            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
        }

        public override async Task OnPageCreated(params object[] parameters)
        {
            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
            FollowedUsers = usersService.GetUsersByIds(usersService.CurrentUser.FollowedUsersIds);

            await base.OnPageCreated(parameters);
        }
    }
}
