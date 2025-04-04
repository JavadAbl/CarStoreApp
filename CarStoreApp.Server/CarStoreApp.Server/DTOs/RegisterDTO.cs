using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

public class RegisterDTO
{
    [Required(ErrorMessage = "{0} Required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "{0} Required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "{0} Required")]
    public string Name { get; set; }

    public string Mobile { get; set; }

    public string Address { get; set; }

    public string Email { get; set; } 
	
	public string Token { get; set; }
}

