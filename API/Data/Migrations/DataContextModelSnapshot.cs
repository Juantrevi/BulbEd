﻿// <auto-generated />
using System;
using BulbEd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulbEd.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BulbEd.Entities.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BulbEd.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BulbEd.Entities.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("BulbEd.Entities.ContactDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmergencyContactName")
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactRelationship")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("ZipCode")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("BulbEd.Entities.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsModuleBased")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BulbEd.Entities.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("BulbEd.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BulbEd.Entities.AppUserRole", b =>
                {
                    b.HasOne("BulbEd.Entities.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BulbEd.Entities.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BulbEd.Entities.ContactDetails", b =>
                {
                    b.HasOne("BulbEd.Entities.AppUser", "AppUser")
                        .WithOne("ContactDetails")
                        .HasForeignKey("BulbEd.Entities.ContactDetails", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BulbEd.Entities.Module", b =>
                {
                    b.HasOne("BulbEd.Entities.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("BulbEd.Entities.Photo", b =>
                {
                    b.HasOne("BulbEd.Entities.AppUser", "AppUser")
                        .WithOne("Photo")
                        .HasForeignKey("BulbEd.Entities.Photo", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("BulbEd.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("BulbEd.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("BulbEd.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("BulbEd.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BulbEd.Entities.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BulbEd.Entities.AppUser", b =>
                {
                    b.Navigation("ContactDetails");

                    b.Navigation("Photo");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BulbEd.Entities.Course", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
