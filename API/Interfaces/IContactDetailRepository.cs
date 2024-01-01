using BulbEd.DTOs;
using BulbEd.Entities;

namespace BulbEd.Interfaces
{
    public interface IContactDetailRepository
    {
        Task<ContactDetail> GetContactDetailByUserId(int userId);
        void CreateContactDetail(int userId);
        Task<ContactDetail> UpdateContactDetail(ContactDetailDto contactDetailDto, int userId);

    }
}