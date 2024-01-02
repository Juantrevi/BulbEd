using AutoMapper;
using BulbEd.Interfaces;
using BulbEd.Services;

namespace BulbEd.Data;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IContactDetailRepository _contactDetailRepository;
    private readonly IInstitutionRepository _institutionRepository;

    public UnitOfWork(DataContext context, IMapper mapper, IContactDetailRepository contactDetailRepository, IInstitutionRepository institutionRepository)
    {
        _context = context;
        _mapper = mapper;
        _contactDetailRepository = contactDetailRepository;
        _institutionRepository = institutionRepository;
        
    }
    
    public IUserRepository UserRepository => new UserRepository(_context, _mapper);
    public IContactDetailRepository ContactDetailRepository => new ContactDetailRepository(_context, _mapper);
    public IInstitutionRepository InstitutionRepository => new InstitutionRepository(_context, _mapper);
    
    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0; 
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}