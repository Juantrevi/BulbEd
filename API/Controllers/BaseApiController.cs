using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

[ApiController]
[Route("api/")]
public class BaseApiController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    public BaseApiController()
    {
        
    }
    public BaseApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
}