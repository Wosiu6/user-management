using Microsoft.EntityFrameworkCore;
using UserManagment.Data.Contracts;
using UserManagment.Data.Models;

namespace UserManagment.Data.Repositories;
public class UserRepository : IUserRepository
{
    private readonly UserDataContext _dbContext;

    public UserRepository(UserDataContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users
                               .OrderByDescending(t => t.Modified)
                               .ThenBy(t => t.Created)
                               .AsNoTracking()
                               .ToListAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users
                               .AsNoTracking()
                               .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> AddAsync(User user)
    {
        user.Id = Guid.NewGuid();
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<int> UpdateAsync(User user)
    {
        var storedUser = await _dbContext.Users
                                 .Where(t => t.Id == user.Id)
                                 .FirstOrDefaultAsync();

        if (storedUser == null)
        {
            return -1;
        }
        storedUser.Name = user.Name;
        storedUser.Surname = user.Surname;
        storedUser.DateOfBirth = user.DateOfBirth;
        storedUser.Email = user.Email;
        storedUser.IsActive = user.IsActive;
        storedUser.Modified = DateTime.UtcNow;

        var result = await _dbContext.SaveChangesAsync();

        return result;
    }

    public async Task<int> DeleteAsync(Guid id)
    {
        var result = await _dbContext.Users
                                     .Where(t => t.Id == id)
                                     .ExecuteDeleteAsync();
        return result;
    }
}