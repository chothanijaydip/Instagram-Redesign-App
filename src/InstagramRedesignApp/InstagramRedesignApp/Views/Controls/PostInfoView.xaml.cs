using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostInfoView : ContentView
    {
        public PostInfoView()
        {
            InitializeComponent();
        }

        private async void LikeTapped(object sender, EventArgs e)
        {
            Grid mainGrid = (sender as Element).Parent.Parent.Parent.Parent as Grid;

            HeartView heartView = mainGrid?.FindView<HeartView>();

            if (heartView is not null)
                await heartView.ShowHeart();
        }
    }
}