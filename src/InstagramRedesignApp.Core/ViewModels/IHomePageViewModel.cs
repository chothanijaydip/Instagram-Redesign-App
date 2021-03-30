using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IHomePageViewModel : IBaseViewModel
    {
        IList<User> FollowedUsers { get; set; }
        IList<Post> Posts { get; set; }
    }
}