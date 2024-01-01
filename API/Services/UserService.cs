using System.Security.Claims;
using AutoMapper;
using BulbEd.Data;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userManager = userManager;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    

    public async Task<ContactDetailDto> UpdateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser)
    {
        var userIdFromToken = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
        int id = int.Parse(userIdFromToken);

        var updatedContactDetail = await _unitOfWork.ContactDetailRepository.UpdateContactDetail(contactDetailDto, id);

        return _mapper.Map<ContactDetailDto>(updatedContactDetail);
    }
}