using System.Security.Cryptography;
using System.Text;
using CarStoreApp.Server.Data;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using CarStoreApp.Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CarStoreApp.Server.Controllers.Filters;

namespace CarStoreApp.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IUserService userService, IJWTService jwtService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDTO loginDTO)
    {

        // throw new Exception("sd");
        var user = await userService.FindUser(loginDTO.Username);

        if (user == null) return BadRequest("user not found");

        if (!VerifyHash(loginDTO.Password, user.Password))
            return BadRequest("Incorrect Password");

        var token = jwtService.createToken(user);

        return Ok(new UserDto { Username = user.Username, Token = token });
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {

        if (await userService.UserExists(registerDTO.Username))
            return BadRequest("username exists.");


        var password = GeneratHash(registerDTO.Password);


        var user = new User { Username = registerDTO.Username.ToLower(), Password = password };
        var userEntity = await userService.SaveUser(user);


        var token = jwtService.createToken(user);

        return Ok(new UserDto { Username = user.Username, Token = token });


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
