using IS_Project.Domain.AuthModels;
using System.Security.Claims;

namespace IS_Project.Identity.JWT.Services;

internal interface ITokenService
{
    TokenPair GenerateTokens(User user);
    ClaimsPrincipal? ValidateToken(string token);
}
