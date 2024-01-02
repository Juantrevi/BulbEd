using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IInstituteService
{
    Task CreateInstitute(InstitutionDto institutionDto);
}