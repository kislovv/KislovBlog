using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserDto> WithoutPasswords(this IEnumerable<UserDto> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static UserDto WithoutPassword(this UserDto user)
        {
            if (user == null) return null;

            user.Password = null;
            return user;
        }
    }
}
