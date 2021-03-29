using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppBar : ContentView
    {
        public AppBar()
        {
            InitializeComponent();
        }

        private void SettingsTapped(object sender, EventArgs e)
        {

        }
    }
}