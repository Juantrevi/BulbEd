using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class ClassScheduleRepository : IClassScheduleRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public ClassScheduleRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
public async Task<IEnumerable<ClassSchedule>> GetClassSchedulesAsync()
{
    var classSchedules = await _context.ClassSchedules.Include(cs => cs.Module).ThenInclude(m => m.Course).ToListAsync();
    return classSchedules;
}
}