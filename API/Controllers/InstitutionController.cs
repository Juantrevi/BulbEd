using System.Security.Claims;
using BulbEd.Common;
using BulbEd.DTOs;
using BulbEd.Interfaces;
using BulbEd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class InstitutionController : BaseApiController
{
    
    
    private readonly IInstituteService _instituteService;
    private readonly IUnitOfWork _unitOfWork;
    
    public InstitutionController(IInstituteService instituteService, IUnitOfWork unitOfWork)
    {
        _instituteService = instituteService;
        _unitOfWork = unitOfWork;
    }

    
}