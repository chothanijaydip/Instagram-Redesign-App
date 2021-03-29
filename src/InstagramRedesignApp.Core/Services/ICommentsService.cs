using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface ICommentsService
    {
        IList<Comment> AssignUsers(IList<Comment> comments);
    }
}