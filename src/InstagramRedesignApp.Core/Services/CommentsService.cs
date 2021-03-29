using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public class CommentsService : ICommentsService
    {
        IUsersService usersService;

        public CommentsService(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IList<Comment> AssignUsers(IList<Comment> comments)
        {
            foreach (var comment in comments)
                comment.Author = usersService.AllUsers[comment.AuthorId];

            return comments;
        }
    }
}
