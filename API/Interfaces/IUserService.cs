using System.Security.Claims;
using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IUserService
{
    Task<ContactDetailDto> UpdateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser);
    
    Task<MemberDto> GetUserByUsernameAsync(string username);
    
    Task<MemberDto> GetUserByIdAsync(int id);
    
    Task<IEnumerable<MemberDto>> GetUsersAsync();
    
    Task<MemberDto> UpdateUserAsync(MemberDto memberDto);
    
    Task<MemberDto> DeleteUserAsync(int id);
    
    Task<MemberDto> GetUserByEmailAddressAsync(string emailAddress);
    
    
    
}
