using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public class HomePageViewModel : BaseViewModel, IHomePageViewModel
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
        
        public ICommand PostTappedCommand { get; private set; }


        public HomePageViewModel(IUsersService usersService, IPostsService postsService, INavigationService navigationService)
        {
            this.usersService = usersService;
            this.postsService = postsService;

            PostTappedCommand = new RelayCommand(parameter => navigationService.PushPageAsync(PagesEnum.PostDetailPage, true, parameter));
        }


        public override async Task OnCreated(params object[] parameters)
        {
            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
            FollowedUsers = usersService.GetUsersByIds(usersService.CurrentUser.FollowedUsersIds);

            await base.OnCreated(parameters);
        }
    }
}
