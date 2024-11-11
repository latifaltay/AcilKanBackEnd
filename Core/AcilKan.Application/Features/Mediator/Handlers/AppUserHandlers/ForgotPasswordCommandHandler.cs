using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
using AcilKan.Application.Features.Mediator.Queries.AppUserQueries;
using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using AcilKan.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class ForgotPasswordCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<ForgotPasswordQuery, ForgotPasswordQueryResult>
    {
        public async Task<ForgotPasswordQueryResult> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(request.Email);

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            return new ForgotPasswordQueryResult { Token = token };
        }
    }
}
