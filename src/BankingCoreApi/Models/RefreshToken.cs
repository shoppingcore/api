using System.ComponentModel.DataAnnotations;

namespace BankingCoreApi.Models;

public class RefreshToken
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid UserId { get; init; }

    [Required, MaxLength(256)] 
    public required string TokenHash { get; init; }

    public bool IsRevoked { get; set; }
    
    public DateTime ExpiresAt { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    // Optional but highly recommended for token rotation detection
    //public Guid? ReplacedByTokenId { get; set; } 

    // Computed domain logic properties
    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
    public bool IsActive => !IsRevoked && !IsExpired;

    // Navigation Property
    public User? User { get; init; }
}