namespace BulbEd.Interfaces;

public interface ITokenBlacklistService
{
    Task AddToken(string token, DateTime expirationDate);
    Task<bool> IsTokenBlacklisted(string token);
}