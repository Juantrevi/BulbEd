namespace BulbEd.Interfaces;

public interface IEmailService
{
    Task SendPasswordEmail(string email, string password);
}