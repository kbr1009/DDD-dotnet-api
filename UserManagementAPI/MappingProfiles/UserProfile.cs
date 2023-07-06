using AutoMapper;
using UserManagement.Domain.Entities;
using UserManagement.Application.Models;
using UserManagementAPI.DTOs;

namespace UserManagementAPI.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDto, UserDto>();
            CreateMap<UserDto, UserResponseDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
