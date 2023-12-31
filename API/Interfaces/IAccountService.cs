using BulbEd.DTOs;

namespace BulbEd.Interfaces;

public interface IAccountService
{
    Task<UserDto> RegisterAsync(RegisterDto registerDto);
    Task<UserDto> LoginAsync(LoginDto loginDto);
}