﻿using BulbEd.Entities;
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
            .HasMany(i => i.Users)
            .WithOne(u => u.Institution)
            .HasForeignKey(u => u.InstitutionId);

        builder.Entity<Institution>()
            .HasMany(i => i.Courses)
            .WithOne(c => c.Institution)
            .HasForeignKey(c => c.InstitutionId);

        builder.Entity<Course>()
            .HasMany(c => c.Modules)
            .WithOne(m => m.Course)
            .HasForeignKey(m => m.CourseId);
    }
}     
        
