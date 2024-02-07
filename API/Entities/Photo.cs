namespace BulbEd.Entities;

// Represents the photo entity
public class Photo
{
    public int Id { get; set; }
    
    public string Url { get; set; }
    
    public string PublicId { get; set; }
    
    public AppUser AppUser { get; set; }
    
    public int AppUserId { get; set; }
    
}