using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IClassScheduleRepository
{
    Task<IEnumerable<ClassSchedule>> GetClassSchedulesAsync();
}