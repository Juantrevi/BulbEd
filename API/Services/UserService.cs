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

public async Task<ContactDetailDto> CreateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser)
{
    var userIdFromToken = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
    int id = int.Parse(userIdFromToken);

    var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

    if (user == null)
    {
        throw new Exception("User not found");
    }

    var newContactDetail = _mapper.Map<ContactDetail>(contactDetailDto);
    newContactDetail.AppUser = user;
    newContactDetail.AppUserId = user.Id;
    

    _unitOfWork.ContactDetailRepository.AddContactDetail(newContactDetail);
    await _unitOfWork.Complete();

    user.ContactDetail = newContactDetail;

    _unitOfWork.UserRepository.Update(user);
    await _unitOfWork.Complete();

    return _mapper.Map<ContactDetailDto>(newContactDetail);
}

    public async Task<ContactDetailDto> UpdateContactDetail(ContactDetailDto contactDetailDto, ClaimsPrincipal currentUser)
    {
        var userIdFromToken = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
        int id = int.Parse(userIdFromToken);

        var updatedContactDetail = await _unitOfWork.ContactDetailRepository.UpdateContactDetail(contactDetailDto, id);

        return _mapper.Map<ContactDetailDto>(updatedContactDetail);
    }
}