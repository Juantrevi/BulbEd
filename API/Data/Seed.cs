using System.Security.Cryptography;
using System.Text.Json;
using BulbEd.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class Seed
{
    public static async Task ClearConnections(DataContext context)
    {
        context.Connections.RemoveRange(context.Connections);
        await context.SaveChangesAsync();
    }

    public static async Task SeedUsers(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        if (await userManager.Users.AnyAsync()) return;
        
        var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);
        
        var roles = new List<AppRole>
        {
            new AppRole{Name = "Admin"},
            new AppRole{Name = "Student"},
            new AppRole{Name = "Teacher"},
            new AppRole{Name = "Staff"}
        };
        
        foreach (var role in roles)
        {
            await roleManager.CreateAsync(role);
        }

        foreach (var user in users)
        {
            using var hmac = new HMACSHA512();
            user.UserName = user.UserName.ToLower();
            
        }
            
        
    }
}