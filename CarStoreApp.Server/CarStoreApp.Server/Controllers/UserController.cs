using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreApp.Server.Controllers;


[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDTO loginDTO)
    {

        var user = await userService.FindUser(loginDTO.Username!);

        if (user == null) throw new BadHttpRequestException("user not found");

        if (!userService.VerifyPassword(loginDTO.Password!, user.Password))
            throw new BadHttpRequestException("Incorrect password");


        var token = userService.GetToken(loginDTO.Username!);

        var userDto = userService.UserEntityToUserDto(user);
        userDto.Token =  token;
        return Ok(userDto);

    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {

        if (await userService.UserExists(registerDTO.Username!))
            throw new BadHttpRequestException("username exists.");

        var newUser = await userService.AddUser(registerDTO);

        var token = userService.GetToken(newUser.Username!);
		newUser.Token = token;
		
        return Ok(newUser);
    }


}
