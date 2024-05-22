
using UserManagement.UserApi.Models;

namespace UserManagement.UI.Services.Contracts;

public interface IUserService
{
    Task<IEnumerable<UserEntity>> GetAllUsersAsync();
    Task<UserEntity> AddUserAsync(UserEntity entity);
    Task UpdateUserAsync(UserEntity entity);
    Task DeleteUserAsync(UserEntity entity);
}
