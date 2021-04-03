using System.Collections.Generic;
using System.ComponentModel;

namespace InstagramRedesignApp.Core
{
    public class Post : INotifyPropertyChanged
    {
        private bool isLiked;
        private int numberOfLikes;

        public string PostId { get; set; }
        public string[] Images { get; set; }
        public string Description { get; set; }
        public string FirstImage => Images[0];
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public int NumberOfLikes
        {
            get => numberOfLikes;
            set
            {
                numberOfLikes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfLikes)));
                System.Diagnostics.Debug.WriteLine("-----------------" + nameof(NumberOfLikes));
            }
        }
        public int NumberComments => Comments.Count;
        public bool IsLiked
        {
            get => isLiked;
            set
            {
                isLiked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLiked)));
            }
        }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
        public IList<string> LikeUserIds { get; set; } = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
