using BulbEd.Entities;
using BulbEd.Interfaces;
using AutoMapper;
using BulbEd.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data
{
public class ContactDetailRepository : IContactDetailRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ContactDetailRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ContactDetail> GetContactDetailByUserId(int userId)
    {
        return await _context.ContactDetails
            .FirstOrDefaultAsync(cd => cd.AppUserId == userId);
    }

    public async Task<ContactDetail> CreateContactDetail(int userId)
    {
        _context.ContactDetails.Add(new ContactDetail
        {
            AppUserId = userId
        });
        
        await _context.SaveChangesAsync();

        return null;

    }

    public async Task<ContactDetail> UpdateContactDetail(ContactDetailDto contactDetailDto, int userId)
    {
        var contactDetail = await GetContactDetailByUserId(userId);
        contactDetail.UpdatedAt = DateTime.UtcNow;
        
        if (contactDetail == null)
        {
            throw new Exception("ContactDetail not found");
        }
        _mapper.Map(contactDetailDto, contactDetail);
        _context.ContactDetails.Update(contactDetail);
        await _context.SaveChangesAsync();
        return contactDetail;
    }
    
}
}