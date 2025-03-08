using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using AcilKan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Interfaces
{
    public interface IJwtTokenService
    {
        Task<TokenResult> GenerateTokens(AppUser user);
        Task<TokenResult> RefreshAccessToken(string refreshToken);
        Task InvalidateTokens(string accessToken, string refreshToken);
        Task<bool> LogoutAsync(AppUser user, string accessToken);

    }
}
