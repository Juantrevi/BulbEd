namespace BulbEd.Entities;

public class Module
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? CourseId { get; set; }
    public Course? Course { get; set; }
    public ICollection<UserModule>? UserModules { get; set; }
    public ICollection<Group>? Groups { get; set; }
    public ICollection<ClassSchedule>? ClassSchedules { get; set; }
}