using InstagramRedesignApp.Core;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    class NavigationService : INavigationService
    {
        ViewModelParameter pushViewModelParameter;

        
        public void OnPageCreated(PagesEnum page, IBaseViewModel viewModel)
        {
            if (pushViewModelParameter is null || page != pushViewModelParameter.Page)
                return;

            viewModel.OnCreated(pushViewModelParameter.Parameters);
        }

        public async Task PopPageAsync()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        public async Task PopToRootPageAsync()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }

        public async Task PushPageAsync(PagesEnum page, bool isRelative = true, params object[] parameters)
        {
            string path = isRelative ? page.ToString() : "///" + page.ToString();

            pushViewModelParameter = new ViewModelParameter { Page = page, Parameters = parameters };

            await Shell.Current.GoToAsync(path, true);
        }

        class ViewModelParameter
        {
            public object[] Parameters { get; set; }
            public PagesEnum Page { get; set; }
        }
    }
}
