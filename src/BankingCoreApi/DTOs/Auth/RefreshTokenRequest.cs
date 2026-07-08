using System.ComponentModel.DataAnnotations;

namespace BankingCoreApi.DTOs.Auth;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}