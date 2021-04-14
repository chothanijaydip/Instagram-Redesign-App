using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class ActivityPageViewModel : BaseViewModel, IActivityPageViewModel
    {
        readonly IActivitiesService activitiesService;
        IList<Activity> allActivities;
        IList<Activity> likeActivities;
        IList<Activity> commentActivities;
        IList<Activity> followActivities;

        public IList<Activity> AllActivities
        {
            get => allActivities;
            set
            {
                allActivities = value;
                OnPropertyChanged(nameof(AllActivities));
            }
        }

        public IList<Activity> LikeActivities
        {
            get => likeActivities;
            set
            {
                likeActivities = value;
                OnPropertyChanged(nameof(LikeActivities));
            }
        }

        public IList<Activity> CommentActivities
        {
            get => commentActivities;
            set
            {
                commentActivities = value;
                OnPropertyChanged(nameof(CommentActivities));
            }
        }

        public IList<Activity> FollowActivities
        {
            get => followActivities;
            set
            {
                followActivities = value;
                OnPropertyChanged(nameof(FollowActivities));
            }
        }

        public ActivityPageViewModel(IActivitiesService activitiesService)
        {
            this.activitiesService = activitiesService;
        }

        public override Task OnCreated(params object[] parameters)
        {
            AllActivities = activitiesService.GetAllActivities();
            CommentActivities = activitiesService.GetCommentActivities(AllActivities);
            LikeActivities = activitiesService.GetLikeActivities(AllActivities);
            FollowActivities = activitiesService.GetFolowActivities(AllActivities);

            return base.OnCreated(parameters);
        }
    }
}
