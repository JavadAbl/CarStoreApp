using System.ComponentModel.DataAnnotations.Schema;

namespace CarStoreApp.Server.Entities;


[Table("CarPhotos")]
public class CarPhoto :BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Url { get; set; }

    //Navigation
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
}

