using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IPostsService
    {
        IList<Post> GetRandomPosts(string currentUserId);
        IList<Post> AssignUsers(IList<Post> posts);
    }
}