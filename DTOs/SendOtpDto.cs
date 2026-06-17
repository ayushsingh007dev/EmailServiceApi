using System.ComponentModel.DataAnnotations;

namespace EmailServiceApi.DTOs;

public class SendOtpDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}