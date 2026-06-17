using System.ComponentModel.DataAnnotations;

namespace EmailServiceApi.DTOs;

public class SendEmailDto
{
    [Required]
    [EmailAddress]
    public string ToEmail { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    [Required]
    public string Body { get; set; } = string.Empty;
}