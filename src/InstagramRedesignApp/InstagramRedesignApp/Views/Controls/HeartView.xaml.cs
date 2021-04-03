using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeartView : ContentView
    {
        public HeartView()
        {
            InitializeComponent();
        }

        public async Task ShowHeart()
        {
            heartGrid.Scale = 0;

            await Task.WhenAll(
                heartGrid.FadeTo(1),
                heartGrid.ScaleTo(1, easing: Easing.SpringOut)
                );

            await Task.Delay(1000);

            await Task.WhenAll(
                heartGrid.FadeTo(0),
                heartGrid.ScaleTo(0, easing: Easing.SpringIn)
                );
        }
    }
}