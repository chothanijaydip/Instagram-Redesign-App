using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public class Post
    {
        public string Image { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public int Likes { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
