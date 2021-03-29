using System.ComponentModel;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface IBasePageViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        Task OnPageAppearing();
        Task OnPageCreated(params object[] parameters);
        Task OnPageDisappearing();
    }
}