using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InstagramRedesignApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostAvatarView : ContentView
    {
        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(PostAvatarView), null, BindingMode.OneWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = bindable as PostAvatarView;

                view.image.Source = newValue as ImageSource;
            });

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create(nameof(Name), typeof(string), typeof(PostAvatarView), null, BindingMode.OneWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = bindable as PostAvatarView;

                view.nameLabel.Text = newValue as string;
            });

        public PostAvatarView()
        {
            InitializeComponent();
        }
    }
}