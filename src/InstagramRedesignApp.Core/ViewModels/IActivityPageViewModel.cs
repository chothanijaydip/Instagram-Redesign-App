using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface IActivityPageViewModel : IBaseViewModel
    {
        IList<Activity> AllActivities { get; set; }
        IList<Activity> CommentActivities { get; set; }
        IList<Activity> FollowActivities { get; set; }
        IList<Activity> LikeActivities { get; set; }

        Task OnCreated(params object[] parameters);
    }
}