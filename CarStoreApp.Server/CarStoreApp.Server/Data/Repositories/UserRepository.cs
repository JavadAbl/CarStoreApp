using AutoMapper;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Data.Repositories;

public class UserRepository(AppDBContext db, IMapper mapper) : IUserRepository
{
    public async Task<User> AddUserAsync(User user)
    {
        var _user = await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
        return _user.Entity;
    }

    public Task<User> DeleteUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByRefreshTokenAsync(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await db.Users.FirstOrDefaultAsync(u => u.Username == username);
    }


    public Task<IEnumerable<User>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}

