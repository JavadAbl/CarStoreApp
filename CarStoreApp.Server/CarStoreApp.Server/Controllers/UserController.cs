using System.Security.Cryptography;
using System.Text;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using CarStoreApp.Server.Interfaces;

namespace CarStoreApp.Server.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var user = await userService.FindUser(loginDTO.Username);

        if (user == null) return Unauthorized("user not found");

        if (!VerifyHash(loginDTO.Password, user.Password))
            return Unauthorized("Incorrect Password");
        return Ok(user);
    }


    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {

        if (await userService.UserExists(registerDTO.Username))
            return BadRequest("username exists.");


        var password = GeneratHash(registerDTO.Password);


        var user = new User { Username = registerDTO.Username.ToLower(), Password = password };
        var userEntity = await userService.SaveUser(user);

        return Ok(userEntity);


    }

    private string GeneratHash(string text)
    {
        return BCrypt.Net.BCrypt.HashPassword(text);
    }

    private bool VerifyHash(string text, string hashedText)
    {
        return BCrypt.Net.BCrypt.Verify(text, hashedText);
    }
}
