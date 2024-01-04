using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;

namespace BulbEd.Services;

public class ClassScheduleService : IClassScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ClassScheduleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public Task<IEnumerable<ClassScheduleDto>> GetClassSchedulesAsync()
    {
        var classSchedules = _unitOfWork.ClassScheduleRepository.GetClassSchedulesAsync();
        _unitOfWork.Complete();
        return classSchedules;
        
    }
}