using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

public class UpdateCarDto
{
    [Required(ErrorMessage = "{0} is required")]
    [Range(1, int.MaxValue, ErrorMessage = "{0} must be a positive number")]
    public int? Id { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, int.MaxValue, ErrorMessage = "{0} must be a positive number")]
    public int? price { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, int.MaxValue, ErrorMessage = "{0} must be a positive number")]
    public int? quantity { get; set; }

}
