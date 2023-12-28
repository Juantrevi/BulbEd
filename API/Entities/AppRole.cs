using Microsoft.AspNetCore.Identity;

namespace BulbEd.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}