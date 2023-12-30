namespace BulbEd.DTOs;

public class MemberDto
{
    
    public int Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string FullName { get; set; }
    
    public string Gender { get; set; }
    
    public string Email { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime LastActive { get; set; } 
    
    public DateTime UpdatedAt { get; set; }
    
    public string PhoneNumber { get; set; }
    public string Status { get; set; }
    
    public List<string> Roles { get; set; }
}