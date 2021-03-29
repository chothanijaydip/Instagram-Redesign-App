using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface INavigationService
    {
        Task PushPageAsync(PagesEnum page, bool isRelative = true, params object[] parameters);
        Task PopPageAsync();
        Task PopToRootPageAsync();
        void OnPageCreated(PagesEnum page, IBasePageViewModel viewModel);
    }
}
