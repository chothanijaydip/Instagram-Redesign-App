using System.ComponentModel;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        Task OnPageAppearing();
        Task OnCreated(params object[] parameters);
        Task OnPageDisappearing();
        void Dispose();
    }
}