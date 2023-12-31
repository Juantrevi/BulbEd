using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BulbEd.DTOs;

namespace BulbEd.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        private IQueryable<AppUser> GetUsersWithIncludes()
        {
            return _context.Users
                .Include(p => p.Photo)
                .Include(u => u.UserRoles)
                .Include(ur => ur.UserRoles)
                .ThenInclude(ur => _context.Roles.Find(ur.RoleId));
        }

        public async Task<MemberDto> GetUserByIdAsync(int id)
        {
            var user = await 
                GetUsersWithIncludes()
                .SingleOrDefaultAsync(x => x.Id == id);
            
            return _mapper.Map<MemberDto>(user);
        }

        public async Task<MemberDto> GetUserByUsernameAsync(string username)
        {
            var user = await 
                GetUsersWithIncludes()
                .SingleOrDefaultAsync(x => x.UserName == username);

            return _mapper.Map<MemberDto>(user);
        }

        public async Task<IEnumerable<MemberDto>> GetUsersAsync()
        {
            var users = await 
                GetUsersWithIncludes()
                .ToListAsync();

            return _mapper.Map<IEnumerable<MemberDto>>(users);
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}