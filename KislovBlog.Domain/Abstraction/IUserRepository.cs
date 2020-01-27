using System.Collections.Generic;
using KislovBlog.Domain.Models;

namespace KislovBlog.Domain.Abstraction
{
    public interface IUserRepository
    {
        UserDto GetUserByLogin(string login, string password);
        UserDto GetUserById(long id);
        void AddUser(UserDto user);
        void RemoveUser(UserDto user);
        List<UserDto> GetAll();
    }
}
