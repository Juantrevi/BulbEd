using System.Security.Claims;
using BulbEd.DTOs;
using BulbEd.Interfaces;
using BulbEd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class InstitutionController : BaseApiController
{
    
    
    private readonly IInstituteService _instituteService;
    public InstitutionController(IInstituteService instituteService)
    {
        _instituteService = instituteService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InstitutionDto>>> GetInstitutions()
    {
        var institutions = await _unitOfWork.InstitutionRepository.GetInstitutions();
        return Ok(institutions);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<InstitutionDto>> GetInstitutionById(int id)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        return Ok(institution);
    }
    
    [Authorize]
    [HttpPost ("createinstitution")]
    public async Task<ActionResult> CreateInstitution(InstitutionDto institutionDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        int id = int.Parse(userId);
        await _instituteService.CreateInstitute(institutionDto, id);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateInstitution(int id, InstitutionDto institutionDto)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        if (institution == null) return NotFound();
        _unitOfWork.InstitutionRepository.Update(id, institutionDto);
        if (await _unitOfWork.Complete()) return NoContent();
        return BadRequest("Problem updating institution");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteInstitution(int id)
    {
        var institution = await _unitOfWork.InstitutionRepository.GetInstitutionById(id);
        if (institution == null) return NotFound();
        _unitOfWork.InstitutionRepository.Delete(id);
        if (await _unitOfWork.Complete()) return Ok();
        return BadRequest("Problem deleting institution");
    }
    
}