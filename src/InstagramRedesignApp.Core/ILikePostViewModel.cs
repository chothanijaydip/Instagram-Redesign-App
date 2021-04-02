using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public interface ILikePostViewModel
    {
        ICommand LikePostCommand { get; }
    }
}
