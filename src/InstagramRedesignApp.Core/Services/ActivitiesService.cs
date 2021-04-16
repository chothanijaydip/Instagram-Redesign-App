using System.Collections.Generic;
using System.Linq;

namespace InstagramRedesignApp.Core
{
    public class ActivitiesService : IActivitiesService
    {
        IUsersService usersService;
        IList<Activity> allActivities;


        public ActivitiesService(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public IList<Activity> GetAllActivities()
        {
            if (allActivities != null)
                return allActivities;

            List<Activity> activities = new List<Activity>();

            foreach (var post in usersService.CurrentUser.Posts)
            {
                foreach (var comment in post.Comments)
                {
                    if (usersService.CurrentUser.UserId == comment.AuthorId)
                        continue;

                    activities.Add(new LikeActivity { UserId = comment.AuthorId, PostId = comment.PostId, Post = post });

                    activities.Add(new CommentActivity { UserId = comment.AuthorId, CommentId = comment.CommentId, Comment = comment, PostId = comment.PostId, Post = post });
                }
            }

            foreach (var userId in usersService.CurrentUser.FollowedUsersIds)
                activities.Add(new FollowActivity { UserId = userId });

            return allActivities = usersService.AssignUsers(activities).Shuffle();
        }

        public IList<Activity> GetCommentActivities(IEnumerable<Activity> activities)
        {
            return activities.Where(a => a.ActivityType == ActivityTypeEnum.Comment).ToList();
        }

        public IList<Activity> GetLikeActivities(IEnumerable<Activity> activities)
        {
            return activities.Where(a => a.ActivityType == ActivityTypeEnum.Like).ToList();
        }

        public IList<Activity> GetFolowActivities(IEnumerable<Activity> activities)
        {
            return activities.Where(a => a.ActivityType == ActivityTypeEnum.Follow).ToList();
        }
    }
}
