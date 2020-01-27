using System;
using System.Collections.Generic;
using System.Text;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;

namespace KislovBlog.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserDto GetUserByLogin(string login, string password)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
