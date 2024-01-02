using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IInstitutionRepository
{
    Task<Institution> GetInstitutionById(int id);
    Task<IEnumerable<Institution>> GetInstitutions();
    
    Task Create(Institution institution);
    
    Task Update(int id, InstitutionDto institutionDto);
    
    Task Delete(int id);
}