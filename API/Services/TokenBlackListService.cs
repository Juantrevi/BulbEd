using BulbEd.Data;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Services;

/*
 * This service handles all the token blacklist related requests
 */
public class TokenBlacklistService : ITokenBlacklistService
{
    private readonly DataContext _context;

    public TokenBlacklistService(DataContext context)
    {
        _context = context;
    }

    //Add token to blacklist
    public async Task AddToken(string token, DateTime expirationDate)
    {
        var tokenBlacklist = new TokenBlackList()
        {
            Token = token,
            ExpirationDate = expirationDate
        };

        _context.TokenBlackLists.Add(tokenBlacklist);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsTokenBlacklisted(string token)
    {
        var tokenBlacklist = await _context.TokenBlackLists
            .FirstOrDefaultAsync(t => t.Token == token && t.ExpirationDate > DateTime.UtcNow);

        return tokenBlacklist != null;
    }
}