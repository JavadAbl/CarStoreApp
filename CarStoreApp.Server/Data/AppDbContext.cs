using CarStoreApp.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public  DbSet<User> Users { get; set; }
    }
}
