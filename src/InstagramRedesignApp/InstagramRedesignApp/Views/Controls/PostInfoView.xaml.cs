using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostInfoView : ContentView
    {
        public bool IsLiked
        {
            get => (bool)GetValue(IsLikedProperty);
            set => SetValue(IsLikedProperty, value);
        }

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public static readonly BindableProperty IsLikedProperty =
            BindableProperty.Create(nameof(IsLiked), typeof(bool), typeof(PostInfoView), false, BindingMode.OneWay, coerceValue: (bindable, value) =>
            {
                var view = bindable as PostInfoView;

                view.likedShadows.IsVisible = (bool)value;

                return value;
            }, propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = bindable as PostInfoView;

                view.likedShadows.IsVisible = (bool)newValue;
            });

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(PostAvatarView), null, BindingMode.OneWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                //var view = bindable as PostAvatarView;

                //view.nameLabel.Text = newValue as string;
            });

        public PostInfoView()
        {
            InitializeComponent();
        }
    }
}