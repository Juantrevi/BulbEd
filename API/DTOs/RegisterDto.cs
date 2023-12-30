using System.ComponentModel.DataAnnotations;

namespace BulbEd.DTOs;

public class RegisterDto
{
    
    public string? FirstName { get; set; }
    
    
    public string? LastName { get; set; }
    
    
    public string? Email { get; set; }
    
    
    //[StringLength(8, MinimumLength = 4)]
    public string? Password { get; set; }
}