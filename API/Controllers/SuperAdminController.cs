using System.Security.Claims;
using BulbEd.Common;
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
    
    
    [Authorize (policy: "RequireSuperAdminRole")]
    [HttpPost ("createinstitution")]
    public async Task<ActionResult> CreateInstitution(InstitutionDto institutionDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null)
        {
            return Unauthorized("User ID not found: " + userId);
        }

        int id = int.Parse(userId);
        await _instituteService.CreateInstitute(institutionDto, id);
        return Ok(new { message = Constants.Messages.InstitutionCreated });
    }
    
}