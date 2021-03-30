using System.ComponentModel;
using System.Threading.Tasks;

namespace InstagramRedesignApp.Core
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        protected bool isDisposed;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch { }
        }

        public async virtual Task OnPageDisappearing()
        {
            await Task.CompletedTask;
        }

        public async virtual Task OnCreated(params object[] parameters)
        {
            await Task.CompletedTask;
        }

        public async virtual Task OnPageAppearing()
        {
            await Task.CompletedTask;
        }

        public virtual void Dispose()
        {
            isDisposed = true;
        }
    }
}
