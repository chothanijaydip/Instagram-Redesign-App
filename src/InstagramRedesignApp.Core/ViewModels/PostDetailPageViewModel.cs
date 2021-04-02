using System.Threading.Tasks;
using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public class PostDetailPageViewModel : BaseViewModel, IPostDetailPageViewModel, ILikePostViewModel
    {
        IUsersService usersService;
        Post currentPost;
        bool isLiked;
        User currentUser;

        public Post CurrentPost
        {
            get => currentPost;
            set
            {
                currentPost = value;

                usersService.AssignUsers(CurrentPost.Comments);

                OnPropertyChanged(nameof(CurrentPost));
                OnPropertyChanged(nameof(CurrentPost.FirstImage));
                OnPropertyChanged(nameof(CurrentPost.Comments));
            }
        }
        public User CurrentUser => usersService.CurrentUser;

        public ICommand LikePostCommand { get; private set; }


        public PostDetailPageViewModel(IUsersService usersService, IPostsService postsService)
        {
            this.usersService = usersService;

            LikePostCommand = new RelayCommand(parameter =>
            {
                Post post = parameter as Post;

                postsService.ReverseLikePost(CurrentPost, usersService.CurrentUser);
            });
        }


        public override async Task OnCreated(params object[] parameters)
        {
            CurrentPost = parameters[0] as Post;

            await base.OnCreated(parameters);
        }
    }
}
