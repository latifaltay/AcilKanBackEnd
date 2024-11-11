using AcilKan.Application.Features.Mediator.Results.AppUserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.Features.Mediator.Commands.AppUserCommands
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
