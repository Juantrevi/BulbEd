namespace BulbEd.Entities;
// Represents the token blacklist entity
public class UserCourse
{
    public int UserId { get; set; }
    public AppUser User { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}