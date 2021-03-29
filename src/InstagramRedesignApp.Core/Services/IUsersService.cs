using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IUsersService
    {
        IDictionary<string, User> AllUsers { get; }
        User CurrentUser { get; }

        IList<User> GetUsersByIds(IEnumerable<string> userIds);
    }
}