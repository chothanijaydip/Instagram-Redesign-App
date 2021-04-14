using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public interface IActivitiesService
    {
        IList<Activity> GetAllActivities();
        IList<Activity> GetCommentActivities(IEnumerable<Activity> activities);
        IList<Activity> GetFolowActivities(IEnumerable<Activity> activities);
        IList<Activity> GetLikeActivities(IEnumerable<Activity> activities);
    }
}