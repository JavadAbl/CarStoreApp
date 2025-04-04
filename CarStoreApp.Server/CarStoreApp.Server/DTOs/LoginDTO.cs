using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

public class LoginDTO
{
    [Required( ErrorMessage ="{0} Required")]
    public  string? Username { get; set; }
    
	[Required( ErrorMessage ="{0} Required")]
    public  string? Password { get; set; }
}

