using System.ComponentModel.DataAnnotations;

namespace EmailServiceApi.DTOs;

public class ResetPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string ResetLink { get; set; } = string.Empty;
}