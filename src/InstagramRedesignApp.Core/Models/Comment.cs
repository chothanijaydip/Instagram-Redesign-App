namespace InstagramRedesignApp.Core
{
    public class Comment
    {
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public User Author { get; set; }
    }
}
