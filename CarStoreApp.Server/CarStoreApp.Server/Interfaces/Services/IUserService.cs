using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces.Services;

public interface IUserService : IBaseService
{
    Task<UserDto> AddUser(RegisterDTO registerDTO);

    Task<User?> FindUser(string username);

    Task<bool> UserExists(string username);

    string GetToken(string username);

    bool VerifyPassword(string inputPassword, string basePassword);

    UserDto UserEntityToUserDto(User user);

    User UserDtoToUser(UserDto userDto);
}
