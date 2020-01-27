using System;
using KislovBlog.Contracts.Enums;

namespace KislovBlog.Contracts
{
    public class User
    {
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Rank Rank { get; set; }
    }


}
