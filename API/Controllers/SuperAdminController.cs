using System.Security.Claims;
using BulbEd.Common;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

/*
 * This controller handles all the account related requests
 */
public class SuperAdminController : BaseApiController
{
    
    private readonly IInstituteService _instituteService;
    private readonly IUnitOfWork _unitOfWork;
    
    public SuperAdminController(IInstituteService instituteService, IUnitOfWork unitOfWork)
    {
        _instituteService = instituteService;
        _unitOfWork = unitOfWork;
    }
    
    //Get all institutions
    [Authorize (Policy = "RequireSuperAdminRole")]
    [HttpGet ("institutions")]
    public async Task<ActionResult<IEnumerable<Institution>>> GetInstitutions()
    {
        var institutions = await _instituteService.GetInstitutions();
        return Ok(institutions);
    }
    
    //Create institution
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
    
    //Get institution by id
    [HttpGet("{id}")]
    public async Task<ActionResult<InstitutionDto>> GetInstitutionById(int id)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        return Ok(institution);
    }
    
    
    //Update institution
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInstitution(int id, InstitutionDto institutionDto)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        if (institution == null) return NotFound();
        await _unitOfWork.InstitutionRepository.Update(id, institutionDto);
        if (await _unitOfWork.Complete()) return NoContent();
        return BadRequest(Constants.Messages.ProblemUpdatingInstitution);
    }
    
    //Delete institution
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInstitution(int id)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        if (institution == null) return NotFound();
        await _unitOfWork.InstitutionRepository.Delete(id);
        if (await _unitOfWork.Complete()) return Ok();
        return BadRequest(Constants.Messages.ProblemDeletingInstitution);
    }
    
}