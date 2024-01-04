using BulbEd.DTOs;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class ClassScheduleController : BaseApiController
{
    private readonly IClassScheduleService _classScheduleService;
    
    public ClassScheduleController(IClassScheduleService classScheduleService)
    {
        _classScheduleService = classScheduleService;
    }
    
        
    [HttpGet("class-schedules")]
    public async Task<ActionResult<IEnumerable<ClassScheduleDto>>> GetClassSchedules()
    {
        var classSchedules = await _classScheduleService.GetClassSchedulesAsync();
        return Ok(classSchedules);
    }
    
}