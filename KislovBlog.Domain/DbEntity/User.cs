using System;

namespace KislovBlog.Domain.DbEntity
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Rank Rank { get; set; }
        public bool IsBanned { get; set; }
    }
}
