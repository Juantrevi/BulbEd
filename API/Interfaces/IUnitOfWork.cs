namespace BulbEd.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IContactDetailRepository ContactDetailRepository { get; }
    IInstitutionRepository InstitutionRepository { get; }
    IClassScheduleRepository ClassScheduleRepository { get; }

    Task<bool> Complete();
    
    bool HasChanges();
}