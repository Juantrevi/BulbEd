using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    
    Task<IEnumerable<MemberDto>> GetUsersAsync();
    
    Task<MemberDto> GetUserByIdAsync(int id);
    
    Task<MemberDto> GetUserByUsernameAsync(string username);
    
    Task<AppUser> GetAppUserByIdAsync(int id);
    
    
}