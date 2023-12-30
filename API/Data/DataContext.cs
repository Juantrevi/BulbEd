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

    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /**
         * AppUser Relations
         * This is where we define the relationships between our entities
         */
        builder.Entity<AppUser>()
            .HasOne(u => u.Photo)
            .WithOne(p => p.AppUser)
            .HasForeignKey<Photo>(p => p.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<AppUser>()
            .HasOne(u => u.ContactDetail)
            .WithOne(c => c.AppUser)
            .HasForeignKey<ContactDetail>(c => c.AppUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        /**
        * AppUserRole Relations
        * This is where we define the relationships between our entities
        */
        builder.Entity<AppUserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.Entity<AppUserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.Entity<AppUserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
        
        
        
        
    }
}