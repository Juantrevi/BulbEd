using BulbEd.Interfaces;
using FluentEmail.Core;

namespace BulbEd.Services;

public class EmailSenderService : IEmailSender
{
    private readonly IFluentEmail _fluentEmail;
    
    public EmailSenderService(IFluentEmail fluentEmail)
    {
        _fluentEmail = fluentEmail;
    }
    
    public async Task SendEmailAsync(string emailAddress, string subject, string message)
    {
        var email = _fluentEmail
            .To(emailAddress)
            .Subject(subject)
            .Body(message, true);
        
        var response = await email.SendAsync();
        
        if (!response.Successful)
        {
            throw new Exception("Error occurred while sending email");
        }
    }
}