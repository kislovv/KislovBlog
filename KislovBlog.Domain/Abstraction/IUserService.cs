using System;
using System.Collections.Generic;
using System.Text;
using KislovBlog.Domain.DbEntity;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);
    }
}
