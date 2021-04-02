using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public class PostsService : IPostsService
    {
        IUsersService usersService;

        public PostsService(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public void ReverseLikePost(Post post, User user)
        {
            post.IsLiked = !post.IsLiked;

            if (post.IsLiked)
            {
                if (!post.LikeUserIds.Contains(user.UserId))
                    post.LikeUserIds.Add(user.UserId);
                if (!user.LikedPostsIds.Contains(post.PostId))
                    user.LikedPostsIds.Add(post.PostId);
            }
            else
            {
                post.LikeUserIds.Remove(user.UserId);
                user.LikedPostsIds.Remove(post.PostId);
            }
        }

        public IList<Post> GetRandomPosts(string currentUserId)
        {
            IList<Post> posts = new List<Post>();
            var users = usersService.AllUsers;

            foreach (var user in users)
            {
                if (user.Key != currentUserId)
                {
                    foreach (var post in user.Value.Posts)
                        posts.Add(post);
                }
            }

            return usersService.AssignUsers(posts);
        }
    }
}
