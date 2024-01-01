using AutoMapper;
using BulbEd.Interfaces;

namespace BulbEd.Data;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IContactDetailRepository _contactDetailRepository;

    public UnitOfWork(DataContext context, IMapper mapper, IContactDetailRepository contactDetailRepository)
    {
        _context = context;
        _mapper = mapper;
        _contactDetailRepository = contactDetailRepository;
        
    }
    
    public IUserRepository UserRepository => new UserRepository(_context, _mapper);
    public IContactDetailRepository ContactDetailRepository => new ContactDetailRepository(_context, _mapper);
    
    
    
    
    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0; 
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}