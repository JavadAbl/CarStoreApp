using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

    public class TestDTO
    {
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }
}

