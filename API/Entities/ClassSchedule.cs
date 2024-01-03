using BulbEd.Entities.Enums;
using DayOfWeek = System.DayOfWeek;

namespace BulbEd.Entities;

public class ClassSchedule
{
    public int Id { get; set; }
    public DayOfWeek? DayOfWeek { get; set; }
    public TimeOfDay? TimeOfDay { get; set; }
    public int? ModuleId { get; set; }
    public Module? Module { get; set; }
    
}