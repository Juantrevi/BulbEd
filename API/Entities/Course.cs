#nullable enable
namespace BulbEd.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Institution? Institution { get; set; }
    public ICollection<Module>? Modules { get; set; }
    public int? InstitutionId { get; set; }
}