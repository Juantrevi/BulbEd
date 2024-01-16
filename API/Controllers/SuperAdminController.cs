using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class SuperAdminController : BaseApiController
{
    
    private readonly IInstituteService _instituteService;
    
    public SuperAdminController(IInstituteService instituteService)
    {
        _instituteService = instituteService;
    }
    
    
    [Authorize (Policy = "RequireSuperAdminRole")]
    [HttpGet ("institutions")]
    public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
    {
        var institutions = await _instituteService.GetInstitutions();
        return Ok(institutions);
    }
    
    
}