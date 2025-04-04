using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> GetUserByEmailAsync(string email);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> AddUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<User> DeleteUserAsync(User user);
}

