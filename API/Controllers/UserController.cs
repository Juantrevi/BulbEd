using System.Security.Claims;
using BulbEd.Common;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using BulbEd.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

/*
 * This controller handles all the account related to the user requests
 */
public class UserController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly ITokenBlacklistService _tokenBlacklistService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClassScheduleService _classScheduleService;


    public UserController(IUserService userService, ITokenBlacklistService tokenBlacklistService, IUnitOfWork unitOfWork, IClassScheduleService classScheduleService)
    {
        _userService = userService;
        _tokenBlacklistService = tokenBlacklistService;
        _unitOfWork = unitOfWork;
        _classScheduleService = classScheduleService;
    }

    //Get all users
    [Authorize(Policy = "RequireStudentRole")]
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUser()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }

    //Get user by email address
    [HttpGet("user/{emailAddress}")]
    public async Task<ActionResult<MemberDto>> GetUser(string emailAddress)
    {
        var user = await _userService.GetUserByEmailAddressAsync(emailAddress);
        return Ok(user);
    }
    
    //Get user by id
    [Authorize(Policy = "RequireStudentRole")]
    //[Authorize(Policy = "RequireAdminRole")]
    [HttpGet("user/{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }
    
    //Update contact details
    [Authorize]
    [HttpPut("contactdetails")]
    public async Task<IActionResult> UpdateContactDetails(ContactDetailDto contactDetailDto)
    {
        var updatedContactDetails = await _userService.UpdateContactDetail(contactDetailDto, User);
        return Ok(updatedContactDetails);
    }
    
    //Logout and blacklist token
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString().Split(' ')[1];
        await _tokenBlacklistService.AddToken(token, DateTime.UtcNow.AddHours(1)); // Token will be blacklisted for 1 hour

        return Ok(Constants.Messages.LogOutSuccess);
    }
    

}