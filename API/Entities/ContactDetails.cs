namespace BulbEd.Entities;

public class ContactDetails
{
    public string Id { get; set; }
    
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    public string Address { get; set; }
    
    public string ZipCode { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string EmergencyContactName { get; set; }
    
    public string EmergencyContactNumber { get; set; }
    
    public string EmergencyContactRelationship { get; set; }
    
    public string UpdatedAt { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public AppUser AppUser { get; set; }
    
    
}