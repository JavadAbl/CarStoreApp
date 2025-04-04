using System.Text.Json;
using CarStoreApp.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Data.Seed;

public static class Seed
{
    public static async Task SeedUsers(AppDBContext db)
    {
        if (db == null) throw new ArgumentNullException("AppDBContext not found");

        if (await db.Users.AnyAsync()) return;

        var userData = await File.ReadAllTextAsync("Data/Seed/Users.json");

        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // var stream = new StreamReader(userData);

        var users = JsonSerializer.Deserialize<List<User>>(userData, jsonOptions);

        if (users == null) return;

        foreach (var user in users)
        {
            var password = GeneratHash("1");
            user.Password = password;
            await db.Users.AddAsync(user);
        }

        await db.SaveChangesAsync();
    }

    private static string GeneratHash(string text)
    {
        return BCrypt.Net.BCrypt.HashPassword(text);
    }



}
