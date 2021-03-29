﻿using System.Collections.Generic;

namespace InstagramRedesignApp.Core
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public IList<Post> Posts { get; set; }
        public IList<string> FollowedUsersIds { get; set; }
    }
}