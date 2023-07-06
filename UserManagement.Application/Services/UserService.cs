using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Interfaces;
using UserManagement.Application.Models;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces;

namespace UserManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public void AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.IdNumbering();
            _userRepository.AddUser(user);
        }

        public void UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(string id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
