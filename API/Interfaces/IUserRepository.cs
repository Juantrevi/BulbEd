using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    
    Task<IEnumerable<AppUser>> GetUsersAsync();
    
    Task<AppUser> GetUserByIdAsync(int id);
    
    Task<AppUser> GetUserByUsernameAsync(string username);
    
    
}