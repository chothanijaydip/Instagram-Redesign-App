using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class PostDetailPageViewModel : BaseViewModel, IPostDetailPageViewModel
    {
        private Post currentPost;

        public Post CurrentPost
        {
            get => currentPost;
            set
            {
                currentPost = value;
                OnPropertyChanged(nameof(CurrentPost));
            }
        }

        public override async Task OnCreated(params object[] parameters)
        {
            CurrentPost = parameters[0] as Post;

            OnPropertyChanged(nameof(CurrentPost.FirstImage));

            await base.OnCreated(parameters);
        }
    }
}
