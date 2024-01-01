using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.Email)) throw new ArgumentException("Username is taken");

        var user = _mapper.Map<AppUser>(registerDto);

        user.UserName = registerDto.Email.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if(!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(x => x.Description));
            throw new InvalidOperationException($"Error occurred during registration: {errors}");
        }
            
        // Check if the "Student" role exists
        if(!await _roleManager.RoleExistsAsync("Student"))
        {
            // If not, create the "Student" role
            var role = new AppRole { Name = "Student" };
            await _roleManager.CreateAsync(role);
        }

        // Add the user to the "student" role
        var roleResult = await _userManager.AddToRoleAsync(user, "Student");

if(!roleResult.Succeeded) throw new InvalidOperationException("Error occurred while adding role");
        return new UserDto
        {
            Email = user.UserName,
            Token = await _tokenService.CreateToken(user),
        };
    }

public async Task<UserDto> LoginAsync(LoginDto loginDto)
{
    
    var user = await _userManager.Users
        .Include(p => p.Photo)
        .SingleOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

    if(user == null) throw new ArgumentException("Invalid username");

    var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

    if(!result) throw new ArgumentException("Invalid Password");

    return new UserDto
    {
        Id = user.Id,
        Email = user.UserName,
        Token = await _tokenService.CreateToken(user),
        PhotoUrl = user.Photo?.Url
    };
}

    private UserDto Unauthorized(string invalidUsername)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}