using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InstagramRedesignApp.Core
{
    public class ProfilePageViewModel : BaseViewModel, IProfilePageViewModel
    {
        IUsersService usersService;
        User currentUser;
        IList<User> followedUsers;

        public User CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public IList<User> FollowedUsers
        {
            get => followedUsers;
            set
            {
                followedUsers = value;
                OnPropertyChanged(nameof(FollowedUsers));
            }
        }

        public ICommand PostTappedCommand { get; private set; }
        public ICommand LinkTappedCommand { get; private set; }

        public ProfilePageViewModel(IUsersService usersService, INavigationService navigationService, IBrowser browser)
        {
            this.usersService = usersService;

            PostTappedCommand = new RelayCommand(async parameter =>
            {
                Post currentPost = parameter as Post;
                await navigationService.PushPageAsync(PagesEnum.PostDetailPage, true, currentPost);
            });
            LinkTappedCommand = new RelayCommand(async parameter =>
            {
                Link link = parameter as Link;
                if (!string.IsNullOrWhiteSpace(link.Url))
                    await browser.OpenAsync(link.Url);
            });
        }


        public override Task OnCreated(params object[] parameters)
        {
            if (parameters.Length == 0)
                CurrentUser = usersService.CurrentUser;
            else
                CurrentUser = parameters[0] as User;

            usersService.AssignUsers(CurrentUser.Posts);
            FollowedUsers = usersService.GetUsersByIds(CurrentUser.FollowedUsersIds);

            return base.OnCreated(parameters);
        }
    }
}
