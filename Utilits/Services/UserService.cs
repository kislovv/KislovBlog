using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Helpers;
using KislovBlog.Domain.Models;
using KislovBlog.Utilities.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KislovBlog.Utilities.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppOptions _appOptions;
        public UserService(IUserRepository userRepository, IOptionsMonitor<AppOptions> appOptions)
        {
            _userRepository = userRepository;
            _appOptions = appOptions.CurrentValue;
        }
        public UserDto Authenticate(string username, string password)
        {
            var user =_userRepository.GetUserByLogin(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appOptions.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

        public IEnumerable<UserDto> GetAll() => _userRepository.GetAll().WithoutPasswords();

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return user.WithoutPassword();
        }

        public void AddUser(UserDto user)
        {
            _userRepository.AddUser(user);
        }
    }
}
