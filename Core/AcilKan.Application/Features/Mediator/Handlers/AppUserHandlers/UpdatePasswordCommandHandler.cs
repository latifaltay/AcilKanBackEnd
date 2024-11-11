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
    public class UpdatePasswordCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<UpdatePasswordCommand>
    {
        public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.Id.ToString());

            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        }
    }
}
