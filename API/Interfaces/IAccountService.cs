using BulbEd.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Interfaces;

public interface IAccountService
{
    Task<UserDto> RegisterAsync(RegisterDto registerDto);
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<(bool, string)> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
    Task<(bool, string)> ResetPasswordAsync(string token, ResetPasswordDto resetPasswordDto);


}