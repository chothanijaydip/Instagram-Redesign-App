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

            return AssignUsers(posts);
        }

        public IList<Post> AssignUsers(IList<Post> posts)
        {
            foreach (var post in posts)
                post.Author = usersService.AllUsers[post.AuthorId];

            return posts;
        }
    }
}
