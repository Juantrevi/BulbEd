using BulbEd.Entities;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<AppUser> Users { get; set; }
}