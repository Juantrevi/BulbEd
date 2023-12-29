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

    public DbSet<ContactDetails> ContactDetails { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Photo> Photos { get; set; }

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

        builder.Entity<AppUser>()
            .HasOne(u => u.ContactDetails)
            .WithOne(c => c.AppUser)
            .HasForeignKey<ContactDetails>(c => c.AppUserId);

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        builder.Entity<Course>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId)
            .IsRequired();
    }
}