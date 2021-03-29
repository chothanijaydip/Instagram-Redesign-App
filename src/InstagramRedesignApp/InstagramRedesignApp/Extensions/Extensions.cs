using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public static class Extensions
    {
        public static ViewModelType InitializeViewModel<ViewModelType>(this Page page, PagesEnum pageEnum) where ViewModelType : IBasePageViewModel
        {
            ViewModelType viewModel = ((App)App.Current).ServiceProvider.GetRequiredService<ViewModelType>();

            page.BindingContext = viewModel;

            INavigationService navigationManager = ((App)App.Current).ServiceProvider.GetRequiredService<INavigationService>();
            navigationManager.OnPageCreated(pageEnum, viewModel);

            return viewModel;
        }
    }
}
