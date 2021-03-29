using Plugin.SharedTransitions;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : SharedTransitionShell
    {
        public AppShell()
        {
            InitializeComponent();
        }
    }
}