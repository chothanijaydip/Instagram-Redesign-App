using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public class Post
    {
        public string[] Images { get; set; }
        public string FirstImage => Images[0];
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public int Likes { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
