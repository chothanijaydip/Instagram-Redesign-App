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
                    Followers = random.Next(0,1000000),
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
                            Images = new[]{ "Jan.1.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.2.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.3.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.4.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.5.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.6.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.7.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.8.jpg" },
                            Likes = random.Next(0,1000000),
                        },
                        new Post
                        {
                            AuthorId = "1",
                            Images = new[]{ "Jan.9.jpg" },
                            Likes = random.Next(0,1000000),
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
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "2",
                            Images = new[]{ "Gordo.1.jpg", "Gordo.2.jpg", "Gordo.3.jpg" },
                            Likes = random.Next(0,1000000),
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
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "3",
                            Images = new[]{ "Jenny.1.jpg" },
                            Likes = random.Next(0,1000000),
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
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "4",
                            Images = new[]{ "Manuel.1.jpg" },
                            Likes = random.Next(0,1000000),
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
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {
                        new Post
                        {
                            AuthorId = "5",
                            Images = new[]{ "Andrey.1.jpg" },
                            Likes = random.Next(0,1000000),
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
                            Images = new[]{ "Laura.1.jpg" },
                            Likes = random.Next(0,1000000),
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
    }
}
