using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IInstituteService
{
    Task CreateInstitute(InstitutionDto institutionDto, int userId);
    
    Task DeleteInstitute(int id);
    
    Task UpdateInstitute(int id, InstitutionDto institutionDto);
}