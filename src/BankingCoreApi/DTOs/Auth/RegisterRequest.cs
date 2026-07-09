using System.ComponentModel.DataAnnotations;

namespace BankingCoreApi.DTOs.Auth;

public class RegisterRequest
{
    [Required, MaxLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required, EmailAddress, MaxLength(300)]
    public string Email { get; set; } = string.Empty;

    [Required, Phone, MaxLength(20)]
    public string Phone { get; set; } = string.Empty;

    //add more validation attributes to use strong password policy
    [Required, MinLength(8), MaxLength(100)]
    public string Password { get; set; } = string.Empty;
}