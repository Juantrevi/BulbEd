using BulbEd.DTOs;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class SuperAdminController : BaseApiController
{
    
    private readonly IInstituteService _instituteService;
    private readonly IUnitOfWork _unitOfWork;
    
    public SuperAdminController(IInstituteService instituteService, IUnitOfWork unitOfWork)
    {
        _instituteService = instituteService;
        _unitOfWork = unitOfWork;
    }
    
    
    [Authorize (Roles = "superadmin")]
    [HttpGet ("institutions")]
    public async Task<ActionResult<IEnumerable<InstitutionDto>>> GetInstitutions()
    {
        var institutions = await _unitOfWork.InstitutionRepository.GetInstitutions();
        return Ok(institutions);
    }
    
    
}