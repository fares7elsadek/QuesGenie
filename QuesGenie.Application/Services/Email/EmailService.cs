using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using QuesGenie.Domain.Entities;
using QuesGenie.Domain.Exceptions;
using QuesGenie.Domain.Helpers;
using Serilog;

namespace QuesGenie.Application.Services.Email;

public class EmailService(IOptions<EmailOptions> options):IEmailSender<ApplicationUser>
{
    private readonly string _smtpEmail = options.Value.smptemail;
    private readonly string _smtpPassword = options.Value.smptpassword;
    private readonly string _smtpHost = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly bool _enableSsl = true;
    public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        using var message = new MailMessage
        {
            From = new MailAddress(_smtpEmail),
            Subject = "Confirm your email",
            Body = EmailTemplates.ConfirmEmail(confirmationLink),
            IsBodyHtml = true
        };

        message.To.Add(email);

        using var smtpClient = new SmtpClient(_smtpHost, _smtpPort)
        {
            Credentials = new NetworkCredential(_smtpEmail, _smtpPassword),
            EnableSsl = _enableSsl,
        };

        try
        {
            await smtpClient.SendMailAsync(message);
        }
        catch (SmtpException smtpEx)
        {
            Log.Fatal($"SMTP Error: {smtpEx.Message}");
            throw new CustomException($"SMTP Error: {smtpEx.Message}");
        }
        catch (Exception ex)
        {
            Log.Fatal($"SMTP Error: {ex.Message}");
            throw new CustomException($"SMTP Error: {ex.Message}");
        }
    }

    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        using var message = new MailMessage
        {
            From = new MailAddress(_smtpEmail),
            Subject = "Confirm your email",
            Body = EmailTemplates.ResetPassword(resetLink),
            IsBodyHtml = true
        };

        message.To.Add(email);

        using var smtpClient = new SmtpClient(_smtpHost, _smtpPort)
        {
            Credentials = new NetworkCredential(_smtpEmail, _smtpPassword),
            EnableSsl = _enableSsl,
        };

        try
        {
            await smtpClient.SendMailAsync(message);
        }
        catch (SmtpException smtpEx)
        {
            Log.Fatal($"SMTP Error: {smtpEx.Message}");
            throw new CustomException($"SMTP Error: {smtpEx.Message}");
        }
        catch (Exception ex)
        {
            Log.Fatal($"SMTP Error: {ex.Message}");
            throw new CustomException($"SMTP Error: {ex.Message}");
        }
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        throw new NotImplementedException();
    }
}