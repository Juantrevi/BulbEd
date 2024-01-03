namespace BulbEd.Entities;

public class Group
{
    public int Id { get; set; }
    public int? ModuleId { get; set; }
    public Module? Module { get; set; }
    public ICollection<AppUser>? Users { get; set; }
}