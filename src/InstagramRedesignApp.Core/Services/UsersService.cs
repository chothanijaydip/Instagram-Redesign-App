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
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    FollowedUsersIds = new List<string>
                    {
                        "2", "3", "4", "5", "6"
                    },
                    Posts = new List<Post>
                    {

                    },
                },
                new User
                {
                    UserId = "2",
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {

                    },
                },
                new User
                {
                    UserId = "3",
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {

                    },
                },
                new User
                {
                    UserId = "4",
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {

                    },
                },
                new User
                {
                    UserId = "5",
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {

                    },
                },
                new User
                {
                    UserId = "6",
                    Name = "",
                    ProfileImage = "",
                    Job = "",
                    Description = "",
                    Followers = random.Next(0,1000000),
                    Following = random.Next(1,50),
                    Posts = new List<Post>
                    {

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
