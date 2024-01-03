using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces
{
    public interface IContactDetailRepository
    {
        Task<ContactDetail> GetContactDetailByUserId(int userId);
        Task<ContactDetail> CreateContactDetailForUser(int userId);
        Task<ContactDetail> UpdateContactDetail(ContactDetailDto contactDetailDto, int userId);
        
        Task<ContactDetail> CreateContactDetailForInstitution(int institutionId);

    }
}