using AndroidX.RecyclerView.Widget;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("InstagramRedesignApp")]
[assembly: ExportEffect(typeof(InstagramRedesignApp.Droid.OverlapItemsEffect), nameof(InstagramRedesignApp.Droid.OverlapItemsEffect))]
namespace InstagramRedesignApp.Droid
{
    public class OverlapItemsEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            CollectionView collectionView = Element as CollectionView;
            var effect = collectionView.Effects.FirstOrDefault(e => e is InstagramRedesignApp.OverlapItemsEffect) as InstagramRedesignApp.OverlapItemsEffect;

            if (Control is RecyclerView recyclerView)
                recyclerView.AddItemDecoration(new OverlapDecoration());
        }

        protected override void OnDetached()
        {
        }
    }

    public class OverlapDecoration : RecyclerView.ItemDecoration
    {
        readonly double vertOverlap = -45 * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

        public override void GetItemOffsets(Android.Graphics.Rect outRect, Android.Views.View view, RecyclerView parent, RecyclerView.State state)
        {
            int itemPosition = parent.GetChildAdapterPosition(view);
            if (itemPosition == 0)
            {
                return;
            }
            outRect.Set(0, (int)vertOverlap, 0, 0);
        }
    }
}