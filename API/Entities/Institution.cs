namespace BulbEd.Entities;

public class Institution
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ContactDetail? ContactDetail { get; set; }
    
    public ICollection<AppUser>? Users { get; set; }
    
    public ICollection<Course>? Courses { get; set; }
    
    public AppUser? CreatedBy { get; set; }
    public int? CreatedById { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;
}
