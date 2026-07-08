using BankingCoreApi.Data;
using BankingCoreApi.DTOs.Auth;
using BankingCoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingCoreApi.Services;

public class AuthService(
    AppDbContext db,
    IJwtService jwt) : IAuthService
{
    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await db.Users.AnyAsync(u => u.Email == request.Email))
            throw new InvalidOperationException("Email already registered.");

        if (await db.Users.AnyAsync(u => u.Phone == request.Phone))
            throw new InvalidOperationException("Phone already registered.");

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return await GenerateAuthResponseAsync(user);
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == request.Email)
            ?? throw new UnauthorizedAccessException("Invalid credentials.");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials.");

        if (!user.IsActive)
            throw new UnauthorizedAccessException("Account is disabled.");

        return await GenerateAuthResponseAsync(user);
    }

    public async Task<AuthResponse> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var tokenHash = BCrypt.Net.BCrypt.HashPassword(request.RefreshToken);
        var storedToken = await db.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.TokenHash == tokenHash && !t.IsRevoked)
            ?? throw new UnauthorizedAccessException("Invalid refresh token.");

        if (storedToken.ExpiresAt < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Refresh token expired.");

        storedToken.IsRevoked = true;
        await db.SaveChangesAsync();

        return await GenerateAuthResponseAsync(storedToken.User);
    }

    public async Task LogoutAsync(string refreshToken)
    {
        var tokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
        var storedToken = await db.RefreshTokens
            .FirstOrDefaultAsync(t => t.TokenHash == tokenHash && !t.IsRevoked);

        if (storedToken is not null)
        {
            storedToken.IsRevoked = true;
            await db.SaveChangesAsync();
        }
    }

    private async Task<AuthResponse> GenerateAuthResponseAsync(User user)
    {
        var accessToken = jwt.GenerateAccessToken(user);
        var rawRefreshToken = jwt.GenerateRefreshToken();

        db.RefreshTokens.Add(new RefreshToken
        {
            UserId = user.Id,
            TokenHash = BCrypt.Net.BCrypt.HashPassword(rawRefreshToken),
            ExpiresAt = DateTime.UtcNow.AddDays(7) // match refresh token expiry
        });

        await db.SaveChangesAsync();

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = rawRefreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15), // match access token expiry
            User = new AuthResponse.UserInfo(user.Id, user.FullName, user.Email)
        };
    }
}