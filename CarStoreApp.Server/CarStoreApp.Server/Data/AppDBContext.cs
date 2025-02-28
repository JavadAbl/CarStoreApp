using CarStoreApp.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Data;

public class AppDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Test> Tests { get; set; }
}