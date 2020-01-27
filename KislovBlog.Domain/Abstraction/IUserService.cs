using System.Collections.Generic;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(int id);

        void AddUser(UserDto user);
    }
}
