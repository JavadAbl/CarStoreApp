using System.ComponentModel.DataAnnotations;

namespace CarStoreApp.Server.DTOs;

public class CreateCarDto
{
    [Required(ErrorMessage = "{0} is required")]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
    public int? price { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
    public int? quantity { get; set; }

    public ICollection<CreateCarPhotoDto> Photos { get; set; } = new List<CreateCarPhotoDto>();

}
