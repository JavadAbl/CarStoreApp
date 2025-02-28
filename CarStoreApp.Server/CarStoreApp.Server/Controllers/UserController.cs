using System.Security.Cryptography;
using System.Text;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(AppDBContext rep) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var user = await rep.Users.FirstOrDefaultAsync(user => user.Username == loginDTO.Username.ToLower());

        if (user == null) return Unauthorized("user not found");

        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(user.PasswordSalt)))
        {
            var dtoPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            if (user.Password != Convert.ToBase64String(dtoPassword))
                return Unauthorized("Incorrect Password");
        }

        return Ok(user);
    }


    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {

        if (await UserExists(registerDTO.Username))
            return BadRequest("username exists.");

        var salt = GenerateSalt();
        var password = GeneratHash(registerDTO.Password, salt);


        var user = new User { Username = registerDTO.Username.ToLower(), Password = Convert.ToBase64String(password), PasswordSalt = Convert.ToBase64String(salt) };
        var userEntity = await rep.Users.AddAsync(user);

        await rep.SaveChangesAsync();
        return Ok(userEntity.Entity);
    }

    private byte[] GeneratHash(string text, byte[] salt)
    {
        using (var hmec = new HMACSHA256(salt))
        {
            return hmec.ComputeHash(Encoding.UTF8.GetBytes(text));

        }
    }

    private byte[] GenerateSalt(int size = 8)
    {
        return RandomNumberGenerator.GetBytes(size);
    }

    private async Task<bool> UserExists(string username)
    {
        return await rep.Users.AnyAsync(user => user.Username == username.ToLower());
    }
}
