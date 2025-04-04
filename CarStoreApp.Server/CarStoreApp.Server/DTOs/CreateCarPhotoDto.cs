using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

public class CreateCarPhotoDto
{
    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public  string Url { get; set; }
}

