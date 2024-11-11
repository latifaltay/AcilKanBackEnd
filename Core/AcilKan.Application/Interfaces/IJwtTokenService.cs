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
    }
}
