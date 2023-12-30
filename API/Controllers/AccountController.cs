using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Controllers;

public class AccountController : BaseApiController
{
    
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;


    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _mapper = mapper;
        
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {   
        if(await UserExists(registerDto.Email)) return BadRequest("Email is taken");
            
        var user = _mapper.Map<AppUser>(registerDto);
            

        user.UserName = registerDto.Email.ToLower();


        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if(!result.Succeeded) return BadRequest(result.Errors);

        //var roleResult = await _userManager.AddToRoleAsync(user, "student");

        //if(!roleResult.Succeeded) return BadRequest(result.Errors);

        return new UserDto
        {
            Email = user.UserName,
            Token = await _tokenService.CreateToken(user),
        };

    }
    
    [HttpPost("login")] //POST //api/accounts/login 
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users
            .Include(p => p.Photo)
            .SingleOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

        if(user == null) return Unauthorized("Invalid username");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if(!result) return Unauthorized("Invalid Password");

        return new UserDto
        {
            Id = user.Id,
            Email = user.UserName,
            Token = await _tokenService.CreateToken(user),
            PhotoUrl = user.Photo?.Url

        };

    }   
    
    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
    
}