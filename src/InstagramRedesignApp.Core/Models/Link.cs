namespace InstagramRedesignApp.Core
{
    public class Link
    {
        public LinkTypesEnum LinkType { get; set; }
        public string Url { get; set; }
    }

    public enum LinkTypesEnum
    {
        Website, Behance, Dribbble, Twitch, TikTok, SnapChat, Unsplash, Discord, YouTube, GitHub
    }
}
