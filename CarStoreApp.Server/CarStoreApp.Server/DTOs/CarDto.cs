namespace CarStoreApp.Server.DTOs;

public class CarDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public ICollection<CarPhotoDto> Photos { get; set; } = new List<CarPhotoDto>();

}
