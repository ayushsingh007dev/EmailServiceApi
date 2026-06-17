using EmailServiceApi.Data;
using EmailServiceApi.DTOs;
using EmailServiceApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmailServiceApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly AppDbContext _context;

    public EmailController(
        IEmailService emailService,
        AppDbContext context)
    {
        _emailService = emailService;
        _context = context;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail(
        SendEmailDto dto)
    {
        await _emailService.SendEmailAsync(
            dto.ToEmail,
            dto.Subject,
            dto.Body);

        return Ok(new
        {
            Message = "Email sent successfully"
        });
    }

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendOtp(
        SendOtpDto dto)
    {
        string otp =
            await _emailService.SendOtpAsync(
                dto.Email);

        return Ok(new
        {
            Message = "OTP sent successfully",
            OTP = otp
        });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(
        ResetPasswordDto dto)
    {
        await _emailService.SendResetPasswordAsync(
            dto.Email,
            dto.ResetLink);

        return Ok(new
        {
            Message = "Password reset email sent"
        });
    }

    [HttpGet("logs")]
    public async Task<IActionResult> GetLogs()
    {
        var logs =
            await _context.EmailLogs
            .OrderByDescending(x => x.SentAt)
            .ToListAsync();

        return Ok(logs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLogById(
        int id)
    {
        var log =
            await _context.EmailLogs
            .FindAsync(id);

        if (log == null)
        {
            return NotFound();
        }

        return Ok(log);
    }
    [HttpPost("welcome")]
    public async Task<IActionResult> SendWelcomeEmail(
        WelcomeEmailDto dto)
    {
        await _emailService.SendWelcomeEmailAsync(
            dto.Email,
            dto.Name);

        return Ok(new
        {
            Message = "Welcome email sent"
        });
    }
}