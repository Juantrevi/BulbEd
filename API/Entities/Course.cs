namespace BulbEd.Entities;

public class Course
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool IsModuleBased { get; set; }
    
    public int Duration { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; }
    
    public ICollection<Module> Modules { get; set; }
    
    // public Institution Institution { get; set; }
}