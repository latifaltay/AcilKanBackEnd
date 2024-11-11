using AcilKan.Application.DTOs.LoginRegisterOperations;
using AcilKan.Application.Features.Mediator.Commands.AppUserCommands;
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
    public class ChangePasswordUsingTokenCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<ChangePasswordUsingTokenCommand>
    {
        public async Task Handle(ChangePasswordUsingTokenCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await _userManager.FindByEmailAsync(request.Email);
            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, request.Token, request.NewPassword);
        }
    }
}
