namespace BulbEd.Entities;

public class UserModule
{
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public int ModuleId { get; set; }
    public Module Module { get; set; }
}