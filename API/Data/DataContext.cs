using BulbEd.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int
                                            ,IdentityUserClaim<int>, AppUserRole
                                            , IdentityUserLogin<int>, IdentityRoleClaim<int>
                                            ,IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        
        builder.Entity<AppUser>()
            .HasOne(u => u.Photo)
            .WithOne(p => p.AppUser)
            .HasForeignKey<Photo>(p => p.AppUserId);
        
        builder.Entity<Photo>()
            .HasOne(p => p.AppUser)
            .WithOne(u => u.Photo)
            .HasForeignKey<AppUser>(u => u.Photo.Id);
        
        builder.Entity<AppUser>()
            .HasOne(u => u.ContactDetails)
            .WithOne(c => c.AppUser)
            .HasForeignKey<ContactDetails>(c => c.AppUser.Id);

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    }
}