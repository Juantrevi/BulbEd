using System.Net;
using System.Net.Mail;
using BulbEd.Interfaces;

namespace BulbEd.Services;

public class EmailService : IEmailService
{
    public async Task SendPasswordEmail(string email, string password)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("prueba34813589@gmail.com", "34813589JmT"),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("prueba34813589@gmail.com"),
            Subject = "Your initial password",
            Body = $"Your initial password is {password}",
            IsBodyHtml = true,
        };
        mailMessage.To.Add(email);

        await smtpClient.SendMailAsync(mailMessage);
    }
}