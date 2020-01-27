using AutoMapper;
using KislovBlog.Contracts;
using KislovBlog.Domain.Abstraction;
using KislovBlog.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KislovBlog.Controllers.Controllers
{
    [Authorize]
    [Route("user")]
    public class UserController : ControllerBase
    { 
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("new")]
        public IActionResult Add([FromBody] User user)
        {
            _userService.AddUser(_mapper.Map<UserDto>(user));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserLoginRq model)
        {
            var user = _userService.Authenticate(model.Login, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id.ToString() != User.Identity.Name && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}