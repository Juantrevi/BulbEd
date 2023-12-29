using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using BulbEd.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data
{
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
                // Add user to database
                await userManager.CreateAsync(user);
            }
        }

        public static async Task SeedCourses(DataContext context)
        {
            if (await context.Courses.AnyAsync()) return;

            var courseData = await System.IO.File.ReadAllTextAsync("Data/CourseSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var courses = JsonSerializer.Deserialize<List<Course>>(courseData, options);

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedContactDetails(DataContext context)
        {
            if (await context.ContactDetails.AnyAsync()) return;

            var contactDetailsData = await System.IO.File.ReadAllTextAsync("Data/ContactDetailsSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var contactDetails = JsonSerializer.Deserialize<List<ContactDetails>>(contactDetailsData, options);

            foreach (var contactDetail in contactDetails)
            {
                context.ContactDetails.Add(contactDetail);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedModules(DataContext context)
        {
            if (await context.Modules.AnyAsync()) return;

            var moduleData = await System.IO.File.ReadAllTextAsync("Data/ModuleSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var modules = JsonSerializer.Deserialize<List<Module>>(moduleData, options);

            foreach (var module in modules)
            {
                context.Modules.Add(module);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedPhotos(DataContext context)
        {
            if (await context.Photos.AnyAsync()) return;

            var photoData = await System.IO.File.ReadAllTextAsync("Data/PhotoSeedData.json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var photos = JsonSerializer.Deserialize<List<Photo>>(photoData, options);

            foreach (var photo in photos)
            {
                context.Photos.Add(photo);
            }

            await context.SaveChangesAsync();
        }
    }
}
            