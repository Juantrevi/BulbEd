using BulbEd.Entities;

namespace BulbEd.Interfaces;

public interface ITokenService
{
    Task<string> CreateToken(AppUser user);
}