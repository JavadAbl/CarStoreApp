using System;
using System.Threading.Tasks;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Services;

public class UserService(AppDBContext rep) : IUserService
{
    public string CreateToken()
    {
        throw new NotImplementedException();
    }

    public async Task<User?> FindUser(string username)
    {
        return await rep.Users.FirstOrDefaultAsync(user => user.Username == username.ToLower());
    }

    public async Task<User> SaveUser(User user)
    {
        var userEntity = await rep.Users.AddAsync(user);
        await rep.SaveChangesAsync();
        return userEntity.Entity;
    }

    public async Task<bool> UserExists(string username)
    {
        return await rep.Users.AnyAsync(user => user.Username == username.ToLower());
    }


}
