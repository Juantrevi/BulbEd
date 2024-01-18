using BulbEd.Common;
using BulbEd.DTOs;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BulbEd.Controllers;

/*
 * This controller handles all the account related requests
 */
public class AccountController : BaseApiController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        return await _accountService.RegisterAsync(registerDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        return await _accountService.LoginAsync(loginDto);
    }
    
    [HttpPost("forgotpassword")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        var (success, result) = await _accountService.ForgotPasswordAsync(forgotPasswordDto);
        if (!success)
            return BadRequest(result);
        
        return Ok(Constants.Messages.PasswordResetLinkSent);
    }

    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetPassword([FromQuery] string token, ResetPasswordDto resetPasswordDto)
    {
        var (success, result) = await _accountService.ResetPasswordAsync(token, resetPasswordDto);
        if (!success)
            return BadRequest(result);

        return Ok(Constants.Messages.PasswordResetSuccess);
    }
    
}