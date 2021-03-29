using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface IHomePageViewModel
    {
        IList<User> FollowedUsers { get; set; }
        IList<Post> Posts { get; set; }

        Task OnPageCreated(params object[] parameters);
    }
}