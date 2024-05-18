using AutoMapper;
using UserManagment.Data.Contracts;
using UserManagment.Data.Models;
using UserManagment.UserApi.Models;
using UserManagment.UserApi.Services.Contracts;

namespace UserManagment.UserApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserEntity>>(users);
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        var user = await _repository.GetByIdAsync(id);
        return _mapper.Map<UserEntity>(user);
    }

    public async Task<UserEntity> AddAsync(UserEntity entity)
    {
        var newUser = _mapper.Map<User>(entity);
        await _repository.AddAsync(newUser);
        return _mapper.Map<UserEntity>(newUser);
    }

    public async Task<int> UpdateAsync(UserEntity entity)
    {
        var userToUpdate = _mapper.Map<User>(entity);
        return await _repository.UpdateAsync(userToUpdate);
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }
}
