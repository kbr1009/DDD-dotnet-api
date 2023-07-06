using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.Models;

namespace UserManagement.Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(string id);
        void AddUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        void DeleteUser(string id);
    }
}
