using System;
using KislovBlog.Domain.Models.Enums;

namespace KislovBlog.Domain.Models
{
    public class UserDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public RankDto Rank { get; set; }
        public bool IsBanned { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
