namespace CarStoreApp.Server.Entities;

public class Car : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public ICollection<CarPhoto> Photos { get; set; } = new List<CarPhoto>();

}

