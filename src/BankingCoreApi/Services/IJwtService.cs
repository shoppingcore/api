using System.Security.Claims;
using BankingCoreApi.Models;

namespace BankingCoreApi.Services;

public interface IJwtService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? ValidateToken(string token);
}