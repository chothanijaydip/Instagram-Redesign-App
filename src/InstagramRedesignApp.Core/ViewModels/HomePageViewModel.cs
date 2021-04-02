using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public class HomePageViewModel : BaseViewModel, IHomePageViewModel, ILikePostViewModel
    {
        readonly IUsersService usersService;
        readonly IPostsService postsService;
        IList<Post> posts;
        IList<User> followedUsers;
        Post currentPost;

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
        public ICommand LikePostCommand { get; private set; }


        public HomePageViewModel(IUsersService usersService, IPostsService postsService, INavigationService navigationService)
        {
            this.usersService = usersService;
            this.postsService = postsService;

            PostTappedCommand = new RelayCommand(parameter => 
            {
                currentPost = parameter as Post;
                navigationService.PushPageAsync(PagesEnum.PostDetailPage, true, currentPost);
            });
            LikePostCommand = new RelayCommand(parameter =>
            {
                Post post = parameter as Post;
                postsService.ReverseLikePost(post, usersService.CurrentUser);
            });
        }


        public override async Task OnCreated(params object[] parameters)
        {
            Posts = postsService.GetRandomPosts(usersService.CurrentUser.UserId);
            FollowedUsers = usersService.GetUsersByIds(usersService.CurrentUser.FollowedUsersIds);

            await base.OnCreated(parameters);
        }

        public override Task OnPageAppearing()
        {
            if (currentPost is not null)
            {
                var s = currentPost.IsLiked;
                currentPost.IsLiked = !currentPost.IsLiked;
                currentPost.IsLiked = s;
            }
            return base.OnPageAppearing();
        }
    }
}
