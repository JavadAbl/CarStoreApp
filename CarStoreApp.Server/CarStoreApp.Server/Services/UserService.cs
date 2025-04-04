using AutoMapper;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Interfaces.Repositories;
using CarStoreApp.Server.Interfaces.Services;

namespace CarStoreApp.Server.Services;

public class UserService(IUserRepository userRep, IJWTService jwtService, IMapper mapper) : IUserService
{

    //-------------------------------------------------------------------
    public async Task<UserDto> AddUser(RegisterDTO registerDTO)
    {
        if (string.IsNullOrEmpty(registerDTO.Password))
        {
            throw new ArgumentException("Password cannot be null or empty", nameof(registerDTO.Password));
        }

        var user = mapper.Map<User>(registerDTO);
        user.Password = GeneratHash(registerDTO.Password);

        var userEntity = await userRep.AddUserAsync(user);

        return UserEntityToUserDto(userEntity);
    }

    //-------------------------------------------------------------------
    public string GetToken(string username)
    {
        return jwtService.createToken(username);
    }

    //-------------------------------------------------------------------
    public async Task<bool> UserExists(string username)
    {
        return await userRep.GetUserByUsernameAsync(username) != null;
    }

    //-------------------------------------------------------------------
    public async Task<User?> FindUser(string username)
    {
        return await userRep.GetUserByUsernameAsync(username);
    }

    //-------------------------------------------------------------------
    public bool VerifyPassword(string inputPassword, string basePassword)
    {
        return VerifyHash(inputPassword, basePassword);
    }

    //-------------------------------------------------------------------
    public UserDto UserEntityToUserDto(User user)
    {
        return mapper.Map<UserDto>(user);
    }

    //-------------------------------------------------------------------
    public User UserDtoToUser(UserDto userDto)
    {
        return mapper.Map<User>(userDto);
    }

    //-------------------------------------------------------------------
    private string GeneratHash(string text)
    {
        return BCrypt.Net.BCrypt.HashPassword(text);
    }

    private bool VerifyHash(string text, string hashedText)
    {
        return BCrypt.Net.BCrypt.Verify(text, hashedText);

    }

    public Dto EntityToDto<Entity, Dto>(Entity entity)
    {
        throw new NotImplementedException();
    }

    public Entity DtoToEntity<Dto, Entity>(Dto dto)
    {
        throw new NotImplementedException();
    }
}
