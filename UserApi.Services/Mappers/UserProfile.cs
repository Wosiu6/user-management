using AutoMapper;
using UserManagement.Data.Models;
using UserManagement.UserApi.Models;

namespace UserManagement.UserApi.Services.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserEntity>()
            .ReverseMap();
    }
}
