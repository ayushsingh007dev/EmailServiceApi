using EmailServiceApi.Data;
using EmailServiceApi.Interfaces;
using EmailServiceApi.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailServiceApi.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly AppDbContext _context;

    public EmailService(
        IOptions<EmailSettings> emailSettings,
        AppDbContext context)
    {
        _emailSettings = emailSettings.Value;
        _context = context;
    }

    public async Task SendEmailAsync(
        string toEmail,
        string subject,
        string body)
    {
        var email = new MimeMessage();

        email.From.Add(
            new MailboxAddress(
                _emailSettings.SenderName,
                _emailSettings.SenderEmail));

        email.To.Add(
            MailboxAddress.Parse(toEmail));

        email.Subject = subject;

        email.Body = new TextPart("html")
        {
            Text = body
        };

        string status = "Sent";

        try
        {
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _emailSettings.SmtpServer,
                _emailSettings.Port,
                SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _emailSettings.Username,
                _emailSettings.Password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
        catch
        {
            status = "Failed";
            throw;
        }
        finally
        {
            _context.EmailLogs.Add(
                new EmailLog
                {
                    ToEmail = toEmail,
                    Subject = subject,
                    Body = body,
                    Status = status,
                    SentAt = DateTime.UtcNow
                });

            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> SendOtpAsync(string email)
    {
        var otp = new Random()
            .Next(100000, 999999)
            .ToString();

        string template = await File.ReadAllTextAsync(
            "Templates/Otp.html");

        template = template.Replace(
            "{{OTP}}",
            otp);

        await SendEmailAsync(
            email,
            "OTP Verification",
            template);

        return otp;
    }

    public async Task SendResetPasswordAsync(
        string email,
        string resetLink)
    {
        string template = await File.ReadAllTextAsync(
            "Templates/ResetPassword.html");

        template = template.Replace(
            "{{LINK}}",
            resetLink);

        await SendEmailAsync(
            email,
            "Password Reset",
            template);
    }
    public async Task SendWelcomeEmailAsync(
    string email,
    string name)
{
    string template =
        await File.ReadAllTextAsync(
            "Templates/Welcome.html");

    template = template.Replace(
        "{{NAME}}",
        name);

    await SendEmailAsync(
        email,
        "Welcome to Email Service API",
        template);
}
}