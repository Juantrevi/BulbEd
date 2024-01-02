using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;

namespace BulbEd.Services;

public class InstituteService : IInstituteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public InstituteService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
public async Task CreateInstitute(InstitutionDto institutionDto, int userId)
{
    var institution = _mapper.Map<Institution>(institutionDto);
    await _unitOfWork.InstitutionRepository.Create(institution);
    await _unitOfWork.Complete();

    var user = await _unitOfWork.UserRepository.GetAppUserByIdAsync(userId);
    if (user != null)
    {
        user.InstitutionId = institution.Id;
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.Complete();
    }
}
}