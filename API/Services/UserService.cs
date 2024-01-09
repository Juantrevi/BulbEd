using System.Security.Claims;
using AutoMapper;
using BulbEd.Data;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Errors.Exceptions;
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
        if (userIdFromToken != null)
        {
            var id = int.Parse(userIdFromToken);

            var updatedContactDetail = await _unitOfWork.ContactDetailRepository.UpdateContactDetail(contactDetailDto, id);

            return _mapper.Map<ContactDetailDto>(updatedContactDetail);
        }
        else
        {
            throw new NotFoundException("Error occurred while updating contact details");
        }
    }

    public async Task<MemberDto> GetUserByUsernameAsync(string username)
    {
        var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
        if (user != null)
        {
            return _mapper.Map<MemberDto>(user);
        }
        else
        {
            throw new NotFoundException("Error occurred while getting user by username, user not found");
        }
        {
            
        }
    }

    public async Task<MemberDto> GetUserByIdAsync(int id)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            return _mapper.Map<MemberDto>(user);
        }
        else
        {
            throw new NotFoundException("Error occurred while getting user by id, user not found");
        }
    }

    public async Task<IEnumerable<MemberDto>> GetUsersAsync()
    {
        var users = await _unitOfWork.UserRepository.GetUsersAsync();
        if (users != null)
        {
            return _mapper.Map<IEnumerable<MemberDto>>(users);
        }
        else
        {
            throw new NotFoundException("Error occurred while getting users, users not found");
        }
        
    }

    public async Task<MemberDto> UpdateUserAsync(MemberDto memberDto)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(memberDto.Id);
        //TODO
        return null;
    }

    public Task<MemberDto> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<MemberDto> GetUserByEmailAddressAsync(string emailAddress)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmailAddressAsync(emailAddress);
        if (user != null)
        {
            return _mapper.Map<MemberDto>(user);
        }
        else
        {
            throw new NotFoundException("Error occurred while getting user by email address, user not found");
        }
    }
    
}
