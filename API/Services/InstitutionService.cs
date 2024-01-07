using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;

namespace BulbEd.Services;

public class InstitutionService : IInstituteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InstitutionService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

public async Task CreateInstitute(InstitutionDto institutionDto, int userId)
{
    var institution = _mapper.Map<Institution>(institutionDto);
    await _unitOfWork.InstitutionRepository.Create(institution);

    var user = await _unitOfWork.UserRepository.GetAppUserByIdAsync(userId);
    if (user == null)
    {
        throw new Exception("Invalid user id");
    }

    institution.CreatedBy = user;
    var contactDetail = await _unitOfWork.ContactDetailRepository.CreateContactDetailForInstitution(institution.Id);

    await _unitOfWork.Complete();
}

    public async Task DeleteInstitute(int id)
    {
        await _unitOfWork.InstitutionRepository.Delete(id);
        await _unitOfWork.Complete();
    }

    public async Task UpdateInstitute(int id, InstitutionDto institutionDto)
    {
        await _unitOfWork.InstitutionRepository.Update(id, institutionDto);
        await _unitOfWork.Complete();
    }
}
