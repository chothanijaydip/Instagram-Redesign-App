namespace InstagramRedesignApp.Core
{
    public class Comment
    {
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
    }
}
