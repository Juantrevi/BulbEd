namespace BulbEd.DTOs;

public class ClassScheduleDto
{
    public string DayOfWeek { get; set; }
    public string TimeOfDay { get; set; }
    public string ModuleName { get; set; }
    
    public Dictionary<string, object> CourseData { get; set; }
}