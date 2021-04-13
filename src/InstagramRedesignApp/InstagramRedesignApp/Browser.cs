using InstagramRedesignApp.Core;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace InstagramRedesignApp
{
    public class Browser : IBrowser
    {
        public async Task OpenAsync(string uri)
        {
            await Xamarin.Essentials.Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
