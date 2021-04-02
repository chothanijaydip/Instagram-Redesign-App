using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IPostsService
    {
        IList<Post> GetRandomPosts(string currentUserId);
        void ReverseLikePost(Post post, User user);
    }
}