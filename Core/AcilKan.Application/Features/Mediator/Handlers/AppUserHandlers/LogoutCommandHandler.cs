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
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, bool>
    {
        // logout kısmı sorulacak
        public Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
