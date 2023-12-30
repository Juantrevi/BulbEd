using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

public class UserController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUser()
    {
        return Ok(await _unitOfWork.UserRepository.GetUsersAsync());
    }

    [HttpGet("user/{username:alpha}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        return await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
    }
    
    [HttpGet("user/{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        return await _unitOfWork.UserRepository.GetUserByIdAsync(id);
    }
    
}