using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IInstitutionRepository
{
    Task<Institution> GetInstitutionById(int id);
    Task<IEnumerable<Institution>> GetInstitutions();
    
    Task Create(InstitutionDto institutionDto);
    
    void Update(int id, InstitutionDto institutionDto);
    
    void Delete(int id);
}