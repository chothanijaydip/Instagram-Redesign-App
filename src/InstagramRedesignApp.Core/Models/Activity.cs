namespace InstagramRedesignApp.Core
{
    public abstract class Activity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public ActivityTypeEnum ActivityType { get; protected set; }
    }

    public class FollowActivity : Activity
    {
        public FollowActivity()
        {
            ActivityType = ActivityTypeEnum.Follow;
        }
    }

    public class CommentActivity : Activity
    {
        public string PostId { get; set; }
        public string CommentId { get; set; }
        public Comment Comment { get; set; }
        public Post Post { get; set; }

        public CommentActivity()
        {
            ActivityType = ActivityTypeEnum.Comment;
        }
    }

    public class LikeActivity : Activity
    {
        public string PostId { get; set; }
        public Post Post { get; set; }

        public LikeActivity()
        {
            ActivityType = ActivityTypeEnum.Like;
        }
    }

    public enum ActivityTypeEnum
    {
        Follow, Comment, Like
    }
}
