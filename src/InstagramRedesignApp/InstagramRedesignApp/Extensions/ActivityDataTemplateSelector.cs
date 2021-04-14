using InstagramRedesignApp.Core;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public class ActivityDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FollowDataTemplate { get; set; }
        public DataTemplate CommentDataTemplate { get; set; }
        public DataTemplate LikeDataTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is FollowActivity)
                return FollowDataTemplate;
            else if (item is CommentActivity)
                return CommentDataTemplate;
            else if (item is LikeActivity)
                return LikeDataTemplate;
            else
                return new DataTemplate(typeof(Grid));
        }
    }
}
