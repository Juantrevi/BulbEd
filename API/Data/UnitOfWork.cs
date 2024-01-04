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
    private readonly IClassScheduleRepository _classScheduleRepository;

    public UnitOfWork(DataContext context, IMapper mapper, 
        IContactDetailRepository contactDetailRepository, 
        IInstitutionRepository institutionRepository,
        IClassScheduleRepository classScheduleRepository)
    {
        _context = context;
        _mapper = mapper;
        _contactDetailRepository = contactDetailRepository;
        _institutionRepository = institutionRepository;
        _classScheduleRepository = classScheduleRepository;
        
    }
    
    public IUserRepository UserRepository => new UserRepository(_context, _mapper);
    public IContactDetailRepository ContactDetailRepository => new ContactDetailRepository(_context, _mapper);
    public IInstitutionRepository InstitutionRepository => new InstitutionRepository(_context, _mapper);
    public IClassScheduleRepository ClassScheduleRepository => new ClassScheduleRepository(_context, _mapper);
    
    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0; 
    }

    public bool HasChanges()
    {
        return _context.ChangeTracker.HasChanges();
    }
}