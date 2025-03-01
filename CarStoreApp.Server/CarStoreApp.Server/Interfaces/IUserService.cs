using System;
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces;

public interface IUserService
{
    string CreateToken();

    Task<bool> UserExists(string username);

    Task<User?> FindUser(string username);

    Task<User> SaveUser(User user);
}
