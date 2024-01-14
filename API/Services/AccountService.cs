using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace BulbEd.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailSender _emailSender;

    public AccountService(UserManager<AppUser> userManager, 
        RoleManager<AppRole> roleManager, 
        ITokenService tokenService, 
        IMapper mapper, 
        IUnitOfWork unitOfWork,
        IEmailSender emailSender)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _emailSender = emailSender;
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
        if(!await _roleManager.RoleExistsAsync("student"))
        {
            // If not, create the "Student" role
            var role = new AppRole { Name = "student" };
            await _roleManager.CreateAsync(role);
        }

        // Add the user to the "student" role
        var roleResult = await _userManager.AddToRoleAsync(user, "student");
        
        await _unitOfWork.ContactDetailRepository.CreateContactDetailForUser(user.Id);
        
        
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

        if(user == null) throw new ArgumentException("Invalid email");

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
    

    public async Task<(bool, string)> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
        if (user == null)
            return (false, "Invalid email address");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var message = $"Please reset your password by clicking the link we have sent to your email.";
        await _emailSender.SendEmailAsync(forgotPasswordDto.Email, "Reset Password", message);

        return (true, token);
    }

    public async Task<(bool, string)> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
    {
        var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
        if (user == null)
            return (false, "Invalid password reset token");

        var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
        if (!result.Succeeded)
            return (false, result.Errors.FirstOrDefault()?.Description);

        return (true, null);
    }

}
