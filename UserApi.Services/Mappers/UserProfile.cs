using AutoMapper;
using UserManagment.Data.Models;
using UserManagment.UserApi.Models;

namespace UserManagment.UserApi.Services.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserEntity>()
            .ReverseMap();
    }
}
