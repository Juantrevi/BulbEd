using BulbEd.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class DataContext : IdentityDbContext<AppUser, AppRole, int
    , IdentityUserClaim<int>, IdentityUserRole<int>
    , IdentityUserLogin<int>, IdentityRoleClaim<int>
    , IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<TokenBlackList> TokenBlackLists { get; set; }
    public DbSet<Institution> Institutions { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Module> Modules { get; set; }

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
        builder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });

        /**
         * Institution Relations
         * This is where we define the relationships between our entities
         */

        builder.Entity<Institution>()
            .HasOne(i => i.ContactDetail)
            .WithOne(c => c.Institution)
            .HasForeignKey<ContactDetail>(c => c.InstitutionId)
            .OnDelete(DeleteBehavior.Cascade);

        /**
        * Courses Relations
        * This is where we define the relationships between our entities
        */
        builder.Entity<Institution>()
            .HasMany(i => i.Courses)
            .WithOne(c => c.Institution)
            .HasForeignKey(c => c.InstitutionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Course>()
            .HasOne(c => c.Institution)
            .WithMany(i => i.Courses)
            .HasForeignKey(c => c.InstitutionId)
            .OnDelete(DeleteBehavior.Cascade);

        /**
        * Modules Relations
        * This is where we define the relationships between our entities
        */
        builder.Entity<Course>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Module>()
            .HasOne(m => m.Course)
            .WithMany(c => c.Modules)
            .HasForeignKey(m => m.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure many-to-many relationship between AppUser and Course
        builder.Entity<UserCourse>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        builder.Entity<UserCourse>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCourses)
            .HasForeignKey(uc => uc.UserId);

        builder.Entity<UserCourse>()
            .HasOne(uc => uc.Course)
            .WithMany(c => c.UserCourses)
            .HasForeignKey(uc => uc.CourseId);

        // Configure many-to-many relationship between AppUser and Module
        builder.Entity<UserModule>()
            .HasKey(um => new { um.UserId, um.ModuleId });

        builder.Entity<UserModule>()
            .HasOne(um => um.User)
            .WithMany(u => u.UserModules)
            .HasForeignKey(um => um.UserId);

        builder.Entity<UserModule>()
            .HasOne(um => um.Module)
            .WithMany(m => m.UserModules)
            .HasForeignKey(um => um.ModuleId);

        // Configure one-to-many relationship between Module and ClassSchedule
        builder.Entity<ClassSchedule>()
            .HasOne(cs => cs.Module)
            .WithMany(m => m.ClassSchedules)
            .HasForeignKey(cs => cs.ModuleId);

        // Configure one-to-many relationship between Module and Group
        builder.Entity<Group>()
            .HasOne(g => g.Module)
            .WithMany(m => m.Groups)
            .HasForeignKey(g => g.ModuleId);
    }

}
