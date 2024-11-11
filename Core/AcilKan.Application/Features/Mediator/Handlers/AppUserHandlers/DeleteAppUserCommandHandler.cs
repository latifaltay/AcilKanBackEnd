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
    public class DeleteAppUserCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<DeleteAppUserCommand>
    {
        public async Task Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var value = await _userManager.FindByEmailAsync(request.Email);
            await _userManager.DeleteAsync(value);
        }
    }
}
