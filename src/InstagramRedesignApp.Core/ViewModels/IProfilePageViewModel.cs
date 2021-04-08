using System.Collections.Generic;
using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public interface IProfilePageViewModel : IBaseViewModel
    {
        User CurrentUser { get; set; }
        IList<User> FollowedUsers { get; set; }
        ICommand PostTappedCommand { get; }
    }
}