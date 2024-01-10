namespace BulbEd.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string emailAddress, string subject, string message);
}