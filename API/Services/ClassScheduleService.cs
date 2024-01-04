using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;

namespace BulbEd.Services;

public class ClassScheduleService : IClassScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public ClassScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<IEnumerable<ClassScheduleDto>> GetClassSchedulesAsync()
    {
        var classSchedules = await _unitOfWork.ClassScheduleRepository.GetClassSchedulesAsync();
        var classSchedulesDto = _mapper.Map<IEnumerable<ClassScheduleDto>>(classSchedules);
        
        return classSchedulesDto;
        
    }
}