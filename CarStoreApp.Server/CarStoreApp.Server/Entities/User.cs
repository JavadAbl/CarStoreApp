namespace CarStoreApp.Server.Entities;

public class User : BaseEntity
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public string Password { get; set; } = null!;
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
    public string? Address { get; set; }
    public int Wallet { get; set; }



}
