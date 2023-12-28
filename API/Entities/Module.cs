namespace BulbEd.Entities;

public class Module
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Duration { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; }
    public Course Course { get; set; }
    
    public string CourseId { get; set; }
}