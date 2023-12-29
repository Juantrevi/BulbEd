﻿using BulbEd.Entities.Enums;
using Microsoft.AspNetCore.Identity;

namespace BulbEd.Entities;

public class AppUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Gender { get; set; }

    public Photo Photo { get; set; } = new();
    
    public ICollection<AppUserRole> UserRoles { get; set; }
    
    public ContactDetail ContactDetail { get; set; }
    
    public AppUserStatus Status { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime LastActive { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; }
    

    

    

    
    
    
    
}