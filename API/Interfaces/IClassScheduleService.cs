using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IClassScheduleService
{
    Task<IEnumerable<ClassScheduleDto>> GetClassSchedulesAsync();

}