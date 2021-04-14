using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IUsersService
    {
        IDictionary<string, User> AllUsers { get; }
        User CurrentUser { get; }

        IList<User> GetUsersByIds(IEnumerable<string> userIds);
        IList<Post> AssignUsers(IEnumerable<Post> posts);
        IList<Comment> AssignUsers(IEnumerable<Comment> comments);
        IList<Activity> AssignUsers(IEnumerable<Activity> activities);
    }
}