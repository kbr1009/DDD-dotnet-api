using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models;
using UserManagementAPI.DTOs;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserResponseDto>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            var userDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponseDto> GetUserById(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserResponseDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult AddUser(UserRequestDto userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            _userService.AddUser(userDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(string id, UserRequestDto userRequest)
        {
            var userDto = _mapper.Map<UserDto>(userRequest);
            userDto.Id = id;
            _userService.UpdateUser(userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
