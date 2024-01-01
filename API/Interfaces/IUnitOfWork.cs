namespace BulbEd.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IContactDetailRepository ContactDetailRepository { get; }
    
    Task<bool> Complete();
    
    bool HasChanges();
}