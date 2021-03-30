using InstagramRedesignApp.Core;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace InstagramRedesignApp
{
    public static class Extensions
    {
        public static ViewModelType InitializeViewModel<ViewModelType>(this Page page, PagesEnum pageEnum) where ViewModelType : IBaseViewModel
        {
            ViewModelType viewModel = ((App)App.Current).ServiceProvider.GetRequiredService<ViewModelType>();

            page.BindingContext = viewModel;

            INavigationService navigationManager = ((App)App.Current).ServiceProvider.GetRequiredService<INavigationService>();
            navigationManager.OnPageCreated(pageEnum, viewModel);

            return viewModel;
        }

        public static T FindView<T>(this Layout<View> layout) where T : View
        {
            foreach(var view in layout.Children)
            {
                if (view is T)
                    return view as T;
            }

            return null;
        }
    }
}
