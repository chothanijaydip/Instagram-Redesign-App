using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface IBrowser
    {
        Task OpenAsync(string uri);
    }
}
