using System.Security.Claims;
using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IUserService
{
    Task<ContactDetailDto> CreateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser);
    Task<ContactDetailDto> UpdateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser);
}
