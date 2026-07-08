using System.ComponentModel.DataAnnotations;

namespace BankingCoreApi.Models;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();

    [Required, MaxLength(100)]
    public required string FullName { get; set; }

    [Required, EmailAddress, MaxLength(256)]
    public required string Email { get; set; }

    [Required, Phone, MaxLength(20)]
    public required string Phone { get; set; }

    [Required, MaxLength(500)]
    public required string PasswordHash { get; set; }

    public bool IsActive { get; set; } = true;
    //public bool IsEmailConfirmed { get; set; }
    //public bool IsTwoFactorEnabled { get; set; }
    
    // Tracks database row version to prevent race conditions during transfers
    //[Timestamp]
    //public byte[] RowVersion { get; set; } = []; 

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } // Kept null until an actual modification occurs

    public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
}