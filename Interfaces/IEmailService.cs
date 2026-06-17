namespace EmailServiceApi.Interfaces;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(
    string email,
    string name);
    Task SendEmailAsync(
        string toEmail,
        string subject,
        string body);

    Task<string> SendOtpAsync(
        string email);

    Task SendResetPasswordAsync(
        string email,
        string resetLink);
}