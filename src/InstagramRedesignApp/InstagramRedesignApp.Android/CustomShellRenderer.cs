using Android.Content;
using InstagramRedesignApp;
using InstagramRedesignApp.Droid;
using Plugin.SharedTransitions.Platforms.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MySharedTransitionShell), typeof(CustomShellRenderer))]
namespace InstagramRedesignApp.Droid
{
    public class CustomShellRenderer : SharedTransitionShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new CustomShellItemRenderer(this);
        }
    }
}