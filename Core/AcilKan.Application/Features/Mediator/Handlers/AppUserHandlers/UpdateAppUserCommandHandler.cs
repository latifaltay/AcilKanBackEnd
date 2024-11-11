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
    public class UpdateAppUserCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<UpdateAppUserCommand>
    {
        public async Task Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.Id.ToString());

            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.ImageUrl = request.ImageUrl;

            await _userManager.UpdateAsync(user);
        }
    }
}
