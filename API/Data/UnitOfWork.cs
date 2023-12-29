using BulbEd.Interfaces;

namespace BulbEd.Data;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }
    
    public IUserRepository UserRepository { get; }
    
    public Task<bool> Complete()
    {
        throw new NotImplementedException();
    }

    public bool HasChanges()
    {
        throw new NotImplementedException();
    }
}