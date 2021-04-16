using System;
using System.Collections.Generic;
using System.Linq;

namespace InstagramRedesignApp.Core
{
    public class UsersService : IUsersService
    {
        Random random = new Random();

        public IDictionary<string, User> AllUsers { get; private set; }
        public User CurrentUser { get; private set; }

        public UsersService()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    UserId = "1",
                    Name = "Jan Novák",
                    ProfileImage = "Jan.avatar.jpg",
                    Job = "Xamariner",
                    Description = "Like to travel, code and take photos of random monkeys.",
                    Followers = random.Next(0,100000),
                    Following = random.Next(1,50),
                    FollowedUsersIds = new List<string>
                    {
                        "2", "3", "4", "5", "6"
                    },
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#1",
                            Description = "Hello friends ",
                            Images = new[]{ "Jan.1.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "1#1",
                                    CommentId = "1#1#1",
                                    Text = "🐒",
                                },
                                new Comment
                                {
                                    AuthorId = "6",
                                    PostId = "1#1",
                                    CommentId = "1#1#2",
                                    Text = "Oh My Monkey! Nice!",
                                },
                                new Comment
                                {
                                    AuthorId = "4",
                                    PostId = "1#1",
                                    CommentId = "1#1#3",
                                    Text = "🍌",
                                },
                            },
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#2",
                            Images = new[]{ "Jan.2.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "6",
                                    PostId = "1#2",
                                    CommentId = "1#2#1",
                                    Text = "❤ 💕 ❤ 💕 ❤",
                                },
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "1#2",
                                    CommentId = "1#2#2",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "1#2",
                                    CommentId = "1#2#3",
                                    Text = "Nice picture!",
                                },
                                new Comment
                                {
                                    AuthorId = "4",
                                    PostId = "1#2",
                                    CommentId = "1#2#4",
                                    Text = "So cute!",
                                },
                            },
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#3",
                            Images = new[]{ "Jan.3.jpg" },
                            NumberOfLikes = random.Next(0,1000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "1#3",
                                    CommentId = "1#3#1",
                                    Text = "🍌 🐒",
                                },
                            },
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#4",
                            Images = new[]{ "Jan.4.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#5",
                            Images = new[]{ "Jan.5.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "3",
                                    PostId = "1#5",
                                    CommentId = "1#5#1",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "1#5",
                                    CommentId = "1#5#2",
                                    Text = "Cute! 🥰",
                                },
                            },
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#6",
                            Images = new[]{ "Jan.6.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "1#6",
                                    CommentId = "1#6#1",
                                    Text = "🐵",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "1#6",
                                    CommentId = "1#6#2",
                                    Text = "Awesome Xamariners!",
                                },
                            },
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#7",
                            Images = new[]{ "Jan.7.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#8",
                            Images = new[]{ "Jan.8.jpg" },
                            NumberOfLikes = random.Next(0,100),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#9",
                            Images = new[]{ "Jan.9.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#10",
                            Description = "Hello friends ",
                            Images = new[]{ "Jan.1.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#11",
                            Images = new[]{ "Jan.2.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#12",
                            Images = new[]{ "Jan.3.jpg" },
                            NumberOfLikes = random.Next(0,1000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#13",
                            Images = new[]{ "Jan.4.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#14",
                            Images = new[]{ "Jan.5.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#15",
                            Images = new[]{ "Jan.6.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#16",
                            Images = new[]{ "Jan.7.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#17",
                            Images = new[]{ "Jan.8.jpg" },
                            NumberOfLikes = random.Next(0,100),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            PostId = "1#18",
                            Images = new[]{ "Jan.9.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                        },
                    },
                    Links = new List<Link>
                    {
                        new Link
                        {
                            LinkType = LinkTypesEnum.Website,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.Behance,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.Dribbble,
                            Url = "https://dribbble.com/shots/14057207-Instagram-Redesign-Part-2",
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.Twitch,
                            Url = "https://www.twitch.tv/kymphillpotts",
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.TikTok,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.SnapChat,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.Unsplash,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.Discord,
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.YouTube,
                            Url = "https://www.youtube.com/channel/UCBBZ2kXWmd8eXlHg2wEaClw",
                        },
                        new Link
                        {
                            LinkType = LinkTypesEnum.GitHub,
                            Url = "https://github.com/RadekVyM",
                        },
                    },
                },
                new User
                {
                    UserId = "2",
                    Name = "Gordo",
                    ProfileImage = "Gordo.avatar.jpg",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,10000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "2",
                            PostId = "2#1",
                            Description = "Monkey is a common name that may refer to certain groups or species of simian mammals of infraorder Simiiformes.",
                            Images = new[]{ "Gordo.1.jpg", "Gordo.2.jpg", "Gordo.3.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "1",
                                    PostId = "2#1",
                                    CommentId = "2#1#1",
                                    Text = "🐒",
                                },
                                new Comment
                                {
                                    AuthorId = "3",
                                    PostId = "2#1",
                                    CommentId = "2#1#2",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "2#1",
                                    CommentId = "2#1#3",
                                    Text = "Super photography!",
                                },
                                new Comment
                                {
                                    AuthorId = "6",
                                    PostId = "2#1",
                                    CommentId = "2#1#4",
                                    Text = "Oh My Monkey! Nice selfie!",
                                },
                                new Comment
                                {
                                    AuthorId = "4",
                                    PostId = "2#1",
                                    CommentId = "2#1#5",
                                    Text = "🍌",
                                },
                            },
                        },
                    },
                },
                new User
                {
                    UserId = "3",
                    Name = "Jenny",
                    ProfileImage = "Jenny.avatar.jpg",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,10000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "3",
                            PostId = "3#1",
                            Images = new[]{ "Jenny.1.jpg" },
                            NumberOfLikes = random.Next(0,10000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "6",
                                    PostId = "3#1",
                                    CommentId = "3#1#1",
                                    Text = "❤ 💕 ❤ 💕 ❤",
                                },
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "3#1",
                                    CommentId = "3#1#2",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "3#1",
                                    CommentId = "3#1#3",
                                    Text = "Lovely photography!",
                                },
                                new Comment
                                {
                                    AuthorId = "4",
                                    PostId = "3#1",
                                    CommentId = "3#1#4",
                                    Text = "So cute!",
                                },
                            },
                        },
                    },
                },
                new User
                {
                    UserId = "4",
                    Name = "Manuel",
                    ProfileImage = "Manuel.avatar.jpg",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,10000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "4",
                            PostId = "4#1",
                            Images = new[]{ "Manuel.1.jpg" },
                            NumberOfLikes = random.Next(0,1000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "4#1",
                                    CommentId = "4#1#1",
                                    Text = "🍌 🐒",
                                },
                            },
                        },
                    },
                },
                new User
                {
                    UserId = "5",
                    Name = "Andrey",
                    ProfileImage = "Andrey.avatar.jpg",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,100000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "5",
                            PostId = "5#1",
                            Images = new[]{ "Andrey.1.jpg" },
                            NumberOfLikes = random.Next(0,100000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "3",
                                    PostId = "5#1",
                                    CommentId = "5#1#1",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "4",
                                    PostId = "5#1",
                                    CommentId = "5#1#2",
                                    Text = "Nice!",
                                },
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "5#1",
                                    CommentId = "5#1#3",
                                    Text = "Super photography!",
                                },
                            },
                        },
                    },
                },
                new User
                {
                    UserId = "6",
                    Name = "Laura",
                    ProfileImage = "Laura.avatar.jpg",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "6",
                            PostId = "6#1",
                            Description = "Monkeys are generally considered to be intelligent, especially the Old World monkeys of Catarrhini.",
                            Images = new[]{ "Laura.1.jpg" },
                            NumberOfLikes = random.Next(0,1000000),
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    AuthorId = "1",
                                    PostId = "6#1",
                                    CommentId = "6#1#1",
                                    Text = "🐒",
                                },
                                new Comment
                                {
                                    AuthorId = "3",
                                    PostId = "6#1",
                                    CommentId = "6#1#2",
                                    Text = "Awesome!",
                                },
                                new Comment
                                {
                                    AuthorId = "5",
                                    PostId = "6#1",
                                    CommentId = "6#1#3",
                                    Text = "Super photography!",
                                },
                                new Comment
                                {
                                    AuthorId = "2",
                                    PostId = "6#1",
                                    CommentId = "6#1#4",
                                    Text = "Oh My Monkey! You are beautiful!",
                                },
                            },
                        },
                    },
                },
            };

            AllUsers = users.ToDictionary(u => u.UserId);
            CurrentUser = AllUsers.First().Value;
        }

        public IList<User> GetUsersByIds(IEnumerable<string> userIds)
        {
            IList<User> users = new List<User>();

            foreach (var userId in userIds)
                users.Add(AllUsers[userId]);

            return users;
        }

        public IList<Post> AssignUsers(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                post.Author = AllUsers[post.AuthorId];
                post.IsLiked = post.LikeUserIds.Contains(CurrentUser.UserId);
            }

            return posts.ToList();
        }

        public IList<Comment> AssignUsers(IEnumerable<Comment> comments)
        {
            foreach (var comment in comments)
                comment.Author = AllUsers[comment.AuthorId];

            return comments.ToList();
        }

        public IList<Activity> AssignUsers(IEnumerable<Activity> activities)
        {
            foreach (var activity in activities)
                activity.User = AllUsers[activity.UserId];

            return activities.ToList();
        }
    }
}
